<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecomm19032025.AdminManage.Default" %>
<!-- הגדרת עמוד ASP.NET עם קובץ קוד מאחוריו -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<!-- HTML רגיל עם כיוון ימין לשמאל לעברית -->
<head runat="server">
    <title>לוח ניהול - בוס</title>
    <!-- כותרת העמוד בדפדפן -->

    <meta charset="utf-8" />
    <!-- תמיכה בעברית ועברית תקינה -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- התאמה למסכים רספונסיביים (מובייל וכו') -->

    <!-- קישורי עיצוב וספריות חיצוניות -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->

    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <!-- ספריית Chart.js לציור גרפים -->

    <!-- עיצוב מותאם אישית -->
    <style>
        body {
            background-color: #f8f9fa; /* רקע בהיר */
            color: #212529; /* טקסט כהה */
            font-family: 'Segoe UI', sans-serif; /* גופן מודרני */
        }

        .navbar-light {
            background: linear-gradient(90deg, #e3f2fd, #ffffff); /* גרדיאנט בהיר */
        }

        .card-glass {
            background: #ffffff; /* רקע לבן לכרטיסים */
            border: 1px solid #dee2e6; /* מסגרת אפורה בהירה */
            border-radius: 12px; /* פינות מעוגלות */
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05); /* צל עדין */
        }

        .icon {
            font-size: 2.5rem; /* גודל האייקון */
            margin-bottom: 10px; /* רווח מתחת לאייקון */
        }

        .btn-glow {
            background-color: #0d6efd; /* כחול Bootstrap */
            color: white;
            font-weight: bold;
            border: none;
            transition: all 0.3s ease; /* מעבר רך בהובר */
        }

        .btn-glow:hover {
            background-color: #0b5ed7;
            box-shadow: 0 0 10px rgba(13, 110, 253, 0.5); /* אפקט זוהר */
        }

        .modal-content {
            background-color: #ffffff;
            color: #212529;
            border-radius: 12px;
            border: 1px solid #dee2e6;
        }

        .form-control {
            background-color: #fff;
            border: 1px solid #ced4da;
            color: #212529;
        }

        .form-control:focus {
            border-color: #0d6efd;
            box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.25);
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <!-- טופס ASP.NET -->

        <!-- תפריט עליון -->
        <nav class="navbar navbar-expand-lg navbar-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">מנהל ראשי</a>
                <!-- שם המערכת -->

                <div class="d-flex align-items-center">
                    <asp:Literal ID="LtUser" runat="server"></asp:Literal>
                    <!-- שם המשתמש המחובר -->

                    <!-- כפתור לפתיחת חלון עריכת פרטים -->
                    <button type="button" class="btn btn-outline-primary ms-3" data-bs-toggle="modal" data-bs-target="#editModal">
                        <i class="bi bi-pencil-square"></i> ערוך פרטים
                    </button>
                </div>
            </div>
        </nav>

        <!-- תוכן הדשבורד -->
        <div class="container py-5">
            <div class="row g-4 text-center">
                <!-- כרטיס מידע: משתמשים -->
                <div class="col-md-4">
                    <div class="card card-glass p-4">
                        <i class="bi bi-people-fill icon text-primary"></i>
                        <h5>משתמשים</h5>
                        <p class="lead">124</p>
                    </div>
                </div>

                <!-- כרטיס מידע: מוצרים -->
                <div class="col-md-4">
                    <div class="card card-glass p-4">
                        <i class="bi bi-box-fill icon text-success"></i>
                        <h5>מוצרים</h5>
                        <p class="lead">87</p>
                    </div>
                </div>

                <!-- כרטיס מידע: הזמנות -->
                <div class="col-md-4">
                    <div class="card card-glass p-4">
                        <i class="bi bi-cart-check-fill icon text-warning"></i>
                        <h5>הזמנות</h5>
                        <p class="lead">45</p>
                    </div>
                </div>
            </div>

            <!-- גרפים -->
            <div class="row mt-5 g-4">
                <!-- גרף פאי - סטטוס הזמנות -->
                <div class="col-md-6">
                    <div class="card card-glass p-4">
                        <h5 class="mb-3">סטטוס הזמנות</h5>
                        <canvas id="pieChart"></canvas>
                    </div>
                </div>

                <!-- גרף עמודות - מכירות חודשיות -->
                <div class="col-md-6">
                    <div class="card card-glass p-4">
                        <h5 class="mb-3">מכירות חודשיות</h5>
                        <canvas id="barChart"></canvas>
                    </div>
                </div>
            </div>

            <!-- הודעות מהשרת -->
            <div class="row mt-5">
                <div class="col-12 text-center">
                    <asp:Literal ID="LtMsg" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

        <!-- חלונית מודל לעריכת פרטי מנהל -->
        <div class="modal fade" id="editModal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content p-4">
                    <div class="modal-header border-0">
                        <h5 class="modal-title">עריכת פרטי מנהל</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <!-- שדות טופס -->
                        <div class="mb-3 text-end">
                            <label>שם מלא</label>
                            <input type="text" class="form-control" placeholder="הכנס שם" />
                        </div>
                        <div class="mb-3 text-end">
                            <label>אימייל</label>
                            <input type="email" class="form-control" placeholder="הכנס אימייל" />
                        </div>
                        <div class="mb-3 text-end">
                            <label>סיסמה</label>
                            <input type="password" class="form-control" placeholder="********" />
                        </div>
                    </div>
                    <div class="modal-footer border-0 justify-content-end">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">ביטול</button>
                        <button type="button" class="btn btn-glow">שמור</button>
                    </div>
                </div>
            </div>
        </div>

    </form>

    <!-- סקריפטים חיצוניים -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Bootstrap JS כולל Popper -->

    <!-- הגדרת הגרפים -->
    <script>
        const ctxPie = document.getElementById('pieChart');
        const ctxBar = document.getElementById('barChart');

        // גרף עוגה - סטטוס הזמנות
        new Chart(ctxPie, {
            type: 'pie',
            data: {
                labels: ['הושלמה', 'בתהליך', 'בוטלה'],
                datasets: [{
                    data: [25, 15, 5],
                    backgroundColor: ['#0dcaf0', '#ffc107', '#dc3545']
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { position: 'bottom' } // מיקום מקרא
                }
            }
        });

        // גרף עמודות - מכירות חודשיות
        new Chart(ctxBar, {
            type: 'bar',
            data: {
                labels: ['ינו׳', 'פבר׳', 'מרץ', 'אפר׳', 'מאי'],
                datasets: [{
                    label: '₪ מכירות',
                    data: [3000, 4500, 3200, 5000, 4200],
                    backgroundColor: '#0d6efd'
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true // ציר Y מתחיל מ-0
                    }
                }
            }
        });
    </script>
</body>
</html>
