using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using R.Models;
using System;

namespace R.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand GoogleLoginCommand { get; set; }
        public INavigationService NavigationService { get; private set; }
        public IPageDialogService PageDialogService { get; private set; }
        public LoginPageViewModel(INavigationService navigationService,IPageDialogService pageDialogService) 
            : base(navigationService,pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            LoginCommand = new DelegateCommand(Login);
            RegisterCommand = new DelegateCommand(Register);
            GoogleLoginCommand = new DelegateCommand(GoogleLogin);
        }
        private async void Login()
        {
            Tuple<bool,string> _loginResult=await App.FirebaseAuthenticator.LoginWithEmailAndPassword("test@test.com", "aaopen3");
            if(!_loginResult.Item1)
            {
                await PageDialogService.DisplayAlertAsync("Login", _loginResult.Item2, "OK");
                return;
            }
        }
        private async void Register()
        {
            Tuple<bool,string> _registerResult= await App.FirebaseAuthenticator.RegsiterEmailAndPassword("test@test.com", "aaopen3");
            if(!_registerResult.Item1)
            {
                await PageDialogService.DisplayAlertAsync("Register", _registerResult.Item2, "OK");
                return;
            }
        }
        private void GoogleLogin()
        {
            var googleMgr = App.GoogleManager;
            googleMgr.Login(OnLoginComplete);
        }
        public void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if(googleUser!=null)
            {
                PageDialogService.DisplayAlertAsync("Google","Success", "OK");
            }
            else
            {
                PageDialogService.DisplayAlertAsync("Google", "Failed", "OK");
            }
        }
    }
}
