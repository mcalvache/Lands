namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
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
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemenbered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {            
            this.IsRemenbered = true;
            this.IsEnabled = true;
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
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter an email.", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter an password.", "Accept");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "mcalvache@baustro.fin.ec" || this.Password !="1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "email or password in correct", "Accept");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            this.Email = string.Empty;
            this.password = string.Empty;

            MainViewModel.GetInstance().Lands= new LandsViewModel(); 
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }

}
