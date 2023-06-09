using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class searchTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Загрузка страницы
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Value.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                List<Test> tests = SearchTestsByName(query);
                rptTests.DataSource = tests;
                rptTests.DataBind();

                if (tests.Count > 0)
                {
                    lblNoResults.Visible = false;
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            }
            else
            {
                rptTests.DataSource = null;
                rptTests.DataBind();
                lblNoResults.Visible = false;
            }
        }


        protected void rptTests_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int testId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("testPage.aspx?id=" + testId);
            }
        }

        private List<Test> SearchTestsByName(string name)
        {
            List<Test> tests = new List<Test>();

            // Установка строки подключения к базе данных
            string connection = ConfigurationManager.AppSettings["connectinDB"];
            // Выполнение запроса к базе данных
            string query = "SELECT * FROM tests WHERE name LIKE @name";
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@Name", "%" + name + "%");

                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int testId = Convert.ToInt32(reader["Id"]);
                    string testName = reader["Name"].ToString();
                    // Другие поля теста

                    Test test = new Test(testId, testName);
                    tests.Add(test);
                }
                reader.Close();
            }

            return tests;
        }
    }

    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }

        public Test(int testId, string name)
        {
            TestId = testId;
            Name = name;
        }
    }
}
