<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="permisosLcs.aspx.cs" Inherits="Intranet.Vista.Sistema.permisosLcs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Permisos</title>
    </head>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <section class="content">
    <div class="container bootstrap snippet">
        <section class="content-header">
            <h1>Gestion Inventario
        <small>Panel Principal</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Menu.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active"><a href="Menu.aspx">Inventario</a></li>
                <li class="active">Gestion de Inventario</li>
            </ol>
        </section>
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
                
                <h1 class="box-title"><b>Permisos</b></h1>
            </div>
            <div class="box-body">
                <div class="col-md-8">
                    <div class="box">
                            <div class="box-header">
                             
                                <div class="box-body">
                                    <div class="input-group">
                                <span class="input-group-addon">Rol:</span>
                       
                                        <select class="form-control" id="Selectrol" runat="server"></select>
                                        <asp:LinkButton Text="Consulta" runat="server" OnClick="Click"/>
                             </div>
                                    <div class="input-group">
                                <span class="input-group-addon">Asignar:</span>
                       
                                        <select class="form-control" id="Selectmenuid" runat="server" >
 
                                            </select>
                             </div>
                                    <label>gridpermisos</label>
                                    <asp:Button Text="Insertar" runat="server" ID="btnconsulta" OnClick="agregarow" />
                                     <div class="table-responsive">
                                    <asp:GridView ID="Gridviewpermisos" runat="server"  GridLines="None" OnRowDeleting="OnRowDeleting"
                                    CssClass="gvuser table table-striped dysplay"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                   <Columns>
                                      
                            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                      </Columns>
                                   
                                </asp:GridView>
                                         </div>
                                    <div class="table-responsive">
                                        <label>gridmenu</label>
                                    <asp:GridView ID="Gridviewmenus" runat="server"  GridLines="None"
                                    CssClass="gvuser table table-striped dysplay"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                  
                                   
                                </asp:GridView>
                                         </div>
                                </div>
                            </div>
                        </div>

                </div>
                <div class="col-md-4">
                    <div class="box">
                            <div class="box-header">
                                
                                <div class="box-body">
                                

                                    <div class="btn-group">
                                        <asp:LinkButton Text="Guardar" runat="server" id="guardar" OnClick="btnconsulta_Click"/>
                                            <i aria-hidden="true" class="fa fa-home"></i>Guardar
                                        
                                    </div>
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
        
    </form>  
        </div>
    </section>
   
    <script type="text/javascript">
         $(document).ready(function () {
            $('.js-example-basic-single').select2();
        });
        $('#btnProcesar').on('click', function () {

        });
         $(document).ready(function () {
            $('#gvuser').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });



        });
        $(document).ready(function () {
            GridGeneral();
        });

      
        var GridGeneral2 = function () {
            $(".Content2").prepend($("<thead></thead>").append($(".Content2").find("tr:first"))).dataTable({
                "language": lenguaje_espanol,
                "dom": "Bfrtip",
                "buttons": botoneraExport,
                responsive: true
            });
        }

        // variables comunes

        var lenguaje_espanol = {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados <a>Agregar Nuevo</a> ",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }

        var botoneraExport =
            [
                {
                    extend: 'copy',
                    className: 'copyButton',
                    text: '<i class="fa fa-clone"></i> Copiar'
                },
                {
                    extend: 'excel',
                    text: '<i class="fa fa-file-excel-o"></i> Excel'
                },
                {
                    extend: 'csv',
                    text: '<i class="fa fa-file-excel-o"></i> CSV'
                },
                {
                    extend: 'print',
                    text: '<i class="fa fa-print"></i> Imprimir',
                    customize: function (win) {
                        $(win.document.body)
                            .css('font-size', '10pt')
                            .prepend(
                            '<img src="../../dist/img/ws.png" style="position:absolute; top:0; left:1;" />'

                            );

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ]
       
        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');

                    return "No hay resultados"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });
        var lenguaje_espanol = {
            "sProcessing": "Procesando...",
        }


    </script>
     
</asp:Content>
