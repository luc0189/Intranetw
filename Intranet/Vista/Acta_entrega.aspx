<%@ Page Title="Actas de Entrega" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Acta_entrega.aspx.cs" Inherits="Intranet.Vista.Acta_entrega" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   <head>
        <title>LCSystem 3 | Actas de Entrega</title>
    </head>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Actas de Entrega</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Activos Fijos</li>
                            <li class="breadcrumb-item active">Acta ID: <asp:Label Text="text" runat="server" name="name" id="txtidacta2" /></li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </section>
       <div class="modal fade show " id="Imprime" style="display: block;" runat="server">
                    <div class="modal-dialog modal-lg modalprint " runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" OnClick="btncerrarimprime_Click">
                                             <span aria-hidden="true" class="fa fa-close"></span>
                                </asp:LinkButton>
                                <h4 class="modal-title">Imprimir</h4>
                            </div>
                            <div class="modal-body">
                                <div class="card card-body">
                                    <div class="table-responsive-lg">
                                         <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Style="" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
                                    <LocalReport ReportPath="Vista\actas.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                                    </div>
                                   
                                </div>
                                

                                <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" style="margin-top: 88" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
            <localreport reportpath="Vista\actas.rdlc">
            </localreport>
        </rsweb:ReportViewer>--%>
                            </div>
                        </div>
                    </div>
                </div>
    <section class="content">
        <div class="container-fluid">
            <form method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-dark">
                           
                            <div class="card-header">
                                Nueva Acta
                                <div class="card-tools">
                                    <asp:LinkButton ID="btnNuevo" runat="server" Text="Nuevo" OnClick="nuevonumeroacta">
                                        <span aria-hidden="true" class="fa fa-magic"> Nuevo</span>
                                                </asp:LinkButton> |
                                    <asp:LinkButton ID="btnimprime" runat="server" Text="Imprimir" OnClick="btnimprime_Click">
                                             <span aria-hidden="true" class="fa  fa-print"> Imprimir</span>
                                                </asp:LinkButton> |
                                    <asp:LinkButton ID="guardar" runat="server" Text="Guardar" OnClick="Button3_Click">
                                             <span aria-hidden="true" class="fa  fa-save"> Guardar acta</span>
                                                </asp:LinkButton> |
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" OnClick="mostrarmenutercero">
                                         <span aria-hidden="true" class="fa  fa-user-circle">Nuevo Usuario</span>
                                                </asp:LinkButton>
                                   
                                </div>
                            </div>
                            <div class="card-body">
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
                        <div class="col-md-4">
                            <div class="form-group has-feedback" id="div_area">
                                <div class="input-group">
                                    <span class="input-group-addon">Area:</span>
                                    <select runat="server" id="Selectarea" class="js-example-basic-single" name="state" style="width: 100%">
                                    </select>
                                </div>
                            </div>
                        </div>
                            </div>
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
                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                            <div class="card-footer">
                                

                    <div class="card-dark">
                        <div class="card-header">
                            Detalles
                            <div class="card-tools">
                                <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-dark" OnClick="agregarow">
                                                    <i aria-hidden="true"  class="fa fa-hand-o-down"></i>Insertar
                                                    </asp:LinkButton>
                                <input type="text" name="name" value="" id="txtidacta" runat="server" />
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table table-responsive">
                                    <asp:GridView ID="GridViewdetalle" runat="server" OnRowDeleting="OnRowDeleting" GridLines="None"
                                                CssClass="gvuser table table-striped dysplay"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                <Columns>

                                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                                </Columns>

                                            </asp:GridView>
                            </div>
                          
                                </div>
                        </div>
                  
                </div>
                                <div class="row">
                                   
                            </div>
                                     </ContentTemplate>

                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
              
                
             
              
              
               
     
           
                    
                               
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

                            <div class="modal modal-warning " id="Nuevotercero" style="display: block;" runat="server">
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
                            <div class="modal modal-warning" id="panelubicacion" style="display: block;" runat="server">
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
