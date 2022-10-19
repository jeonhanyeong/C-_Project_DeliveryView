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
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>



    public partial class Login : Window
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
        public String Shop_ID;
        public String Company_ID;
        public String Customer_ID;
        public String Driver_ID;

        public Login()
        {
            InitializeComponent();

        }




        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            String selecttQuery = "select customerID from project.customer;";
            //String selecttPWQuery = "select customerPW from project.customer where customerID='" + NameTextBox.Text + "';";

            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
            MySqlDataReader rd = cmd_select.ExecuteReader();

            //카운트 값 가져오는 방법 1,

            //   MySqlDataReader rp = PW_select.ExecuteReader();

            String ID;
            String BoxID = NameTextBox.Text;
            String Pass;
            String BoxPW = IpTextBox.Password;
            int CN = 0;
            int login_test = 0;
            while (rd.Read() == true)
            {
                ID = rd["customerID"].ToString();

                if (ID.Equals(BoxID))
                {
                    rd.Close();
                    CN = 1;
                    //cmd_select = new MySqlCommand(selecttPWQuery, connection);           //아이디호출
                    //rd = cmd_select.ExecuteReader(); 
                    cmd_select.CommandText = "select customerPW from project.customer where customerID='" + NameTextBox.Text + "';";
                    Pass = (String)cmd_select.ExecuteScalar();
                    login_test = 1;
                    if (Pass.Equals(BoxPW))
                    {
                        Customer_ID = BoxID;
                        CustomerManagement customerManagement = new CustomerManagement(Customer_ID);
                        customerManagement.Show();
                        Window.GetWindow(this).Close();
                        break;
                    }

                    else { MessageBox.Show("비빌번호가 올바르지 않습니다."); rd.Close(); break; }
                }
            }
            rd.Close(); connection.Close();

            //위에서 못찾았으면 이제 shop 테이블에서 찾아보자!
            if (login_test == 0)
            {
                selecttQuery = "select shopID from project.shop;";
                // selecttPWQuery = "select shopPW from project.shop where shopID='" + NameTextBox.Text + "';";

                connection.Open();
                cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
                rd = cmd_select.ExecuteReader();

                BoxID = NameTextBox.Text;
                BoxPW = IpTextBox.Password;

                while (rd.Read() == true)
                {
                    ID = rd["shopID"].ToString();

                    if (ID.Equals(BoxID))
                    {
                        rd.Close();
                        CN = 1;
                        //cmd_select = new MySqlCommand(selecttPWQuery, connection);           //아이디호출
                        //rd = cmd_select.ExecuteReader(); 
                        cmd_select.CommandText = "select shopPW from project.shop where shopID='" + NameTextBox.Text + "';";
                        Pass = (String)cmd_select.ExecuteScalar();
                        login_test = 1;
                        if (Pass.Equals(BoxPW))
                        {
                            Shop_ID = BoxID;
                            Main MainWindow = new Main(Shop_ID);
                            MainWindow.Show();
                            Window.GetWindow(this).Close();
                            break;
                        }

                        else { MessageBox.Show("비빌번호가 올바르지 않습니다."); rd.Close(); break; }
                    }
                }
                rd.Close(); connection.Close();
            }

            //그래도 못찾았다면 delivery_company 테이블에서 찾아보자!
            if (login_test == 0)
            {
                selecttQuery = "select companyID from project.delivery_company;";
                // selecttPWQuery = "select shopPW from project.shop where shopID='" + NameTextBox.Text + "';";

                connection.Open();
                cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
                rd = cmd_select.ExecuteReader();

                BoxID = NameTextBox.Text;
                BoxPW = IpTextBox.Password;

                while (rd.Read() == true)
                {
                    ID = rd["companyID"].ToString();

                    if (ID.Equals(BoxID))
                    {
                        rd.Close();
                        CN = 1;
                        //cmd_select = new MySqlCommand(selecttPWQuery, connection);           //아이디호출
                        //rd = cmd_select.ExecuteReader(); 
                        cmd_select.CommandText = "select companyPW from project.delivery_company where companyID='" + NameTextBox.Text + "';";
                        Pass = (String)cmd_select.ExecuteScalar();
                        login_test = 1;
                        if (Pass.Equals(BoxPW))
                        {
                            Company_ID = BoxID;
                            Company company = new Company(Company_ID);
                            company.Show();
                            Window.GetWindow(this).Close();
                            break;
                        }

                        else { MessageBox.Show("비빌번호가 올바르지 않습니다."); rd.Close(); break; }
                    }
                }
                rd.Close(); connection.Close();
            }

            // 마지막 기사 테이블
            if (login_test == 0)
            {
                selecttQuery = "select driverID from project.delivery_driver;";
                // selecttPWQuery = "select shopPW from project.shop where shopID='" + NameTextBox.Text + "';";

                connection.Open();
                cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
                rd = cmd_select.ExecuteReader();

                BoxID = NameTextBox.Text;
                BoxPW = IpTextBox.Password;

                while (rd.Read() == true)
                {
                    ID = rd["driverID"].ToString();

                    if (ID.Equals(BoxID))
                    {
                        rd.Close();
                        CN = 1;
                        //cmd_select = new MySqlCommand(selecttPWQuery, connection);           //아이디호출
                        //rd = cmd_select.ExecuteReader(); 
                        cmd_select.CommandText = "select driverPW from project.delivery_driver where driverID='" + NameTextBox.Text + "';";
                        Pass = (String)cmd_select.ExecuteScalar();
                        login_test = 1;
                        if (Pass.Equals(BoxPW))
                        {
                            Driver_ID = BoxID;
                            Driver Driver = new Driver(Driver_ID);
                            Driver.Show();
                            Window.GetWindow(this).Close();
                            break;
                        }

                        else { MessageBox.Show("비빌번호가 올바르지 않습니다."); rd.Close(); break; }
                    }
                }
                rd.Close(); connection.Close();
            }


            if (CN == 0) MessageBox.Show("아이디가 올바르지 않습니다.");


            //카운트 값 가져오는 방법 2 구글의 누군가가 이게 더 효율적이라고 함..
            //cnt = Convert.ToInt32(cmd_select.ExecuteScalar());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)       //회원가입 버튼
        {
            Join_Membership join_Membership = new Join_Membership();
            join_Membership.Show();
            Window.GetWindow(this).Close();

        }


    }
}
