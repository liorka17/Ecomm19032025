<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Ecomm19032025.AdminManage.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1>טבלת ניהול מוצרים</h1>
    <a href="ProductAddEdit.aspx" class="btn btn-info">הוספת מוצר</a>
    <table class="table table-borderless table-hover">
        <thead>
            <tr>
                <th>קוד מוצר</th>
                <th>שם מוצר</th>
                <th>מחיר</th>
                <th>תמונה</th>
                <th>ניהול</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RptProds" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("Pid") %></td>
                        <td><%#Eval("Pname") %></td>
                        <td><%#Eval("Price") %></td>
                        <td>
                            <img src="/uploads/prods/img/<%#Eval("Picname") %>" class="avatar-img rounded-circle" width="40" />
                        </td>
                        <td>
                            <button class="btn btn-sm dropdown-toggle more-horizontal" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="text-muted sr-only">ניהול</span>
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a class="dropdown-item" href="ProductAddEdit.aspx?Pid=<%#Eval("Pid") %>">עריכה</a>
                                <a class="dropdown-item" href="#">הסרה</a>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
    <script src='js/jquery.dataTables.min.js'></script>
    <script src='js/dataTables.bootstrap4.min.js'></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>