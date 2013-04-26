using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoShutdownApplication.ViewModels;

namespace AutoShutdownApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ShutDownViewModel Model
        {
            get { return DataContext as ShutDownViewModel; }

        }

        private Thread _workerThread;

        public new bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(MainWindow));



        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ShutDownViewModel();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                _workerThread.Abort();
            }
            base.OnClosed(e);

        }

        private void OnClickButton(object sender, RoutedEventArgs e)
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
                if (_workerThread == null)
                {
                    _workerThread = new Thread(ThreadAction);
                }
                _workerThread.Start();
            }
        }

        private void ThreadAction()
        {
            bool loop = true;
            while (loop)
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke((Action)(() =>
                    {
                        loop = CalculateTime();
                    }));
            }
            this.Dispatcher.Invoke((Action)(() => Model.ActionRequest()));
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

        private void OnLoadedComboBox(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                List<ShutDownViewModel.ActionType> actionTypes = new List<ShutDownViewModel.ActionType>
                    {
                        ShutDownViewModel.ActionType.Shutdown,
                        ShutDownViewModel.ActionType.Restart,
                        ShutDownViewModel.ActionType.LogOff,
                    };
                comboBox.ItemsSource = actionTypes;
                comboBox.SelectedValue = ShutDownViewModel.ActionType.Shutdown;
            }
        }

    }
}
