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

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// MenuManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShopInformation : Window
    {
        public String Shop_ID;
        public ShopInformation()
        {
            InitializeComponent();
        }

        public ShopInformation(String Shop_ID)
        {
            this.Shop_ID = Shop_ID;
            InitializeComponent();


            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            String selecttQuery = "select * from shop where shopID='" + Shop_ID + "'";


            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
            MySqlDataReader rd = cmd_select.ExecuteReader();

            //카운트 값 가져오는 방법 1,

            //   MySqlDataReader rp = PW_select.ExecuteReader();


            if (rd.Read() == true)
            {
                Shop_AddressBox.Text = rd["shopAddress"].ToString();
                Shop_NameBox.Text= rd["shopName"].ToString();
                Shop_PhoneBox.Text= rd["shopPhone"].ToString();
                Shop_TipBox.Text = rd["tip"].ToString();
                Shop_GuideBox.Text = rd["shopIntroduce"].ToString();
                Shop_CategoryBox.Text = "분식";
            }

        }

        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = true;
            ShopInformationRadio.IsChecked = false;

            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = false;
            ShopInformationRadio.IsChecked = true;

            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = false;
            ShopInformationRadio.IsChecked = false;

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

        private void ShopInformationEditBtnClicked(object sender, RoutedEventArgs e)
        {
            ShopInformationEdit shopInformationEdit = new ShopInformationEdit();
            shopInformationEdit.Show();
        }
    }
}
