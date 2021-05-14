<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PLANTILLA1.aspx.cs" Inherits="Intranet.Vista.reportes.PLANTILLA1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title>Lcsystem's</title>
    <link href="../../bower_components/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link rel="apple-touch-icon" href="http://www.supermio.co/wp-content/uploads/2017/06/2.jpg"/>
    <link rel="shortcut icon" href="../2a.PNG" type="image/PNG" />
    <script src="https://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="../../bower_components/select2/dist/js/select2.min.js"></script>
    <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../bower_components/font-awesome/css/font-awesome.min.css">
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

    <style type="text/css">
        *, *::after, *::before {
            margin: 0;
            padding: 0;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }
        .botonesx{border-radius:5%;
            -webkit-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.84);
-moz-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.84);
box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.84);
        }
        #contenedor_carga {
            background-color: rgba(254,240,245,0.9);
            height: 100%;
            width: 100%;
            position: fixed;
            -moz-transition: all 1s ease;
            -o-transition: all 1s ease;
            -webkit-transition: all 1s ease;
            transition: all 1s ease;
            z-index:10000;
        }
        #carga {
            border: 15px solid #ccc;
            border-top-color: #f4266a;
            border-top-style: groove;
            height: 100px;
            width: 100px;
            border-radius: 100%;
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            margin: auto;
          -webkit-animation: girar 1.5s linear infinite;
            -o-animation: girar 1.5s linear infinite;
           animation: girar 1.5s linear infinite;
        }
        @keyframes girar{
            from{
                transform:rotate(0deg);
            }
            to{
                transform:rotate(360deg);
            }
        }
     
        .fondoblanco {
            margin-right: 2px;
            background: #CCD1D1;
            border:solid;
        }

        .menuabierto {
            display: block;
        }
  
            </style>
    
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.0/css/buttons.dataTables.min.css" />



    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" />
    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/buttons.dataTables.min.css" />


   
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>



    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
    <style type="text/css">
       #contenedor_carga
        .small-box h3 {
            font-size: 30px;
            font-weight: bold;
            margin: 0 0 10px 0;
            white-space: nowrap;
            padding: 0;
            margin-bottom: 10px;
        }

        #logosimbolo {
            display: none;
        }

        #div_datosempresa {
            display: none;
        }

        @media print {
            /* Contenido del fichero print.css */
            .c{
                display:none;
            }
            
            p {
                margin-bottom: 0px;
                font-weight: bold;
            }
            #div_numerodeacta{
                font-weight:bold;
         
                 top: 5px;
                left: 50px;
            }
            #div_datosempresa {
                display: inline;
            }

            #div_detalles {
                top: 50px;
            }

            #botonera {
                display: none;
            }

            #insert {
                display: none;
            }

            #botonInsertar {
                display: none;
            }

            ButtonField {
                display: none;
            }

            input {
                border: 0px;
            }

            .margin {
                height: 70px;
                width: 100%;
                text-align: center;
            }

            #div_nombredocumento {
                position: absolute;
                width: 100%;
                font-size: 30px;
                font-weight: bold;
                top: 5px;
                left: 5px;
            }

            #div_tercero {
                position: absolute;
                width: 100%;
                font-size: 20px;
                font-weight: bold;
                top: 5px;
            }

            #div_ubicacion {
                position: absolute;
                width: 100%;
                font-size: 20px;
                font-weight: bold;
                top: 5px;
                left: 5%;
            }
            body{
                overflow-y:hidden;
            }

            #div_area {
                position: absolute;
                width: 100%;
                font-size: 18px;
                top: 5px;
                left: 5%;
            }

            #logosimbolo {
                position: absolute;
                top: 0px;
                left: 25px;
                display: inline;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box"> 
            <h1>Barrido de Precios</h1>
            <input type="text" name="codigo" id="codigo" runat="server" placeholder="Nombre - incluir Fecha" value="" />
            <asp:Button Text="Crear Barrido" id="btn_crearbarrido" runat="server" OnClick="btn_crearbarrido_Click" />
        </div>
        <div class="modal modal-warning fade in" id="tablero" style="display: block;" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                        <h4 class="modal-title">
                            <label runat="server" id="Nombre_barrido"></label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <p>Detalles Articulo</p>
                        <div class="form-group">
                            <div class="input-group">
                                <input type="text" name="name" class="form-control" value="" runat="server" id="lector" placeholder="codigo" />
                        <button type="submit" name="consulta" value="" runat="server"  id="btnconsulta">Ir...</button>
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
                                    OnClientClick="if(!confirm('Confirm?')) return false;" />
                    
                            </div>
                               
                        </div>
                        
                        <input id="txtdetalle" runat="server" type="text" class="form-control" placeholder="Detalle" disabled/>
                        <input id="txtbarcode" runat="server" type="text" class="form-control" placeholder="Codigo de barras" disabled/>
                        <input id="txtprecio" runat="server" type="text" class="form-control" placeholder="Precio" disabled/>
                        <input id="txtpeso" runat="server" type="number" class="form-control" placeholder="Peso" disabled/>
                        <input id="txtPLU" runat="server" type="text" class="form-control" placeholder="P.L.U" disabled />
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button10" runat="server" class="btn btn-outline" Text="Guardar" />

                        <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar e Imprimir"/>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
        </div>
        <div>
          
        </div>
               <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
