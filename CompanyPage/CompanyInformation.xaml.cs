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

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// UserControlCustomers.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CompanyInformation : UserControl
    {

        string Company_Num;
        public CompanyInformation(string Company_ID)
        {
            InitializeComponent();
            string company = "SELECT * from delivery_company where companyID='" + Company_ID + "'";
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(company, connection);
            MySqlDataReader rd = command.ExecuteReader();

            if (rd.Read() == true)
            companyName.Text = rd["companyName"].ToString();
            companyNumber.Text = rd["companyPhone"].ToString();
            companyAdress.Text = rd["companyAddress"].ToString();
            companyIntro.Text = rd["companyIntroduce"].ToString();
            Company_Num = rd["companyNum"].ToString();
            companyNum1.Text = Company_Num;

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



        private void EditClicked(object sender, RoutedEventArgs e)
        {
            CompanyPage.CompanyInformationEdit menuManagementEdit = new CompanyPage.CompanyInformationEdit(companyNum1.Text);
            menuManagementEdit.Show();
        }


    }
}