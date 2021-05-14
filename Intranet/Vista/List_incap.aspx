<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="List_incap.aspx.cs" Inherits="Intranet.Vista.List_incap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .fondoblanco {
            margin-right: 2px;
            background: #CCD1D1;
            border: solid;
        }

        .menuabierto {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form method="post" runat="server">
    <div class="page-content">
        <div class="container">
            <div class="row ">
                <div class="box box-success">

                    <div class="box-body">
                        <ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#home">Principal</a></li>
                                <li><a data-toggle="tab" href="#listado">Listado</a></li>
                                <li><a data-toggle="tab" href="#novedades">Novedades</a></li>
                            </ul>
                          <div class="row">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="home">
                                         
                                    <div class="col-md-4">
                                        <!-- /articulo a mantenimiento-->

                                        <div class="form-group has-feedback">
                                            <input runat="server" id="txtidempleado" type="text" style="width: 12%" />
                                            <select runat="server" id="Selectempleado" class="js-example-basic-single" name="state" style="width: 85%">
                                            </select>
                                        </div>
                                        <div class="form-group has-feedback">

                                            <input id="txtfechaini" runat="server" type="date" class="form-control" />
                                            <span aria-hidden="true" class="fa fa-hand-stop-o form-control-feedback"></span>
                                        </div>
                                        <div class="form-group has-feedback">
                                            <input id="txtfechafin" runat="server" type="date" class="form-control" />
                                            <span aria-hidden="true" class="fa fa-shopping-cart form-control-feedback"></span>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <!-- /observaciones-->
                                        <div class="form-group has-feedback">
                                            <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Comentarios" rows="7"></textarea>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group has-feedback">

                                            <div class="btn-group">
                                                <asp:LinkButton ID="btneditar" runat="server" Text="Volver" class="btn btn-app" OnClick="btneditar_Click">
                                    <i aria-hidden="true"  class="fa fa-edit"></i>Editar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardar_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btncancelar" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelar_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                                </asp:LinkButton>
                                            </div>
                                            <asp:LinkButton ID="btnestados" runat="server" Text="Volver" class="btn btn-app" OnClick="btnestados_Click">
                                    <i aria-hidden="true"  class="fa fa-list-ul"></i>Novedades
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnborra" runat="server" class="btn btn-app " Text="Insertar" OnClick="btnborra_Click">
                                     <i aria-hidden="true" class="fa  fa-recycle"></i>Borra Fila
                                            </asp:LinkButton>

                                        </div>


                                    </div>
                                    </div>
                                    <div class="tab-pane" id="listado" >
                                          <div class="col-md-12">
                                    <div class="box">
                                        <div class="box-body">
                                           <div class="table-responsive fondoblanco">
                                              <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None" class="display "
                                              CssClass="gvuser table table-hover table-responsive text-sm"
                                             CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                             <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" />

                                             </Columns>

                                    </asp:GridView>
                                </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                    <div class="tab-pane" id="novedades">
                                        <div class="input-group">
                                        <span class="input-group-addon">Estado: </span>
                                        <select class="form-control" runat="server" id="selectestado">
                                            <option value="TRANSCRIBIR">TRANSCRIBIR</option>
                                            <option value="LIQUIDADA">LIQUIDADA</option>
                                            <option value="POR PAGAR">POR PAGAR</option>
                                            <option value="POR REELIQUIDAR">POR REELIQUIDAR</option>
                                            <option value="NO RECONOCIDA">NO RECONOCIDA</option>
                                            <option value="SOLICITAR PAGO">SOLICITAR PAGO</option>
                                            <option value="NO PROCEDE">NO PROCEDE</option>
                                            <option value="PENDIENTE REPORTE">PENDIENTE REPORTE</option>
                                        </select>
                                    </div>
                                    <div class="input-group">
                                        <span class="input-group-addon">Observaciones</span>
                                        <input type="text" runat="server" id="txtnovedadincapacidad" class="form-control">
                                        <span class="input-group-addon">
                                            <asp:LinkButton ID="btninsertarnovedad" runat="server" Text="Insertar" OnClick="btninsertarnovedad_Click">
                                    
                                            </asp:LinkButton></span>
                                    </div>

                                    <asp:GridView ID="GridViewNovedades" runat="server" GridLines="None" class="display "
                                        CssClass=" table table-hover table-responsive text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" CancelText="Seleccion" />

                                        </Columns>

                                    </asp:GridView>   
                                    </div>
                                </div>
                          </div>
                    </div>
                </div>
            </div>

          
        </div>
    </div>
 
       
    </form>
    <script>


        $('#btnProcesar').on('click', function () {

        });

        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');
                    btnProcesar.hidden = false;
                    return "No hay resultados - agregar Nuevo ->"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });



    </script>
</asp:Content>
