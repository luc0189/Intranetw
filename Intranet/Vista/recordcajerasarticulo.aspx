<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="recordcajerasarticulo.aspx.cs" Inherits="Intranet.Vista.recordcajerasarticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
        <a href="1.aspx" class="fa fa-home">Inicio</a>
        <div class="box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Records Ventas Aux-Registro por Articulo</h3>
            </div>
        </div>
        <form method="post" runat="server">
            <div class="box-body">
                <div class="row">
                    <div class="col-xs-3">

                        <label>Fecha inicio </label>
                        <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">
                    </div>
                    <div class="col-xs-3">
                        <label>Fecha fin </label>
                        <input runat="server" id="txtfechafin" type="date" class="form-control" placeholder="Fecha fin">
                    </div>
                    <div class="col-xs-3">
                        <label>PLU Articulo </label>
                        <input runat="server" id="txtarticuloid" type="text" class="form-control" placeholder="Articulo ID">
                    </div>
                     <div class="col-xs-3">
                        <label>Sala de Ventas </label>
                         <select id="Select1" runat="server">
                             <option value="000001">SUPERMIO LA 16 </option>
                             <option value="000002">SUPERMIO LA 13 </option>
                             <option value="000004">SUPERMIO VERSALLES </option>
                             <option value="000005">SUPERMIO CIUDADELA </option>

                         </select>
                    </div>
                    <div id="btconsulta">
                        <asp:Button ID="Button1" runat="server" Font-Size="Larger" class="btn btn-block btn-success btn-sm " Text="Consulta" OnClick="listaventas" />
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div id="tabla" class="box">
                        <div class="box-header">
                            - Top 10 -
                        </div>
                        <div class="box-body">
                               <div class="table-responsive">
                          
                            <asp:GridView ID="GridViewventascajeraXarticulo" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                        </div>
                     
                    </div>
                        </div>
                        <div class="col-md-6">
                            <div class="box">
                                <div class="box-header">
                                    ACOMULADO
                                </div>
                                <div class="box-body">
                                     <div class="table-responsive">
                          
                            <asp:GridView ID="GridViewtodos" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="box">
                                <div class="box-header">
                                     supermio la 16
                                </div>
                                <div class="box-body">
                                    <div class="table-responsive">
                          
                            <asp:GridView ID="Gridventasarticulo16" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="box">
                                <div class="box-header">
                                    Supermio la 13
                                </div>
                                        <div class="box-body">
                                    <div class="table-responsive">
                          
                            <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="box">
                                <div class="box-header">
                                    Supermio Versalles
                                </div>
                                <div class="box-body">
                                    <div class="table-responsive">
                          
                            <asp:GridView ID="GridView2" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="box">
                                <div class="box-header">
                                    Supermio Ciudadela
                                </div>
                                <div class="box-body">
                                    <div class="table-responsive">
                          
                            <asp:GridView ID="GridView3" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView>

                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
                  
                </div>

            </div>
        </form>
        </div>
    </section>
</asp:Content>
