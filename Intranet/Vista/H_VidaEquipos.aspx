<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="H_VidaEquipos.aspx.cs" Inherits="Intranet.Vista.H_VidaEquipos" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />--%>
     <section class="content">
         <div class="container bootstrap snippet"> 
    <form runat="server" method="post">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
       
        <section class="content">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-default">
                <div class="box-header with-border">
                    <label class="box-title">Hoja de Vida de Activos</label>
               

                    <div class="box-tools pull-right">
                        <a href="1.aspx" class="fa fa-home"></a>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>


                    </div>

                </div>
                <!-- /.box-header -->
                <div class="box-body">
                     <div class="form-group" >
                    <label class="col-md-2 col-form-label">Serial</label>
                        <div class="input-group col-md-10">
                             <input type="text" name="name" class="form-control" id="Select2" runat="server" placeholder="Ingrese serial" value="" />
                            <span class="input-group-btn">
                                <asp:LinkButton ID="botonbusca" runat="server" Text="Buscar" OnClick="buscararticulo" class="btn btn-social-icon">
                                             <i class="fa fa-search-plus"></i>
                                </asp:LinkButton>
                            </span>



                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group has-feedback">
                                <input type="text" runat="server" class="form-control" placeholder="Serial" id="Select1" name="name" value="" />
                               
                                <span class="fa fa-list-alt form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <input id="txtnombre" runat="server" type="text" class="form-control" placeholder="Nombre" disabled="">

                                <span class="glyphicon glyphicon-user form-control-feedback"></span>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group has-feedback">
                                <textarea id="TextArea1" runat="server" style="width: 100%;" placeholder="Comentarios" rows="4" disabled=""></textarea>
                            </div>

                            <!-- /.form-group -->
                        </div>
                        <!-- /.col modelo, fabricante y categoria -->
                        <div class="col-md-4">
                            <div class="form-group has-feedback">

                                <input type="text" runat="server" id="txtmodelo" placeholder="Modelo" class="form-control" name="name" value="" disabled="" />
                                <span class="fa fa-cubes form-control-feedback"></span>
                            </div>

                            <div class="form-group has-feedback">
                                <input type="text" id="txtfabricante" runat="server" placeholder="Fabricante" disabled="" class="form-control" name="name" value="" />
                                <span class="fa fa-industry form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <input type="text" id="txtcategoria" runat="server" placeholder="Categoria" disabled="" name="name" class="form-control" value="" />
                                <span class="fa fa-spinner form-control-feedback"></span>
                            </div>
                            <div class="for-group has-feedback">
                                <table class="auto-style5">

                                    <td class="auto-style4">
                                        <div class="btn-group" id="botonera">
                                            <button type="button" class="btn btn-success">Opciones</button>
                                            <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                                <span class="caret"></span>
                                                <span class="sr-only"></span>
                                            </button>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                                <li class="divider"></li>
                                                <li>
                                                    <a href='javascript:window.print(); void 0;'>
                                                        <span aria-hidden="true" class="disabled fa fa-print">Imprimir</span>
                                                </li>



                                            </ul>

                                        </div>
                                    </td>
                                </table>
                            </div>
                            <!-- /.form-group -->

                            <!-- /.form-group -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-4">
                            <div class="form-group has-feedback">
                                <input type="text" id="txtproveedor" runat="server" placeholder="Proveedor" name="name" class="form-control" value="" disabled="" />
                                <span class="fa fa-users form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <input id="txtfechacompra" runat="server" type="text" placeholder="Fecha de Compra" class="form-control" disabled="">
                                <span class="glyphicon glyphicon-calendar form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <input id="txtvalor" type="text" runat="server" class="form-control" placeholder="Valor Compra" disabled="">
                                <span class="fa fa-dollar form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">

                                <input id="txtgarantia" type="text" runat="server" class="form-control" placeholder="Tiempo garantia (Meses) " disabled="">
                                <span class="fa fa-calendar form-control-feedback"></span>

                            </div>
                            <!-- /.form-group -->
                        </div>
                    </div>
                    <!-- /.row -->
                </div>

            </div>
            <!-- /.box -->

            <div class="row">
                <div class="col-md-12">

                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title">Mantenimientos</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>


                            </div>
                        </div>
                        <div class="box-body">
                            <!-- Date dd/mm/yyyy -->
                            <div>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridViewmantenimientos" runat="server" GridLines="None"
                                        CssClass=" table gvuser table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>
                                </div>


                            </div>


                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->

                    <!-- /.box -->

                </div>
                <!-- /.col (left) -->
                <div class="col-md-12">
                    <!-- /.box -->

                    <!-- iCheck -->
                    <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">Repuestos Utilizados</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>


                            </div>
                        </div>
                        <div class="box-body">
                            <!-- Minimal style -->

                            <!-- checkbox -->
                            <div>

                                <asp:GridView ID="GridViewrepuestos" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>

                            </div>


                        </div>
                        <!-- /.box-body -->

                    </div>
                    <!-- /.box -->
                </div>
                <div class="col-md-12">
                    <!-- /.box -->

                    <!-- iCheck -->
                    <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">Historial de Asignaciones</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <!-- Minimal style -->

                            <!-- checkbox -->
                            <div>

                                <asp:GridView ID="GridViewhistoria" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>

                            </div>


                        </div>
                        <!-- /.box-body -->

                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col (right) -->
                


            </div>
            <!-- /.row -->
</ContentTemplate>

                    </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
                <ProgressTemplate>
                    <div id="backgroud">

                    </div>
                    <div id="Progress">
                        <h6>
                            <p style="text-align:center"><b>Procesando, Espere por favor...</b></p>
                        </h6>
                    </div>
                    
                </ProgressTemplate>
            </asp:UpdateProgress>
        </section>
    </form>
             </div>
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
