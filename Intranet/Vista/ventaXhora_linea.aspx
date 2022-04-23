<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="ventaXhora_linea.aspx.cs" Inherits="Intranet.Vista.ventaXhora_linea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Ventas/Hora por linea</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
    <form runat="server" method="post">
       
        <div class="box box-warning box-solid " runat="server" id="notificacion">
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
              <label id="txtnotifica" runat="server">Recuerde verificar la lista de SMS enviados</label>
            </font></font>
                    </div>
                    <!-- /.box-body -->
                </div>
        <section class="content">
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title"><b>Ventas por Hora - Linea </b></h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Linea:</span>
                                <select runat="server" id="selectLinea" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>

                            </div>

                        </div>

                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Bodega:</span>
                                <select runat="server" id="selectBodega" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>

                            </div>

                        </div>


                    </div>
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Fecha:</span>
                                <input type="date" runat="server" id="txtfecha" name="name" value="" class="form-control" style="width: 100%;" />

                            </div>

                        </div>
                    </div>
                    <div class="col-md-4" id="boton">

                        <div class="box">

                            <div class="box-body">
                                <div class="btn-group">

                                    <asp:LinkButton ID="Btnconsulta" runat="server" Text="Listar Activos" CssClass="btn btn-app" OnClick="btnconsulta">
                                    <i aria-hidden="true"  class="fa fa-search"></i>Consultar
                                    </asp:LinkButton>


                                </div>
                                <div class="btn-group">
                                    <a href='javascript:window.print(); void 0;' class="btn btn-app">
                                        <i aria-hidden="true" class=" fa fa-print"></i>Imprimir
                                    </a>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <h3 class="box-title"><b>Salas de Ventas</b></h3>
                    </h3>
                    <div class="box-tools pull-right"><button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                    </div>
                </div>
                <!-- Date dd/mm/yyyy -->
                <div class="box-body">
                    <div class="col-md-12">
                      
                             <asp:GridView ID="GridViewsupermio" runat="server" GridLines="None"
                            CssClass="gvuser table table-striped table-bordered text-sm"
                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                        </asp:GridView>
                        
                       
                       
                    </div>
                
                </div>

            </div>
        </section>
    </form>
        </div>
         </section>
    <script type="text/javascript">
        function esconde_div() {
            var elemento = document.getElementById("Nuevomodelo");
            elemento.style.display = 'none';
        }

        function visible_div() {
            var elemento = document.getElementById("Nuevomodelo");
            elemento.style.display = 'block';
        }

        $('#btnProcesar').on('click', function () {

        });

        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');

                    return "No hay resultados - Clic en Nuevo"

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
