<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="flight.aspx.cs" Inherits="AirlineManagementSystem.fight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="container">
        <div class="col-md-12 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="col">
                        <div class="col mx-auto">
                            <center>
                            <h4>Flight Management</h4>
                        </center>
                        </div>
                        <div class="row">
                            <div class="col mx-auto">
                                <center>
                                <img width="120px" src="imgs/flightdetail.png" />         
                            </center>
                            </div>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-6 mx-auto">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h4>Add Flight</h4>
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
                                            <label>Flight ID</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Airplane ID</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>From</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="id" CssClass="btn btn-info">
                                                        <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>To</label>
                                            <div class="form-group">
                                                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="id" CssClass="btn btn-info">
                                                    <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Departure</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Arrival</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <center>
                                                    <asp:Button class="btn btn-outline-success" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6 mx-auto">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h4>Edit Flights</h4>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <hr>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-10">
                                            <label>Flight ID</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ID"></asp:TextBox>
                                                    <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Departure</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="TextBox8" runat="server" TextMode="DateTime" CssClass="form-control" placeholder="mm/dd/yyyy hh:mm tt"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Arrival</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="DateTime" placeholder="mm/dd/yyyy hh:mm tt"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <center>
                                                    <asp:Button class="btn btn-outline-success" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click"/>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                    <h5>Add new City</h5>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="ID"></asp:TextBox>
                                                    <asp:Button class="btn btn-success" ID="Button4" runat="server" Text="Add" OnClick="Button4_Click"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br>
</asp:Content>
