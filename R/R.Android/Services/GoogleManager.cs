using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Widget;
using R.Droid.Services;
using R.Interfaces;
using R.Logs;
using R.Models;
using System;
using Xamarin.Forms;
[assembly: Dependency(typeof(GoogleManager))]
namespace R.Droid.Services
{
    public class GoogleManager : Java.Lang.Object, IGoogleManager, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        public Action<GoogleUser, string> _onLoginComplete;
        public static GoogleApiClient _googleApiClient { get; set; }
        public static GoogleManager Instance { get; private set; }
        public GoogleManager()
        {
            Instance = this;
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                                                           .RequestProfile()
                                                           .RequestScopes(new Scope(Scopes.Email))
                                                           .RequestEmail()
                                                           .Build();
            _googleApiClient = new GoogleApiClient.Builder(Android.App.Application.Context)
            .AddConnectionCallbacks(this)
            .AddOnConnectionFailedListener(this)
            .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
            .AddScope(new Scope(Scopes.Email))
            .Build();
        }

        public void Login(Action<GoogleUser, string> OnLoginComplete)
        {
            try
            {
                _onLoginComplete = OnLoginComplete;
                Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(_googleApiClient);
                ((MainActivity)Forms.Context).StartActivityForResult(signInIntent, 1);
                _googleApiClient.Connect();
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                Toast.MakeText(Forms.Context, ex.Message, ToastLength.Short);
            }
        }
        public void LogOut()
        {
        }
        public void OnConnected(Bundle connectionHint)
        {
        }
        public void OnConnectionFailed(ConnectionResult result)
        {
        }
        public void OnConnectionSuspended(int cause)
        {
        }
        public void OnAuthCompleted(GoogleSignInResult result)
        {
            if (result.IsSuccess)
            {
                GoogleSignInAccount account = result.SignInAccount;
                _onLoginComplete?.Invoke(new GoogleUser()
                {
                    Name = account.DisplayName,
                    Email = account.Email,
                    Picture = new Uri(account.PhotoUrl != null ? $"{account.PhotoUrl}" : $"https://autisticdating.net/imgs/profile-placeholder.jpg")
                }, string.Empty);
            }
        }
    }
}