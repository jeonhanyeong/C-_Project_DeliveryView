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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// CustomerInformation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WriteReview : Window
    {
        public String Customer_ID;
        public String DrNum;
        public WriteReview()
        {
            InitializeComponent();
        }

        public WriteReview(String Customer_ID)
        {
            this.Customer_ID = Customer_ID;
            InitializeComponent();


            MySqlDataAdapter daCountry;
            DataSet dsCountry;




            string select_CustomerNum = "SELECT customerNum from customer where customerID='" + Customer_ID + "'";
            string CustomerNum = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_CustomerNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                CustomerNum = rd["customerNum"].ToString();

            rd.Close();



            try
            {
                //SELECT shopName 가게이름, orderDate 주문날짜, totalPrice 주문가격 FROM orders LEFT JOIN shop ON orders.shopNum = shop.shopNum where customerNum=1
                // string sql = "SELECT shopName 가게이름, date_format(orderDate,'%Y-%m-%d') 주문날짜, totalPrice 주문가격 FROM orders LEFT JOIN shop ON orders.shopNum = shop.shopNum where customerNum='" + CustomerNum + "'";
                string sql = "SELECT orderNum 넘버, shopName 가게이름, date_format(orderDate, '%Y-%m-%d') 주문날짜, totalPrice 주문가격, driverNum 기사번호 FROM orders as oder, shop as sp where oder.shopNum = sp.shopNum and oder.customerNum = '" + CustomerNum + "'";


                daCountry = new MySqlDataAdapter(sql, connection);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                ShopReview_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void CustomerOrdersClicked(object sender, RoutedEventArgs e)
        {
            CustomerOrders customerOrders = new CustomerOrders(Customer_ID);
            customerOrders.Show();
            Window.GetWindow(this).Close();
        }
        private void CustomerPowerClicked(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CustomerHomeClicked(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement(Customer_ID);
            customerManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void CustomerManagementClicked(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement(Customer_ID);
            customerManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void WriteReviewClicked(object sender, RoutedEventArgs e)
        {
            WriteReview writeReview = new WriteReview(Customer_ID);
            writeReview.Show();
            Window.GetWindow(this).Close();
        }

        //기사 리뷰 버튼 클릭시
        private void DriverClicked(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)ShopReview_DataGrid.SelectedItem;
            WriteDriverReview writeDriverReview = new WriteDriverReview(DrNum, dataRow.Row.ItemArray[0].ToString());
            writeDriverReview.Show();

        }

        private void ShopReview_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dataRow = (DataRowView)ShopReview_DataGrid.SelectedItem;
            String orderNum = dataRow.Row.ItemArray[0].ToString();
            shopName_Box.Text = dataRow.Row.ItemArray[1].ToString();      //컴퍼니 넘버 저장 이유는 리퀘스트 버튼클릭에서 써먹으려고

            Date_Box.Text = dataRow.Row.ItemArray[2].ToString();


            DrNum = dataRow.Row.ItemArray[4].ToString();


            //select driverName from delivery_driver where driverNum=1;
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            string select_Name = "select driverName from delivery_driver where driverNum='" + DrNum + "'";
            MySqlCommand command = new MySqlCommand(select_Name, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
            {
                driver_Name_Box.Text = rd["driverName"].ToString();
            }
            else
            {
                driver_Name_Box.Text = "기사미정";
            }

            rd.Close();

            //SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=1
            String ShowMenu = "SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=" + orderNum;
            command = new MySqlCommand(ShowMenu, connection);
            rd = command.ExecuteReader();
            string menuName;
            string menuCnt;
            string menuPrice;
            int i = 0;
            while (rd.Read() == true)
            {

                menuName = rd["menuName"].ToString();
                menuCnt = rd["count"].ToString();
                menuPrice = rd["price"].ToString();
                if (i < 1)
                {
                    Menu_Box.Text = menuName + " " + menuCnt + "개 " + menuPrice + "원";
                }
                else
                {
                    Menu_Box.Text = Menu_Box.Text + "\n" + menuName + " " + menuCnt + "개 " + menuPrice + "원";
                }

                i++;
            }

            connection.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //로그인 화면으로
            Login login = new Login();
            login.Show();
            Window.GetWindow(this).Close();
        }

        //리뷰 작성완료 버튼 클릭시
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");


            DataRowView dataRow = (DataRowView)ShopReview_DataGrid.SelectedItem;
            String orderNum = dataRow.Row.ItemArray[0].ToString();

            //오더 테이블 삽입
            String StarTemp = Star.selected.ToString();
            //샵리뷰 테이블 삽입
            String insert_Review_Query = "INSERT INTO project.shop_review(sReviewContent, sReviewGrade, sReviewDate, orderNum) VALUES('" + Review_Box.Text + "', '" + StarTemp + "', '" + DateTime.Today.ToShortDateString() + "', '" + orderNum + "' )";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insert_Review_Query, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("리뷰 저장 완료");
                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}
