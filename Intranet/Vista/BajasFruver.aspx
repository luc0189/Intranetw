<%@ Page Title="Bajas Fruver" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="BajasFruver.aspx.cs" Inherits="Intranet.Vista.reportes.BajasFruver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <head>
        <title>Bajas Fruver</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Reporte Bajas Fruver</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="1.aspx">Inicio</a></li>
                        <li class="breadcrumb-item active">Reportes</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <form runat="server">
                <div class="row">
                    <div class="col-md-4">


                        <div class="card card-dark">
                            <div class="card-header">
                                Acomulado Bajas de Fruver
                            </div>
                            <div class="card-body">


                                <div class="form-group row">
                                    <label for="txtfechadesde" class="col-sm-3 col-form-label">Fecha desde:</label>
                                    <input type="date" class="col-sm-9 form-control" name="name" id="txtfechadesde" runat="server" />
                                </div>
                                <div class="form-group row">
                                    <label for="txtfechahasta" class="col-sm-3 col-form-label">Fecha Hasta:</label>
                                    <input type="date" name="name" class="col-sm-9 form-control" id="txtfechahasta" runat="server" />
                                </div>





                            </div>
                            <div class="card-footer">
                                <div class="form-group">
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" OnClick="Consulta">
                                         <span aria-hidden="true" class="btn btn-dark">Consultar</span>
                                    </asp:LinkButton>
                                    <button type="button" id="consultaadmon" runat="server" class="btn btn-dark"  data-toggle="modal" data-target="#modal-default">
                                        Consultar
                                    </button>
                                </div>
                            </div>
                            <div class="modal fade" id="modal-default" style="display: none;" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title">Seleccione la Sala de Ventas</h4>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                           <select runat="server" id="Selectsala" class="js-example-basic-single form-control">
                                               
                                            </select>
                                        </div>
                                        <div class="modal-footer justify-content-between">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Salir</button>
                                             <asp:LinkButton ID="Consultadmon" runat="server" Text="Nuevo" OnClick="Consultaadmon_Click">
                                         <span aria-hidden="true" class="btn btn-dark">Consultar</span>
                                    </asp:LinkButton>
                                         
                                        </div>
                                    </div>

                                </div>

                            </div>
                           
                        </div>


                    </div>
                    <div class="col-md-8">
                        <div class="card card-dark">
                            <div class="card-header">
                                Datos
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                        CssClass="gvuser table table-bordered table-striped dataTable dtr-inline"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
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
