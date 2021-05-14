<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="JobDelivery.aspx.cs" Inherits="Intranet.Vista.JobDelivery" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <section class="content">
        <div class="container bootstrap snippet">
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
              <label id="txtnotifica" runat="server">Este panel es para notificaciones</label>
            </font></font>
            </div>
            <!-- /.box-body -->
        </div>
            <form method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              
                        <div class="row">
                            <div class="col-md-6">
                                <div class="box">
                                    <div class="box-header">
                                        Entrega
                                    </div>
                                    <div class="box-body">
                                        <select runat="server" id="SelectEmployeeDelivery" class="js-example-basic-single">
                                            <option value="value">Empleado Entrega</option>
                                        </select>
                                         <asp:LinkButton ID="btnConsulta" runat="server" Text="Nuevo" OnClick="btnConsulta_Click">
                                        <span aria-hidden="true" class="fa fa-magic"> Consultar</span>
                                                </asp:LinkButton>
                                    </div>
                                    
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="box">
                                    <div class="box-header">
                                        Recibe
                                    </div>
                                    <div class="box-body">
                                          <select runat="server" id="SelectEmployeeReceives" class="js-example-basic-single" >
                                            <option value="value">Empleado recibe</option>
                                        </select>
                                        
                                    </div>
                                    
                                </div>
                            </div>

                          
                        </div>
                <div class="row">
                     <asp:updatepanel runat="server" id="UpdatePanel1">
             <ContentTemplate>
                    <div class="col-md-6">
                          <div class="box">
                              <div class="box-body">
                                  <div class="table-responsive">
                                              <asp:GridView ID="GridDelivery" runat="server"  GridLines="None" onselectedindexchanged="GridDelivery_SelectedIndexChanged"
                                                CssClass="gvuser table table-striped dysplay"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                              </div>
                                        
                                  
                            </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box">
                            <div class="box-body">
                                <div class="table-responsive">
                                            <asp:GridView ID="GridViewdetalle" runat="server"  GridLines="None"
                                                CssClass="gvuser table table-striped dysplay"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                <Columns>

                                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                            </div>
                            <div class="box-footer">
                               <input type="button" name="acta" value="crear Acta" />
                            </div>
                           
                                        
                                    
                        </div>
                    </div>
                 </ContentTemplate>
                         </asp:updatepanel>
                </div>
                   <div class="modal modal-warning fade in " id="Imprime" style="display: block;" runat="server">
                    <div class="modal-dialog modalprint " runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Insertar" >
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
                </form>
            
            </div>
        </section>
        <script type="text/javascript">


            $('#btnProcesar').on('click', function () {

            });

            $('select').select2({
                language: {

                    noResults: function () {

                        $('p').slideToggle('slow');
                        btnProcesar.hidden = false;
                        return "No hay resultados "

                    },
                    searching: function () {

                        return "Buscando..";
                    }
                }
            });



    </script>
</asp:Content>
