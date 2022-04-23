<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="VentasXhora_articulo.aspx.cs" Inherits="Intranet.Vista.VentasXhora_articulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Ventas/Hora Articulo</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form  method="post" runat="server">
        <div class="margin">
                <div class="box-header with-border">

                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style4">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-success">Opciones</button>
                                    <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only">Toggle Dropdown</span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                       
                                        <li>
                                            <a href='javascript:window.print(); void 0;'>
                                            <span aria-hidden="true" class="disabled fa fa-print"> Imprimir</span>
                                            </a></li>
                                        
                                    </ul>

                                </div>
                            </td>
                              <td style="width:20px"></td>
                            <td class="auto-style4">
                                <h3 class="box-title"><b>Ventas por Hora</b></h3>
                            </td>
                          
                            
                        </tr>
                    </table>
                </div>


            </div>
         <div class="col-xs-6">
          <div class="input-group input-group-sm">
                <input type="date" runat="server" ID="txtfechaini" class="form-control">
                <input type="text" runat="server" ID="txtidarticulo" class="form-control">
              
                    <span class="input-group-btn">
                        <asp:LinkButton ID="activcos" runat="server" Text="Listar Activos" class="btn btn-info btn-flat-sm"
                    OnClick="ListaraDATOS">Buscar
                </asp:LinkButton>
                     
                    </span>
              </div>
              </div>    
    <section class="content">
         
       <div class="box-body">
           <div class="row">
              
             </div>
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
                <div class="box-body no-padding">

                    <div class="row">
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- DIRECT CHAT -->
                                    <div class="box box-danger direct-chat direct-chat-danger">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">SUPERMIO LA 16</h3>

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

                                                <asp:GridView ID="Gridsuper16" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>

                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotal" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                  
                                        </div>
                                        <!-- /.box-body -->

                                        <!-- /.box-footer-->
                                    </div>
                                    <!--/.direct-chat -->

                                </div>
                                <!-- SUPERMIO 16 -->
                                <div class="col-md-6">
                                    <!-- USERS LIST -->
                                    <div class="box box-danger">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Supermio la 13</h3>

                                            <div class="box-tools pull-right">
                                                <!-- <span class="label label-danger"></span>-->
                                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                    <i class="fa fa-minus"></i>
                                                </button>

                                                <button type="button" class="btn btn-box-tool" data-widget="remove">
                                                    <i class="fa fa-times"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="table-responsive">

                                            <asp:GridView ID="Gridsuper13" runat="server" GridLines="None"
                                                CssClass="gvuser2d table table-striped table-bordered text-sm"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                            </asp:GridView>

                                        </div> 
                                        <!-- tabla supermio 13 -->
                                        <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotal13" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                        <!-- /.box-body -->

                                        <!-- /.box-footer -->
                                    </div>
                                    <!--/.box -->

                                </div>
                                <!-- SUPERMIO 13 -->

                            </div>
                        </div>

                       <!-- /.col -->
                        <div class="col-md-4">
                            <!-- USERS LIST -->
                            <div class="box box-danger">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Supermio Versalles</h3>

                                    <div class="box-tools pull-right">
                                        <!-- <span class="label label-danger"></span>-->
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove">
                                            <i class="fa fa-times"></i>
                                        </button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="table-responsive">

                                    <asp:GridView ID="GridsuperVERSA" runat="server" GridLines="None"
                                        CssClass="gvuser4 table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>

                                </div>
                                   <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotalversa" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                <!-- /.box-body -->

                                <!-- /.box-footer -->
                            </div>
                            <!--/.box -->

                        </div>
                        <!-- VERSALLES -->
                    </div>
                   
                </div>

                <div class="table-responsive">

                    <asp:GridView ID="GridViewDatos" runat="server" GridLines="None"
                        CssClass="gvuser table table-striped table-bordered text-sm"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                    </asp:GridView>

                </div>


            </div>
            
            </div>
     
    </section>
       </form>
</asp:Content>
