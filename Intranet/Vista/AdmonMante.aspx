<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="AdmonMante.aspx.cs" Inherits="Intranet.Vista.AdmonMante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" method="post">
        <div class="box-default">
            <div class="fondoblanco">
                <ul class="sidebar-menu" style="display: block;" data-widget="tree">
                    <li class="treeview menu-open" style="display: block;">
                        <a href="admin2" runat="server" hreflang="#"><i class="fa fa-plus-circle"></i>
                            <span>Gestion Mantenimiento</span>
                        </a>
                        <ul class="treeview-menu" id="ulnovedad" runat="server">
                            <li class="treeview">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">
                                            <h3 class="box-title"><b>Ordenes de trabajo</b></h3>
                                        </h3>

                                    </div>
                                    <!-- Date dd/mm/yyyy -->
                                    <div class="box-body">
                                        <div class="col-md-4">
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">Ubicacion</span>
                                                    <select runat="server" id="Selectubicacion" class="js-example-basic-single" name="state" required style="width: 100%">
                                                    </select>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="LinkButton11" runat="server" Text="Nuevo" class="btn btn-success btn-flat">+</asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">Area</span>
                                                    <select runat="server" id="Selectarea" class="js-example-basic-single" name="state" required style="width: 100%">
                                                    </select>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Nuevo" class="btn btn-success btn-flat">+</asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">TipoM.</span>
                                                    <select runat="server" id="Selecttipo" class="js-example-basic-single" name="state" style="width: 100%" required>
                                                    </select>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Nuevo" class="btn btn-success btn-flat">+</asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">


                                            <textarea placeholder="Descripcion" class="form-control" runat="server" dir="auto" rows="5" id="txtDescripcion" required title="P"></textarea>

                                        </div>

                                        <div class="col-md-4">
                                            <div class="box">
                                                <div class="box-header">
                                                    Menu
                                <div class="box-body">
                                    <div class="btn-group">

                                        <asp:LinkButton ID="btnNuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnNuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                                        </asp:LinkButton>

                                    </div>

                                    <div class="btn-group">

                                        <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardar_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                        </asp:LinkButton>

                                    </div>
                                    <div class="btn-group">
                                        <a href="1.aspx" class="btn btn-app">
                                            <i aria-hidden="true" class="fa fa-home"></i>Inicio
                                        </a>
                                    </div>

                                </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                            CssClass=" table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>

                                    </div>
                                </div>

                            </li>
                        </ul>
                    </li>
                </ul>
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview">
                        <a href="admin2" runat="server" hreflang="#"><i class="fa fa-plus-circle"></i>
                            <span>Lista Mantenimiento Pendiente</span>
                        </a>
                        <ul class="treeview-menu" id="ul1" runat="server">
                            <li class="treeview">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">
                                            <h3 class="box-title"><b>Pendientes</b></h3>
                                          </h3>
                                        <div class="box-tools pull-right">
                                                <asp:LinkButton ID="btnbuscarpendientes" runat="server" Text="Volver" class="form-control" OnClick="btnbuscarpendientes_Click">
                                                    <i aria-hidden="true"  class="fa fa-search"></i>
                                                </asp:LinkButton>
                                            </div>

                                    </div>
                                    <!-- Date dd/mm/yyyy -->
                                    <div class="box-body">

                                        <asp:GridView ID="GridViewpendientes" runat="server" GridLines="None"
                                            CssClass="gvuser table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>

                                    </div>

                                </div>

                            </li>
                        </ul>

                    </li>
                </ul>
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview">
                        <a href="admin2" runat="server" hreflang="#"><i class="fa fa-plus-circle"></i>
                            <span>Lista Mantenimiento Asignados</span>
                        </a>
                        <ul class="treeview-menu" id="ul2" runat="server">
                            <li class="treeview">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">
                                            <h3 class="box-title"><b>Asignados</b></h3>
                                        </h3>

                                    </div>
                                    <!-- Date dd/mm/yyyy -->
                                    <div class="box-body">

                                        <asp:GridView ID="GridViewasignados" runat="server" GridLines="None"
                                            CssClass=" table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>

                                    </div>

                                </div>

                            </li>
                        </ul>

                    </li>
                </ul>
            </div>
        </div>

    </form>
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
