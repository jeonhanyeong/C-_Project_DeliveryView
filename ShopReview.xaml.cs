using System;
using System.Data;
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

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// MenuManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShopReview : Window
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        public String Shop_ID;
        public String CsNum;

        public ShopReview(String Shop_ID)
        {
            InitializeComponent();


            //로그인했던 ID에 맞는 가게 사업자 등록번호 가져오기

            string select_shopNum = "SELECT shopNum from shop where shopID='" + Shop_ID + "'";
            string shop_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close(); connection.Close();

            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string sql = "select sReviewNum 번호,customerNum 사용자ID, date_format(sReviewDate, '%Y-%m-%d')  주문일시, sReviewGrade 평점 ,sReviewContent 리뷰, sr.orderNum 주문번호 from orders o join shop_review sr where o.orderNum=sr.orderNum and o.shopNum='" + shop_num + "'";
                daCountry = new MySqlDataAdapter(sql, conn);
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                ShopReview_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public ShopReview()
        {
            InitializeComponent();
        }

        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            ShopReviewRadio.IsChecked = true;

            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            ShopReviewRadio.IsChecked = false;

            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            ShopReviewRadio.IsChecked = false;

            OrdersStatus ordersStatus = new OrdersStatus(Shop_ID);
            ordersStatus.Show();
            Window.GetWindow(this).Close();
        }

        private void ShopReviewBtnClicked(object sender, RoutedEventArgs e)
        {

            mainDrawer.IsLeftDrawerOpen = false;

            ShopReview shopReview = new ShopReview(Shop_ID);
            shopReview.Show();
            Window.GetWindow(this).Close();
        }

        private void dragME(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login MainWindow = new Login();
            MainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //로그인 화면으로
            Login login = new Login();
            login.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void HomeClicked(object sender, RoutedEventArgs e)
        {
            Main main = new Main(Shop_ID);
            main.Show();
            Window.GetWindow(this).Close();
        }
        private void ShopInformationRadioClicked(object sender, RoutedEventArgs e)
        {
            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void MenuManagementRadioClicked(object sender, RoutedEventArgs e)
        {
            MenuManagement menuManagement = new MenuManagement(Shop_ID);
            menuManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void ShopReviewRadioClicked(object sender, RoutedEventArgs e)
        {
            ShopReview shopReview = new ShopReview(Shop_ID);
            shopReview.Show();
            Window.GetWindow(this).Close();
        }

        private void OrdersStatusRadioClicked(object sender, RoutedEventArgs e)
        {
            OrdersStatus ordersStatus = new OrdersStatus(Shop_ID);
            ordersStatus.Show();
            Window.GetWindow(this).Close();
        }
        private void OrdersRecordRadioClicked(object sender, RoutedEventArgs e)
        {
            OrdersRecord ordersRecord = new OrdersRecord(Shop_ID);
            ordersRecord.Show();
            Window.GetWindow(this).Close();
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            string constring = "Server=localhost;Database=project;Uid=root;Pwd=root";
            if (sReviewContentBox.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from menu where menuNum ='" + this.sReviewContentBox.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("삭제완료");

                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //   LoadData();
            }
        }

        private void ShopReview_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)ShopReview_DataGrid.SelectedItem;
            String orderNum = dataRow.Row.ItemArray[0].ToString();
            customerNumBox.Text = dataRow.Row.ItemArray[1].ToString();
            sReviewDateBox.Text = dataRow.Row.ItemArray[2].ToString();
            sReviewGradeBox.Text = dataRow.Row.ItemArray[3].ToString();

            sReviewContentBox.Text = dataRow.Row.ItemArray[4].ToString();

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            String ShowMenu = "SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=" + orderNum;
            MySqlCommand command = new MySqlCommand(ShowMenu, connection);
            MySqlDataReader rd = command.ExecuteReader();
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

            rd.Close();

            connection.Close();
        }
    }
}