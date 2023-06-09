using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].Equals(""))
                    {
                        LinkButton1.Visible = true;
                        LinkButton2.Visible = true;

                        LinkButton3.Visible = false;
                        LinkButton4.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;


                        LinkButton6.Visible = false;
                        LinkButton7.Visible = false;
                    }
                    else
                    {
                        if (Session["role"].Equals("user"))
                        {
                            LinkButton1.Visible = false;
                            LinkButton2.Visible = false;

                            LinkButton3.Visible = true;
                            LinkButton3.Text = "User profile";
                            LinkButton4.Visible = true;
                            LinkButton8.Visible = true;
                            LinkButton9.Visible = true;


                            LinkButton6.Visible = false;
                            LinkButton7.Visible = false;
                        }
                        else
                        {
                            if (Session["role"].Equals("admin"))
                            {
                                LinkButton1.Visible = false;
                                LinkButton2.Visible = false;

                                LinkButton3.Visible = true;
                                LinkButton3.Text = "Admin profile";
                                LinkButton4.Visible = true;
                                LinkButton8.Visible = false;
                                LinkButton9.Visible = false;

                                LinkButton6.Visible = true;
                                LinkButton7.Visible = true;
                            }
                        }
                    }
                }
            }
            catch { }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-registration.aspx");
        }


        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["role"] = "";
            Session["id"] = null;
            Response.Redirect("home-page.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-info.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-task-management.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-user-management.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("searchTest.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {

        }
    }
}