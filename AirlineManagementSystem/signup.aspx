<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="AirlineManagementSystem.signup" %>
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
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                            <h4>Registration</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <label>Full Name</label>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox><br>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"/>
                           </div>
                        </center>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>
