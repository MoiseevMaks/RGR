using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.AppSettings["connectinDB"];
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open(); 
                    }
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE users.login ='" + TextBox1.Text + "'" +
                        " AND users.password ='" + TextBox2.Text + "'", con);//
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Response.Write("<script>alert('Successful login');</script>");
                        if (dr.Read())
                        {                          
                            Session["id"] = dr.GetValue(0).ToString();//
                            int RoleID = dr.GetInt32(6); //
                            if (RoleID == 1)
                            {
                                Session["role"] = "user";
                            }

                            if (RoleID == 2) 
                            {
                                Session["role"] = "admin";
                            }

                            
                            Response.Redirect("home-page.aspx");
                        }                 
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong info, try again.')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }
    }
}