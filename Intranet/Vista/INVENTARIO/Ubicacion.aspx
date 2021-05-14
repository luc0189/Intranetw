<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Ubicacion.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Ubicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="card card">
        <div class="card-header">
            <h3 class="card-title">Ubicacion de Inventario</h3>
        </div>
        <div class=" card-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="card card-dark">
                      <div class="card-header">
                       <h3 class="card-title">Gestion</h3>
                      </div>
                        <div class="card-body">

                          
                            <div class="form-group">
                                <select id="Select1" runat="server">
                                  

                                </select>                                
                            </div>
                            <div class="form-group">
                             
                                <button type="submit" class="btn btn-success" runat="server" id="btncrea1" onserverclick="btncrea1_ServerClick">Crear Inventario</button>
                            </div>

                        </div>
                    </div>
                </div>
              <div class="col-md-6">
                <div class="card card-dark">
                  <div class="card-header">
                    <h3 class="card-title">Listado</h3>
                  </div>
                  <div class="card-body">
                    <div class="table-responsive">
                                         <asp:gridview runat="server" id="GridviewUbicaciones" gridlines="None"
                                        cssclass=" table table-striped dysplay" onselectedindexchanged="GridviewUser_SelectedIndexChanged" emptydatatext="No se encontraron Registros con los parametros indicados.">
                                             <Columns>
  
                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../../dist/img/edit.png" ControlStyle-CssClass="c"  >

                                              </asp:CommandField>
                                            

                                        </Columns>
                                  </asp:gridview>
                                    </div>
                  </div>
                </div>
              </div>
            </div>
              

                <!-- /.card-body -->

                <div class="card-footer">
                    <label id="txtestado" runat="server"></label>
                   
                </div>
           
        </div>

    </div>
</asp:Content>
