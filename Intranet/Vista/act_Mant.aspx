<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="act_Mant.aspx.cs" Inherits="Intranet.Vista.act_Mant" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
        
        <div class="margin">
            <div class="box-header">

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
                                    <!-- /ir a inicio-->
                                    <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                    <li>
                                        <asp:LinkButton ID="btnNuevo" runat="server" Text="Nuevo" OnClick="nuevonumeroacta">
                                        <span aria-hidden="true" class="fa fa-magic"> Nuevo</span>
                                        </asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton7" runat="server" Text="Nuevo" OnClick="LinkButton7_Click">
                                        <span aria-hidden="true" class="fa fa-magic"> imprime</span>
                                        </asp:LinkButton></li>
                                    <li class="divider"></li>
                                    <li>
                                        <asp:LinkButton ID="guardar" runat="server" Text="Insertar" OnClick="Guardar">
                                         <span aria-hidden="true" class="fa  fa-hdd-o"> Guardar Mantenimiento</span>
                                        </asp:LinkButton>

                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" OnClick="mostrarmenutercero">
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
                            </div>

                        </td>


                    </tr>
                </table>
            </div>


        </div>
        <div class="box-body">

            <div class="row">
                <div class="col-md-4">

                    <!-- /realizado por-->
                    <div class="form-group-sm has-feedback">
                        <select runat="server" id="SelectProveedor" class="js-example-basic-single" name="state" style="width: 100%">
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
        <div class="box" id="insert">
            <div class="box-body">
                <div class="col-md-4">

                    <!-- /clases mante-->
                    <div class="box">
                        <!-- <div class="box-header">
             <h3 class="box-title">Trabajos</h3>
            </div>-->
                        <div class="box-body">



                            <div class="input-group ">
                                <div class="input-group-btn">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                        Seleccione
                    <span class="fa fa-caret-down"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Text="Elect." CssClass="btn btn-primary"  OnClick="btnselectelectrico_Click">
                                <span aria-hidden="true" class="fa fa-bolt">Electrico</span>
                                            </asp:LinkButton>
                                        </li>
                                        <li><asp:LinkButton ID="LinkButton1" runat="server" Text="Elect." CssClass="btn btn-primary"  OnClick="btnobracivil_Click">
                                <span aria-hidden="true" class="fa fa-bolt">Obra Civil</span>
                                            </asp:LinkButton></li>
                                        <li><asp:LinkButton ID="LinkButton2" runat="server" Text="Elect." CssClass="btn btn-primary"  OnClick="btnornamentacion_Click">
                                <span aria-hidden="true" class="fa fa-bolt">Ornamentacion</span>
                                            </asp:LinkButton></li>
                                        <li><asp:LinkButton ID="LinkButton6" runat="server" Text="Elect." CssClass="btn btn-primary"  OnClick="btnPintura_Click">
                                <span aria-hidden="true" class="fa fa-bolt">Pintura</span>
                                            </asp:LinkButton></li>
                                        <li class="divider"></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton4" runat="server" Text="Insertar" CssClass="btn btn-primary" OnClick="mostrarselect">
                                <span aria-hidden="true" class="fa  fa-bolt">Activos Fijos</span>
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                                <!-- /btn-group -->
                                <input type="text" id="clasetrabajo" runat="server" class="form-control" style="width: 100%">
                            </div>
                            <!-- /input-group -->


                            <div id="Selectarticulodiv" runat="server">

                                <select runat="server" id="Selectarticulo" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>

                            </div>
                            <!-- /input-group -->
                            <div class="input-group">
                        <span class="input-group-addon">Tipo Mantenimiento:</span>
                          
                                <select runat="server" id="SelecttipoMant" class="js-example-basic-single" name="state" style="width: 100%">
                                    <option value="P">Preventivo</option>
                                    <option value="C">Correctivo</option>
                                </select>
                            </div>
                                 <div class="input-group">
                        <span class="input-group-addon">Repuestos:</span>
                        <input id="txtRepuestos" runat="server" type="text" placeholder="Repuestos Utilizados" class="form-control" />
                    </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>



                <div class="col-md-3">

                   <div class="input-group">
                        <span class="input-group-addon">$_Mano Obra:</span>

                        <input id="valorManObra" runat="server" type="number" placeholder="Valor Mano de Obra" value="0" class="form-control" />
                        <span aria-hidden="true" class="fa fa-hand-stop-o form-control-feedback"></span>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">$_Repuestos</span>
                        <input id="V_repuestos" runat="server" type="text" placeholder="Valor Respuestos" value="0" class="form-control" />
                        <span aria-hidden="true" class="fa fa-shopping-cart form-control-feedback"></span>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Numero Externo:</span>
                        <input id="Textnumeroexterno" runat="server" type="text" placeholder="Numero Externo" class="form-control" />
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Garantia:</span>
                        <input id="Textgarantia" runat="server" type="number" placeholder="Meses Garantia" class="form-control" />
                    </div>
                </div>
                <div class="col-md-5">
                    <!-- /detalle del mantenimiento-->
                    <div class="form-group ">
                        <textarea id="txtobserva" runat="server" type="text" onKeyUp="this.value=this.value.toUpperCase();" placeholder="Descripcion del Mantenimiento" class="form-control" ></textarea>
                    </div>
                   
                    <div id="botonInsertar">

                        <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-primary" OnClick="agregarow">
                <span aria-hidden="true" class="fa  fa-hand-o-down"> Insertar</span>
                        </asp:LinkButton>

                    </div>
                </div>

            </div>

        </div>

        <div class="box">
            <div class="box-header" id="div_detalles">
                <h3 class="box-title">Detalles</h3>

            </div>

            <div class="row">

                <div class="col-xs-12">


                    <!-- /.box-header -->
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None" OnRowDeleting="OnRowDeleting" OnRowEditing="GridViewdetalle_RowEditing" OnRowCancelingEdit="GridViewdetalle_RowCancelingEdit" OnRowUpdating="GridViewdetalle_RowUpdating" class="display compact"
                                CssClass="table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                <Columns>
                                    <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/dist/img/edit1.png" UpdateImageUrl="~/dist/img/update.png" CancelImageUrl="~/dist/img/cancel.png" ControlStyle-CssClass="c" />

                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                </Columns>
                            </asp:GridView>

                            </>
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
                        <asp:Button ID="Button10" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenutercero" />

                        <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaTercero_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
         <div class="modal modal-warning fade in " id="Imprime" style="display: block;" runat="server">
            <div class="modal-dialog modalprint "  runat="server" >
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" OnClick="btncerrarimprime_Click">
                                             <span aria-hidden="true" class="fa fa-close"></span>
                                        </asp:LinkButton>
                        <h4 class="modal-title">Imprimir</h4>
                    </div>
                    <div class="modal-body">
                       
                        <rsweb:reportviewer ID="ReportViewer1"  runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" style="margin-top: 88" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
            <localreport reportpath="Vista\reportes\actasmantenimiento.rdlc">
            </localreport>

                        </rsweb:reportviewer>
          
        </div>
                    </div>
                </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
        </div>
         </section>
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
