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
    public partial class AffiliateBusiness : Window
    {
        public String Shop_ID;
        public AffiliateBusiness()
        {
            InitializeComponent();
        }
        public AffiliateBusiness(String shop)
        {
            InitializeComponent();
            Shop_ID = shop;

            String Company_Name = "";
            String Company_Address = "";
            String Company_StartDate = "";
            String Company_Count_Staff = "";

            //샵 넘버 구하기
            string select_ShopNum = "SELECT shopNum from shop where shopID='" + Shop_ID + "'";
            string shop_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_ShopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close();

            //샵 넘버를 통해 제휴를 맺은 컴퍼니 넘버를 가져오기
            //select companyNum from affiliate_business where shopNum='12313'
            String select_CompanyNum_Query = "select companyNum from affiliate_business where shopNum='" + shop_num + "'";

            command = new MySqlCommand(select_CompanyNum_Query, connection);
            rd = command.ExecuteReader();
            String Company_Num = "";
            if (rd.Read() == true)
            {
                Company_Num = rd["companyNum"].ToString();
            }
            rd.Close();



            //컴퍼니에 접근해서 업체이름, 지역 가져오기
            //select companyName, companyAddress from delivery_company where companyNum ='64353'
            string Company_Select = "select companyName, companyAddress from delivery_company where companyNum ='" + Company_Num + "'";

            command = new MySqlCommand(Company_Select, connection);
            rd = command.ExecuteReader();

            if (rd.Read() == true)
            {
                Company_Name = rd["companyName"].ToString();
                Company_Address = rd["companyAddress"].ToString();
            }
            rd.Close();

            //어필레이트에 접근해서 제휴날짜 가져오기
            //select affiliateStartDate from affiliate_business where shopNum='12313'
            string select_Startdate = "select affiliateStartDate from affiliate_business where shopNum='" + shop_num + "'";
            command = new MySqlCommand(select_Startdate, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Company_StartDate = rd["affiliateStartDate"].ToString();

            rd.Close();



            string Counting_Staff = "select count(companyNum) count from delivery_driver where companyNum = '" + Company_Num + "'";
            command = new MySqlCommand(Counting_Staff, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Company_Count_Staff = rd["count"].ToString();

            rd.Close();


            //소개글
            //select companyIntroduce from delivery_company where companyNum=64353
            string select_Guide = "select companyIntroduce from delivery_company where companyNum= '" + Company_Num + "'";
            command = new MySqlCommand(select_Guide, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Guide_Box.Text = rd["companyIntroduce"].ToString();
            rd.Close();

            if (Company_Num.Equals("64353"))
            {
                //별점
                //SELECT round(avg(dReviewGrade),1) avg FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1
                select_Guide = "SELECT round(avg(dReviewGrade),1) avg FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1";
                command = new MySqlCommand(select_Guide, connection);
                rd = command.ExecuteReader();
                if (rd.Read() == true)
                    Star.Text = rd["avg"].ToString();
                rd.Close();
            }
            else
            {
                Star.Text = "0";
            }






            connection.Close();

            Company_Name_Box.Text = Company_Name;
            Campany_Address_Box.Text = Company_Address;
            Company_StaffCount_Box.Text = Company_Count_Staff;
            AffiliateStart_Date_Box.Text = Company_StartDate.Substring(0, 10);     //년, 월, 일 출력하고 그 뒤 시간데이터 컷








        }



        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            CompanyListRadio.IsChecked = true;
            AffiliateBusinessRadio.IsChecked = false;

            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            CompanyListRadio.IsChecked = false;
            AffiliateBusinessRadio.IsChecked = true;

            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            CompanyListRadio.IsChecked = false;
            AffiliateBusinessRadio.IsChecked = false;

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

        private void CompanyListRadioRadioClicked(object sender, RoutedEventArgs e)
        {
            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void AffiliateBusinessRadioClicked(object sender, RoutedEventArgs e)
        {
            AffiliateBusiness affiliateBusiness = new AffiliateBusiness(Shop_ID);
            affiliateBusiness.Show();
            Window.GetWindow(this).Close();
        }
    }
}
