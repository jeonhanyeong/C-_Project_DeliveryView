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
using Microsoft.Toolkit.Uwp.Notifications;
using MySql.Data.MySqlClient;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// MenuList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuList : Window
    {
        public String SHOP;                     //선택한 가게 샵 넘버
        public String customer;             //로그인한 고객 ID
        public int cnt = 1;                     //메뉴 종류 수 
        public int[] menuNum = new int[6];          //메뉴를 총 6개까지 고를 수 있으니 각각의 메뉴 넘버를 담을 수 있는 배열 생성
        public int[] menuCnt = new int[6];          //오더DB에 메뉴 각각의 갯수가 필요해서 만들었음, 이런 야만적인 방법이 맞나 모르겠지만 귀찮.. 
        public int[] menuPrice = new int[6];        //위와 같은 이유임
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        public int cntt;
        public MenuList()
        {
            InitializeComponent();

        }

        public MenuList(String Customer_ID, String Shop_Num)
        {
            InitializeComponent();
            SHOP = Shop_Num;
            customer = Customer_ID;

            t2.Visibility = Visibility.Hidden;
            t3.Visibility = Visibility.Hidden;
            t4.Visibility = Visibility.Hidden;
            t5.Visibility = Visibility.Hidden;
            t6.Visibility = Visibility.Hidden;
            p2.Visibility = Visibility.Hidden;
            p3.Visibility = Visibility.Hidden;
            p4.Visibility = Visibility.Hidden;
            p5.Visibility = Visibility.Hidden;
            p6.Visibility = Visibility.Hidden;
            q2.Visibility = Visibility.Hidden;
            q3.Visibility = Visibility.Hidden;
            q4.Visibility = Visibility.Hidden;
            q5.Visibility = Visibility.Hidden;
            q6.Visibility = Visibility.Hidden;


            InitializeComponent();
            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string sql = "select menuName, menuPrice, menuGuide FROM menu where shopNum ='" + SHOP + "'";
                daCountry = new MySqlDataAdapter(sql, conn);
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                MenuList_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //고객 아이디를 통해 주소 구하기 구하기
            string select_Address = "SELECT customerAddress from customer where customerID='" + customer + "'";
            string Customer_Address = "";
            conn.Open();
            MySqlCommand command = new MySqlCommand(select_Address, conn);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                Customer_Address = rd["customerAddress"].ToString();

            rd.Close();


            Address_Box.Text = Customer_Address;
        }


    

        public ComboBoxItem currentItem { get; private set; }

        private void MenuPutClicked1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)MenuList_DataGrid.SelectedItem;
            cnt++;

            if (cnt >= 2)
            {

                t2.Visibility = Visibility.Visible;
                p2.Visibility = Visibility.Visible;
                q2.Visibility = Visibility.Visible;
                if (cnt == 2)
                {
                    string s0 = dataRow.Row.ItemArray[0].ToString();
                    t1.Text = s0;

                    string s1 = dataRow.Row.ItemArray[1].ToString();
                    p1.Text = s1;
                }

            }
            if (cnt >= 3)
            {
                t3.Visibility = Visibility.Visible;
                p3.Visibility = Visibility.Visible;
                q3.Visibility = Visibility.Visible;
                if (cnt == 3)
                {
                    string s2 = dataRow.Row.ItemArray[0].ToString();
                    t2.Text = s2;

                    string s3 = dataRow.Row.ItemArray[1].ToString();
                    p2.Text = s3;
                }
            }
            if (cnt >= 4)
            {
                t4.Visibility = Visibility.Visible;
                p4.Visibility = Visibility.Visible;
                q4.Visibility = Visibility.Visible;

                if (cnt == 4)
                {
                    string s4 = dataRow.Row.ItemArray[0].ToString();
                    t3.Text = s4;

                    string s5 = dataRow.Row.ItemArray[1].ToString();
                    p3.Text = s5;
                }

            }
            if (cnt >= 5)
            {
                t5.Visibility = Visibility.Visible;
                p5.Visibility = Visibility.Visible;
                q5.Visibility = Visibility.Visible;

                if (cnt == 5)
                {
                    string s6 = dataRow.Row.ItemArray[0].ToString();
                    t4.Text = s6;

                    string s7 = dataRow.Row.ItemArray[1].ToString();
                    p4.Text = s7;
                }
            }
            if (cnt >= 6)
            {
                t6.Visibility = Visibility.Visible;
                p6.Visibility = Visibility.Visible;
                q6.Visibility = Visibility.Visible;

                if (cnt == 6)
                {
                    string s8 = dataRow.Row.ItemArray[0].ToString();
                    t5.Text = s8;

                    string s9 = dataRow.Row.ItemArray[1].ToString();
                    p5.Text = s9;
                }

                if (cnt == 7)
                {
                    string s10 = dataRow.Row.ItemArray[0].ToString();
                    t6.Text = s10;

                    string s11 = dataRow.Row.ItemArray[1].ToString();
                    p6.Text = s11;
                }
            }

            //string s0 = dataRow.Row.ItemArray[0].ToString();
            //t1.Text = s0;

            //string s1 = dataRow.Row.ItemArray[1].ToString();
            //p1.Text = s1;
        }
        public int Tp_Add()         //총액 계산
        {
            int tp = 0;
            if (cnt == 2)       //메뉴가 1개 들어가 있을 떄 
            {
                tp = Convert.ToInt32(p1.Text);
            }
            else if (cnt == 3)
            {
                tp = Convert.ToInt32(p1.Text) + Convert.ToInt32(p2.Text);
            }
            else if (cnt == 4)
            {
                tp = Convert.ToInt32(p1.Text) + Convert.ToInt32(p2.Text) + Convert.ToInt32(p3.Text);
            }
            else if (cnt == 5)
            {
                tp = Convert.ToInt32(p1.Text) + Convert.ToInt32(p2.Text) + Convert.ToInt32(p3.Text) + Convert.ToInt32(p4.Text);
            }
            else if (cnt == 6)
            {
                tp = Convert.ToInt32(p1.Text) + Convert.ToInt32(p2.Text) + Convert.ToInt32(p3.Text) + Convert.ToInt32(p4.Text) + Convert.ToInt32(p5.Text);
            }
            else if (cnt == 7)
            {
                tp = Convert.ToInt32(p1.Text) + Convert.ToInt32(p2.Text) + Convert.ToInt32(p3.Text) + Convert.ToInt32(p4.Text) + Convert.ToInt32(p5.Text) + Convert.ToInt32(p6.Text);
            }
            return tp;
        }

        private void q1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();


            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t1.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[0] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();

    
            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t1.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();

            rd.Close();

            int price = Convert.ToInt32(Price_s);

            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String q1 = currentItem.Content.ToString();
                    int q1Num = Convert.ToInt32(q1);
                    menuCnt[0] = q1Num;                             // 메뉴 각각의 카운트를 나중에 써야해서 배열에 저장
                    menuPrice[0] = price;                               //위와 같음
                    p1.Text = Convert.ToString(price * q1Num);
    
                    int tp = Tp_Add();
                    Total.Text = "메뉴 가격 : " + tp + "\n배달팁 : 1000원";
                    TotalPrice.Text ="결제금액 : "+ Convert.ToString(tp+1000);
                    cntt = tp;
                }
            }

        }

        private void q2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();

            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t2.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[1] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();


            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t2.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();


            rd.Close();

            int price = Convert.ToInt32(Price_s);

            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String q2 = currentItem.Content.ToString();
                    int q2Num = Convert.ToInt32(q2);
                    menuCnt[1] = q2Num;
                    menuPrice[1] = price;
                    p2.Text = Convert.ToString(price * q2Num);
                    int tp = Tp_Add();
                    TotalPrice.Text = Convert.ToString(tp);
                }
            }

        }

        private void q3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();

            // 메뉴넘버 가져오기
            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t3.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[2] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();

            // 메뉴넘버 가져오기
            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t3.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();


            rd.Close();

            int price = Convert.ToInt32(Price_s);

            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String q3 = currentItem.Content.ToString();
                    int q3Num = Convert.ToInt32(q3);
                    menuCnt[2] = q3Num;
                    menuPrice[2] = price;
                    p3.Text = Convert.ToString(price * q3Num);
                    int tp = Tp_Add();
                    TotalPrice.Text = Convert.ToString(tp);
                }
            }
        }

        private void q4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();

            // 메뉴넘버 가져오기
            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t4.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[3] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();

            // 메뉴넘버 가져오기
            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t4.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();


            rd.Close();

            int price = Convert.ToInt32(Price_s);

            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String q4 = currentItem.Content.ToString();
                    int q4Num = Convert.ToInt32(q4);
                    menuCnt[3] = q4Num;
                    menuPrice[3] = price;
                    p4.Text = Convert.ToString(price * q4Num);
                    int tp = Tp_Add();
                    TotalPrice.Text = Convert.ToString(tp);
                }
            }
        }

        private void q5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();

            // 메뉴넘버 가져오기
            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t5.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[4] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();

            // 메뉴넘버 가져오기
            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t5.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();


            rd.Close();

            int price = Convert.ToInt32(Price_s);

            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {
                    String q5 = currentItem.Content.ToString();
                    int q5Num = Convert.ToInt32(q5);
                    menuCnt[4] = q5Num;
                    menuPrice[4] = price;
                    p5.Text = Convert.ToString(price * q5Num);
                    int tp = Tp_Add();
                    TotalPrice.Text = Convert.ToString(tp);
                }
            }
        }

        private void q6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();

            // 메뉴넘버 가져오기
            //  select menuNum from menu where shopNum='321321' and menuName='갈비탕'
            string select_menuNum = "select menuNum from menu where shopNum='" + SHOP + "' and menuName ='" + t6.Text + "'";
            MySqlCommand command = new MySqlCommand(select_menuNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                menuNum[5] = Convert.ToInt32(rd["menuNum"].ToString());

            rd.Close();

            // 메뉴넘버 가져오기
            //  select menuPrice from menu where shopNum='321321' and menuName='갈비탕'
            string select_price = "select menuPrice from menu where shopNum='" + SHOP + "' and menuName ='" + t6.Text + "'";
            string Price_s = "";
            command = new MySqlCommand(select_price, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                Price_s = rd["menuPrice"].ToString();


            rd.Close();

            int price = Convert.ToInt32(Price_s);
 
            ComboBox currentComboBox = sender as ComboBox;
            if (currentComboBox != null)
            {
                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                if (currentItem != null)
                {

                    String q6 = currentItem.Content.ToString();
                    int q6Num = Convert.ToInt32(q6);
                    menuCnt[5] = q6Num;
                    menuPrice[5] = price;
                    p6.Text = Convert.ToString(price * q6Num);
                    int tp = Tp_Add();
                    TotalPrice.Text = Convert.ToString(tp);
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 버튼 클릭시 골랐던 가게 메뉴 등 주문정보를 DB에 저장을 아래에서 부터 시작

            //오더넘버의 맥스값을 구한다. 키값 자동 증가가 있다면 안해도 되는건데...ㅠ
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

            String select_orderNum_Query = "select max(orderNum) max from orders";

            connection.Open();
            //오더 넘버 저장, ? 는 null값을 저장하기 위한 것,
            int? order_Num = 0;
            MySqlCommand cmd_select = new MySqlCommand(select_orderNum_Query, connection);
            MySqlDataReader rd = cmd_select.ExecuteReader();

            //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
            //굳이 이런 방식을 택한건 mysql에서 값이 없을떄 null을 반환하는게 아닌 그냥 공백반환, 또는 반환을 아예 안한다.
            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    order_Num = null;
                }
                else
                    order_Num = Convert.ToInt32(max);

            }

            //최대치에 +1, 없으면 1로 기본키인 드라이버 넘버 값 설정
            if (order_Num >= 1)
            {
                order_Num++;
            }
            else if (order_Num == null)
            {
                order_Num = 1;
            }

            rd.Close(); connection.Close();

            //customer ID를 통해  customer_num구하기
            string select_customerNum = "SELECT customerNum from customer where customerID='" + customer + "'";
            string customerNum = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_customerNum, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
                customerNum = rd["customerNum"].ToString();

            rd.Close(); connection.Close();


            //오더넘버에 맞춰서 날짜, 주문한 고객넘버, 요청사항, 기사요청사항, 주문한 가게넘버를 넣음
            String insert_order_Query = "INSERT INTO project.orders(orderNum, orderDate, customerNum, orderRequest, deliveryRequest, shopNum, totalPrice, customerAddress) VALUES('" + order_Num + "', '" + DateTime.Today.ToShortDateString() + "', '" + customerNum + "' , '" + Order_Request_Box.Text + "', '" + Delivery_Request_Box.Text + "', '" + SHOP + "', '" + cntt + "', '" + Address_Box.Text + "' )";

            connection.Open();
            command = new MySqlCommand(insert_order_Query, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    //이게 있어야 하는건가..? 왜..? 확인용이 아니었어..?
                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //오더-디테일 넘버의 맥스값을 구한다. 키값 자동 증가가 있다면 안해도 되는건데...ㅠ
            String select_orderDetailNum_Query = "select max(orderDetailNum) max from order_detail";


            //오더 넘버 저장, ? 는 null값을 저장하기 위한 것,
            int? orderDetail_Num = 0;

            cmd_select = new MySqlCommand(select_orderDetailNum_Query, connection);
            rd = cmd_select.ExecuteReader();

            //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
            //굳이 이런 방식을 택한건 mysql에서 값이 없을떄 null을 반환하는게 아닌 그냥 공백반환, 또는 반환을 아예 안한다.
            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    orderDetail_Num = null;
                }
                else
                    orderDetail_Num = Convert.ToInt32(max);

            }

            //최대치에 +1, 없으면 1로 기본키인 드라이버 넘버 값 설정
            if (orderDetail_Num >= 1)
            {
                orderDetail_Num++;
            }
            else if (orderDetail_Num == null)
            {
                orderDetail_Num = 1;
            }

            rd.Close(); connection.Close();


            //오더 디테일을 저장할건데 메뉴 갯수만큼 생성되야한다. 그래서 cnt값을 활용함
            //cnt값은 기본적으로 1, 장바구니에 메뉴를 하나 넣으면  cnt값은 2가됨, 
           
            connection.Open();
            for (int i=0; i<cnt-1; i++)
            {
                String insert_order_detail_Query = "INSERT INTO project.order_detail(orderDetailNum, menuNum, count, price, orderNum) VALUES('" + orderDetail_Num + "', '" + menuNum[i] + "', '" + menuCnt[i]  + "' , '" + menuCnt[i]  * menuPrice[i] + "', '" + order_Num + "' )";
                orderDetail_Num++;
                command = new MySqlCommand(insert_order_detail_Query, connection);
                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        //이게 있어야 하는건가..? 왜..? 확인용이 아니었어..?
                    }
                    else
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            //알림창 띄우는 부분
            new ToastContentBuilder()
              //.AddArgument("action", "viewConversation")
              //.AddArgument("주문 현황으로 이동합니다.")
              .AddText("주문이 완료되었습니다.")
              .AddText("신속하고 정확한 배달!")
              .Show();

            Window.GetWindow(this).Close();
        }

        //private void MenuList_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DataRowView dataRow = (DataRowView)MenuList_DataGrid.SelectedItem;

        //    string s2 = dataRow.Row.ItemArray[0].ToString();
        //    t2.Text = s2;

        //    string s3 = dataRow.Row.ItemArray[1].ToString();
        //    p2.Text = s3;
        //}
    }
}
