using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using AutoShutdownApplication.ViewModels;

namespace AutoShutdownApplication.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
  /// </summary>
    public partial class ShutDownTimerMainWindow
    {

        #region Propreties
        public ShutDownViewModel Model
        {
            get { return DataContext as ShutDownViewModel; }

        }

        public new bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(ShutDownTimerMainWindow));

        private Thread _workerThread;

        #endregion

        #region Ctor
        public ShutDownTimerMainWindow()
        {
            InitializeComponent();
            DataContext = new ShutDownViewModel();
        }
        #endregion

        #region Override
        protected override void OnClosed(EventArgs e)
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                _workerThread.Abort();
            }
            base.OnClosed(e);

        }
        #endregion

        #region Event Handlers

        private void OnComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null) return;
            var actionTypes = new List<ShutDownViewModel.ActionType>
                {
                    ShutDownViewModel.ActionType.Shutdown,
                    ShutDownViewModel.ActionType.Restart,
                    ShutDownViewModel.ActionType.LogOff,
                };
            comboBox.ItemsSource = actionTypes;
            comboBox.SelectedValue = ShutDownViewModel.ActionType.Shutdown;
        }

        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {

            if (IsActive)
            {
                if (_workerThread.IsAlive)
                {
                    _workerThread.Abort();
                }
                IsActive = false;
            }
            else
            {
                IsActive = true;
                _workerThread = new Thread(ThreadAction);
                _workerThread.Start();
            }
        }

        #endregion

        #region Private Methods

        private void ThreadAction()
        {
            var loop = true;
            while (loop)
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(() =>
                    {
                        loop = CalculateTime();
                    });
            }
            Dispatcher.Invoke(() => Model.ActionRequest());
        }

        private bool CalculateTime()
        {
            if (Model.Hours > 0 || Model.Minutes > 0 || Model.Seconds > 0)
            {
                if (Model.Seconds == 0)
                {
                    if (Model.Minutes > 0)
                    {
                        Model.Minutes--;
                        Model.Seconds = 59;
                    }
                    else
                    {
                        if (Model.Hours > 0)
                        {
                            Model.Minutes = 59;
                            Model.Seconds = 59;
                            Model.Hours--;

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    Model.Seconds--;
                }
            }
            else { return false; }
            return true;
        }

        #endregion

    }
}
