using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class CustomerOrders : Window
    {
        public String Customer_ID;
        public String Shop_Num;
        MySqlDataAdapter daCountry;
        DataSet dsCountry;

        public CustomerOrders()
        {
            InitializeComponent();
          
        }
        public CustomerOrders(String Customer_ID)
        {
            InitializeComponent();
            this.Customer_ID = Customer_ID;

            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string sql = "select shopNum, shopName, shopPhone, orderMinimum, tipProcess, shopIntroduce from Shop";
                daCountry = new MySqlDataAdapter(sql, conn);
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                CustomerOrders_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CustomerManagementClicked(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement(Customer_ID);
            customerManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void CustomerOrdersClicked(object sender, RoutedEventArgs e)
        {
            CustomerOrders customerOrders = new CustomerOrders(Customer_ID);
            customerOrders.Show();
            Window.GetWindow(this).Close();
        }
        private void CustomerHomeClicked(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement(Customer_ID);
            customerManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void CustomerPowerClicked(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void GoMenuListClicked(object sender, RoutedEventArgs e)
        {
            MenuList menuList = new MenuList(Customer_ID, Shop_Num);
            menuList.Show();
        }
        private void WriteReviewClicked(object sender, RoutedEventArgs e)
        {
            WriteReview writeReview = new WriteReview(Customer_ID);
            writeReview.Show();
            Window.GetWindow(this).Close();
        }

        private void CustomerOrders_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)CustomerOrders_DataGrid.SelectedItem;
            Shop_Num = dataRow.Row.ItemArray[0].ToString();      


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //로그인 화면으로
            Login login = new Login();
            login.Show();
            Window.GetWindow(this).Close();
        }
    }
}