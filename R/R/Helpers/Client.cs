using Firebase.Database;

namespace R.Helpers
{
    public static class Client
    {
        public static FirebaseClient DBClient
        {
            get
            {
                return new FirebaseClient(UserSettings.FirebaseDB);
            }
        }
    }
}
