<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="flightsearch.aspx.cs" Inherits="AirlineManagementSystem.flightsearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>
    <link href="css/gridviewstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                            <h4>Flight Search</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AirlineManagement_V2ConnectionString %>" SelectCommand="SELECT * FROM [flightView] where Departure >= DATEADD(hour,5,CURRENT_TIMESTAMP)"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Flight" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Flight" HeaderText="Flight" ReadOnly="True" SortExpression="Flight" />
                                        <asp:BoundField DataField="CityFrom" HeaderText="From" SortExpression="From" />
                                        <asp:BoundField DataField="CityTo" HeaderText="To" SortExpression="To" />
                                        <asp:BoundField DataField="Departure" HeaderText="Departure" SortExpression="Departure" />
                                        <asp:BoundField DataField="Arrival" HeaderText="Arrival" SortExpression="Arrival" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                               <h4>Booking</h4>
                           </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                              <img width="120px" src="imgs/bookings.png" />         
                          </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <label class="input-group-text" for="inputGroupSelect01">Flight ID</label>
                                    </div>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GridView2" CssClass="gridviewstyle" runat="server" PagerStyle-CssClass="pager"
                                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                </asp:GridView>
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="inputGroupSelect01">Class</label>
                                </div>
                                <asp:DropDownList runat="server" ID="DropDownList1" CssClass="btn btn-info" DataTextField="class"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3 mx-auto ">
                                <asp:Button class="btn btn-secondary btn-lg" ID="Button2" runat="server" Text="Booking" OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br>
</asp:Content>
