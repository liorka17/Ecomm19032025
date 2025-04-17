<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecomm19032025.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="he" dir="rtl">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>התחברות</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

    <style>
        body {
            background: #f3f6fc;
            font-family: 'Segoe UI', sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
        }

        .login-card {
            background: #ffffff;
            border-radius: 20px;
            padding: 40px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.08);
            width: 100%;
            max-width: 420px;
        }

        .login-card h2 {
            color: #333;
            font-weight: 600;
            margin-bottom: 24px;
        }

        .form-control {
            border-radius: 12px;
            background-color: #f9fbfe;
            border: 1px solid #dce3ed;
            color: #333;
        }

        .form-control:focus {
            border-color: #6cc4ff;
            box-shadow: 0 0 0 0.2rem rgba(108, 196, 255, 0.25);
        }

        .btn-primary {
            background-color: #6cc4ff;
            border: none;
            border-radius: 12px;
            font-weight: bold;
        }

        .btn-primary:hover {
            background-color: #57b4f5;
        }

        .links a {
            color: #007bff;
            text-decoration: none;
            font-size: 0.9rem;
        }

        .links a:hover {
            text-decoration: underline;
        }

        .logo-img {
            width: 80px;
            margin-bottom: 16px;
        }

        .text-danger {
            font-size: 0.9rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateForm();">
        <div class="login-card text-center">
            <img src="https://cdn-icons-png.flaticon.com/512/263/263142.png" class="logo-img" alt="Logo" />
            <h2>ברוך הבא</h2>

            <div class="mb-3 text-end">
                <asp:TextBox ID="TextEmail" runat="server" TextMode="Email" CssClass="form-control text-end" placeholder="אימייל"></asp:TextBox>
            </div>
            <div class="mb-3 text-end">
                <asp:TextBox ID="TextUser" runat="server" CssClass="form-control text-end" placeholder="שם משתמש"></asp:TextBox>
            </div>
            <div class="mb-3 text-end">
                <asp:TextBox ID="TextPass" runat="server" TextMode="Password" CssClass="form-control text-end" placeholder="סיסמה"></asp:TextBox>
            </div>

            <asp:Button ID="BtnLogin" runat="server" Text="התחבר" CssClass="btn btn-primary w-100 mb-3" OnClick="BtnLogin_Click" />

            <div class="text-danger mb-2">
                <asp:Literal ID="LtlMsg" runat="server" EnableViewState="false" Mode="PassThrough"></asp:Literal>
            </div>

            <div class="links">
                <a href="forgotpassword.aspx">שכחת סיסמה?</a> |
                <a href="register.aspx">הירשם עכשיו</a>
            </div>
        </div>
    </form>

    <script>
        function validateForm() {
            var email = document.getElementById('<%= TextEmail.ClientID %>').value.trim();
            var user = document.getElementById('<%= TextUser.ClientID %>').value.trim();
            var pass = document.getElementById('<%= TextPass.ClientID %>').value.trim();

            if (email === "" || user === "" || pass === "") {
                alert("אנא מלא את כל השדות");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
