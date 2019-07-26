using Android.App;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.OS;
using Firebase;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using R.Droid.Services;
using R.Helpers;
using R.Logs;
using System;
using System.Threading.Tasks;

namespace R.Droid
{
    [Activity(Label = "R", Icon = "@mipmap/appIcon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            FirebaseApp.InitializeApp(Application.Context);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            FirebaseApp.InitializeApp(this);
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptions.CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += GlobalExceptions.TaskSchedulerOnUnobservedTaskException;
            RegisterAppCenter();
            LoadApplication(new App(new AndroidInitializer()));
        }
        private void RegisterAppCenter()
        {
            AppCenter.Start("ed763bf0-c21b-4035-b348-aa63ce1c9996",typeof(Analytics), typeof(Crashes));
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            try
            {
                if (requestCode == 1)
                {
                    GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                    GoogleManager.Instance.OnAuthCompleted(result);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
            }
        }
    }
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

