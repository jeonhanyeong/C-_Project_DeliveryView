using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation.Collections;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            // Pause to show the splash screen for 3 seconds
            System.Threading.Thread.Sleep(3000);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // Listen to notification activation
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Obtain any user input (text boxes, menu selections) from the notification
                ValueSet userInput = toastArgs.UserInput;

                // Need to dispatch to UI thread if performing UI operations
                Application.Current.Dispatcher.Invoke(delegate
                {
                    // TODO: Show the corresponding content
                    //MessageBox.Show("알림! " + toastArgs.Argument);
                    MessageBox.Show("알림! " + toastArgs.Argument.Substring(0, 14));
                    String Shop_ID = toastArgs.Argument.Substring(15);
                    OrdersStatus Orderwindow1 = new OrdersStatus(Shop_ID);
                    Orderwindow1.Show();


                });
            };
        }
    }
}