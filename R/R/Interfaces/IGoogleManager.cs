using R.Models;
using System;

namespace R.Interfaces
{
    public interface IGoogleManager
    {
        void Login(Action<GoogleUser, string> OnLoginComplete);
        void LogOut();
    }
}
