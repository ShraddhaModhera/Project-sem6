using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class AdminController : Controller
    {
        //AdminContext db = new AdminContext();
        AdminContext db;
        public AdminController()
        {
            db = new AdminContext();       
        }
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(string User,string Pass)
        //{
        //    var obj = db.CustomerTable.Where(a => a.Email.Equals(User) && a.Password.Equals(Pass)).FirstOrDefault();
        //    if (User == "admin@gmail.com" && Pass == "Admin123")
        //    {
        //        Session["user"] = User;
        //        Session["pass"] = Pass;
        //        return RedirectToAction("List","DashBoard");
        //    }            
        //    else if (obj != null)
        //    {
        //        Session["email"] = obj.Email.ToString();
        //        Session["cid"] = obj.Customer_id.ToString();
        //        return RedirectToAction("Myorder","UserProduct");
        //    }
        //    else
        //    {
        //        ViewBag.msg = "Invalid Email and Password!!";
        //    }
        //    return View();
        //}


        //login 
        [HttpGet]
        public ActionResult Login()
        {
            return View(new CustomerLogin { cid = 0 });
        }

        //login post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin cl, string ReturnUrl = "")
        {
            string message = "";
            using (AdminContext db = new AdminContext())
            {
                var v = db.CustomerTable.Where(a => a.Email == cl.Email).FirstOrDefault();
                //var obj = db.CustomerTable.Where(a => a.Email.Equals(User) && a.Password.Equals(Pass)).FirstOrDefault();
                if (cl.Email == "admin@gmail.com" && cl.Password == "Admin123")
                {
                    Session["user"] = cl.Email;
                    Session["pass"] = cl.Password;
                    return RedirectToAction("List", "DashBoard");
                }
                //var v = db.CustomerLogin.Where(a => a.EmailID == cl.EmailID).FirstOrDefault();

                else if (v != null)
                {
                    if (string.Compare(Crypto.Hash(cl.Password), v.Password) == 0)
                    {
                        int timeout = cl.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(cl.Email, cl.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Home", "Home");
                        }

                    }
                    else
                    {
                        message = "Invalid credential provided !";
                    }
                }
                else
                {
                    message = "Invalid credential provided !";
                }

            }
            ViewBag.Message = message;
            return View();
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Signup(Customer cust)
        {
            bool Status = false;
            string Message = "";

            //if (ModelState.IsValid)
            //{

                #region Is Email Exist
                var isExist = IsEmailExist(cust.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already Exsit!");
                    return View(cust);
                }
                #endregion


                #region Generate activation Code
                cust.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing 
                cust.Password = Crypto.Hash(cust.Password);
                cust.ConfirmPassword = Crypto.Hash(cust.ConfirmPassword);
                #endregion

                cust.IsEmailVerified = false;

                #region Save to database
                db.CustomerTable.Add(cust);
                db.SaveChanges();

                //Sending mail to user
                SendVerificationEmail(cust.Email, cust.ActivationCode.ToString());
                Message = "Registration Successfully done. Account activation link " +
                    "has been sent to your Email id : " + cust.Email;
                Status = true;

                #endregion
            //}
            //else
            //{
            //    Message = "Invalid Request";
            //}

            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View(cust);
        }

        //Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (AdminContext db = new AdminContext())
            {
                //db.Configuration.ValidateOnSaveEnabled = false;
                var v = db.CustomerTable.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }


        [NonAction]
        public bool IsEmailExist(string emailid)
        {
            using (AdminContext db = new AdminContext())
            {
                var v = db.CustomerTable.Where(a => a.Email == emailid).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationEmail(string mailid, string activationcode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Admin/" + emailFor + "/" + activationcode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("modherashraddha2010@gmail.com", "Premier Mart");
            var toEmail = new MailAddress(mailid);
            var fromEmailPassword = "#ModheraShrad2010";

            string subject = "";
            string body = "";

            if (emailFor == "VerifyAccount")
            {
                subject = "your account is successfully created!";

                body = "<br/><br/>We are excited to tell you that your Premier Mart account is " +
                   "successfully created.Please click on the below link  to verify your account " +
                   "<br/><br/><a href= '" + link + "'>" + link + "</a>";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi, <br/><br/> we got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword),
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        #region Forgot Password
        public ActionResult Forget()
        {
            return View();
        }              

        [HttpPost]
        public ActionResult Forget(string EmailID)
        {
            //Verify Emailid
            //Generate Reset Password Link
            //Send Email

            string message = "";
            bool status = false;

            using (AdminContext db = new AdminContext())
            {
                var account = db.CustomerTable.Where(a => a.Email == EmailID).FirstOrDefault();
                if (account != null)
                {
                    //send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationEmail(account.Email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "Reset password link has been sent to your Email Id";
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            //verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            using (AdminContext db = new AdminContext())
            {
                var c = db.CustomerTable.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (c != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();                    
                }                
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                using (AdminContext db = new AdminContext())
                {
                    var cust = db.CustomerTable.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (cust != null)
                    {
                        cust.Password = Crypto.Hash(model.NewPassword);
                        cust.ResetPasswordCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something went wrong!";
            }

            ViewBag.Message = message;
            return View(model);
        }
 

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Home","Home");
        }
        #endregion
    }
}