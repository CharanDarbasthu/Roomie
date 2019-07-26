using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using R.Helpers;

namespace R.ViewModels
{
    public class StartupPageViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; private set; }
        public IPageDialogService PageDialogService { get; private set; }
        public DelegateCommand CreateRoomCommand { get; set; }
        public DelegateCommand LoginCommand { get; set; }
        public StartupPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService=pageDialogService;
            CreateRoomCommand = new DelegateCommand(CreateRoom);
            LoginCommand = new DelegateCommand(Login);
        }
        private async void CreateRoom()
        {
            var fbHelper = new FirebaseHelper();
            if (await fbHelper.GetRoom(1) == null)
            {
                var room = await new FirebaseHelper().AddRoom(1, "KP");
                if(room !=null)
                {
                    await PageDialogService.DisplayAlertAsync("Create Room", "Room created successfully.", "OK");
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Create Room", "Unable to create room at the moment, please try again", "OK");
                }
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Create Room", "A room had already been created on KP, please try with some different name.", "OK");
            }
        }
        private async void Login()
        {

        }
    }
}
