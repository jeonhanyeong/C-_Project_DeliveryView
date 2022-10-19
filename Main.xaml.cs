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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    ///    

    public partial class Main : Window
    {
        

        public String Shop_ID;
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection1 { get; set; }

        public string[] Labels { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Main()
        {
            InitializeComponent();
        }
        public Main(String Shop_ID)
        {

            this.Shop_ID = Shop_ID;
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "월간",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4, 4, 6, 5, 2, 4,5,5 }
                },

            };
            Labels = new[] { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" };
            SeriesCollection1 = new SeriesCollection
            {
                 new LineSeries
                {

                },
                new LineSeries
                {
                    Title = "주간",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 },
                    Stroke = new SolidColorBrush(Colors.Red)

                },

            };
            Labels1 = new[] { "1주", "2주", "3주", "4주", "5주", };
            Formatter = value => value.ToString();
            DataContext = this;


            //로그인했던 ID에 맞는 가게 사업자 등록번호 가져오기
            string select_shopNum = "SELECT shopNum from shop where shopID='" + Shop_ID + "'";
            string shop_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close();


            //로그인한 계정의 주문의 갯수 확인, 1개 이상이면 메세지 출력
            //select count(shopNum) cnt from orders where shopNum=321321;
            string select_orders_count = "select count(shopNum) cnt from orders where shopNum='" + shop_num + "'";
            string count = "";
            command = new MySqlCommand(select_orders_count, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                count = rd["cnt"].ToString();

            rd.Close();

             select_orders_count = "select cnt from count";
            string pcount = "";
            command = new MySqlCommand(select_orders_count, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                pcount = rd["cnt"].ToString();

            rd.Close();


            //     MessageBox.Show(pcount);
            //select count(orderNum) cnt from orders  
            //오더의 수가 카운트 값보다 높으면 추가 주문이 들어온 거니까 메시지 출력
            select_orders_count = "select count(orderNum) cnt from orders ";
            string Tcount = "";
            command = new MySqlCommand(select_orders_count, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Tcount = rd["cnt"].ToString();
            rd.Close();

            select_orders_count = "select cnt from count ";
            int ccc = 0;
            command = new MySqlCommand(select_orders_count, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                ccc = Convert.ToInt32(rd["cnt"].ToString());
            rd.Close();

            connection.Close();

            if (Convert.ToInt32(Tcount) > ccc)
            {
                new ToastContentBuilder()
                .AddArgument("주문 현황으로 이동합니다.", Shop_ID)
                .AddText("배달 주문이 들어왔습니다!")
                .AddText("주문 현황에서 확인하세요.")
                .Show();

            }


        }



        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {

            mainDrawer.IsLeftDrawerOpen = false;

            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();

        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {

            mainDrawer.IsLeftDrawerOpen = false;

            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {

            mainDrawer.IsLeftDrawerOpen = false;

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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //}

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
        private void HomeClicked(object sender, RoutedEventArgs e)
        {
            Main main = new Main(Shop_ID);
            main.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).Close();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {


            Date1_Box.Text = Convert.ToString(Calendar_Box.SelectedDate).Substring(0,10) + "일";
            Date2_Box.Text = Convert.ToString(Calendar_Box.SelectedDate).Substring(0, 10) + "일";

            Random rand = new Random();

            rjstn.Text = "건수 "+ Convert.ToString(rand.Next(80, 200));
            aocnf.Text = "매출 " + String.Format("{0:#,0}", rand.Next(1000000, 2000000)) + " 원";

        }

    }
}
