<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Baja_Activos.aspx.cs" Inherits="Intranet.Vista.Baja_Activos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .auto-style3 {
            height: 16px;
            width: 180px;
        }
    .auto-style4 {
            height: 16px;
            width: 250px;
        }
</style>
     <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
        
   
        <div class="box">
            <div class="box-header with-border">
                <label style="width:300px;">ACTA BAJA DE ACTIVOS FIJOS</label>
                
               <asp:LinkButton ID="LinkButton1" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="Guardar" >
                <span aria-hidden="true" class="fa   fa-save"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Insertar" CssClass="btn btn-success" >
                <span aria-hidden="true" class="fa   fa-print"></span>
                    </asp:LinkButton>
                <div class="box-tools pull-right">
                    <label>No.</label>
                      <input type="text" runat="server" style="width:60px;" class=" input-mini" id="txtN_acta" name="name" value="" />
         
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="col-md-5">
                    <div class="form-group has-feedback" id="div_ubicacion">
                         <div class="input-group">
                                <span class="input-group-addon"><b>Ubicacion</b></span>
                        <select runat="server" id="Selectubicacion" class="js-example-basic-single form-control" name="state" style="width: 100%">
                        </select>
                             </div>
                    </div>
                </div>
                <div class="col-md-4">
                     <div class="form-group has-feedback "  id="div_area">
                         <div class="input-group">
                                <span class="input-group-addon"><b>Area:</b></span>
                        <select runat="server" id="Selectarea" class="js-example-basic-single form-control" name="state" style="width: 100%">
                        </select>
                            
                             </div>
                    </div>
                     
                </div>
                <div class="col-md-3">
                    <div class="form-group  " >
                         <div class="input-group">
                                <span class="input-group-addon"><b>Fecha:</b></span>
                    <input type="date" name="name" runat="server" value="" id="txtfecha" class="form-control"/>
                             </div>
                        </div>
                        </div>
                </div>
            
        </div>
    
        <div class="box-footer">
            <div class="row" id="insert">
                <div class="col-md-6">
                     <div class="form-group has-feedback">
                         <div class="input-group">
                                <span class="input-group-addon"><b>Articulo:</b></span>
                        <select runat="server" id="Selectarticulo" class="js-example-basic-single form-control" name="state" style="width: 100%">
                        </select>
                             </div>
                    </div>
                     <div class="form-group has-feedback" >
                         <div class="input-group">
                                <span class="input-group-addon"><b>Destino</b></span>
                             <input type="text" runat="server" id="txtdestino" name="name" value="" class="form-control" />
                             </div>
                    </div>
                </div>
               
                <div class="col-md-5">
                    <div class="form-group has-feedback">
                        <textarea id="txtobserva" runat="server" style="width:100%" placeholder="Observaciones"  class="form-control" onkeyup="javascript:ComprobarCasilla(this);" rows="3" ></textarea>
                                     
                    </div>
                    
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="agregarow" >
                <span aria-hidden="true" class="fa   fa-plus-square"></span>
                    </asp:LinkButton>
                   

                </div>

            </div>
         </div>

               
                    <div class="box">
                        <div class="box-header with-border">
                            Detalles de Acta
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">

                            <div class="table-responsive">
                                
                                <asp:GridView ID="GridViewdetalle" runat="server" OnRowDeleting="OnRowDeleting"  GridLines="None"
                                    CssClass="gvusersd table table-striped dysplay"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                  <Columns>
                                      
                            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                      </Columns>
                                   
                                </asp:GridView>


                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                

         <div class="modal modal-warning fade in " id="Imprime" style="display: none;" runat="server">
            <div class="modal-dialog modalprint "  runat="server" >
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" >
                                             <span aria-hidden="true" class="fa fa-close"></span>
                                        </asp:LinkButton>
                        <h4 class="modal-title">Imprimir</h4>
                    </div>
                    <div class="modal-body">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="White" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="Azure" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" style="margin-top: 88" Width="100%" ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False">
            <localreport reportpath="Vista\actas.rdlc">
            </localreport>
        </rsweb:ReportViewer>
        </div>
                    </div>
                </div>
        </div>
    
    </form>
        </div>
         </section>
    <script>
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
