namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }

        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email...",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password...",
                    "Accept");
                return;
            }

            if (this.Email != "r@gmail.com" || this.Password != "123")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or passwod incorrect...",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.Email = "r@gmail.com";
            this.Password = "123";
        }
        #endregion
    }
}
