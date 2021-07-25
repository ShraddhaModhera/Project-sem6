let submitButton = document.querySelector('#js-submitItem');
let fields = document.getElementsByTagName('input');

function displayMessage(status) {
	if (status) {
		alert('Ops, os campos obrigatórios não foram preenchidos!');
	}
}

function checkValues(event) {
	const [name, email] = fields;
	let setErrorStatusMessage = false;
	event.preventDefault();

	if (name.value === '' || email.value === '') {
		setErrorStatusMessage = true;
		displayMessage(setErrorStatusMessage);
	}
	validPassword();
}

function validPassword(status) {
	const [name, email, password, retypePassword] = fields;
	let setErrorStatusMessage = false;

	if (password.value === '' || retypePassword.value === '') {
		setErrorStatusMessage = true;
		displayMessage(setErrorStatusMessage);
	}

	if (fields[3].value !== fields[2].value) {
		alert('Ops, as senhas não conferem!');
	}
}

submitButton.addEventListener('click', checkValues);

