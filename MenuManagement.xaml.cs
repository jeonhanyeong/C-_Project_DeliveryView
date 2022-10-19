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
    /// MenuManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuManagement : Window
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        String SHOP;
        public MenuManagement(String Shop_ID)
        {
            InitializeComponent();

            //메뉴 불러오기
            if (MenuManagementRadio.IsChecked == true)
            {

                SHOP = Shop_ID;
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

                    string sql = "SELECT menuNum, menuName, menuPrice, menuGuide FROM menu where shopNum='" + shop_num + "'";
                    daCountry = new MySqlDataAdapter(sql, conn);
                    // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry);
                    MenuManagement_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public MenuManagement()
        {
            InitializeComponent();
        }


        private void MenuManagementBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = true;
            ShopInformationRadio.IsChecked = false;

            ShopInformation shopInformation = new ShopInformation(SHOP);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void CompanyListBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = false;
            ShopInformationRadio.IsChecked = true;

            CompanyList companyList = new CompanyList(SHOP);
            companyList.Show();
            Window.GetWindow(this).Close();
        }

        private void OrderInformationBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MenuManagementRadio.IsChecked = false;
            ShopInformationRadio.IsChecked = false;

            OrdersStatus ordersStatus = new OrdersStatus(SHOP);
            ordersStatus.Show();
            Window.GetWindow(this).Close();
        }

        private void ShopReviewBtnClicked(object sender, RoutedEventArgs e)
        {

            mainDrawer.IsLeftDrawerOpen = false;

            ShopReview shopReview = new ShopReview(SHOP);
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
            Main main = new Main(SHOP);
            main.Show();
            Window.GetWindow(this).Close();
        }

        private void ShopInformationRadioClicked(object sender, RoutedEventArgs e)
        {
            ShopInformation shopInformation = new ShopInformation(SHOP);
            shopInformation.Show();
            Window.GetWindow(this).Close();
        }

        private void MenuManagementRadioClicked(object sender, RoutedEventArgs e)
        {
            MenuManagement menuManagement = new MenuManagement(SHOP);
            menuManagement.Show();
            Window.GetWindow(this).Close();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            MenuManagementAdd menuManagementAdd = new MenuManagementAdd(SHOP);
            menuManagementAdd.ShowDialog();
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            MenuManagementEdit menuManagementEdit = new MenuManagementEdit(menuNumBox.Text);

            menuManagementEdit.Show();

        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            string constring = "Server=localhost;Database=project;Uid=root;Pwd=root";
            if (menuNumBox.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from menu where menuNum ='" + this.menuNumBox.Text + "';";
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

        private void MenuManagement_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)MenuManagement_DataGrid.SelectedItem;

            string s0 = dataRow.Row.ItemArray[0].ToString();
            menuNumBox.Text = s0;

            string s1 = dataRow.Row.ItemArray[1].ToString();
            MenuName_Box.Text = s1;

            string s2 = dataRow.Row.ItemArray[2].ToString();
            MenuPrice_Box.Text = s2;

            string s3 = dataRow.Row.ItemArray[3].ToString();
            menuGuide_Box.Text = s3;
        }


    }
}
