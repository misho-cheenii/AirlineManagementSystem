<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="AirlineManagementSystem.booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/gridviewstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <label>Booking ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>
        <br>
        <asp:GridView ID="GridView1" CssClass="gridviewstyle" runat="server" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
        </asp:GridView>
        <br>
        <div class="row">
            <div class="col-md-2 mx-auto">
                <asp:Button ID="Button3" class="btn btn-secondary btn-block" runat="server" Text="View Details" OnClick="Button3_Click" />
                <asp:Button ID="Button4" class="btn btn-danger btn-block " runat="server" Text="Cancel Booking" OnClick="Button4_Click" />
            </div>
        </div>
        <br>
    </div>
</asp:Content>
