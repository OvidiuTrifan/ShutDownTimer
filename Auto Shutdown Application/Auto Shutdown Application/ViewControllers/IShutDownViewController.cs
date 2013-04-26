using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
