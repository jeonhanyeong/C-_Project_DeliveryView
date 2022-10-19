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
using Microsoft.Toolkit.Uwp.Notifications;
using MySql.Data.MySqlClient;
using System.Data;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// Company.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Driver : Window
    {

        public String Driver_ID;
        public String Driver_ID_company;
        public int cnt = 0;
        public int pcnt = 0;
        public Driver()
        {
            InitializeComponent();
            companyNum.Text = "64353";
            driverNum.Text = "1";
            companyName.Text = "신속배달";
            driverName.Text = "김기사";
        }
            public Driver(String DriverID)
        {
            this.Driver_ID = DriverID;
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            //String selecttQuery2 = "select * from delivery_company where driverID='" + Driver_ID + "'";



            //카운트값이 1 이상이면, 
            //카운트 넘버 구하기
            String Cnt_select = "select cnt from count";
            connection.Open();
          
            MySqlCommand cmd_select = new MySqlCommand(Cnt_select, connection);
            MySqlDataReader rd = cmd_select.ExecuteReader();
            if (rd.Read() == true)
            {
                cnt = Convert.ToInt32(rd["cnt"].ToString());
            }

            rd.Close();


            //카운트값이 1 이상이면, 
            //카운트 넘버 구하기
            String PCnt_select = "select pniCnt from count";
            cmd_select = new MySqlCommand(PCnt_select, connection);
            rd = cmd_select.ExecuteReader();
            if (rd.Read() == true)
            {
                pcnt = Convert.ToInt32(rd["pniCnt"].ToString()); 
            }
            rd.Close();


            if (cnt >= 1)
            {
                //그리드 출력!!!!!!!!!!!!!!
                MySqlDataAdapter daCountry;
                DataSet dsCountry;
                try
                {
                    //SELECT shopName "가게이름" , customerAddress "고객주소", deliveryRequest "요청사항" FROM orders LEFT JOIN shop ON shop.shopNum = orders.shopNum where orderNum='1';
                    string sql = "SELECT orderNum 번호, shopName 가게이름 ,shopAddress 가게주소,  customerAddress 고객주소, deliveryRequest 요청사항 FROM orders LEFT JOIN shop ON shop.shopNum = orders.shopNum where orderNum=";
                    
                    for (int j = 0; j < cnt; j++)
                    {
                        if (j < pcnt)
                        {
                            continue;
                        }
                        if (j == pcnt)
                        {

                            sql = sql + Convert.ToString(j+1);
                    
                        }
                        else
                        {
                            sql = sql + " or orderNum=" + Convert.ToString(j+1);
                        }
                    }

                    daCountry = new MySqlDataAdapter(sql, connection);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry);
                    Driver_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            //SELECT * FROM delivery_company LEFT JOIN delivery_driver ON delivery_company.companyNum = delivery_driver.companyNum where driverID="rltk1"
            String selecttQuery = "SELECT * FROM delivery_company LEFT JOIN delivery_driver ON delivery_company.companyNum = delivery_driver.companyNum where driverID='"+ Driver_ID + "'";


             cmd_select = new MySqlCommand(selecttQuery, connection);           //아이디호출
             rd = cmd_select.ExecuteReader();

            //카운트 값 가져오는 방법 1,

            //   MySqlDataReader rp = PW_select.ExecuteReader();


            if (rd.Read() == true)
            {
                companyNum.Text = rd["companyNum"].ToString();
                companyName.Text = rd["companyName"].ToString();
                driverNum.Text = rd["driverNum"].ToString();
                driverName.Text = rd["driverName"].ToString();
                //가게 주소, 배달팁, 카테고리, 소게는 테이블 등 의 문제로 아직 안함
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Company main = new Company();
            main.Show();
            Window.GetWindow(this).Close();
        }

        public String orderNum="";
        private void Driver_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             DataRowView dataRow = (DataRowView)Driver_DataGrid.SelectedItem;

            orderNum = dataRow.Row.ItemArray[0].ToString();
          //  t2.Text = s2;

        }

        //수락 버튼 클릭시
        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            
            string select_DrNum = "SELECT driverNum from delivery_driver where driverID='" + Driver_ID + "'";
            string Dr_num = "";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_DrNum, connection);
            MySqlDataReader rd = command.ExecuteReader();

            if (rd.Read() == true)
                Dr_num = rd["driverNum"].ToString();

            rd.Close();

            //UPDATE `project`.`orders` SET `driverNum` = '1' WHERE (`orderNum` = '1');
            String update_Cmd = "update orders set driverNum='" + Dr_num + "' where orderNum='" + orderNum + "'";
            command = new MySqlCommand(update_Cmd, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("수락 완료");
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

        //완료 버튼 클릭시 
        private void Completion_btn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            pcnt++;
            //카운트 값 저장 
            String cntQuery = "update project.count set pniCnt='" + pcnt + "' where cntNum='1'";
            MySqlCommand command = new MySqlCommand(cntQuery, connection);
            connection.Open();
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

            Driver Driver_s = new Driver();
            Driver_s.Show();
            Window.GetWindow(this).Close();

        }


    }

}