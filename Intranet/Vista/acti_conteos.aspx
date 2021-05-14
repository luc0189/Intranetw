<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="acti_conteos.aspx.cs" Inherits="Intranet.Vista.acti_conteos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content">
        <div class="container bootstrap snippet">
            <section class="content-header">
                <h1>Gestion Inventario
        <small>Panel Principal</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Menu.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                    <li class="active"><a href="Menu.aspx">Inventario</a></li>
                    <li class="active">Gestion de Inventario</li>
                </ol>
            </section>

            <form method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <div class="box-body">

                    <div class="col-md-4">

                        <input runat="server" id="txtidconteo" type="text" class="form-control " placeholder="ID CONTEO" label="ID CONTEO">
                    </div>

                    <div class="col-md-8">
                        <asp:LinkButton ID="guardar" runat="server" Text="Insertar" CssClass="btn btn-warning" OnClick="guardar_Click">
                <span aria-hidden="true" class="fa fa-lock">Cerrar</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="Adicionar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="Adicionar_Click">
                <span aria-hidden="true" class="fa fa-unlock"> Abrir</span>
                        </asp:LinkButton>
                        <a class="btn btn-danger" data-toggle="modal" href="#modallimpiaconteos"><i class="fa fa-trash-o"></i>Limpiar</a>

                        <a class="btn btn-success" data-toggle="modal" href="#modaloperaciones"><i class="fa fa-plus-circle"></i>Operaciones</a>

                        <%-- <asp:LinkButton ID="btnmasOpera" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnmasOpera_Click">
                <span aria-hidden="true" class="fa fa-plus-circle"> Operaciones</span>
                    </asp:LinkButton>--%>
                    </div>

                </div>

                <br />


                <div class="row">

                    <!-- PROGRESS BAR -->
                    <div class="col-md-6">

                        <div class="box box" style="background-color: #343a40; color: white;">
                            <div class="box-header">
                                <div class="box-title">
                                    <span class="badge badge-danger">Conteo 1 =
                                                      <label id="txtcactivos" runat="server">&nbsp; </label>
                                    </span>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="progress active">
                                    <div class="progress-bar progress-bar-success progress-bar-striped" style="width: 1%" id="bar1" runat="server"></div>
                                </div>
                                <span class="progress-description">
                                    <label id="r" runat="server"></label>
                                </span>

                                <a class="btn btn-outline" data-toggle="modal" href="#modal2">Activar Conteos</a>

                                <a class="btn btn-outline" data-toggle="modal" href="#modalcierratodos">Cerrar Todos</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box box" style="background-color: #343a40; color: white;">
                            <div class="box-header">
                                <div class="box-title">
                                    <span class="badge badge-danger">Conteo 2 =
                                                       <label id="txtactivosdos" runat="server">&nbsp; </label>
                                    </span>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="progress active">
                                    <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" id="Bar2" runat="server" />

                                </div>
                                <span class="progress-description">
                                    <label id="txtpor2" runat="server"></label>
                                </span>


                                <a class="btn btn-outline" data-toggle="modal" href="#Mactivaconteos2">Activar Conteos</a>
                                <a class="btn btn-outline" data-toggle="modal" href="#modalcierratodos2">Cerrar Conteos</a>
                            </div>
                        </div>

                    </div>

                </div>



                <div class="row">

                    <div class="row">

                        <!-- DIRECT CHAT -->
                        <div class="col-md-6">
                            <div class="box box" style="background-color: #343a40; color: white">
                                <div class="box-body">
                                    <div class="table table-responsive">
                                        <asp:GridView ID="GridViewabiertos1" runat="server" GridLines="None" CssClass="gv3 table table-striped table-bordered text-sm" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>." AllowCustomPaging="True" CellPadding="4" ForeColor="#333333">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <!-- small box -->
                            <div class="box box" style="background-color: #343a40; color: white">
                                <div class="box-body">
                                    <div class="table table-responsive">
                                        <asp:GridView ID="GridViewconteos2" runat="server" GridLines="None"
                                            CssClass="gv2 table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>." ForeColor="#333333">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <!-- SUPERMIO 16 -->
                </div>
                <!-- CERRAR Y ABRIR TODO -->


                <div class="modal modal-danger fade in" id="modallimpiaconteos" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Limpiar Modulo</h4>
                            </div>
                            <div class="modal-body">
                                <p>Esta seguro de eliminar el contenido de este conteo?</p>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Btncancelalimpiar" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="Button4_click" />
                                  <asp:Button ID="Btnlimpiar" runat="server" class="btn btn-outline" Text="Aceptar" OnClick="si_Click" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>

                </div>
                <div class="modal modal-info fade in" id="modal2" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Activar modulos</h4>
                            </div>
                            <div class="modal-body">
                                <p>Desea Activar todos los modulos del Primer Grupo de conteo?</p>

                            </div>
                            <div class="modal-footer">

                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Aceptar" CssClass="btn btn-outline-primary" OnClick="Button3_click">
                                             <span aria-hidden="true" class="fa fa-lock"> Aceptar</span>
                                </asp:LinkButton>


                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>

                </div>
                <div class="modal modal-info fade in" id="modalcierratodos" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Cerrar modulos</h4>
                            </div>
                            <div class="modal-body">
                                <p>Desea Cerrar todos los modulos del Primer Grupo de conteo?</p>

                            </div>
                            <div class="modal-footer">

                                <asp:LinkButton ID="LinkButton2" runat="server" Text="Aceptar" CssClass="btn btn-outline-primary" OnClick="btncierra1_Click">
                                             <span aria-hidden="true" class="fa fa-lock"> Aceptar</span>
                                </asp:LinkButton>


                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>

                </div>
                <div class="modal modal-info fade in" id="modaloperaciones" role="dialog">
                    <div class="modal-dialog" style="width: 580px">
                        <div class="modal-content ">
                            <div class="modal-header">
                                <div class="box-tools pull-right">

                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">X</span></button>
                                </div>

                                <h4 class="modal-title">Mas Operaciones en Bloque</h4>
                            </div>
                            <div class="modal-body">

                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group"><b>Desde</b></span>
                                        <input id="txtIdInicio" runat="server" type="text" class="form-control" placeholder="ID CONTEO" required>
                                        <span class="input-group"><b>Hasta</b></span>
                                        <input id="txtIdFin" runat="server" type="text" class="form-control" placeholder="ID CONTEO" required>
                                    </div>
                                </div>
                                <div class="row">
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="btnabrirRango" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnabrirRango_Click">
                                                <span aria-hidden="true" class="fa fa-unlock"></span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btncerrarRango" runat="server" Text="Insertar" CssClass="btn btn-warning" OnClick="btncerrarRango_Click">
                                             <span aria-hidden="true" class="fa fa-lock"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon"><b>Fecha</b></span>
                                        <input type="date" class="form-control" id="txtfecha" runat="server" name="name" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="btnactualizafecha" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnactualizafecha_Click">
                                             <span aria-hidden="true" class="fa fa-pencil-square-o"> </span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>

                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon"><b>bodega</b></span>
                                        <select id="selecbodegaid" runat="server" class="form-control">
                                            <option value="011">Supermio la 16</option>
                                            <option value="012">Supermio la 13</option>
                                            <option value="014">Supermio Versalles</option>
                                            <option value="041">Averias y cambios Versalles</option>
                                            <option value="030">Centro de Distribucion</option>
                                            <option value="040">Averias y Cambios Cendis</option>
                                            <option value="018">Bodega la 18</option>
                                            <option value="015">Supermio Ciudadela</option>

                                        </select>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="btnactualizabodega" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnactualizabodega_Click">
                                             <span aria-hidden="true" class="fa fa-pencil-square-o"> </span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <div class="modal modal-info fade in" id="Mactivaconteos2" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">X</span></button>
                                <h4 class="modal-title">Activar modulos</h4>
                            </div>
                            <div class="modal-body">
                                <p>Desea Activar todos los modulos del segundo Grupo de conteo?</p>

                            </div>
                            <div class="modal-footer">

                                <asp:LinkButton ID="btnactivaconteos2" runat="server" Text="Aceptar" CssClass="btn btn-outline-primary" OnClick="Btnactivaconteos2">
                                             <span aria-hidden="true" class="fa fa-lock"> Aceptar</span>
                                </asp:LinkButton>


                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>

                </div>
                <div class="modal modal-info fade in" id="modalcierratodos2" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">X</span></button>
                                <h4 class="modal-title">Cerrar modulos</h4>
                            </div>
                            <div class="modal-body">
                                <p>Desea Cerrar todos los modulos del Segundo Grupo de conteo?</p>

                            </div>
                            <div class="modal-footer">

                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Aceptar" CssClass="btn btn-outline-primary" OnClick="Btncierra2_Click">
                                             <span aria-hidden="true" class="fa fa-lock"> Aceptar</span>
                                </asp:LinkButton>


                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>

                </div>
            </form>
        </div>
    </section>
</asp:Content>
