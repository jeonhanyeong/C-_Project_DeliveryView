using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// UserControlProviders.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DriverReview : UserControl
    {
        public DriverReview()
        {
            InitializeComponent();
        }
     
        private void AddClicked(object sender, RoutedEventArgs e)
        {
            CompanyPage.DriverManagementAdd driverManagementAdd = new CompanyPage.DriverManagementAdd();
            driverManagementAdd.ShowDialog();
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            CompanyPage.DriverManagementEdit driverManagementEdit = new CompanyPage.DriverManagementEdit();
            driverManagementEdit.Show();
        }


    }
}