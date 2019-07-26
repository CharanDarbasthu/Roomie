using Microsoft.AppCenter.Crashes;
using R.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
namespace R.Helpers
{
    public class GlobalExceptions
    {
        public static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }

        public static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            LogUnhandledException(newExc);
        }
        public static void LogUnhandledException(Exception exception)
        {
            try
            {
                AppCenterDTO customServiceFault = GetCustomException(exception);
                Dictionary<string, string> deviceInfo = new Dictionary<string, string>
                {
                    {"Device Name",DeviceInfo.Name },
                    {"DeviceType ",DeviceInfo.DeviceType.ToString()},
                    {"Model",DeviceInfo.Model },
                    {"Manufacturer",DeviceInfo.Manufacturer },
                    {"Platform ",DeviceInfo.Platform.ToString() },
                    {"Version",DeviceInfo.Version.ToString() },
                    {"ErrorMessage",customServiceFault.ErrorMessage },
                    {"Source",customServiceFault.Source },
                    {"StackTrace",customServiceFault.StackTrace },
                    {"Target ",customServiceFault.Target },
                    {"InnerExceptionMessage" ,customServiceFault.InnerExceptionMessage },
                    {"ExceptionName",customServiceFault.ExcName},
                };
                Crashes.TrackError(exception, deviceInfo);
            }
            catch (Exception ex)
            {
                // just suppress any error logging exceptions
            }
        }
        private static AppCenterDTO GetCustomException(Exception exception)
        {
            var customServiceFault = new AppCenterDTO
            {
                ErrorMessage = exception.Message,
                Source = exception.Source ?? "",
                StackTrace = exception.StackTrace ?? "",
                Target = exception.TargetSite?.ToString(),
                InnerExceptionMessage = exception.InnerException?.Message,
                ExcName = exception.GetType().FullName
            };
            return customServiceFault;
        }

        public virtual void LogToDevice()
        {

        }
    }
}
