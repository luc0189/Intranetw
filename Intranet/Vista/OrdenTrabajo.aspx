<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="OrdenTrabajo.aspx.cs" Inherits="Intranet.Vista.OrdenTrabajo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" runat="server">

        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">
                    <h3 class="box-title"><b>Ordenes de trabajo</b></h3>
                </h3>
                
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                
                <div class="col-md-4">
                    <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Ubicacion</span>
                                <select runat="server" id="Selectubicacion" class="js-example-basic-single" name="state" required style="width: 100%">
                                </select>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="LinkButton11" runat="server" Text="Nuevo" class="btn btn-success btn-flat" >+</asp:LinkButton>
                                </span>
                            </div>
                        </div>
                       <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Area</span>
                                <select runat="server" id="Selectarea" class="js-example-basic-single" name="state" required style="width: 100%">
                                </select>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Nuevo" class="btn btn-success btn-flat" >+</asp:LinkButton>
                                </span>
                            </div>
                        </div>
                    <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">TipoM.</span>
                                <select runat="server" id="Selecttipo" class="js-example-basic-single" name="state" style="width: 100%" required>
                                </select>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Nuevo" class="btn btn-success btn-flat" >+</asp:LinkButton>
                                </span>
                            </div>
                        </div>
                </div>
               
                <div class="col-md-4">
                   
                                
                        <textarea placeholder="Descripcion" class="form-control"  runat="server" dir="auto" rows="5" id="txtDescripcion" required title="P"></textarea>
                           
                </div>
                   
                <div class="col-md-4">
                    <div class="box">
                            <div class="box-header">
                                Menu
                                <div class="box-body">
                                  <%--  <div class="btn-group">

                                        <asp:LinkButton ID="btnNuevo" runat="server" Text="Volver" class="btn btn-app botonesx" OnClick="btnNuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                                        </asp:LinkButton>
                                       
                                    </div>--%>

                                    <div class="btn-group">

                                        <asp:LinkButton ID="btnguardar" runat="server"  Text="Volver" class="btn btn-app botonesx" OnClick="btnguardar_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                        </asp:LinkButton>

                                    </div>
                                    <div class="btn-group">
                                        <a href="1.aspx" class="btn btn-app botonesx">
                                            <i aria-hidden="true" class="fa fa-home"></i>Inicio
                                        </a>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                </div>
            </div>
            </div>
            <div class="row">
                <div class="col-md-6">

                    <div class="box box-default">
                     <div class="box-header with-border">
                            <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <h3 class="box-title">Ordenes Pendientes por Asignar</h3>
                                </button>
                            </div>
                            <div class="box-tools pull-right">
                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Volver" class="form-control" OnClick="btnbuscar_Click">
                                    <i aria-hidden="true"  class="fa fa-search"></i>
                                        </asp:LinkButton>
                              
                            </div>
                        </div>
                        <div class="box-body">
                            <!-- Date dd/mm/yyyy -->
                            <div class="table-responsive">

                                <asp:GridView ID="GridViewPENDIENTES" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." >
                                    
                                </asp:GridView>

                            </div>


                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->

                    <!-- /.box -->
                </div>
             
              
                <div class="col-md-6">
                    <!-- /.box -->
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <h3 class="box-title">Ordenes Asignadas</h3>
                                </button>
                            </div>
                            <div class="box-tools pull-right">
                                <asp:LinkButton ID="btnasignadas" runat="server" Text="Volver" class="form-control" OnClick="btnasignadas_Click">
                                    <i aria-hidden="true"  class="fa fa-search"></i>
                                        </asp:LinkButton>
                              
                            </div>
                        </div>
                        <div class="box-body" style="">
                            <div class="table-responsive">
                                  <asp:GridView ID="GridViewASIGNADO" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewpendientes_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" />

                                    </Columns>
                                </asp:GridView>
                            </div>
                          
                        </div>
                       
                     </div>
                   
                </div>
        </div>
     <%--   <div class="box fondoblanco">
        <div class="box-header with-border">
            <div class=" pull-left">
             <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
              <h3 class="box-title">Ordenes Resueltas</h3></button>
                </div>
          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
              <i class="fa fa-minus"></i></button>
            <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="" data-original-title="Remove">
              <i class="fa fa-times"></i></button>
          </div>
        </div>
        <div class="box-body" style="">
            <div class="table-responsive">
                 <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>
            </div>
        
        </div>
        <!-- /.box-body -->
        <div class="box-footer" style="">
          Footer
        </div>
        <!-- /.box-footer-->
      </div>--%>
      
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="modal modal-warning fade in " id="Imprime_R" style="display: block;" runat="server">
            <div class="modal-dialog modalprint" style="width:70%;"  runat="server" >
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" OnClick="btncerrarimprime_Click">
                                             <span aria-hidden="true" class="fa fa-close"></span>
                                        </asp:LinkButton>
                        <h4 class="modal-title">Imprimir</h4>
                    </div>
                    <div class="modal-body">
                        <div class="table-responsive">
                              <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Style="" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">

                             </rsweb:ReportViewer>
                        </div>
                       
        </div>
                    </div>
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
