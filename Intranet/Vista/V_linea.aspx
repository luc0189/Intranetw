<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="V_linea.aspx.cs" Inherits="Intranet.Vista.V_linea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <form runat="server">
            <a href="1.aspx" class="fa fa-home">Inicio</a>
            <div class="box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Ventas Por Linea</h3>
                </div>
            </div>
            <div>
                <asp:Label Text="alerta" runat="server" ID="alerta" Visible="false" class="alert-danger" />
            </div>
            <div class="row">
                <div class="box">
                    <div class="box box-header">

                        <asp:Label Text="Fecha desde" runat="server" />
                        <input type="date" name="name" value="" runat="server" id="txtdesde" />
                        <asp:Label Text="Fecha Hasta" runat="server" />
                        <input type="date" name="name" runat="server" value="" id="txthasta" />

                        <asp:LinkButton ID="LinkButton6" runat="server" Text="General" OnClick="Consulta" class="btn btn-secondary "> </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Supermio 16" OnClick="Consultala16" class="btn btn-secondary"> </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Supermio 13" OnClick="Consultala13" class="btn btn-secondary"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text="Supermio Versalles" OnClick="Consultalaversalles" class="btn btn-secondary"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" Text="Supermio Ciudadela" OnClick="Consultalaciudadela" class="btn btn-secondary"></asp:LinkButton>

                    </div>

                </div>


            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card card-widget widget-user-2 shadow-sm">
                        <!-- Add the bg color to the header using any of the bg-* classes -->
                        <div class="widget-user-header bg-warning">

                            <!-- /.widget-user-image -->

                            <div class="widget-user-image">
                                <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                            </div>
                            <h3 class="widget-user-username">SUPERMIO  S.A.S</h3>



                            <div class="widget-user-desc">
                                <asp:Label Text="Rango Fecha" ID="info1" runat="server" />
                            </div>

                        </div>
                        <div class="box-footer p-0">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="GridGeneral" AllowCustomPaging="True" AllowPaging="True" CssClass=" table table-bordered table-hover dataTable dtr-inline">
                                    <RowStyle CssClass="nav-link" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card card-widget widget-user-2 shadow-sm">
                        <!-- Add the bg color to the header using any of the bg-* classes -->
                        <div class="widget-user-header bg-warning">
                            <div class="widget-user-image">
                                <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                            </div>
                            <!-- /.widget-user-image -->
                            <h3 class="widget-user-username">SUPERMIO LA 16</h3>
                            <div class="widget-user-desc">
                                <asp:Label Text="Rango Fecha" ID="info2" runat="server" />
                            </div>
                            <%-- <div class="widget-user-desc">  <asp:LinkButton ID="LinkButton2" runat="server" Text="Buscar" OnClick="Consultala16" class="btn btn-microsoft"> </asp:LinkButton></div>--%>
                        </div>
                        <div class="box-footer p-0">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="gridla16" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                    <RowStyle CssClass="nav-link" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card card-widget widget-user-2 shadow-sm">
                        <!-- Add the bg color to the header using any of the bg-* classes -->
                        <div class="widget-user-header bg-warning">
                            <div class="widget-user-image">
                                <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                            </div>
                            <!-- /.widget-user-image -->
                            <h3 class="widget-user-username">SUPERMIO LA 13</h3>
                            <div class="widget-user-desc">
                                <asp:Label Text="Rango Fecha" ID="info3" runat="server" />
                            </div>
                            <%--     <div class="widget-user-desc">  <asp:LinkButton ID="LinkButton3" runat="server" Text="Buscar" OnClick="Consultala13" class="btn btn-microsoft"> </asp:LinkButton></div>--%>
                        </div>
                        <div class="box-footer p-0">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="Gridla13" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                    <RowStyle CssClass="nav-link" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card card-widget widget-user-2 shadow-sm">
                        <!-- Add the bg color to the header using any of the bg-* classes -->
                        <div class="widget-user-header bg-warning">
                            <div class="widget-user-image">
                                <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                            </div>
                            <!-- /.widget-user-image -->
                            <h3 class="widget-user-username">SUPERMIO VERSALLES</h3>
                            <div class="widget-user-desc">
                                <asp:Label Text="Rango Fecha" ID="info4" runat="server" />
                            </div>
                            <%--<div class="widget-user-desc">  <asp:LinkButton ID="LinkButton4" runat="server" Text="Buscar" OnClick="Consultalaversalles" class="btn btn-microsoft"> </asp:LinkButton></div>--%>
                        </div>
                        <div class="box-footer p-0">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="GridVersalles" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                    <RowStyle CssClass="nav-link" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card card-widget widget-user-2 shadow-sm">
                        <!-- Add the bg color to the header using any of the bg-* classes -->
                        <div class="widget-user-header bg-warning">
                            <div class="widget-user-image">
                                <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                            </div>
                            <!-- /.widget-user-image -->
                            <h3 class="widget-user-username">SUPERMIO CIUDADELA</h3>
                            <div class="widget-user-desc">
                                <asp:Label Text="Rango Fecha" ID="info5" runat="server" />
                            </div>
                            <%-- <div class="widget-user-desc">  <asp:LinkButton ID="LinkButton5" runat="server" Text="Buscar" OnClick="Consultalaciudadela" class="btn btn-microsoft"> </asp:LinkButton></div>--%>
                        </div>
                        <div class="box-footer p-0">
                            <div class="table table-responsive">
                                <asp:GridView runat="server" ID="GridCiudadela" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                    <RowStyle CssClass="nav-link" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            . 
        </form>
    </section>
</asp:Content>
