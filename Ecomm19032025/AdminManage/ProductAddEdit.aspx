<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductAddEdit.aspx.cs" Inherits="Ecomm19032025.AdminManage.ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h2 class="page-title">עריכת מוצרים</h2>
    <p class="text-muted">נא להזין את פרטי המוצר המבוקש ולבצע שמירה</p>
    <div class="card-deck">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">פרטי המוצר</strong>
            </div>
            <div class="card-body">

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="TxtPname">שם המוצר</label>
                        <asp:TextBox ID="TxtPname" runat="server" class="form-control" placeholder="יש להזין שם מוצר" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="TxtPrice">מחיר</label>
                        <asp:TextBox ID="TxtPrice" runat="server" class="form-control" placeholder="יש להזין מחיר מוצר" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="TxtPicname">תמונת המוצר</label>
                        <asp:HiddenField ID="HidPid" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtPicname" runat="server" class="form-control" placeholder="יש להזין שם תמונת מוצר" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="TxtPicname"> בחר קטגוריה</label>
                        <asp:DropDownList ID="DDLCategory" runat="server" class="form-control" placeholder="בחר קטגוריה" />

                    </div>
                    <div class="form-group col-md-6">
                        <label for="TxtPdesc">תאור</label>
                        <asp:TextBox ID="TxtPdesc" runat="server" class="form-control" TextMode="MultiLine" Columns="40" Rows="10" placeholder="יש להזין תאור" />
                    </div>
                </div>

                <asp:Button ID="BtnSave" Text="שמור" runat="server" class="btn btn-primary" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>
