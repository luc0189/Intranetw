<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="articulo_Cliente.aspx.cs" Inherits="Intranet.Vista.articulo_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <a href="1.aspx" class="fa fa-home">Inicio</a>
        <div class="box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Records Ventas Articulos por Cliente</h3>
            </div>
        </div>
        <form method="post" runat="server">
            <div class="box-body">
                <div class="row">
                    <div class="col-xs-4">

                        <label>Fecha inicio </label>
                        <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">
                    </div>
                    <div class="col-xs-4">
                        <label>Fecha fin </label>
                        <input runat="server" id="txtfechafin" type="date" class="form-control" placeholder="Fecha fin">
                    </div>
                    <div class="col-xs-4">
                        <label>PLU Articulo </label>
                        <input runat="server" id="txtarticuloid" type="text" class="form-control" placeholder="Articulo ID">
                    </div>

                    <div id="btconsulta">
                        <asp:Button ID="Button1" runat="server" Font-Size="Larger" class="btn btn-block btn-success btn-sm " Text="Consulta" OnClick="listaventas" />
                    </div>
                    <div id="tabla">
                        <div class="table-responsive">

                            <asp:GridView ID="GridViewventasclienteXarticulo" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>
        </form>
    </section>
</asp:Content>
