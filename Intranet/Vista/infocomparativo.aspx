<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="infocomparativo.aspx.cs" Inherits="Intranet.Vista.Documentos.infocomparativo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @media print {
  /* Contenido del fichero print.css */
        .SNIP{
            width:100%;
        }
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <section class="content SNIP" >
    <div class="container bootstrap snippet SNIP" id="SNIP">
         <div class="box box-warning box-solid " runat="server" id="notificacion">
            <div class="box-header with-border">
                <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Notificacion</font></font></h3>

                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                </div>
                <!-- /.box-tools -->
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="txtnotifica" runat="server">Este panel es para notificaciones</label>
            </font></font>
            </div>
            <!-- /.box-body -->
        </div>
    <form  method="post" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
     <div class="margin">
                <div class="box-header with-border">

                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style4">
                                <div class="btn-group" id="botonera">
                                    <button type="button" class="btn btn-success">Opciones</button>
                                    <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only"></span>
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
                                <h3 class="box-title"><b>Comparativo</b></h3>
                            </td>
                          
                            
                        </tr>
                    </table>
                </div>


            </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
         <div class="col-sm-6 ">

                   <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">
                </div>
                <div class="col-sm-6 input-group  " >
                    
                    <input runat="server" id="txtfechafin" type="date" class="form-control" >
                      <span class="input-group-btn">
                          <asp:LinkButton ID="activos" runat="server" Text="Listar Activos" class="btn btn-info btn-flat"
                        OnClick="ListaraDATOS">>
                    </asp:LinkButton></span>
                </div>
                
    <section class="content">
       
        <div class="col-md-12">
            <!-- MAP & BOX PANE -->
           
           
                <!-- /.box-header -->
           
                    <div class="row">
                        
                                <div class="col-md-3">
                                    <!-- DIRECT CHAT -->
                                    <div class="box box-danger ">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">SUPERMIO LA 16</h3>
                                         
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
                                                <asp:GridView ID="Gridsuper16total" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- SUPERMIO 16 -->
                                <div class="col-md-3">
                                    <!-- USERS LIST -->
                                    <div class="box box-danger">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Supermio la 13</h3>

                                        </div>
                                        <!-- /.box-header -->
                                         <div class="box-body">
                                            <div class="table-responsive">

                                                <asp:GridView ID="Gridsuper13" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." >
                                                </asp:GridView>
                                            </div>
                                             <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotal13" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                             </div>
                                        </div>
                                    </div>
                               
                                <!-- SUPERMIO 13 -->
                           
                        <!-- /.col -->
                        <div class="col-md-3">
                            <!-- USERS LIST -->
                            <div class="box box-danger">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Supermio Versalles</h3>

                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                <div class="table-responsive">

                                    <asp:GridView ID="GridsuperVERSA" runat="server" GridLines="None"
                                        CssClass="gvuser1 table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>
                                </div>
                                    <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotalversa" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                            </div>
                           </div>
                        </div>

                        <!-- VERSALLES -->
                        <div class="col-md-3">
                            <div class="box box-danger">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Supermio Ciudadela</h3>

                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                <div class="table-responsive">

                                    <asp:GridView ID="GridViewCiudadela" runat="server" GridLines="None"
                                        CssClass="gvuser1 table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>
                                </div>
                                    <div class="table-responsive">
                                                <asp:GridView ID="GridViewtotalCiudadela" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                            </div>
                           </div>
                        </div>
                    </div>
                    <!-- /.row -->

                    <!-- /.box -->

            </div>
      
    </section>

          </form>
                            </ContentTemplate>

                    </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
                <ProgressTemplate>
                    <div id="backgroud">

                    </div>
                    <div id="Progress">
                        <h6>
                            <p style="text-align:center"><b>Procesando, Espere por favor...</b></p>
                        </h6>
                    </div>
                    
                </ProgressTemplate>
            </asp:UpdateProgress>
        </form>
        </div>
             </section>
</asp:Content>
