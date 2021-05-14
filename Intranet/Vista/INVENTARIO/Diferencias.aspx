<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Diferencias.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Diferencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card">
        <div class="card-header">
            <h3>Modulo Diferencias</h3>
        </div>
        <div class="card-body">
            <div class="table table-responsive">
                <asp:GridView ID="GridViewDiferencias" runat="server" GridLines="None"
                            CssClass="gv table table-striped table-bordered text-sm"
                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados."  OnSelectedIndexChanged="click_VerArticulos" OnRowDeleting="GridViewDiferencias_RowDeleting">
                           <Columns>
                                <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Print"  ControlStyle-CssClass="btn btn-success" />                                                                                                                        
                           </Columns>
                  <Columns>
                                      
                            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="btn btn-info"  />
                                      </Columns>
                     
                        </asp:GridView>
                

            </div>
        </div>
      
    </div>
  <div class ="card card-dark">
     <div class="card card-body" id="vistaArticulos" runat="server" role="dialog"  >
            <div class="modal-dialog">
                <div class="modal-content" style="width:700px;" >
                    <div class="modal-header">
                        <b class="card-title">Articulos con diferencias</b>
                        <div class="box-tools pull-right">
                            <input type="text" name="fecha" id="txtzona" runat="server" class=" form-control" style="width: 100%" />
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="table table-responsive">
                         <asp:GridView ID="Gridarticulos" runat="server" GridLines="None"
                            CssClass="gvuser table table-striped table-bordered text-sm"
                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                        </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="btncancelaingreso" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancelaingreso_Click" />--%>

<%--                        <asp:Button ID="btnIngreso" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btnIngreso_Click" />--%>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
  </div>
 
    <script>  
      //setInterval("location.reload()",190000);
    </script>
  
</asp:Content>
