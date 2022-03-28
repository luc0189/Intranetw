<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="Intranet.Vista._1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">


        <div class="row">
            <div class="box">
                <div class="box-header no-border">
                    <div class="col-md-4">
                        <div class="input-group">
                            <span class="input-group-addon">Desde:</span>
                            <input type="date" runat="server" id="txtdesde" name="name" value="" class="form-control" />

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">
                            <span class="input-group-addon">hasta:</span>
                            <input type="date" runat="server" id="txthasta" name="name" value="" class="form-control" />

                        </div>
                    </div>
                    <div class="col-md-4">
                        <asp:LinkButton ID="Btnconsulta" runat="server" Text="Listar Activos" CssClass="btn form-control" OnClick="Btnconsulta_Click">
                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                        </asp:LinkButton>
                    </div>
                </div>

            </div>
            <div class="col-lg-6">
                <div class="box">
                    <div class="box-header">
                        Datos Estadisiticos  
                <span class="badge bg-danger">NEW</span>
                    </div>

                    <div class="box-body p-0">
                        <table class="table table-striped table-valign-middle">
                            <thead>
                                <tr>
                                    <th>Detalle</th>
                                    <th>Valor</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Variacion Mensual
                                    </td>
                                    <td>
                                        <small class="text-success mr-1">
                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="txtporcentaMesAnterior"></label>
                                                %</font></font></h5>
                                        </small>
                                    </td>

                                </tr>
                                <tr>
                                    <td>Ventas
                                    </td>

                                    <td>
                                        <small class="text-warning mr-1">

                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblventasr"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>

                                </tr>
                                <tr>
                                    <td>Promedio de Venta diaria
                                    </td>

                                    <td>
                                        <small class="text-danger mr-1">
                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblpromventadiaria"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>

                                </tr>
                                <tr>
                                    <td>Ventas por Metro Cuadrado
                  
                                    </td>

                                    <td>
                                        <small class="text-success mr-1">
                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblventasmetroc"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>

                                </tr>
                                <tr>
                                    <td>Promedio de Compra por Cliente
              
                                    </td>

                                    <td>
                                        <small class="text-success mr-1">
                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblcompraclientes"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>

                                </tr>
                            </tbody>
                        </table>

                    </div>

                </div>
                <div class="box">
                    <div class="box-header">
                        Ventas Por Hora
                        <div class="box-tools">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Listar Activos" OnClick="LinkButton1_Click">
                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="table-responsive">

                            <asp:GridView ID="Gridsuper" runat="server" GridLines="None"
                                CssClass="gvuser1 table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                            </asp:GridView>

                        </div>
                        <div class="table table-responsive">
                            <asp:GridView runat="server" ID="grid" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                <RowStyle CssClass="nav-link" />

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="box">
                    <div class="box-header">
                        Proyecciones 
                <span class="badge bg-danger">NEW</span>
                    </div>

                    <div class="box-body p-0">
                        <table class="table table-striped table-valign-middle">
                            <thead>
                                <tr>
                                    <th>Detalle</th>
                                    <th>Valor</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Meta
                                    </td>
                                    <td>
                                        <small class="text-success mr-1">
                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblvrproyectado"></label>
                                            </font></font></h5>
                                        </small>
                                    </td>
                                    <td>100%
                                    </td>

                                </tr>
                                <tr>
                                    <td>Proyectado de Ventas
                                    </td>

                                    <td>
                                        <small class="text-warning mr-1">

                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="lblproyectado"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>
                                    <td>
                                        <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                            <label runat="server" id="lblporcen_Proyectado"></label>
                                            %
                                        </font></font></h5>
                                    </td>

                                </tr>
                                <tr>
                                    <td>Cumplido
                                    </td>

                                    <td>
                                        <small class="text-warning mr-1">

                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                                <label runat="server" id="Label1"></label>
                                            </font></font></h5>
                                        </small>

                                    </td>
                                    <td>
                                        <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                                            <label runat="server" id="porcentaje"></label>
                                            %
                                        </font></font></h5>
                                    </td>

                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
                <div class="box">
                    <div class="box-header">
                        Ventas Rango de tiempo
                        <div class="box-tools">
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Listar Activos" OnClick="LinkButton2_Click">
                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="table-responsive">
                            <asp:GridView ID="Gridsupermio" runat="server" GridLines="None"
                                CssClass="gvuser1 table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="Gridsupermiototal" runat="server" GridLines="None"
                                CssClass="gvuser1 table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>


        </div>

    </form>
</asp:Content>
