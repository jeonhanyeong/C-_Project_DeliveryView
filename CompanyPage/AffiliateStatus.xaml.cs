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
    public partial class AffiliateStatus : UserControl
    {
        public String Company_ID;
        public String Driver_Num;
        public AffiliateStatus()
        {
            InitializeComponent();
        }

        public AffiliateStatus(string Company_ID)
        {
            InitializeComponent();
            MySqlDataAdapter daCountry;
            DataSet dsCountry;

            string connStr = "Server=localhost; Database=project; Uid=root; Pwd=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string sql = "select affiliateNum 제휴넘버, shopNum 가게넘버, companyNum 대행업체넘버, date_format(affiliateStartDate, '%Y-%m-%d') 제휴시작일 from affiliate_business";
                daCountry = new MySqlDataAdapter(sql, conn);
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry);
                AffiliateStatus_DataGrid.ItemsSource = dsCountry.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AffiliateStatus_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dataRow = (DataRowView)AffiliateStatus_DataGrid.SelectedItem;
            Driver_Num = dataRow.Row.ItemArray[0].ToString();      //컴퍼니 넘버 저장 이유는 리퀘스트 버튼클릭에서 써먹으려고

            AffiliateStartDateBox.Text = dataRow.Row.ItemArray[3].ToString();

            string shopNum = dataRow.Row.ItemArray[1].ToString();

            //샵 네임 구하기
            string select_shopNum = "SELECT shopName, categoryNum, shopAddress from shop where shopNum='" + shopNum + "'";

            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            MySqlCommand command = new MySqlCommand(select_shopNum, connection);
            MySqlDataReader rd = command.ExecuteReader(); 
            if (rd.Read() == true)
            {
                ShopNameBox.Text = rd["shopName"].ToString(); 
                ShopAddressBox.Text = rd["shopAddress"].ToString();
                CategoryNumBox.Text = rd["categoryNum"].ToString();
            }

            if (ShopNameBox.Text.Equals("만두나라"))
            {
                CategoryNumBox.Text = "분식";
            }
            else if (ShopNameBox.Text.Equals("뒤뚝"))
            {
                CategoryNumBox.Text = "한식";
            }
            rd.Close();




        }
    }
}