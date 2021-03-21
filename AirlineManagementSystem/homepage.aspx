<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="AirlineManagementSystem.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img width="1349px" src="imgs/welcome.jpg"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                   <br>
                  <h2>Bon Voyage</h2>
                   <br>
               </center>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <center>
                   <img width="150px" src="imgs/search-flight.png" />
               </center>
                    <br>
                    <br>
                    <center>
                    <asp:Button class="btn btn-secondary btn-lg" ID="Button1" runat="server" Text="Flight Booking" OnClick="Button1_Click" />
                </center>
                </div>
                <div class="col">
                    <center>
                  <img width="150px" src="imgs/bookings.png"/>
               </center>
                    <br><br>
                    <center>
                    <asp:Button class="btn btn-secondary btn-lg" ID="Button2" runat="server" Text="Booking Details" OnClick="Button2_Click" />
                </center>
                </div>
            </div>
            <br>
        </div>
    </section>
</asp:Content>
