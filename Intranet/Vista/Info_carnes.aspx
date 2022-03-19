<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Info_carnes.aspx.cs" Inherits="Intranet.Vista.Info_carnes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">
                <div class="margin">
                    <div class="box-header with-border">

                        <table class="auto-style5">
                            <tr>
                                <td class="auto-style4">
                                    <div class="btn-group" id="botonera">
                                        <button type="button" class="btn btn-success">Opciones</button>
                                        <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                            <span class="caret"></span>
                                            <span class="sr-only"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>

                                            <li>
                                                <a href='javascript:window.print(); void 0;'>
                                                    <span aria-hidden="true" class="disabled fa fa-print">Imprimir</span>
                                                </a></li>

                                        </ul>

                                    </div>
                                </td>
                                <td style="width: 20px"></td>
                                <td class="auto-style4">
                                    <h3 class="box-title"><b>Comparativo de ventas</b></h3>
                                </td>


                            </tr>
                        </table>
                    </div>


                </div>
                <div class="col-md-3 ">

                    <select id="selectgrupo" runat="server" class="js-example-basic-single sm" style="width: 100%">
                        <option value="00000356">CERDO</option>
                        <option value="360">CARNE DE RES </option>
                        <option value="00000357">POLLO</option>
                        <option value="00000351">MAC-POLLO</option>
                        <option value="329">PECES Y MAR</option>
                    </select>
                </div>
                <div class="col-md-3 ">

                    <select id="selectSucursal" runat="server" class="js-example-basic-single sm" style="width: 100%">
                        <option value="SUPERMIO LA 16">SUPERMIO LA 16</option>
                        <option value="SUPERMIO LA 13">SUPERMIO LA 13</option>
                        <option value="SUPERMIO VERSALLES">SUPERMIO VERSALLES</option>
                        <option value="SUPERMIO CIUDADELA">SUPERMIO CIUDADELA</option>

                    </select>
                </div>
                <div class="col-md-3 ">

                    <input runat="server" id="txtfechaini" type="date" class="form-control input-sm" label="Fecha inicio">
                </div>

                <div class="col-md-3 input-group input-group-sm ">

                    <input runat="server" id="txtfechafin" type="date" class="form-control">
                    <span class="input-group-btn">
                        <asp:LinkButton ID="activos" runat="server" Text="Listar Datos" class="btn btn-info btn-flat-sm"
                            OnClick="Buscararticulo">
                        </asp:LinkButton></span>
                </div>

                <section class="content">

                    <div class="col-md-12">
                        <!-- MAP & BOX PANE -->
                        <div class="box box-success">
                            <div class="box-header with-border">
                                <h3 class="box-title">Reportes Bnet Empresarial</h3>

                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <div class="box">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridViewBnet" runat="server" GridLines="None"
                                            CssClass="gvuser1 table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>
                                    </div>
                                </div>








                                <!-- /.row -->


                                <!-- /.box -->

                            </div>

                        </div>

                    </div>

                    <div class="col-md-12">
                        <div class="box box-success">
                            <div class="box-header with-border">
                                <h3 class="box-title">Reportes Basculas</h3>

                                <div class="box-tools pull-right">
                                   <asp:LinkButton ID="LinkButton1" runat="server" Text="Listar Datos" class="btn btn-info btn-flat-sm"
                            OnClick="BuscaBasculas">
                        </asp:LinkButton>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">

                                <div class="box">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridViewBasculas" runat="server" GridLines="None"
                                            CssClass="gvuser1 table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>
                                    </div>
                                </div>


                               
                                <!-- /.row -->


                                <!-- /.box -->

                            </div>

                        </div>
                    </div>
                </section>



                <!-- MAP & BOX PANE -->






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
