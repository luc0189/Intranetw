<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="recordcajerasmarca.aspx.cs" Inherits="Intranet.Vista.recordcajerasmarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Ventas Aux-Registro- Marca</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Ventas Aux-Registro por Marca</h1>
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
                    <div class="col-md-6">
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
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Marca</label>
                                    <input runat="server" id="txtmarca" type="text" class="col-sm-9 form-control" placeholder="Marca">
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Sala de Ventas </label>
                                    <select id="Select1" class="col-sm-9 form-control" runat="server">
                                        <option value="011">SUPERMIO LA 16 </option>
                                        <option value="012">SUPERMIO LA 13 </option>
                                        <option value="014">SUPERMIO VERSALLES </option>
                                        <option value="015">SUPERMIO CIUDADELA </option>

                                    </select>
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="Button1" runat="server" Font-Size="Larger" class="btn btn-dark" Text="Consulta" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
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

                                        <asp:GridView ID="GridViewventascajeraXmarca" runat="server" GridLines="None"
                                            CssClass="gvuser table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                        </div>

                       

                   
                 
                 

                </div>
            </form>
        </div>
    </section>
</asp:Content>
