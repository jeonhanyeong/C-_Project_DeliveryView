using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MobileAppUsageDashboard.CompanyPage
{


    public partial class CompanyInformationEdit : Window
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");

        public CompanyInformationEdit(String companyNum)
        {
            InitializeComponent();

            // select menuName, menuPrice from menu where menuNum='1';
            String SelectNumQuery = "select companyName, companyPhone, companyAddress, companyIntroduce from delivery_company where companyNum='" + companyNum + "'";
            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(SelectNumQuery, connection);           //아이디호출
            MySqlDataReader rd = cmd_select.ExecuteReader();


            companyNumEdit.Text = companyNum;
            if (rd.Read() == true)
            {

                EditShop.Text = rd["companyName"].ToString();
                EditNumber.Text = rd["companyPhone"].ToString();
                EditAddress.Text = rd["companyAddress"].ToString();
                EditIntro.Text = rd["companyIntroduce"].ToString();

            }

            rd.Close(); connection.Close();

            companyNumEdit.Visibility = Visibility.Hidden;


        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save Data
            String UpdateMenuQuery = "update delivery_company set companyName ='" + EditShop.Text + "', companyPhone='" + EditNumber.Text + "', companyAddress='" + EditAddress.Text + "', companyIntroduce='" + EditIntro.Text + "' where companyNum='" + companyNumEdit.Text + "';";
            connection.Open();
            MySqlCommand cmd_select = new MySqlCommand(UpdateMenuQuery, connection);           //아이디호출


            if (cmd_select.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("수정완료");
                connection.Close();

                Window.GetWindow(this).Close();
            }




        }

        private void EditShop_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
