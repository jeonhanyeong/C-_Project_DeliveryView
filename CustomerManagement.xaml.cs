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
using MySql.Data.MySqlClient;

namespace MobileAppUsageDashboard
{

    public partial class CustomerManagement : Window
    {
        public String Customer_ID; 

        public CustomerManagement()
        {
            InitializeComponent();
        }

        public CustomerManagement(String Customer_ID)
        {
            this.Customer_ID = Customer_ID;
            InitializeComponent();

            //커스터머 넘버 구하기
            string select_CustomerNum = "SELECT customerNum from customer where customerID='" + Customer_ID + "'";
            string Customer_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_CustomerNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                Customer_num = rd["customerNum"].ToString();

            rd.Close();




            //총 주문금액 표시해주기
            //select sum(totalPrice) sum from orders where customerNum=1
            string select_Spending = "select sum(totalPrice) sum from orders where customerNum=" + Customer_num;
            string ToSpending = "";
            command = new MySqlCommand(select_Spending, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                ToSpending = rd["sum"].ToString();

            rd.Close();
            Spending_Box.Text = ToSpending;

            //총 주문 건수 표시해주기
            //select count(customerNum) cnt from orders where customerNum=1;
            string select_Total_orders_count = "select count(customerNum) cnt from orders where customerNum=" + Customer_num;
            string orders_count = "";
            command = new MySqlCommand(select_Total_orders_count, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                orders_count = rd["cnt"].ToString();

            Total_orders_count_Box.Text = orders_count;
            rd.Close();

            ////손님화면 정보 띄우기
            string Customer_Information = "select customerName, customerPhone,customerAddress FROM customer where customerID='" + Customer_ID + "'";
            command = new MySqlCommand(Customer_Information, connection);
            rd = command.ExecuteReader();

            if (rd.Read() == true)
            {
                CustomerName.Text = rd["customerName"].ToString();
                CustomerPhone.Text = rd["customerPhone"].ToString();
                CustomerAddress.Text = rd["customerAddress"].ToString();
            }
            rd.Close(); connection.Close();



        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
        private void WriteReviewClicked(object sender, RoutedEventArgs e)
        {
            WriteReview writeReview = new WriteReview(Customer_ID);
            writeReview.Show();
            Window.GetWindow(this).Close();
        }

        private void LogoutClicked(object sender, RoutedEventArgs e)
        {
            //로그인 화면으로
            Login login = new Login();
            login.Show();
            Window.GetWindow(this).Close();
        }
    }

}
