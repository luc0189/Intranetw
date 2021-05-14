<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Auditores.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Auditores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card">
        <div class="card-header">
            <h3>Modulo Auditores</h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">Gestion</h3>
                        </div>
                        <div class="card-body">
                            <div class="input-group input-group">
                                <input type="number" name="name" id="txtidconteo" runat="server" class="form-control" required="required" />
                                <span class="input-group-append">
                                    <button type="submit" class="btn btn-info btn-flat" runat="server" onserverclick="Unnamed_ServerClick">Cerrar Conteo</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-dark">
                        <div class="card-header">
                            <div class="card-title">
                                Conteos Abiertos
                <span class="badge badge-danger">
                    <strong>
                        <label id="lbl_abiertos" runat="server"></label>
                    </strong>
                </span>
                            </div>

                        </div>
                        <div class="card-body">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="gridAbiertos" GridLines="None"
                                    CssClass="gv2 table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>

                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-dark">
                        <div class="card-header">
                            <div class="card-title">
                                Conteos Cerrados 
               
                                <span class="badge badge-danger">
                                    <strong>
                                        <label id="LabelConteosCerrados" runat="server"></label>
                                    </strong>
                                </span>

                            </div>

                        </div>
                        <div class="card-body">
                            <div class="table table-responsive dark">
                                <asp:GridView runat="server" ID="gridCerrados" GridLines="None"
                                    CssClass="gv3 table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
