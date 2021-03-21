<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="roles.aspx.cs" Inherits="AirlineManagementSystem.roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    //<link href="css/roles.css" rel="stylesheet" />
    <link href="css/StyleSheet2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br>
        <br>
        <div class="row">
            <div class="col">
                <div class="d-flex justify-content-end">
                    <center>
                        <asp:Button class="btn btn-secondary btn-lg" ID="Button1" runat="server" Text="Staff Management" OnClick="Button1_Click"/>
                    </center>
                </div>
            </div>
    </div>
    <br>
    <br>
    <br>
    <div class="row">
        <div class="col">
            <div class="d-flex justify-content-end">
                <center>
                        <asp:Button class="btn btn-secondary btn-lg" ID="Button2" runat="server" Text="Passenger Management" OnClick="Button2_Click1"/>
                    </center>
            </div>
        </div>
    </div>
    <br>
    <br>
    <br>
    <div class="row">
        <div class="col">
            <div class="d-flex justify-content-end">
                <center>
                        <asp:Button class="btn btn-secondary btn-lg" ID="Button3" runat="server" Text="Flight Management" OnClick="Button3_Click"/>
                </center>
            </div>
        </div>
    </div>
    <br>
    <br>
    <br>
    <div class="row">
        <div class="col">
            <div class="d-flex justify-content-end">
                <center>
                        <asp:Button class="btn btn-secondary btn-lg" ID="Button4" runat="server" Text="Airplane Management" OnClick="Button4_Click"/>
                    </center>
            </div>
        </div>
    </div>
    <br>
    <br>
    <br>
    </div>
</asp:Content>
