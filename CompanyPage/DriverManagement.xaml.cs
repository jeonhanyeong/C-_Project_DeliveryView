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

using System.Data;
using MySql.Data.MySqlClient;

namespace MobileAppUsageDashboard
{
    /// <summary>
    /// UserControlProviders.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DriverManagement : UserControl
    {
        public String Company_ID;
        public String Driver_Num;


        public DriverManagement()
        {
            InitializeComponent();
        }
        public DriverManagement(string Company_ID)
        {
            InitializeComponent();
            MySqlDataAdapter daCountry;
            DataSet dsCountry;

            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string sql = "select driverNum, driverName, driverPhone from delivery_driver";
                daCountry = new MySqlDataAdapter(sql, conn);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                DriverManagement_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            CompanyPage.DriverManagementAdd driverManagementAdd = new CompanyPage.DriverManagementAdd();
            driverManagementAdd.ShowDialog();
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            CompanyPage.DriverManagementEdit driverManagementEdit = new CompanyPage.DriverManagementEdit();
            driverManagementEdit.Show();
        }

        private void DriverManagement_DataGridrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DriverManagement_DataGrid.SelectedItem;
            Driver_Num = dataRow.Row.ItemArray[0].ToString();      //컴퍼니 넘버 저장 이유는 리퀘스트 버튼클릭에서 써먹으려고

            Driver_Name.Text = dataRow.Row.ItemArray[1].ToString();

            Driver_Phone.Text = dataRow.Row.ItemArray[2].ToString();



            //별점구하기, 총 배달 횟수 셀렉트 
            //SELECT round(avg(dReviewGrade),1) avg, count(driverNum) cnt FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1
            string select_Dr = "SELECT round(avg(dReviewGrade),1) avg, count(driverNum) cnt FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum='" + Driver_Num + "'";

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_Dr, connection);
            MySqlDataReader rd = command.ExecuteReader();

            if (rd.Read() == true)
            {
                Start_Box.Text = rd["avg"].ToString();
                Driver_Count_Box.Text = rd["cnt"].ToString();
            }

            rd.Close();

            //리뷰 구하기
            //SELECT dReviewContent FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum=1
            string select_Review = "SELECT dReviewContent FROM driver_review LEFT JOIN delivery_drivers_by_order ON driver_review.orderDriverNum = delivery_drivers_by_order.orderDriverNum where driverNum='" + Driver_Num + "'";

            command = new MySqlCommand(select_Review, connection);
             rd = command.ExecuteReader();
            int i = 0;
            while (rd.Read() == true)
            {
                if (i < 1)
                {
                    Driver_Review_Box.Text = rd["dReviewContent"].ToString();
                }
                else
                {
                    Driver_Review_Box.Text = Driver_Review_Box.Text + "\n" + rd["dReviewContent"].ToString();
                }
                i++;
            }
            connection.Close();

        }

    }
}