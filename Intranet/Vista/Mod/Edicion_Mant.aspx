<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edicion_Mant.aspx.cs" Inherits="Intranet.Vista.Mod.Edicion_Mant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title>Editar Actas de Mantenimiento</title>

    <link href="../../bower_components/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link rel="apple-touch-icon" href="http://www.supermio.co/wp-content/uploads/2017/06/2.jpg" />
    <link rel="shortcut icon" href="../../2a.PNG" type="image/PNG" />
    <script src="https://code.jquery.com/jquery-1.9.1.js"></script>
    
    <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->

    <link rel="stylesheet" href="../../dist/css/AdminLTE.css" />
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css" />
    <!-- Morris chart -->
    <link rel="stylesheet" href="../../bower_components/morris.js/morris.css" />
    <!-- jvectormap -->
    <link rel="stylesheet" href="../../bower_components/jvectormap/jquery-jvectormap.css" />
    <!-- Date Picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-daterangepicker/daterangepicker.css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" />


    <!-- select2 -->


    <!-- AdminLTE Skins. We have chosen the skin-blue for this starter
        page. However, you can choose any other skin. Make sure you
        apply the skin class to the body tag so the changes take effect. -->
    <!-- data tabless -->
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.0/css/buttons.dataTables.min.css" />



    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" />
    <link rel="stylesheet" href="../../bower_components/datatables.net-bs/css/buttons.dataTables.min.css" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <!-- Google Font -->


    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
    <style type="text/css">
        body {
            background-color: #fff;
        }
    </style>
</head>
<script type="text/javascript">

    function alerta(campos) {
        alert('este es el contenido-> ' + campos);
    }

</script>

<body>
    <form id="form1" runat="server">

        <section class="content">
            <div class="content">

                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Acta No</h3>
                        <input type="text" name="name" id="txtidacta" value="" runat="server" disabled="disabled" />
                         <div class="btn-group">
                             <asp:LinkButton ID="btnnuevo" runat="server" Text="Volver" class="btn btn-default" OnClick="Nuevo">
                                    <span aria-hidden="true"  class="fa fa-plus-circle">Nuevo</span>
                                        </asp:LinkButton>
                             <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-success" OnClick="btnguardar_Click"  >
                                    <span aria-hidden="true"  class="fa fa-save">Guardar</span>
                                        </asp:LinkButton>
                         </div>
                        
                        <div class="btn-group">
                        <asp:LinkButton ID="btneditar" runat="server" Text="Volver" class="btn btn-success" OnClick="editar">
                                    <span aria-hidden="true"  class="fa fa-edit">Editar</span>
                                        </asp:LinkButton>
                        <asp:LinkButton ID="btnactualizar" runat="server" class="btn btn-success" Text="Insertar" OnClick="GridViewdetalle_RowUpdating">
                                     <span aria-hidden="true" class="fa  fa-save">Modificar</span>
                                        </asp:LinkButton>
                            <asp:LinkButton ID="btncancelar" runat="server" Text="Volver" class="btn btn-default" OnClick="cancela_modifica">
                                    <span aria-hidden="true"  class="fa fa-stop">Cancelar</span>
                                        </asp:LinkButton>
                            </div>
                        <asp:LinkButton ID="btnborra" runat="server" class="btn btn-danger" Text="Insertar" OnClick="borra">
                                     <span aria-hidden="true" class="fa  fa-recycle">Borra Fila</span>
                                        </asp:LinkButton>

                        <div class="box-tools pull-right">
                            <asp:LinkButton ID="btnvolver" runat="server" Text="Volver" class="btn btn-success" OnClick="salir">
                                    <span aria-hidden="true"  class="fa fa-arrow-left"></span>
                                        </asp:LinkButton>
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                        
                        </div>
                    </div>
                    <div class="box-footer">
                       
                            <div class="col-md-4">
                                <!-- /articulo a mantenimiento-->

                                <div class="form-group has-feedback">
                                    <input runat="server" id="txtidart" type="text" style="width: 12%" />
                                   <select runat="server" id="Selectarticulo" class="js-example-basic-single" name="state" style="width: 85%">
                                    </select>
                                </div>
                                
                                <div class="form-group has-feedback">
                                    <select runat="server" id="SelecttipoMant" class="js-example-basic-single" name="state" style="width: 100%">
                                        <option value="P">Preventivo</option>
                                        <option value="C">Correctivo</option>
                                    </select>
                                </div>
                                <div class="form-group has-feedback">
                                    <input id="txtRepuestos" runat="server" type="text" placeholder="Repuestos Utilizados" class="form-control" />
                                </div>
                               
                            </div>
                            <div class="col-md-4">
                                <!-- /tipo de mantenimiento-->
                                <div class="form-group has-feedback">

                                    <input id="valorManObra" runat="server" type="number" placeholder="Valor Mano de Obra" value="0" class="form-control" />
                                    <span aria-hidden="true" class="fa fa-hand-stop-o form-control-feedback"></span>
                                </div>
                                
                                <div class="form-group has-feedback">
                                    <input id="Textnumeroexterno" runat="server" type="text" placeholder="Numero Externo"  />
                                    <input type="number" id="timegarantia" runat="server" name="name" value="" placeholder="Garantia" />
                                </div>
                                <div class="form-group has-feedback">
                                    <input id="V_repuestos" runat="server" type="text" placeholder="Valor Respuestos" value="0" class="form-control" />
                                    <span aria-hidden="true" class="fa fa-shopping-cart form-control-feedback"></span>
                                </div>

                            </div>
                            <div class="col-md-4">
                                 <div class="form-group has-feedback">
                                    <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Comentarios" rows="6" ></textarea>
                                </div>
                               
                                        
                                </div>
                             
                       
                    </div>
                </div>
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Detalles</h3>
                            <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                        </div>
                    </div>
                    <div class="box-footer">
                         <div class="box-body">

                                <div>

                                    <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None" class="display compact"
                                        CssClass="gvuser table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" />

                                        </Columns>

                                    </asp:GridView>

                                </div>
                            </div>
                    </div>
                </div>

               
              
                <label id="txtahora" runat="server"></label>
                <div class="modal modal-warning fade in" id="Aviso" style="display: block;" runat="server">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="box-tools pull-right">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Volver" class="btn btn-success" OnClick="salir">
                                    <span aria-hidden="true"  class="fa fa-arrow-left"></span>
                                        </asp:LinkButton>
                            
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                        </div>
                                <h4 class="modal-title">Borrar Fila</h4>
                            </div>
                            <div class="modal-body">
                                <p>Esta seguro de Eliminar la Fila de Datos</p>
                                
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button10" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenu" />

                                <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar" OnClick="borraitems_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                </div>
          
        </section>
    </form>

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
    <script src="../../bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/buttons.html5.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/buttons.print.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.buttons.flash.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/dataTables.buttons.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/jszip.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/pdfmake.min.js"></script>
    <script src="../../bower_components/datatables.net-bs/js/vfs_fonts.js"></script>
    <script src="../../bower_components/select2/dist/js/select2.min.js"></script>
    <script src="dist/js/demo.js"></script>
   <script>


        $('#btnProcesar').on('click', function () {

        });

        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');
                    btnProcesar.hidden = false;
                    return "No hay resultados - agregar Nuevo ->"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });


       
    </script>
</body>
</html>
