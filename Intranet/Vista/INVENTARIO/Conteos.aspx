<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Conteos.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Conteos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card card">
        <div class="card-header">
            <h3 class="card-title">Conteos de Inventario</h3>
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
                                <label for="txtconteo">Nombre del conteo</label>
                                <input type="text" runat="server" class="form-control" id="txtconteo" placeholder="Conteo 1 ">
                            </div>

                        </div>
                        <div class="card-footer">
                        <h3 class="card-title">
                            <label id="txtestado" runat="server"></label>
                        </h3>
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
                                         <asp:gridview runat="server" id="Gridviewconteos" gridlines="None"
                                        cssclass=" table table-striped dysplay" onselectedindexchanged="Gridviewzonas_SelectedIndexChanged" emptydatatext="No se encontraron Registros con los parametros indicados.">
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
                   <asp:Button runat="server" ID="UploadButton" type="submit" Text="Guardar" CssClass="btn btn-primary" OnClick="Newconteo" />
                   
                </div>
           
        </div>

    </div>
</asp:Content>
