<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="user-info.aspx.cs" Inherits="WebApplication1.user_info" %>
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
                               <img width="100" src="imgs/generaluser.png"/>
                                <br />
                                Your Profile
                            </center>
                         </div>
                      </div>
                      <div class="row">
                         <div class="col">
                            <hr>
                         </div>
                      </div>

                      <div class="row">
                        <div class="col-md-6">
                            <label>ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                             <label>Login</label>
                             <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Login" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                       <center>
                           <h4>Changable</h4>

                           Write elements you want to change on the right,or leave empty
                        </center>



                        <div class="row">
                         <div class="col-md-6">
                            <label>Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Name" ReadOnly="True"></asp:TextBox>
                            </div>
                         </div>
                            <div class="col-md-6">
                                <label>New Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="New Name"></asp:TextBox>
                                </div>
                         </div>
                         </div>

                         <div class="row">
                        <div class="col-md-6">
                            <label>Surname</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Surname" ReadOnly="True"></asp:TextBox>
                            </div>
                            </div>

                            <div class="col-md-6">
                            <label>New Surname</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="New Surname"></asp:TextBox>
                            </div>
                         </div>
                        </div>


                              <div class="row">
                         <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                               <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="Email " ReadOnly="True"></asp:TextBox>
                            </div>
                         </div>
                            <div class="col-md-6">
                                <label>New Email</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder=" New Email" TextMode="Email"></asp:TextBox>
                                </div>
                         </div>
                         </div>

                       <div class="row">
                            <div class="col-md-6">
                            <label>Password</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Password" ReadOnly="True" ></asp:TextBox>
                            </div>
                         </div>

                         <div class="col-md-6">
                            <label>New Password</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="New Password"></asp:TextBox>
                            </div>
                         </div>
                         </div>

                      <div class="row">

                         <div class="col-6 mx-auto">
                            <center>

                               <div class="form-group">
                                  <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                               </div>
                            </center>
                         </div>
                      </div>
                   </div>
                </div>              
             </div>
             
    </div>              
</div>


</asp:Content>

