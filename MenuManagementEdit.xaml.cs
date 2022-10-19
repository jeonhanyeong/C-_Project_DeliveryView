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
    /// MenuManagementEdit.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuManagementEdit : Window
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

        public MenuManagementEdit(String menuNumBox)
        {

            InitializeComponent();

            // select menuName, menuPrice from menu where menuNum='1';
            String SelectNumQuery = "select menuName, menuPrice from menu where menuNum='" + menuNumBox + "'";
            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(SelectNumQuery, connection);           //아이디호출
            MySqlDataReader rd = cmd_select.ExecuteReader();

            String ID;
            String Pass;
            Menu_Num_Box.Text = menuNumBox;
            if (rd.Read() == true)
            {
                ID = rd["menuName"].ToString();
                Pass = rd["menuPrice"].ToString();
                Menu_Name_Box.Text = ID;
                Menu_Price_Box.Text = Pass;
            }
            rd.Close(); connection.Close();

        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            //update menu set menuName = '유부김밥', menuPrice = '3500' where menuNum = '3';
            String UpdateMenuQuery = "update menu set menuName ='" + Menu_Name_Box.Text + "', menuPrice='" + Menu_Price_Box.Text + "', menuGuide='"+ menuGuide_Box.Text + "' where menuNum='" + Menu_Num_Box.Text + "';";
            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(UpdateMenuQuery, connection);           //아이디호출

            if (cmd_select.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("수정완료");
                connection.Close();

                Window.GetWindow(this).Close();

            }


        }
    }
}
