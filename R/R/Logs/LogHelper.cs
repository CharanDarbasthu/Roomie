using R.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace R.Logs
{
    public class LogHelper
    {
        public static void LogError(Exception exception)
        {
            GlobalExceptions.LogUnhandledException(exception);
        }
    }
}
