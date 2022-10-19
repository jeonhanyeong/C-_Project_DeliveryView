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
using MySql.Data.MySqlClient;       //db참조

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// Join_Membership.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class Join_Membership : Window
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

        int Join_Num = 1;       //로그인 구분, 1=고객, 2=사장 3=대행업체 4=기사
        int Dong_Num;
        public Join_Membership()
        {
            InitializeComponent();

            SP_customer.Visibility = Visibility.Visible;
            SP_shop.Visibility = Visibility.Hidden;
            SP_company.Visibility = Visibility.Hidden;
            SP_Driver.Visibility = Visibility.Hidden;
            //처음에 콤보박스 숨김
            SP_See.Visibility = Visibility.Hidden;
            DG_Dong.Visibility = Visibility.Hidden;
            JG_Dong.Visibility = Visibility.Hidden;
            SG_Dong.Visibility = Visibility.Hidden;
            USG_Dong.Visibility = Visibility.Hidden;
            DDG_Dong.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Join_Num == 1)      //고객 회원가입
            {
                String insertQuery = "INSERT INTO project.customer(customerID, customerPW, customerName, customerPhone) VALUES('" + IDBox.Text + "', '" + PWBox.Password + "', '" + NameBox.Text + "' , '" + PhoneBox.Text + "')";

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료");
                        Login login = new Login();
                        login.Show();
                        Window.GetWindow(this).Close();
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

            if (Join_Num == 2)      //가게 회원가입
            {
                //확인용
                //    String test = Convert.ToString(Dong_Num);         
                //  MessageBox.Show(test);

                //동 포함버젼
                String insertQuery = "INSERT INTO project.shop(shopNum, shopName, shopPhone, shopID, shopPW, dongNum) VALUES('" + ShopNumBox.Text + "', '" + ShopNameBox.Text + "', '" + ShopPhoneBox.Text + "' , '" + ShopIDBox.Text + "', '" + ShopPWBox.Password + "', '" + Dong_Num + "' )";

                //String insertQuery = "INSERT INTO project.shop(shopNum, shopName, shopPhone, shopID, shopPW) VALUES('" + ShopNumBox.Text + "', '" + ShopNameBox.Text + "', '" + ShopPhoneBox.Text + "' , '" + ShopIDBox.Text + "', '" + ShopPWBox.Password + "' )";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료");
                        Login login = new Login();
                        login.Show();
                        Window.GetWindow(this).Close();
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

            if (Join_Num == 3)      //대행업체 회원가입
            {
                String insertQuery = "INSERT INTO project.delivery_company(companyNum, companyName, companyPhone, companyID, companyPW, companyAddress) VALUES('" + companyNumBox.Text + "', '" + companyNameBox.Text + "', '" + companyPhoneBox.Text + "' , '" + companyIDBox.Text + "', '" + companyPWBox.Password + "', '" + companyAddress.Text + "' )";

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료");
                        Login login = new Login();
                        login.Show();
                        Window.GetWindow(this).Close();
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

            if (Join_Num == 4)      //배달기사 회원가입
            {
                // 드라이버 넘버 맥스값 구하기
                MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

                String selectQuery = "select max(driverNum) max from delivery_driver";

                connection.Open();
                int? Driver_Num = 0;

                MySqlCommand cmd_select = new MySqlCommand(selectQuery, connection);
                MySqlDataReader rd = cmd_select.ExecuteReader();

                //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
                //굳이 이런 방식을 택한건 mysql에서 값이 없을떄 null을 반환하는게 아닌 그냥 공백반환, 또는 반환을 아예 안한다.
                if (rd.Read() == true)
                {
                    String max = rd["max"].ToString();
                    if (max == "")
                    {
                        Driver_Num = null;
                    }
                    else
                        Driver_Num = Convert.ToInt32(max);

                }



                //최대치에 +1, 없으면 1로 기본키인 드라이버 넘버 값 설정
                if (Driver_Num >= 1)
                {
                    Driver_Num++;
                }
                else if (Driver_Num == null)
                {
                    Driver_Num = 1;
                }

                rd.Close(); connection.Close();


                String insertQuery = "INSERT INTO project.delivery_driver(driverNum, driverName, driverPhone, driverID, driverPW, companyNum) VALUES('" + Driver_Num + "', '" + Driver_NameBox.Text + "', '" + Driver_PhoneBox.Text + "' , '" + Driver_IDBox.Text + "', '" + Driver_PWBox.Password + "', '" + Driver_companyNumBox.Text + "' )";

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);



                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료");
                        Login login = new Login();
                        login.Show();
                        Window.GetWindow(this).Close();
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



        private void Button_Click_1(object sender, RoutedEventArgs e)       //가게 버튼 클릭시
        {
            SP_customer.Visibility = Visibility.Visible;
            SP_shop.Visibility = Visibility.Hidden;
            SP_company.Visibility = Visibility.Hidden;
            SP_Driver.Visibility = Visibility.Hidden;

            //콤보 박스 숨김
            SP_See.Visibility = Visibility.Hidden;
            DG_Dong.Visibility = Visibility.Hidden;
            JG_Dong.Visibility = Visibility.Hidden;
            SG_Dong.Visibility = Visibility.Hidden;
            USG_Dong.Visibility = Visibility.Hidden;
            DDG_Dong.Visibility = Visibility.Hidden;


            Join_Num = 1;
        }

        private void Join_shop_Click(object sender, RoutedEventArgs e)
        {
            SP_customer.Visibility = Visibility.Hidden;
            SP_shop.Visibility = Visibility.Visible;
            SP_company.Visibility = Visibility.Hidden;
            SP_Driver.Visibility = Visibility.Hidden;

            //콤보박스 공개
            SP_See.Visibility = Visibility.Visible;
            DG_Dong.Visibility = Visibility.Visible;
            JG_Dong.Visibility = Visibility.Visible;
            SG_Dong.Visibility = Visibility.Visible;
            USG_Dong.Visibility = Visibility.Visible;
            DDG_Dong.Visibility = Visibility.Visible;
            Join_Num = 2;
        }

        private void Join_delivery_Click(object sender, RoutedEventArgs e)
        {
            SP_customer.Visibility = Visibility.Hidden;
            SP_shop.Visibility = Visibility.Hidden;
            SP_company.Visibility = Visibility.Visible;
            SP_Driver.Visibility = Visibility.Hidden;

            //콤보박스 숨김
            SP_See.Visibility = Visibility.Hidden;
            DG_Dong.Visibility = Visibility.Hidden;
            JG_Dong.Visibility = Visibility.Hidden;
            SG_Dong.Visibility = Visibility.Hidden;
            USG_Dong.Visibility = Visibility.Hidden;
            DDG_Dong.Visibility = Visibility.Hidden;
            Join_Num = 3;
        }


        private void Join_driver_Click(object sender, RoutedEventArgs e)
        {
            SP_customer.Visibility = Visibility.Hidden;
            SP_shop.Visibility = Visibility.Hidden;
            SP_company.Visibility = Visibility.Hidden;
            SP_Driver.Visibility = Visibility.Visible;

            //콤보박스 숨김
            SP_See.Visibility = Visibility.Hidden;
            DG_Dong.Visibility = Visibility.Hidden;
            JG_Dong.Visibility = Visibility.Hidden;
            SG_Dong.Visibility = Visibility.Hidden;
            USG_Dong.Visibility = Visibility.Hidden;
            DDG_Dong.Visibility = Visibility.Hidden;

            Join_Num = 4;
        }

        private void GuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String Gu = currentItem.Content.ToString();
                    if (Gu.Equals("중구"))
                    {
                        DG_Dong.Visibility = Visibility.Hidden;
                        JG_Dong.Visibility = Visibility.Visible;
                        SG_Dong.Visibility = Visibility.Hidden;
                        USG_Dong.Visibility = Visibility.Hidden;
                        DDG_Dong.Visibility = Visibility.Hidden;

                    }
                    if (Gu.Equals("서구"))
                    {
                        DG_Dong.Visibility = Visibility.Hidden;
                        JG_Dong.Visibility = Visibility.Hidden;
                        SG_Dong.Visibility = Visibility.Visible;
                        USG_Dong.Visibility = Visibility.Hidden;
                        DDG_Dong.Visibility = Visibility.Hidden;
                    }
                    if (Gu.Equals("동구"))
                    {
                        DG_Dong.Visibility = Visibility.Visible;
                        JG_Dong.Visibility = Visibility.Hidden;
                        SG_Dong.Visibility = Visibility.Hidden;
                        USG_Dong.Visibility = Visibility.Hidden;
                        DDG_Dong.Visibility = Visibility.Hidden;
                    }
                    if (Gu.Equals("유성구"))
                    {
                        DG_Dong.Visibility = Visibility.Hidden;
                        JG_Dong.Visibility = Visibility.Hidden;
                        SG_Dong.Visibility = Visibility.Hidden;
                        USG_Dong.Visibility = Visibility.Visible;
                        DDG_Dong.Visibility = Visibility.Hidden;
                    }
                    if (Gu.Equals("대덕구"))
                    {
                        DG_Dong.Visibility = Visibility.Hidden;
                        JG_Dong.Visibility = Visibility.Hidden;
                        SG_Dong.Visibility = Visibility.Hidden;
                        USG_Dong.Visibility = Visibility.Hidden;
                        DDG_Dong.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        //유성구
        private void USG_Dong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String dong = currentItem.Content.ToString();
                    if (dong.Equals("원내동"))
                    {
                        Dong_Num = 1;
                    }
                    if (dong.Equals("교촌동"))
                    {
                        Dong_Num = 2;
                    }
                    if (dong.Equals("대정동"))
                    {
                        Dong_Num = 3;
                    }
                    if (dong.Equals("용계동"))
                    {
                        Dong_Num = 4;
                    }
                    if (dong.Equals("학하동"))
                    {
                        Dong_Num = 5;
                    }

                }
            }
        }
        //중구
        private void JG_Dong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String dong = currentItem.Content.ToString();
                    if (dong.Equals("은행동"))
                    {
                        Dong_Num = 6;
                    }
                    if (dong.Equals("선화동"))
                    {
                        Dong_Num = 7;
                    }
                    if (dong.Equals("목동"))
                    {
                        Dong_Num = 8;
                    }
                    if (dong.Equals("중촌동"))
                    {
                        Dong_Num = 9;
                    }
                    if (dong.Equals("대흥동"))
                    {
                        Dong_Num = 10;
                    }

                }
            }
        }

        //서구
        private void SG_Dong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String dong = currentItem.Content.ToString();
                    if (dong.Equals("복수동"))
                    {
                        Dong_Num = 11;
                    }
                    if (dong.Equals("변동"))
                    {
                        Dong_Num = 12;
                    }
                    if (dong.Equals("도마동"))
                    {
                        Dong_Num = 13;
                    }
                    if (dong.Equals("청림동"))
                    {
                        Dong_Num = 14;
                    }
                    if (dong.Equals("용문동"))
                    {
                        Dong_Num = 15;
                    }

                }
            }
        }

        //동구
        private void DG_Dong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String dong = currentItem.Content.ToString();
                    if (dong.Equals("원동"))
                    {
                        Dong_Num = 16;
                    }
                    if (dong.Equals("인동"))
                    {
                        Dong_Num = 17;
                    }
                    if (dong.Equals("효동"))
                    {
                        Dong_Num = 18;
                    }
                    if (dong.Equals("천동"))
                    {
                        Dong_Num = 19;
                    }
                    if (dong.Equals("가오동"))
                    {
                        Dong_Num = 20;
                    }

                }
            }
        }

        //대덕구
        private void DDG_Dong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String dong = currentItem.Content.ToString();
                    if (dong.Equals("오정동"))
                    {
                        Dong_Num = 21;
                    }
                    if (dong.Equals("대화동"))
                    {
                        Dong_Num = 22;
                    }
                    if (dong.Equals("읍내동"))
                    {
                        Dong_Num = 23;
                    }
                    if (dong.Equals("연축동"))
                    {
                        Dong_Num = 24;
                    }
                    if (dong.Equals("신대동"))
                    {
                        Dong_Num = 25;
                    }

                }
            }
        }




    }
}
