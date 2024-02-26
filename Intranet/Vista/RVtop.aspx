<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="RVtop.aspx.cs" Inherits="Intranet.Vista.RVtop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Top Ventas</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Top Articulos</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                        <li class="breadcrumb-item active">Reportes</li>
                        <li class="breadcrumb-item active">Ventas</li>

                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <form method="post" runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <div class="card card-dark">
                            <div class="card-header">
                                Parametros
                            </div>
                            <div class="card-body">
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Fecha inicio </label>
                                    <input runat="server" id="txtfechaini" type="date" class="col-sm-9 form-control" label="Fecha inicio">
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Fecha fin </label>
                                    <input runat="server" id="txtfechafin" type="date" class="col-sm-9 form-control" placeholder="Fecha fin">
                                </div>
                                <select runat="server" id="selectTop" class="form-control">
                                    <option value="10">Top 10</option>
                                    <option value="20">Top 20</option>
                                    <option value="30">Top 30</option>
                                    <option value="50">Top 50</option>
                                </select>
                              <%--  <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">PLU Articulo </label>
                                    <input runat="server" id="txtarticuloid" type="text" class="col-sm-9 form-control" placeholder="Articulo ID">
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Sala de Ventas </label>
                                    <select id="Select1" class="col-sm-9 form-control" runat="server">
                                        <option value="000001">SUPERMIO LA 16 </option>
                                        <option value="000002">SUPERMIO LA 13 </option>
                                        <option value="000004">SUPERMIO VERSALLES </option>
                                        <option value="000005">SUPERMIO CIUDADELA </option>

                                    </select>
                                </div>--%>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="Button1" runat="server" Font-Size="Larger" class="btn btn-dark" Text="Consulta" OnClick="listaventas" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9">
                        <div class="card card-dark">
                            <div class="card-header">
                                <h4 class="card-title ">
                                    <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseOne" aria-expanded="false">Datos Seleccionados
                                    </a>
                                </h4>

                            </div>
                            <div id="collapseOne" class="collapse" data-parent="#accordion" style="">
                                <div class="card-body">
                                    <div class="table-responsive">

                                        <asp:GridView ID="GridViewTopventas" runat="server" GridLines="None"
                                            CssClass="gvuser table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                        </div>

                      <%--   <div class="card card-dark">
                            <div class="card-header">
                                <h4 class="card-title ">
                                    <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseDos" aria-expanded="false">General
                                    </a>
                                </h4>

                            </div>
                             <div id="collapseDos" class="collapse" data-parent="#accordion" style="">
                                <div class="card-body">
                                     <div class="table-responsive">

                                        <asp:GridView ID="GridViewtodos" runat="server" GridLines="None"
                                            CssClass="table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                                        </asp:GridView>

                                    </div>
                                    </div>
                                 </div>

                    </div>--%>

                   
                 
                 

                </div>
                    </div>
            </form>
        </div>
    </section>
</asp:Content>
