using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace R.Helpers
{
    public class UserSettings
    {
        static ISettings AppSettings { get { return CrossSettings.Current; } }
        #region Constants
        private const string FirebaseDBKey = "firebaseDbKey";
        private static readonly string FirebaseDBValue = "https://rrrr-6d384.firebaseio.com/";
        #endregion
        public static string FirebaseDB
        {
            get
            {
                return AppSettings.GetValueOrDefault(FirebaseDBKey, FirebaseDBValue);
            }
        }
    }
}
