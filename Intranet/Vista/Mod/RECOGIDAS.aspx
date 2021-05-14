<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RECOGIDAS.aspx.cs" Inherits="Intranet.Vista.Mod.RECOGIDAS" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
         <div class="margin">
            <div class="box-header">

                <table class="auto-style5">
                    <tr>
                        <td class="auto-style4">
                            <div class="btn-group" id="botonera">
                                <button type="button" class="btn btn-success">Opciones</button>
                                <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                    <span class="caret"></span>
                                    <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                <ul class="dropdown-menu" role="menu">
                                    <!-- /ir a inicio-->
                                    <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                    <li>
                                        <asp:LinkButton ID="btnNuevo" runat="server" Text="Nuevo" >
                                        <span aria-hidden="true" class="fa fa-magic"> Nuevo</span>
                                        </asp:LinkButton></li>
                                    <li>
                                        <a href='javascript:window.print(); void 0;'>
                                            <span aria-hidden="true" class="disabled fa fa-print">Imprimir</span>
                                        </a></li>
                                    <li class="divider"></li>
                                    <li>
                                        <asp:LinkButton ID="guardar" runat="server" Text="Insertar" >
                                         <span aria-hidden="true" class="fa  fa-hdd-o"> Guardar Mantenimiento</span>
                                        </asp:LinkButton>

                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" >
                                         <span aria-hidden="true" class="fa  fa-user-circle">Nuevo Tercero</span>
                                        </asp:LinkButton>

                                    </li>
                                </ul>

                            </div>
                        </td>

                        <td class="auto-style4">
                            <div id="div_nombredocumento">
                                <h3 class="box-title"><b>Acta de Mantenimiento</b></h3>
                            </div>
                        </td>
                        <td style="width: 20px;"></td>
                        <td class="auto-style3">
                            <div id="div_numerodeacta">
                               <b>Acta No. </b>
                                <input id="txtidacta" runat="server" type="text" name="name" value="" />
                               <asp:LinkButton ID="LinkButton1" runat="server" Text="Nuevo"  >
                                         <span aria-hidden="true" class="fa  fa-user-circle">Buscar</span>
                                        </asp:LinkButton>
                            
                            </div>

                        </td>

                        <td style="width: 20px;"></td>


                    </tr>
                </table>
            </div>


        </div>

        <div class="box-body">
            <div class="row">
                <div class="col-md-4">

                    <!-- /realizado por-->
                    <div class="form-group-sm has-feedback">
                        <select runat="server" id="Select1" class="js-example-basic-single-sm" name="state" style="width: 100%">
                        </select>
                    </div>

                </div>
                <div class="col-md-5">
                    <!-- /OBSERVACION GENERAL -->
                    <div class="form-group ">

                        <input id="OBSERVACIONG" runat="server" type="text" placeholder="OBSERVACION GENERAL" class="form-control" />
                    </div>
                </div>
                <div class="col-md-3">
                    <!-- /FECHA DEL MANTENIMIENTO -->
                    <div>
                        <input id="FECHAMANT" runat="server" type="date" class="form-control" />
                    </div>
                </div>
            </div>
        </div>
        <div class="box-footer">
            <div class="row" id="insert">
                <div class="col-md-4">
                    <!-- /articulo a mantenimiento-->
                    <div class="form-group has-feedback">
                        <select runat="server" id="Selectarticulo" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                    </div>
                </div>
                <div class="col-md-3">
                    <!-- /tipo de mantenimiento-->
                    <div class="form-group has-feedback">
                        <select runat="server" id="SelecttipoMant" class="js-example-basic-single" name="state" style="width: 100%">
                            <option value="P">Preventivo</option>
                            <option value="C">Correctivo</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-5">
                    <!-- /detalle del mantenimiento-->
                    <div class="form-group ">
                        <input id="txtobserva" runat="server" type="text" placeholder="Descripcion del Mantenimiento" class="form-control" />
                    </div>
                </div>

                <div class="col-xs-12">
                    <!-- /Valor mano de obra-->
                    <div class="col-md-3">
                        <div class="form-group has-feedback">

                            <input id="valorManObra" runat="server" type="number" placeholder="Valor Mano de Obra" value="0" class="form-control" />
                            <span aria-hidden="true" class="fa fa-hand-stop-o form-control-feedback"> </span>
                        </div>
                    </div>
                    <!-- /Repuestos utilizados-->
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <input id="txtRepuestos" runat="server" type="text" placeholder="Repuestos Utilizados" class="form-control" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group has-feedback">
                            <input id="Textnumeroexterno" runat="server" type="text" placeholder="Numero Externo" class="form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <!-- /valor repuestos-->
                        <div class="form-group has-feedback">
                            <input id="V_repuestos" runat="server" type="text" placeholder="Valor Respuestos" value="0" class="form-control" />
                            <span aria-hidden="true" class="fa fa-shopping-cart form-control-feedback"> </span>
                        </div>
                    </div>
                </div>
            </div>
         </div>
            <div class="box-header" id="div_detalles">
                <h3 class="box-title">Detalles</h3>
                <div class="col-xs-3" id="botonInsertar">

                    <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-primary" >
                <span aria-hidden="true" class="fa  fa-hand-o-down"> Insertar</span>
                    </asp:LinkButton>

                </div>
            </div>
   <div class="row">
    
       <div class="col-xs-12">
                    <div class="box">

                        <!-- /.box-header -->
                        <div class="box-body">

                            <div>
                               
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->

                </div>

            </div>




        <label id="txtahora" runat="server"></label>
        <div class="modal modal-warning fade in" id="Nuevotercero" style="display: block;" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                        <h4 class="modal-title">Nuevo tercero</h4>
                    </div>
                    <div class="modal-body">
                        <p>Detalles Tercero</p>
                        <input id="txtccoNit" runat="server" type="text" class="form-control" placeholder="Cedula o Nit">
                        <input id="txtNomb" runat="server" type="text" class="form-control" placeholder="Nombre o Razon Social">
                        <input id="txtdir" runat="server" type="text" class="form-control" placeholder="Direccion">
                        <input id="txttel" runat="server" type="number" class="form-control" placeholder="Telefono">
                        <input id="txtCiudad" runat="server" type="text" class="form-control" placeholder="Ciudad- Ingrese el #1 ">
                        <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="Correo Electronico">
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button10" runat="server" class="btn btn-outline" Text="Cancelar"  />

                        <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

     <script src="../../bower_components/jquery/dist/jquery.min.js"></script>
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
    <script src="../../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../../bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/adminlte.min.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../../dist/js/pages/dashboard.js"></script>
    <!-- DataTables -->
    <script src="../bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/buttons.html5.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/buttons.print.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/dataTables.buttons.flash.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/dataTables.buttons.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/jszip.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/pdfmake.min.js"></script>
    <script src="../bower_components/datatables.net-bs/js/vfs_fonts.js"></script>

    <script src="dist/js/demo.js"></script>


         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
         <a href="Report1.rdlc">Report1.rdlc</a></form>

     
</body>
</html>
