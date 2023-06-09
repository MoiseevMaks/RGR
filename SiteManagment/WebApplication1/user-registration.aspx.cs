using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class user_registration : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["connectinDB"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool CheckUserExists()
        {
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("SELECT * from users where users.login='" + TextBox4.Text + "';", con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    return false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(MySqlConnection con = new MySqlConnection(connection))
            {
                if(!CheckUserExists())
                {
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`, `mail`)" +
                            " VALUES (@login, @password, @name, @surname, @mail)", con);

                        cmd.Parameters.AddWithValue("@login", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@password", TextBox5.Text);
                        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@surname", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@mail", TextBox3.Text);
                        if((TextBox1.Text.Trim().Length == 0)|| (TextBox2.Text.Trim().Length == 0) || 
                            (TextBox3.Text.Trim().Length == 0) ||
                            (TextBox4.Text.Trim().Length == 0) || (TextBox5.Text.Trim().Length == 0))
                        {
                            con.Close();
                            Response.Write("<script>alert('Some lines are empty')</script>");
                            
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Registration Complete! Go to login.')</script>");
                            Response.Redirect("home-page.aspx");
                        }
                       

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('User with that login already exists')</script>");
                }
               
            }
           
         
        }
    }
}