using System;
using System.Windows;
using AutoShutdownApplication.ViewControllers;

namespace AutoShutdownApplication.ViewModels
{
    public class ShutDownViewModel : UIElement
    {

        #region Propretis

        private IShutDownViewController shutDownViewController;


        public ShutDownViewModel()
        {
          shutDownViewController= new ShutDownViewController();
        }

        public int Hours
        {
            get { return (int)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register("Hours", typeof(int), typeof(ShutDownViewModel));


        public int Minutes
        {
            get { return (int)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(int), typeof(ShutDownViewModel));


        public int Seconds
        {
            get { return (int)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register("Seconds", typeof(int), typeof(ShutDownViewModel));


        public ActionType Action
        {
            get { return (ActionType)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Action.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(ActionType), typeof(ShutDownViewModel));

        #endregion

        #region Enum

        public enum ActionType
        {
            Restart,
            Shutdown,
            LogOff
        };

        #endregion

        #region Public Methods

        public void ActionRequest()
        {
            switch (Action)
            {
                case ActionType.Restart:
                    shutDownViewController.Restart(this);
                    break;
                case ActionType.Shutdown:
                    shutDownViewController.ShutDown(this);
                    break;
                case ActionType.LogOff:
                    shutDownViewController.LogOff(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        #endregion
    }
}
