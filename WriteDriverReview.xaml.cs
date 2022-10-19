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
    public partial class WriteDriverReview : Window
    {

        public String DriverNum;
        public String orderNum;
        public WriteDriverReview(String DrNum, String orderNum)
        {

            InitializeComponent();
            DriverNum = DrNum;
            this.orderNum = orderNum;

            //배딜기사 이름, 전화번호 출력
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");
            connection.Open();
            string select_Driver = "select driverName, driverPhone, companyNum from delivery_driver where driverNum='" + DriverNum + "'";
            MySqlCommand command = new MySqlCommand(select_Driver, connection);
            MySqlDataReader rd = command.ExecuteReader();
            String affiliationCompany = "";
            if (rd.Read() == true)
            {
                Driver_Name_Box.Text = rd["driverName"].ToString();
                Driver_Phone_Box.Text = rd["driverPhone"].ToString();
                affiliationCompany = rd["companyNum"].ToString();
            }
            rd.Close();


            string select_Company = "select companyName, companyPhone from delivery_company where companyNum='" + affiliationCompany + "'";
            command = new MySqlCommand(select_Company, connection);
            rd = command.ExecuteReader();
            if (rd.Read() == true)
            {
                Company_Box.Text = rd["companyName"].ToString();
                Company_Phone_Box.Text = rd["companyPhone"].ToString();
            }
            rd.Close();
            connection.Close();

        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=project; Uid=root; Pwd=root;");



            //드라이버 오더 바이 뭐 거 테이블 넘버 맥스값 구하기
            String selectQuery = "select max(orderDriverNum) max from delivery_drivers_by_order";

            connection.Open();
            int? orderDriverNum = 0;

            MySqlCommand cmd_select = new MySqlCommand(selectQuery, connection);
            MySqlDataReader rd = cmd_select.ExecuteReader();

            //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
            //굳이 이런 방식을 택한건 mysql에서 값이 없을떄 null을 반환하는게 아닌 그냥 공백반환, 또는 반환을 아예 안한다.
            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    orderDriverNum = null;
                }
                else
                    orderDriverNum = Convert.ToInt32(max);

            }

            //최대치에 +1, 없으면 1로 기본키인 드라이버 넘버 값 설정
            if (orderDriverNum >= 1)
            {
                orderDriverNum++;
            }
            else if (orderDriverNum == null)
            {
                orderDriverNum = 1;
            }

            rd.Close(); connection.Close();

            //오더바이 테이블 삽입
            String insertQuery = "INSERT INTO project.delivery_drivers_by_order(orderDriverNum, orderNum, driverNum) VALUES('" + orderDriverNum + "', '" + orderNum + "', '" + DriverNum + "' )";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

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

            connection.Close();



            //드라이버 리뷰 테이블 맥스값 구하기
             selectQuery = "select max(dReviewNum) max from driver_review";

            connection.Open();
            int? dReviewNum = 0;

            cmd_select = new MySqlCommand(selectQuery, connection);
            rd = cmd_select.ExecuteReader();

            //max가 반환값이 없으면 null을 넣고 아니면 그 값을 넣는다
            //굳이 이런 방식을 택한건 mysql에서 값이 없을떄 null을 반환하는게 아닌 그냥 공백반환, 또는 반환을 아예 안한다.
            if (rd.Read() == true)
            {
                String max = rd["max"].ToString();
                if (max == "")
                {
                    dReviewNum = null;
                }
                else
                    dReviewNum = Convert.ToInt32(max);

            }

            //최대치에 +1, 없으면 1로 기본키인 드라이버 넘버 값 설정
            if (dReviewNum >= 1)
            {
                dReviewNum++;
            }
            else if (dReviewNum == null)
            {
                dReviewNum = 1;
            }

            rd.Close(); connection.Close();




            //오더 테이블 삽입
            String StarTemp = Star.selected.ToString();
            String insert_Review_Query = "INSERT INTO project.driver_review(dReviewNum, dReviewContent, dReviewGrade, dReviewDate, orderDriverNum) VALUES('" + dReviewNum + "', '" + Review_Box.Text + "', '" + StarTemp + "', '" + DateTime.Today.ToShortDateString() + "' , '" + orderDriverNum + "' )";

            connection.Open();
            command = new MySqlCommand(insert_Review_Query, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("리뷰 저장 완료");
                    this.Close();
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

    }
}