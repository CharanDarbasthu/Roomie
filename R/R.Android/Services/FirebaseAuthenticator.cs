using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Xamarin.Auth;
using R.Droid.Services;
using R.Interfaces;
using R.Logs;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace R.Droid.Services
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<Tuple<bool, string>> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                IAuthResult user = await Firebase.Auth.FirebaseAuth.Instance.
                       SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return new Tuple<bool, string>(true, token.Token);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
        public async Task<Tuple<bool, string>> RegsiterEmailAndPassword(string email, string password)
        {
            try
            {
                IAuthResult user = await Firebase.Auth.FirebaseAuth.Instance.
                                                CreateUserWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return new Tuple<bool, string>(true, token.Token);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                return new Tuple<bool, string>(false,ex.Message);
            }
        }
    }
}