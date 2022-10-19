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
    /// MenuManagementAdd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuManagementAdd : Window
    {
        String SHOP = "";
        public MenuManagementAdd()
        {
            InitializeComponent();
        }
        public MenuManagementAdd(String shopID)
        {
            InitializeComponent();
            SHOP = shopID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

            string select_shopNum = "SELECT shopNum from shop where shopID='" + SHOP + "'";
            string shop_num = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader();
            if (rd.Read() == true)
                shop_num = rd["shopNum"].ToString();

            rd.Close(); connection.Close();


            String selectQuery = "select max(menuNum) max from menu";


            connection.Open();
            int? Menu_Num = 0;
            MySqlCommand cmd_select = new MySqlCommand(selectQuery, connection);
            rd = cmd_select.ExecuteReader();

            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    Menu_Num = null;
                }
                else
                    Menu_Num = Convert.ToInt32(max);
            }
           
            //위에서 구한 값에 menu넘이 뭔가 있다면, 1증가시킴, null이면 첫 값이 되니까 1을 넣어줌
            if (Menu_Num >= 1)
            {
                Menu_Num++;
            }
            else if (Menu_Num == null)
            {
                Menu_Num = 1;
            }
            rd.Close(); connection.Close();



            String insertQuery = "INSERT INTO project.menu(menuNum, menuName, menuprice, shopNum, menuGuide) VALUES('" + Menu_Num + "', '" + Name_Box.Text + "', '" + Price_Box.Text + "' , '" + shop_num + "' , '" + menu_Guide.Text + "')";
            connection.Open();
            MySqlCommand cmd_insert = new MySqlCommand(insertQuery, connection);

            if (cmd_insert.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(Convert.ToString("추가 완료"));
                Window.GetWindow(this).Close();
            }

        }
    }
}
