<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Bodega.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Bodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card">
        <div class="card-header">
            <h3 class="card-title">Bodegas de Inventario</h3>
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
                                <label for="txtBodega">Nombre de la Bodega</label>
                                <input type="text" runat="server" class="form-control" id="txtBodega" placeholder="Sala de Venta 1" autofocus required="required">
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
                                <asp:GridView runat="server" ID="GridviewBodega" GridLines="None"
                                    CssClass=" table table-striped dysplay" OnSelectedIndexChanged="GridviewBodega_SelectedIndexChanged" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    <Columns>

                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../../dist/img/edit.png" ControlStyle-CssClass="c" AccessibleHeaderText="Editar" >

                                            <ControlStyle CssClass="c"></ControlStyle>
                                           
                                        </asp:CommandField>


                                        <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="../../dist/img/delete2.png" />


                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!-- /.card-body -->

            <div class="card-footer">
                <asp:Button runat="server" ID="UploadButton" type="submit" Text="Guardar" CssClass="btn btn-primary" OnClick="NewBodega" />

            </div>

        </div>

    </div>
</asp:Content>
