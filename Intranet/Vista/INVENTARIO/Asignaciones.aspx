<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card">
        <div class="card-header">
            <h3 class="card-title">Asignaciones Inventario</h3>
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
                                <label for="txtUsuario">Usuarios</label>
                                <input type="text" runat="server" class="form-control" id="txtUsuario" placeholder="Grupo_1">
                            </div>
                           <div class="form-group">
                                <label for="txtUsuario">Ubicaciones</label>
                                <input type="text" runat="server" class="form-control" id="Text1" placeholder="P1L1M2 - MODULO 1">
                            </div>
                        </div>
                      <div class="card-footer">
                
                              <button type="submit" class="btn btn-primary">Guardar</button>
                                <button type="submit" class="btn btn-success" runat="server" id="btncrea1" onserverclick="NewconteoUno">Zonas 1 Conteo</button>
                          <button type="submit" class="btn btn-success" runat="server" id="Button1" onserverclick="NewconteoDos" >Zonas 2 Conteo</button>
                        
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
                                         <asp:gridview runat="server" id="GridviewASG" gridlines="None"
                                        cssclass=" table table-striped dysplay" onselectedindexchanged="GridviewASG_SelectedIndexChanged" emptydatatext="No se encontraron Registros con los parametros indicados.">
                                             <Columns>
  
                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../dist/img/iconfinder_sms_43332.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Envio SMS" >

                                              
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
