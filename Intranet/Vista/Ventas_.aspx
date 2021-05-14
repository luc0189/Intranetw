<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Ventas_.aspx.cs" Inherits="Intranet.Vista.Ventas_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container">
            <form method="post" runat="server">
                <div class="margin">
                    <div class="box-header with-border">
                        <h3 class="box-title"><b>Informe de ventas</b></h3>

                    </div>


                </div>
                <section class="content">



                    <div class="box-body">
                        <center>
                              <div class="shadow p-3 mb-2 bg-body rounded">
                                <div class="row align-items-start">
                                    <div class="col-md-4">
                                        <input runat="server" id="txtfechaini" type="date" label="Fecha inicio">
                                    </div>
                                    <div class="col-md-4">

                                        <input runat="server" id="txtfechafin" type="date"  placeholder="Fecha fin">
                                    </div>
                                    <div class="col-md-4" id="boton">

                                        <asp:LinkButton ID="BtnConsulta" runat="server" Text="Listar Activos" CssClass="btn btn-success"
                                            OnClick="BtnConsulta_Click">
                                                <span aria-hidden="true" class="fa fa-list">Consultar Datos</span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </center>
                                 
                            
                    </div>



                    <br />

                    <div class="col-md-12">
                        <!-- MAP & BOX PANE -->
                        <div class="box box-success">
                            <div class="box-header with-border">
                                <h3 class="box-title">Reportes</h3>

                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body ">



                                <div class="row">


                                    <!-- DIRECT CHAT -->
                                    <div class="box box-danger ">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">LA 14</h3>
                                            <div class="box-tools pull-right">
                                                <!-- <span data-toggle="tooltip" title="" class="badge bg-yellow" data-original-title="3 New Messages">3</span>-->
                                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                    <i class="fa fa-minus"></i>
                                                </button>

                                                <button type="button" class="btn btn-box-tool" data-widget="remove">
                                                    <i class="fa fa-times"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <div class="table-responsive">
                                                <asp:GridView ID="Gridla14" runat="server" GridLines="None"
                                                    CssClass="gvuser table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                </section>
            </form>
        </div>
    </div>
</asp:Content>
