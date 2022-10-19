using MaterialDesignThemes.Wpf;
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
    /// Company.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Company : Window
    {
        public String Company_ID;
        string Company_Num;
        public Company(String Company_ID)
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("업체 정보", new CompanyInformation(Company_ID)));
            menuRegister.Add(new SubItem("기사 관리", new DriverManagement(Company_ID)));

            var item6 = new ItemMenu("업체 관리", menuRegister, PackIconKind.HomeCity);

            var menuSchedule = new List<SubItem>();


            menuSchedule.Add(new SubItem("제휴가게 목록", new AffiliateStatus(Company_ID)));
            var item1 = new ItemMenu("제휴 관리", menuSchedule, PackIconKind.Store);



            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));

            this.Company_ID = Company_ID;

            string company = "SELECT * from delivery_company where companyID='" + Company_ID + "'";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(company, connection);
            MySqlDataReader rd = command.ExecuteReader();

            if (rd.Read() == true)
            {
                companyName.Text = rd["companyName"].ToString();
                companyNumber.Text = rd["companyPhone"].ToString();
                companyAdress.Text = rd["companyAddress"].ToString();
                companyIntro.Text = rd["companyIntroduce"].ToString();
                Company_Num = rd["companyNum"].ToString();
                companyNum1.Text = Company_Num;


            }
            rd.Close();

            //select count(companyNum)cnt from delivery_driver where companyNum=64353
            string select_cnt = "select count(companyNum)cnt from delivery_driver where companyNum='" + Company_Num + "'";
            command = new MySqlCommand(select_cnt, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
            {
                employees_Count.Text = rd["cnt"].ToString();
            }


            connection.Close();

        }
        public Company()
        {

        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
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
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //로그인 화면으로
            Login login = new Login();
            login.Show();
            Window.GetWindow(this).Close();
        }

        private void HomeClicked(object sender, RoutedEventArgs e)
        {
            Company main = new Company(Company_ID);
            main.Show();
            Window.GetWindow(this).Close();
        }


    }
}