<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecomm19032025.AdminManage.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>לוח ניהול</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap + Icons -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <style>
        body {
            background-color: #f3f6fc;
            font-family: 'Segoe UI', sans-serif;
            color: #212529;
        }

        .navbar-light {
            background: linear-gradient(to right, #e0f1ff, #ffffff);
            border-bottom: 1px solid #dee2e6;
        }

        .navbar-brand {
            font-weight: bold;
            font-size: 1.3rem;
            color: #0d6efd;
        }

        .card-glass {
            background: #ffffff;
            border-radius: 16px;
            padding: 24px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
            border: 1px solid #e3e7ed;
        }

        .icon {
            font-size: 2.5rem;
            margin-bottom: 10px;
        }

        h5 {
            font-weight: 600;
        }

        .lead {
            font-size: 1.4rem;
            color: #495057;
        }

        .btn-glow {
            background-color: #6cc4ff;
            color: white;
            font-weight: bold;
            border-radius: 10px;
            transition: 0.3s ease;
            border: none;
        }

        .btn-glow:hover {
            background-color: #57b4f5;
            box-shadow: 0 0 12px rgba(87, 180, 245, 0.4);
        }

        .form-control {
            background-color: #fff;
            border: 1px solid #ced4da;
            border-radius: 10px;
            color: #212529;
        }

        .form-control:focus {
            border-color: #6cc4ff;
            box-shadow: 0 0 0 0.2rem rgba(108, 196, 255, 0.25);
        }

        .modal-content {
            background-color: #ffffff;
            border-radius: 16px;
            border: 1px solid #e3e7ed;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <!-- תפריט עליון -->
        <nav class="navbar navbar-expand-lg navbar-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">מנהל ראשי</a>
                <div class="d-flex align-items-center">
                    <asp:Literal ID="LtUser" runat="server"></asp:Literal>
                    <button type="button" class="btn btn-outline-primary ms-3" data-bs-toggle="modal" data-bs-target="#editModal">
                        <i class="bi bi-pencil-square"></i> ערוך פרטים
                    </button>
                </div>
            </div>
        </nav>

        <!-- תוכן הדשבורד -->
        <div class="container py-5">
            <div class="row g-4 text-center">
                <div class="col-md-4">
                    <div class="card card-glass">
                        <i class="bi bi-people-fill icon text-primary"></i>
                        <h5>משתמשים</h5>
                        <p class="lead">124</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-glass">
                        <i class="bi bi-box-fill icon text-success"></i>
                        <h5>מוצרים</h5>
                        <p class="lead">87</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-glass">
                        <i class="bi bi-cart-check-fill icon text-warning"></i>
                        <h5>הזמנות</h5>
                        <p class="lead">45</p>
                    </div>
                </div>
            </div>

            <!-- גרפים -->
            <div class="row mt-5 g-4">
                <div class="col-md-6">
                    <div class="card card-glass">
                        <h5 class="mb-3">סטטוס הזמנות</h5>
                        <canvas id="pieChart"></canvas>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-glass">
                        <h5 class="mb-3">מכירות חודשיות</h5>
                        <canvas id="barChart"></canvas>
                    </div>
                </div>
            </div>

            <!-- הודעות -->
            <div class="row mt-5">
                <div class="col-12 text-center">
                    <asp:Literal ID="LtMsg" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

        <!-- מודל עריכת פרטי מנהל -->
        <div class="modal fade" id="editModal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content p-4">
                    <div class="modal-header border-0">
                        <h5 class="modal-title">עריכת פרטי מנהל</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
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

    <!-- סקריפטים -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <script>
        const ctxPie = document.getElementById('pieChart');
        const ctxBar = document.getElementById('barChart');

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
                    legend: { position: 'bottom' }
                }
            }
        });

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
                        beginAtZero: true
                    }
                }
            }
        });
    </script>
</body>
</html>
