<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lectura.aspx.cs" Inherits="Intranet.Vista.COVID.Lectura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro-Uno</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content="LCSystem"/>
    <link href="css/sb-admin.css" rel="stylesheet" />
    <link href="vendor/fontawesome-free/css/all.css" rel="stylesheet" />
    <style type="text/css">
        /* Chart.js */
        @keyframes chartjs-render-animation {
            from {
                opacity: .99
            }

            to {
                opacity: 1
            }
        }

        .chartjs-render-monitor {
            animation: chartjs-render-animation 1ms
        }

        .chartjs-size-monitor, .chartjs-size-monitor-expand, .chartjs-size-monitor-shrink {
            position: absolute;
            direction: ltr;
            left: 0;
            top: 0;
            right: 0;
            bottom: 0;
            overflow: hidden;
            pointer-events: none;
            visibility: hidden;
            z-index: -1
        }

            .chartjs-size-monitor-expand > div {
                position: absolute;
                width: 1000000px;
                height: 1000000px;
                left: 0;
                top: 0
            }

            .chartjs-size-monitor-shrink > div {
                position: absolute;
                width: 200%;
                height: 200%;
                left: 0;
                top: 0
            }
    </style>
    <link type="text/css" rel="stylesheet" href="https://translate.googleapis.com/translate_static/css/translateelement.css"/>
</head>
<body>
     <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

        <a class="navbar-brand mr-1" href="#">Registro</a>

        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle">
            <i class="fas fa-bars"></i>
        </button>

        <ul class="navbar-nav ml-auto ml-md-0">
            <li class="nav-item dropdown no-arrow mx-1">
                <a class="nav-link dropdown-toggle" href="#" id="alertsDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fas fa-bell fa-fw"></i>
                    <span class="badge badge-danger">9+</span>
                </a>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="alertsDropdown">
                    <a class="dropdown-item" href="#">Action</a>
                    <a class="dropdown-item" href="#">Another action</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#">Something else here</a>
                </div>
            </li>
            <%--  <li class="nav-item dropdown no-arrow mx-1">
        <a class="nav-link dropdown-toggle" href="#" id="messagesDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <i class="fas fa-envelope fa-fw"></i>
          <span class="badge badge-danger">7</span>
        </a>
        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="messagesDropdown">
          <a class="dropdown-item" href="#">Action</a>
          <a class="dropdown-item" href="#">Another action</a>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" href="#">Something else here</a>
        </div>
      </li>--%>
            <li class="nav-item dropdown no-arrow">
                <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fas fa-user-circle fa-fw"></i>
                </a>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">
                    <a class="dropdown-item" href="../1.aspx">Volver</a>
                    <a class="dropdown-item" href="#">Log</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">Salir</a>
                </div>
            </li>
        </ul>

    </nav>
    <div id="wrapper">
        <div id="content-wrapper">
            <!-- Sidebar -->

            <div class="container-fluid">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a href="exit.aspx">Seleccionar Area</a>
                    </li>

                    <li class="breadcrumb-item active">Registro</li>
                    <li class="breadcrumb-item active">
                        <label id="area" runat="server"></label>
                    </li>
                </ol>
                <form id="form1" runat="server">
                    <div class="alert alert-warning alert-dismissible" id="notificacion" runat="server">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">×</font></font></button>
                        <h5><i class="icon fa fa-check"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> ¡Notificacion!</font></font></h5>
                        <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                <label runat="server" id="alertant">aqui</label></font></font>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h3>Registro</h3>
                            <strong><label id="txtnombre" runat="server"></label></strong>
                            
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-xl-12 col-sm-12 mb-12">
                                    <div class="card text-white bg-primary o-hidden h-100">
                                        <div class="card-body">
                                            <div class="card-body-icon">
                                                <i class="fas fa-fw fa-user"></i>
                                            </div>
                                            <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Principal</font></font>
                                                <label id="txtid" runat="server"></label>
                                            </div>
                                            <div class="form-group ">


                                                <input id="txtcc" runat="server" type="number" class="form-control" placeholder="No Documento de Indentidad" required="required"/>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="datoin" runat="server" type="text" class="form-control" placeholder="Dato in" />
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="datoout" runat="server" type="text<" class="form-control" placeholder="Dato Out" />
                                            </div>
                                           
                                            <div style="display: flex; justify-content: center; align-content: center;" class="card">
                                            
                                              
                                                                                           
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card-footer">
                            <div class="form-group has-feedback">
                                <div class="btn-group">

                                    <asp:Button ID="btnGuardar" Text="Consultar" runat="server" OnClick="btnGuardar_Click" />
                                     <asp:Button ID="btnGuardaRegistro" Text="Guardar" runat="server" OnClick="btnGuardaRegistro_Click" />
                                     <asp:Button ID="btnGuardaRegistro2" Text="Guardar" runat="server" OnClick="btnGuardaRegistro2_Click" />
                                </div>

                            </div>
                        </div>

                    </div>
                                  <input type="text" id="ruta" runat="server" name="name" style="display:none;" />
                </form>

            </div>
        </div>
    </div>
</body>
  <script type="text/javascript">

    $(document).ready(function () {
        setTimeout(function () {
            $("#notificacion").fadeOut(6000);
        }, 3000);
    });
</script>
<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="js/Fima2.js"></script>
                                                <script src="js/Firma.min.js"></script>
<script src="vendor/jquery-easing/jquery.easing.min.js"></script>
<script src="vendor/fontawesome-free/js/all.js"></script>
<!-- Custom scripts for all pages-->
<script src="js/sb-admin.min.js"></script>
</html>
