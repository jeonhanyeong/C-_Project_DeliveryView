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
using System.Data;
using MySql.Data.MySqlClient;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// MenuManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CompanyList : Window
    {
        public String Shop_ID;
        public String Company_Num;
        public CompanyList()
        {
            InitializeComponent();
        }
        public CompanyList(String Shop_IDD)
        {
            InitializeComponent();
            Shop_ID = Shop_IDD;

            MySqlDataAdapter daCountry;
            DataSet dsCountry;

            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {

                string sql = "select companyNum, companyName, companyPhone, companyAddress from delivery_company";
                daCountry = new MySqlDataAdapter(sql, conn);
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                CompanyList_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



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

        private void CompanyList_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)CompanyList_DataGrid.SelectedItem;
            Company_Num = dataRow.Row.ItemArray[0].ToString();      //컴퍼니 넘버 저장 이유는 리퀘스트 버튼클릭에서 써먹으려고

            string s1 = dataRow.Row.ItemArray[1].ToString();
            Company_nameBox.Text = s1;

            string s3 = dataRow.Row.ItemArray[3].ToString();
            Company_Address.Text = s3;

            

            string select_shopNum = "select count(companyNum) count from delivery_driver where companyNum = '" + dataRow.Row.ItemArray[0].ToString() + "'";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                Company_StaffCount_Box.Text = rd["count"].ToString();

            rd.Close();

            //소개글
            //select companyIntroduce from delivery_company where companyNum=64353
            select_shopNum = "select companyIntroduce from delivery_company where companyNum= '" + dataRow.Row.ItemArray[0].ToString() + "'";
             command = new MySqlCommand(select_shopNum, connection);
             rd = command.ExecuteReader();
            if (rd.Read() == true)
                Guide_Box.Text = rd["companyIntroduce"].ToString();
            rd.Close();

            if (dataRow.Row.ItemArray[0].ToString().Equals("64353"))
            {
                //별점
                //SELECT round(avg(dReviewGrade),1) avg FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1
                select_shopNum = "SELECT round(avg(dReviewGrade),1) avg FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1";
                command = new MySqlCommand(select_shopNum, connection);
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

        }

        private void Request_btn_Click(object sender, RoutedEventArgs e)
        {

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

            //-------------어필레이트 맥스 구하기
            String selectQuery = "select max(affiliateNum) max from affiliate_business";


            int? Affiliate_Max = 0;

            command = new MySqlCommand(selectQuery, connection);
            rd = command.ExecuteReader();

            //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    Affiliate_Max = null;
                }
                else
                    Affiliate_Max = Convert.ToInt32(max);

            }
            rd.Close();
            //최대치에 +1, 없으면 1로 기본키인 어필레이트 넘버 값 설정
            if (Affiliate_Max >= 1)
            {
                Affiliate_Max++;
            }
            else if (Affiliate_Max == null)
            {
                Affiliate_Max = 1;
            }


            //어필레이트 넘버 구하기
            //select affiliateNum from affiliate_business where shopNum ='12313'
            string affiliate_Num = "select affiliateNum from affiliate_business where shopNum ='" + shop_num + "'";

            command = new MySqlCommand(affiliate_Num, connection);
            rd = command.ExecuteReader();
            //어필레이트 넘 변수는 어차피 위에서 이미 쿼리문 날렸으니 아래에서 재활용 ㅋㅋ
            int? AffiliateNum = 0;
            if (rd.Read() == true)
            {
                affiliate_Num = rd["affiliateNum"].ToString();
                if (affiliate_Num == "")
                {
                    AffiliateNum = 0;
                }
                else
                    AffiliateNum = Convert.ToInt32(affiliate_Num);

            }
            rd.Close();
            // MessageBox.Show(Affiliate_Max + ", " + shop_num + ", " + Company_Num + ". " + AffiliateNum);  확인용임
            //만약 샵에서 처음으로 제휴를 맺는거면 insert, 이미 맺었는데 다른 곳으로 교체하는거면 update로 한다.
            if (AffiliateNum >= 1)
            {
                //이게 1보다 큰, 뭔가 값이 있다면, 첫 재휴가 아닌 바꾸는 거니까 update가 된다
                String UpdateAffiliateQuery = "update affiliate_business set companyNum ='" + Company_Num + "', affiliateStartDate='" + DateTime.Today.ToShortDateString() + "' where shopNum='" + shop_num + "';";
                command = new MySqlCommand(UpdateAffiliateQuery, connection);
            }
            else if (AffiliateNum == 0)
            {
                //처음 재휴를 맞는거니까 insert가 된다
                String insertQuery = "INSERT INTO project.affiliate_business(affiliateNum, shopNum, companyNum, affiliateStartDate) VALUES('" + Affiliate_Max + "', '" + shop_num + "', '" + Company_Num + "' , '" + DateTime.Today.ToShortDateString() + "' )";
                command = new MySqlCommand(insertQuery, connection);
            }

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("재휴 신청 완료");
                }
                else
                {
                    MessageBox.Show("비정상 이당");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            connection.Close();





        }







    }
}
