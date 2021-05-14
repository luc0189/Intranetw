<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Acta_entrega.aspx.cs" Inherits="Intranet.Vista.Acta_entrega" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 16px;
            text-align: right;
        }

        .auto-style3 {
            height: 16px;
            width: 180px;
        }

        .auto-style4 {
            height: 16px;
            width: 250px;
        }

        .auto-style5 {
            width: 99%
        }

        @media screen and (min-width: 575px) {
            .modalprint {
                width: 80%;
            }
        }

        @media screen and (min-width: 999px) {
            .modalprint {
                width: 825px;
            }

        }
    </style>

    <!-- data tabless -->
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.0/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="margin">
                    <div class="box-header">
                         <b>ACTA DE ENTREGA</b>
                        <div class="box-tools">
                             <table >
                            <tr>
                                <td class="auto-style4">
                                    <div class="btn-group" id="botonera">
                                        <button type="button" class="btn btn-dark">Opciones</button>
                                        <button type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown">
                                            <span class="caret"></span>
                                            <span class="sr-only"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>

                                            <li>
                                                <asp:LinkButton ID="btnNuevo" runat="server" Text="Nuevo" OnClick="nuevonumeroacta">
                                        <span aria-hidden="true" class="fa fa-magic"> Nuevo</span>
                                                </asp:LinkButton></li>

                                            <li>

                                                <asp:LinkButton ID="btnimprime" runat="server" Text="Insertar" OnClick="btnimprime_Click">
                                             <span aria-hidden="true" class="fa  fa-hdd-o"> Imprimir</span>
                                                </asp:LinkButton></li>
                                            <li class="divider"></li>
                                            <li>
                                                <asp:LinkButton ID="guardar" runat="server" Text="Insertar" OnClick="Button3_Click">
                                             <span aria-hidden="true" class="fa  fa-hdd-o"> Guardar acta</span>
                                                </asp:LinkButton></li>
                                            <li class="divider"></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" OnClick="mostrarmenutercero">
                                         <span aria-hidden="true" class="fa  fa-user-circle">Nuevo Usuario</span>
                                                </asp:LinkButton>

                                            </li>
                                        </ul>

                                    </div>
                                </td>
                                
                            </tr>
                        </table>
                        </div>
                        
                    </div>


                </div>

                <div class="modal modal-warning fade in " id="Imprime" style="display: block;" runat="server">
                    <div class="modal-dialog modalprint " runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" OnClick="btncerrarimprime_Click">
                                             <span aria-hidden="true" class="fa fa-close"></span>
                                </asp:LinkButton>
                                <h4 class="modal-title">Imprimir</h4>
                            </div>
                            <div class="modal-body">

                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Style="" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
                                    <LocalReport ReportPath="Vista\actas.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>

                                <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" style="margin-top: 88" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
            <localreport reportpath="Vista\actas.rdlc">
            </localreport>
        </rsweb:ReportViewer>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box">
                      <div class="box-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group has-feedback" id="div_tercero">
                                <div class="input-group">
                                    <span class="input-group-addon">Empleado:</span>
                                    <select runat="server" id="Select1" class="js-example-basic-single" name="state" style="width: 100%">
                                    </select>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group has-feedback" id="div_ubicacion">
                                <div class="input-group">
                                    <span class="input-group-addon">Ubic:</span>
                                    <select runat="server" id="Selectubicacion" class="js-example-basic-single" name="state" style="width: 100%">
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group has-feedback" id="div_area">
                                <div class="input-group">
                                    <span class="input-group-addon">Area:</span>
                                    <select runat="server" id="Selectarea" class="js-example-basic-single" name="state" style="width: 100%">
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
              
                <div class="box">
                    <div class="box-body">

                        <div class="row" id="insert">
                            <div class="col-md-12">

                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon">Articulo:</span>
                                        <select runat="server" id="Selectarticulo" class="js-example-basic-single" name="state" style="width: 100%">
                                        </select>
                                    </div>
                                </div>
                                
                            </div>

                            <div class="col-md-12">
                                <div class="form-group has-feedback">
                                    <textarea id="observatxt" runat="server" style="width: 100%" placeholder="Observaciones" class="form-control" onkeyup="javascript:ComprobarCasilla(this);" rows="3"></textarea>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
           
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="box">
                                        <div class="box-header">
                                            <h3 class="box-title"><b>Detalles</b></h3>
                                            <div class="box-tools">
                                                 <div id="div_numerodeacta">
                                                    <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-dark" OnClick="agregarow">
                                                    <i aria-hidden="true"  class="fa fa-hand-o-down"></i>Insertar
                                                    </asp:LinkButton>
                                                    <b>Acta No. </b>
                                                    <input id="txtidacta" runat="server" type="text" name="name" value="" />
                                                </div>
                                            </div>

                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">



                                            <asp:GridView ID="GridViewdetalle" runat="server" OnRowDeleting="OnRowDeleting" GridLines="None"
                                                CssClass="gvuser table table-striped dysplay"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                <Columns>

                                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                                </Columns>

                                            </asp:GridView>



                                        </div>
                                        <!-- /.box-body -->
                                    </div>
                                    <!-- /.box -->



                                </div>

                            </div>
                                </ContentTemplate>

                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <div id="backgroud">
                                    </div>
                                    <div id="Progress">
                                        <h6>
                                            <p style="text-align: center"><b>Procesando, Espere por favor...</b></p>
                                        </h6>
                                    </div>

                                </ProgressTemplate>
                            </asp:UpdateProgress>

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
                                            <asp:Button ID="Button10" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenutercero" />

                                            <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaTercero_Click" />

                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <div class="modal modal-warning fade in" id="panelubicacion" style="display: block;" runat="server">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                            <h4 class="modal-title">Ubicaciones</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Nueva Ubicacion</p>
                                            <input id="txtUbicacion" runat="server" type="text" class="form-control" placeholder="Nombre de la Ubicacion">
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btncancelaubicacion" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancelaubicacion_Click" />

                                            <asp:Button ID="btncreaubicacion" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btncreaubicacion_Click" />

                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <div class="modal modal-warning fade in" id="panelarea" style="display: block;" runat="server">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                            <h4 class="modal-title">Nuevo</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Nueva Area</p>
                                            <div class="form-group has-feedback">
                                                <select runat="server" id="selectubicacion_nuevaarea" class="js-example-basic-single" name="state" style="width: 100%">
                                                </select>
                                            </div>
                                            <input id="txtArea" runat="server" type="text" class="form-control" placeholder="Area">
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btncancelapanelarea" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancelapanelarea_Click" />

                                            <asp:Button ID="btncreaArea" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btncreaArea_Click" />

                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
            </form>
        </div>
    </section>
    <script type="text/javascript">

        function ComprobarAcentos(inputtext) {
            if (!inputtext) return false;
            if (inputtext.value.match('[á,é,í,ó,ú]|[Á,É,Í,Ó,Ú]')) {
                alert('No se permiten acentos en la casilla');
                inputtext.value = '';
                inputtext.focus();
                return true;
            }
            return false;
        }

    </script>
    <script>
        $(document).ready(function () {
            $('#gvusersd').DataTable({

            });

            $(document).ready(function () {
                var table = $('.gvusersd').DataTable();


            });

    </script>
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

</asp:Content>
