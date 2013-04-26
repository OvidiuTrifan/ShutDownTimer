using AutoShutdownApplication.ViewModels;

namespace AutoShutdownApplication.ViewControllers
{
    interface IShutDownViewController
    {

        void ShutDown(ShutDownViewModel obj);

        void Restart(ShutDownViewModel obj);
        
        void LogOff(ShutDownViewModel obj);

    }
}
