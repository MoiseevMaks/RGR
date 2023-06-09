<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="user-registration.aspx.cs" Inherits="WebApplication1.user_registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <div class="col-md-6 mx-auto">
                <div class="card">
                   <div class="card-body">
                      <div class="row">
                         <div class="col">
                            <center>
                                <img width="100" src="images/SadFace.png" />
                                <br />
                               <h3>REGISTRATION</h3>
                            </center>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col">
                            <hr>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col-md-8">
                            <label>Name*</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Name"></asp:TextBox>
                            </div>
                         </div>
                        <div class="col-md-8">
                            <label>Surname*</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Surname"></asp:TextBox>
                            </div>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col-md-8">
                            <label>Email*</label>
                            <div class="form-group">
                               <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                            </div>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col-md-6">
                            <label>Login*</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Login"></asp:TextBox>
                            </div>
                         </div>
                         <div class="col-md-6">
                            <label>Password*</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Password" ></asp:TextBox>
                            </div>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col-8 mx-auto">
                            <center>
                               <div class="form-group">
                                  <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Register now" OnClick="Button1_Click" />
                               </div>
                            </center>
                         </div>
                  
                    </div>
                   </div>
                </div>
                <center>
                   <a href="home-page.aspx"><< Back to Home</a><br><br>
                </center>
             </div>

        </div>
    </div>

</asp:Content>
