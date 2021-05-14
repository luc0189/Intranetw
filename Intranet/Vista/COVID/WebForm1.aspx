<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Intranet.Vista.COVID.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro-lcs</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="LCSystem">
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
                        <a href="exitwebform.aspx" onclick="btncierra">Lectura </a>
                    </li>

                    <li class="breadcrumb-item active">Registro</li>
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
                                            <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Principal</font></font></div>
                                            <div class="form-group ">


                                                <input id="txtcc" runat="server" type="number" class="form-control" placeholder="No Documento de Indentidad" required="required"/>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="txtname1" runat="server" type="text" class="form-control" placeholder="Nombres" required="required"/>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="txtcelular" runat="server" type="number" class="form-control" placeholder="Telefono" required="required"/>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <select id="Select" runat="server" class="js-example-basic-single form-control" required="required">
                                                    <option></option>
                                                    <option value="C">Cliente</option>
                                                    <option value="E">Empleado</option>
                                                    <option value="P">Proveedor</option>
                                                </select>
                                            </div>
                                            <div style="display: flex; justify-content: center; align-content: center;">
                                                 <strong>  <label>* Firmando acepta el uso y tratamiento de datos personales segun ley 1581 de 2012 </label></strong>
                                            </div>
                                            
                                            <div style="display: flex; justify-content: center; align-content: center;" class="card">
                                               
                                              
                                                <canvas id="lienzo" runat="server" width="460" height="220"></canvas>
                                                <div id="Encabezado" class="tools" style="display: flex; justify-content: center; align-content: center;" runat="server">
                                                    <a href="#lienzo" data-tool="marker" class="btn btn-success">Firmar</a> <a href="#lienzo" data-tool="eraser" class="btn btn-danger">Limpiar</a>
                                                </div>
                                                <script src="js/Fima2.js"></script>
                                                <script src="js/Firma.min.js"></script>
                                                <script type="text/javascript">
                                                    $(function () {
                                                        $('#lienzo').sketch();
                                                        $(".tools a").eq(0).attr("style", "color:#000");
                                                        $(".tools a").click(function () {
                                                            $(".tools a").removeAttr("style");
                                                            $(this).attr("style", "color:#000");
                                                        });
                                                    });
                                                    function SaveSketch() {
                                                        var dataUri = $("#lienzo")[0].toDataURL();
                                                        $("#ruta").val(dataUri);
                                                        //console.log(dataUri);
                                                        //alert("");
                                                        //window.close();
                                                    };
                                                </script>
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card-footer">
                            <div class="form-group has-feedback">
                                <div class="btn-group">

                                    <asp:Button ID="btnGuardar" Text="Guardar" runat="server" OnClientClick="SaveSketch()" OnClick="btnguardanuevo_Click" />
                                  
                                   
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

<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>


<script src="vendor/jquery-easing/jquery.easing.min.js"></script>
<script src="vendor/fontawesome-free/js/all.js"></script>
<!-- Custom scripts for all pages-->
<script src="js/sb-admin.min.js"></script>
</html>
