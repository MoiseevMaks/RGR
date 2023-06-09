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
    public partial class user_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE users.id ='" +Session["id"]+"'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            TextBox1.Text = dr.GetValue(0).ToString();                         
                            TextBox2.Text = dr.GetValue(3).ToString();
                            TextBox3.Text = dr.GetValue(4).ToString();
                            TextBox4.Text = dr.GetValue(5).ToString();
                            TextBox5.Text = dr.GetValue(1).ToString();
                            TextBox6.Text = dr.GetValue(2).ToString();
                        }
                    }                    
                    else
                    {
                        Response.Write("<script>alert('Smth wrong, try again.')</script>");
                    }
                    con.Close();
                }
                catch 
                {
                }
            }
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
                    MySqlCommand cmd = new MySqlCommand("UPDATE " +
                    "users SET login = @login, password = @password, name = @name, surname = @surname," +
                    " mail = @mail WHERE users.id ='" + TextBox1.Text + "'", con);
                    TextBox1 = new TextBox();
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@login", TextBox5.Text);

                   
                    if (TextBox8.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@name", TextBox8.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", TextBox2.Text);
                    }
               
                    if (TextBox9.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@surname", TextBox9.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@surname", TextBox3.Text);
                    }


                   
                    if (TextBox10.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@mail", TextBox10.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@mail", TextBox4.Text);
                    }

                    if (TextBox7.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@password", TextBox7.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@password", TextBox6.Text);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("home-page.aspx");
                }
                catch
                {
                }

            }
        }
    }
}