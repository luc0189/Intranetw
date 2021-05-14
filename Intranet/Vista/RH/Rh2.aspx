<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Rh2.aspx.cs" Inherits="Intranet.Vista.RH.Rh2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            position: relative;
            border-radius: 3px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
            left: 0px;
            top: 40px;
            height: 291px;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            background: #ffffff;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <link rel="stylesheet" href="../../dist/css/AdminLTE.css">
   <link href="../../bower_components/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link rel="apple-touch-icon" href="http://www.supermio.co/wp-content/uploads/2017/06/2.jpg">
    <link rel="shortcut icon" href="../../2a.PNG" type="image/PNG" />
    <script src="https://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="../../bower_components/select2/dist/js/select2.min.js"></script>
    <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->

    <link rel="stylesheet" href="../../dist/css/AdminLTE.css">
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">
    <!-- Morris chart -->
    <link rel="stylesheet" href="../../bower_components/morris.js/morris.css">
    <!-- jvectormap -->
    <link rel="stylesheet" href="../../bower_components/jvectormap/jquery-jvectormap.css">
    <!-- Date Picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-daterangepicker/daterangepicker.css">
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.0/css/buttons.dataTables.min.css" />




    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" />
    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/buttons.dataTables.min.css" />
        <div class="box box-warning box-solid notifica" runat="server" id="excepcion">
        <div class="box-header with-border">
            <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excp Controlada</font></font></h3>

            <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="error" runat="server"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div>
    <div class="box box-success box-solid notifica" runat="server" id="notificacion">
        <div class="box-header with-border">
            <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Notificacion</font></font></h3>

            <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="txtnotifica" runat="server"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div>
    <form id="form1" runat="server">
          
        <div class="box">
            <div class="box-header with-border">
                
                <h1 class="box-title"><b>Reporte Asistencia</b></h1>
            </div>
            <div class="box-body">
                <div class="col-md-9">
                    <div class="auto-style1">
                            <div class="box-header">
                                Lista
                                <div class="box-body">
                                    <input type="date" name="name" id="fechaini" runat="server" value="" />
                                    <input type="date" name="name" id="fechafin" runat="server" value="" />
                                    <asp:Button Text="Consultar" runat="server" ID="btnconsulta" OnClick="btnconsulta_Click"/>
                                     <div class="table-responsive">
                                    <asp:GridView runat="server" ID="Gridviewasistencia" GridLines="None"
                                    CssClass="gvuser table table-striped dysplay"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">

                </asp:GridView>
                                         </div>
                                    
                                </div>
                            </div>
                        </div>

                </div>
                <div class="col-md-3">
                    <div class="box">
                            <div class="box-header">
                                Menu
                                <div class="box-body">
                                

                                    <div class="btn-group">
                                        <a href="../1.aspx" class="btn btn-app">
                                            <i aria-hidden="true" class="fa fa-home"></i>Inicio
                                        </a>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>

                </div>
                 
                
            </div>
        </div>
        
    </form>    <script src="../../bower_components/jquery/dist/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="../../bower_components/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script src="../../bower_components/raphael/raphael.min.js"></script>
    <script src="../../bower_components/morris.js/morris.min.js"></script>
    <script src="../../bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/plug-ins/1.10.16/api/sum().js"></script>
    <script src="../../plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../../plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="../../bower_components/jquery-knob/dist/jquery.knob.min.js"></script>
    <!-- daterangepicker -->
    <script src="../../bower_components/moment/min/moment.min.js"></script>
    <script src="../../bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- datepicker -->
    <script src="../../bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../../bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/adminlte.min.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../../dist/js/pages/dashboard.js"></script>
    <!-- DataTables -->
    <script src="../../bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/buttons.html5.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/buttons.print.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.buttons.flash.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.buttons.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/jszip.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/pdfmake.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/vfs_fonts.js"></script>

</asp:Content>
