using Prism;
using Prism.Ioc;
using Prism.Unity;
using R.Interfaces;
using R.ViewModels;
using R.Views;
using R.Views.Login;
using R.Views.Startup;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace R
{
    public partial class App:PrismApplication
    {
        public static IFirebaseAuthenticator FirebaseAuthenticator { get;private set; }
        public static IGoogleManager GoogleManager { get;private set; }
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }
        protected override async void OnInitialized()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Run(this);
#endif
            InitDependencies();
            await NavigationService.NavigateAsync("StartupPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<StartupPage, StartupPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
        private void InitDependencies()
        {
            FirebaseAuthenticator = DependencyService.Get<IFirebaseAuthenticator>();
            GoogleManager=DependencyService.Get<IGoogleManager>();
        }
    }
}
