<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Zonas.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Zonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card card">
        <div class="card-header">
            <h3 class="card-title">Zonas de Inventario</h3>
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
                                <label for="txtzona">Nombre de la zona</label>
                                <input type="text" runat="server" class="form-control" id="txtzona" placeholder="P1L1M1 - Zona de Ejemplo ">
                            </div>
                            <div class="input-group input-group">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                <span class="input-group-append">
                                    <button type="button" class="btn btn-info btn-flat" runat="server" onserverclick="subir">Subir</button>
                                </span>
                            </div>

                        </div>
                        <div class="card-footer">
                           <asp:Button runat="server" ID="UploadButton" type="submit" Text="Guardar" CssClass="btn btn-primary" OnClick="NewZonas" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">Listado</h3>
                          <div class="card-tools">
                        <asp:Button runat="server" ID="Button1" type="submit" Text="Listar" CssClass="btn btn-primary" OnClick="NewZonas" />
                      </div>
                        </div>
                      
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="Gridviewzonas" GridLines="None"
                                    CssClass=" table table-striped dysplay" OnSelectedIndexChanged="Gridviewzonas_SelectedIndexChanged" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    <Columns>

                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../../dist/img/edit.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Editar"></asp:CommandField>


                                    </Columns>
                                
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!-- /.card-body -->

            <div class="card-footer">
                
               <h3 class="card-title">
                                <label id="txtestado" runat="server"></label>
                            </h3>

            </div>

        </div>

    </div>

</asp:Content>
