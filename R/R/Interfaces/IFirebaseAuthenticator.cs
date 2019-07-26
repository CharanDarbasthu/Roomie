using System;
using System.Threading.Tasks;

namespace R.Interfaces
{
    public interface IFirebaseAuthenticator
    {
        Task<Tuple<bool, string>> LoginWithEmailAndPassword(string email, string password);
        Task<Tuple<bool, string>> RegsiterEmailAndPassword(string email, string password);
    }
}
