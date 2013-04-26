using System.Diagnostics;
using AutoShutdownApplication.ViewModels;

namespace AutoShutdownApplication.ViewControllers
{
    public class ShutDownViewController:IShutDownViewController
    {

        public void ShutDown(ShutDownViewModel obj)
        {
            Process.Start("shutdown", "/s /f /t 0");
        }

        public void Restart(ShutDownViewModel obj)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        public void LogOff(ShutDownViewModel obj)
        {
            Process.Start("shutdown", "/l /t 0");
        }
    }
}
