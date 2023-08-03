﻿using Controller;
using Domain;
using Domain.Exceptions;
using System;
using System.Windows.Forms;

namespace GUI
{
	public partial class SignIn : UserControl
	{
		private const string UsernamePlaceHolder = "Username";
		private const string PasswordPlaceHolder = "Password";

		private MainForm _mainForm;

		private ClientController _clientController;

		public SignIn(MainForm mainForm, ClientController clientController)
		{
			_clientController = clientController;
			_mainForm = mainForm;
			InitializeComponent();
			txtPasswordSignIn.KeyPress += new KeyPressEventHandler(CheckEnter);
			txtUsernameSignIn.KeyPress += new KeyPressEventHandler(CheckEnter);
		}

		private void SignInUser()
		{
			string username = txtUsernameSignIn.Text;
			string password = txtPasswordSignIn.Text;

			try
			{
				Client currentClient = _clientController.SignIn(username, password);
				_mainForm.GoToHome(currentClient);

				ResetPlaceholders();
			}
			catch (InvalidCredentialsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LblSignUpRef_Click(object sender, EventArgs e)
		{
			_mainForm.GoToSignUp();
			ResetPlaceholders();
		}


		private void LblSignIn_Click(object sender, EventArgs e)
		{
			SignInUser();
		}

		private void PicSignInButton_Click(object sender, EventArgs e)
		{
			SignInUser();
		}

		private void ResetPlaceholders()
		{
			InputUtils.ResetPlaceholder(ref txtUsernameSignIn, UsernamePlaceHolder);
			InputUtils.ResetPasswordPlaceholder(ref txtPasswordSignIn, PasswordPlaceHolder);
		}


		private void TxtUsernameSignIn_Enter(object sender, EventArgs e)
		{
			InputUtils.RemovePlaceHolder(ref txtUsernameSignIn, UsernamePlaceHolder);
		}

		private void TxtUsernameSignIn_Leave(object sender, EventArgs e)
		{
			InputUtils.SetPlaceHolder(ref txtUsernameSignIn, UsernamePlaceHolder);
		}

		private void TxtPasswordSignIn_Enter(object sender, EventArgs e)
		{
			InputUtils.RemovePlaceHolder(ref txtPasswordSignIn, PasswordPlaceHolder);
			InputUtils.HidePassword(ref txtPasswordSignIn);
		}

		private void TxtPasswordSignIn_Leave(object sender, EventArgs e)
		{
			InputUtils.SetPlaceHolder(ref txtPasswordSignIn, PasswordPlaceHolder);
			InputUtils.ShowPassword(ref txtPasswordSignIn);

		}

		private void CheckEnter(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				SignInUser();

				e.Handled = true;
			}
		}

        private void picIconLogs_Click(object sender, EventArgs e)
        {
			_mainForm.GoToLogs();
			ResetPlaceholders();
		}

        private void picBackgroundLogs_Click(object sender, EventArgs e)
        {
			_mainForm.GoToLogs();
			ResetPlaceholders();
		}
    }
}
