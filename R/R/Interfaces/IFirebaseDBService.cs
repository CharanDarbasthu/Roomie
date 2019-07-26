using System;

namespace R.Interfaces
{
    public interface IFirebaseDBService
    {
        void Connect();
        void GetMessage();
        void SetMessage(String message);
        String GetMessageKey();
    }
}
