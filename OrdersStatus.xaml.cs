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
    /// MenuManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrdersStatus : Window
    {
        public String Shop_ID;
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        public int cnt;             //스타트에서 클리어로 넘어간게 몇개인지 카운팅

        public OrdersStatus()
        {
            InitializeComponent();
        }

        public OrdersStatus(String Shop_ID)
        {
            this.Shop_ID = Shop_ID;
            InitializeComponent();


            //샵 넘버에 구하기
            string select_shopNum = "SELECT shopNum from shop where shopID='" + Shop_ID + "'";
            string shop_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close();


            //카운트 넘버 구하기
            String Cnt_select = "select cnt from count";
            command = new MySqlCommand(Cnt_select, connection);
            rd = command.ExecuteReader();
            if(rd.Read() == true)
            {
                cnt=  Convert.ToInt32(rd["cnt"].ToString());

            }
            rd.Close();
            //샵넘버를 통해 샵넘버에 맞는 오더 넘버를 구함
            //select orderNum from orders where shopNum=321321;
            string select_orderNum = "SELECT orderNum from orders where shopNum='" + shop_num + "'";
            String[] orderNum = new String[30];
            int i = 0;
            command = new MySqlCommand(select_orderNum, connection);
            rd = command.ExecuteReader();
            while (rd.Read() == true)
            {
                orderNum[i] = rd["orderNum"].ToString();
                i++;
            }
            rd.Close();
            command.Clone();
            //왼쪽 그리드
            if(cnt != i)
            {
                try
                {
                    //SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=1;
                    string sql = "select odrd.orderNum, me.menuName, odrd.count, odrd.price, odr.orderRequest from order_detail as odrd left join orders as odr on odrd.orderNum = odr.orderNum left join menu as me on me.menuNum = odrd.menuNum where odrd.orderNum='";
                    for (int j = cnt; j < i; j++)
                    {
                        // SELECT orderNum from orders where shopNum = '321321' or shopNum = '12313';
                        //select orderNum, menuNum, count, price from order_detail where orderNum ='1';

                        if (j == cnt)
                        {
                            sql = sql + orderNum[j] + "'";
                        }
                        else
                        {
                            sql = sql + "or odrd.orderNum='" + orderNum[j] + "'";
                        }


                    }
                    daCountry = new MySqlDataAdapter(sql, connection);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry);
                    Start_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            //오른쪽 그리드
            if (cnt != 0)
            {
                try
                {
                    //SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=1;
                    string sql = "select odrd.orderNum, me.menuName, odrd.count, odrd.price, odr.orderRequest from order_detail as odrd left join orders as odr on odrd.orderNum = odr.orderNum left join menu as me on me.menuNum = odrd.menuNum where odrd.orderNum='";
                    for (int j = 0; j < cnt; j++)
                    {
                        // SELECT orderNum from orders where shopNum = '321321' or shopNum = '12313';
                        //select orderNum, menuNum, count, price from order_detail where orderNum ='1';

                        if (j == 0)
                        {
                            sql = sql + orderNum[j] + "'";
                        }
                        else
                        {
                            sql = sql + "or odrd.orderNum='" + orderNum[j] + "'";
                        }


                    }
                    daCountry = new MySqlDataAdapter(sql, connection);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry);
                    OrdersStatus_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }






        }

        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            OrdersStatusRadio.IsChecked = true;
            OrdersRecordRadio.IsChecked = false;

            ShopInformation shopInformation = new ShopInformation(Shop_ID);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            OrdersStatusRadio.IsChecked = false;
            OrdersRecordRadio.IsChecked = true;

            CompanyList companyList = new CompanyList(Shop_ID);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            OrdersStatusRadio.IsChecked = false;
            OrdersRecordRadio.IsChecked = false;

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

        //콜 버튼 클릭시 기사에게 오더 뿌림
        private void Call_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("기사 호출 완료");
            cnt++;

            string select_shopNum = "SELECT shopNum from shop where shopID='" + Shop_ID + "'";
            string shop_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close();

            //샵넘버를 통해 샵넘버에 맞는 오더 넘버를 구함
            //select orderNum from orders where shopNum=321321;
            string select_orderNum = "SELECT orderNum from orders where shopNum='" + shop_num + "'";
            String[] orderNum = new String[30];
            int i = 0;
            command = new MySqlCommand(select_orderNum, connection);
            rd = command.ExecuteReader();
            while (rd.Read() == true)
            {
                orderNum[i] = rd["orderNum"].ToString();
                i++;
            }
            rd.Close();
            command.Clone();

            if(cnt != i)
            {
                    try
                    {
                        //SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=1;
                        string sql = "select odrd.orderNum, me.menuName, odrd.count, odrd.price, odr.orderRequest from order_detail as odrd left join orders as odr on odrd.orderNum = odr.orderNum left join menu as me on me.menuNum = odrd.menuNum where odrd.orderNum='";
                        for (int j = cnt; j < i; j++)
                        {
                            // SELECT orderNum from orders where shopNum = '321321' or shopNum = '12313';
                            //select orderNum, menuNum, count, price from order_detail where orderNum ='1';

                            if (j == cnt)
                            {
                                sql = sql + orderNum[j] + "'";
                            }
                            else
                            {
                                sql = sql + "or dord.orderNum='" + orderNum[j] + "'";
                            }


                        }
                        daCountry = new MySqlDataAdapter(sql, connection);
                        dsCountry = new DataSet();
                        daCountry.Fill(dsCountry);
                        Start_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


     


            try
            {
                //SELECT orderNum, menuName, count, price FROM menu LEFT JOIN order_detail ON menu.menuNum = order_detail.menuNum where orderNum=1;
                string sql = "select odrd.orderNum, me.menuName, odrd.count, odrd.price, odr.orderRequest from order_detail as odrd left join orders as odr on odrd.orderNum = odr.orderNum left join menu as me on me.menuNum = odrd.menuNum where odrd.orderNum='";
                for (int j = 0; j < cnt; j++)
                {
                    // SELECT orderNum from orders where shopNum = '321321' or shopNum = '12313';
                    //select orderNum, menuNum, count, price from order_detail where orderNum ='1';

                    if (j == 0)
                    {
                        sql = sql + orderNum[j] + "'";
                    }
                    else
                    {
                        sql = sql + "or odrd.orderNum='" + orderNum[j] + "'";
                    }


                }
                daCountry = new MySqlDataAdapter(sql, connection);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                OrdersStatus_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //카운트 값 저장 
            //UPDATE `project`.`count` SET `cnt` = '2' WHERE (`cntNum` = '1');
            String cntQuery = "update project.count set cnt='" + cnt + "' where cntNum='1'";
            command = new MySqlCommand(cntQuery, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {

                }
                else
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            command.Clone();
   





            }
        }
}
