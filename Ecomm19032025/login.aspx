<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecomm19032025.login" %>
<!-- עמוד התחברות - מקושר לקובץ קוד בשם login.aspx.cs -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<!-- מסמך HTML עם כיוון כתיבה ימין לשמאל לעברית -->
<head runat="server">
    <title>התחברות</title>
    <!-- כותרת הדף -->

    <meta charset="utf-8" />
    <!-- קידוד UTF-8 לטקסט תקין בעברית -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- התאמה לכל מכשיר (רספונסיביות) -->

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- עיצוב מותאם לטפסים -->
    <style>
        .form-icon {
            position: absolute; /* ממקם את האייקון בתוך השדה */
            left: 10px;
            top: 50%;
            transform: translateY(-50%);
            color: #6c757d; /* צבע אפור בהיר */
        }
        .position-relative input {
            padding-left: 2.5rem !important; /* מרווח לשדה עבור האייקון */
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server" onsubmit="return validateForm();">
        <!-- טופס ASP.NET עם פונקציית JS לאימות -->

        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6 col-lg-4">
                    <div class="card shadow p-4 text-center">
                        <!-- קופסת טופס עם הצללה ועיצוב נעים -->

                        <!-- לוגו חדש עם אייקון של חנות אונליין -->
                        <div class="mb-4">
                            <img src="https://cdn-icons-png.flaticon.com/512/263/263142.png" alt="Online Store Logo" class="img-fluid rounded-circle shadow-sm" style="width: 100px;" />
                            <!-- לוגו עגול של חנות אונליין -->
                        </div>

                        <!-- כותרת -->
                        <h4 class="mb-4">התחברות</h4>

                        <!-- שדה אימייל -->
                        <div class="mb-3 text-end position-relative">
                            <i class="bi bi-envelope form-icon"></i>
                            <asp:TextBox ID="TextEmail" runat="server" TextMode="Email" CssClass="form-control text-end" placeholder="אימייל"></asp:TextBox>
                        </div>

                        <!-- שדה שם משתמש -->
                        <div class="mb-3 text-end position-relative">
                            <i class="bi bi-person form-icon"></i>
                            <asp:TextBox ID="TextUser" runat="server" CssClass="form-control text-end" placeholder="שם משתמש"></asp:TextBox>
                        </div>

                        <!-- שדה סיסמה -->
                        <div class="mb-3 text-end position-relative">
                            <i class="bi bi-lock form-icon"></i>
                            <asp:TextBox ID="TextPass" runat="server" TextMode="Password" CssClass="form-control text-end" placeholder="סיסמה"></asp:TextBox>
                        </div>

                        <!-- כפתור התחברות -->
                        <div class="d-grid mb-3">
                            <asp:Button ID="BtnLogin" runat="server" Text="התחבר" OnClick="BtnLogin_Click" CssClass="btn btn-primary" />
                        </div>

                        <!-- תצוגת הודעות שגיאה מהשרת -->
                        <div class="text-danger mb-3">
                            <asp:Literal ID="LtlMsg" runat="server"></asp:Literal>
                        </div>

                        <!-- קישורים נוספים -->
                        <div class="text-center">
                            <a href="forgotpassword.aspx">שכחת סיסמה?</a> |
                            <a href="register.aspx">עדיין אין לך משתמש? הירשם עכשיו</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap Icons -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <!-- JavaScript לאימות טופס -->
    <script>
        function validateForm() {
            // שליפת הערכים מהשדות
            var email = document.getElementById('<%= TextEmail.ClientID %>').value.trim();
            var user = document.getElementById('<%= TextUser.ClientID %>').value.trim();
            var pass = document.getElementById('<%= TextPass.ClientID %>').value.trim();

            // בדיקה אם שדה ריק
            if (email === "" || user === "" || pass === "") {
                alert("אנא מלא את כל השדות");
                return false; // עצירת שליחה
            }

            return true; // טופס תקין
        }
    </script>
</body>
</html>
