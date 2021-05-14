<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="HojaVida_empleados.aspx.cs" Inherits="Intranet.Vista.HojaVida_empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #backgroud {
            position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: #f0f8f0;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 100000;
        }
        #progress{
            position:fixed;
            top:40%;
            left:40%;
            height:20%;
            width:20%;
            z-index:100001;
            background-color:#FFFFFF;
            border:1px solid gray;
            background-image:url('\dist\img\loading.Gif');
            background-repeat:no-repeat;
            background-position:center;
        }
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
        <section class="content">
            <div class="box box-warning box-solid notifica" runat="server" id="excepcion">
                <div class="box-header with-border">
                    <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excp Controlada</font></font></h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="error" runat="server"></label>
            </font></font>
                </div>
                <!-- /.box-body -->
            </div>
            <div class="box box-success box-solid notifica" runat="server" id="notificacion">
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
              <label id="txtnotifica" runat="server"></label>
            </font></font>
                </div>
                <!-- /.box-body -->
            </div>
            <div class="fondoblanco">
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="header">
                        <div class="box box-default">
                            <div class="box-header with-border">

                                <div class="form-group has-feedback" style="width: 80%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">Hoja de Vida Empleados</span>
                                        <select runat="server" id="Select1" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                                            <asp:LinkButton ID="botonbusca" runat="server" Text="Buscar" OnClick="botonbusca_Click" class="btn btn-success btn-flat">
                                             
                                            </asp:LinkButton>
                                        </span>



                                    </div>

                                </div>

                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>

                                </div>
                            </div>
                            <div class="box-footer" id="footer" runat="server">
                                <div class="fondoblanco">
                                    <div class="col-md-5">
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
                                    <div class="col-md-5">
                                        <!-- /observaciones-->
                                        <div class="form-group has-feedback">
                                            <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Comentarios" rows="7"></textarea>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group has-feedback">
                                            <asp:LinkButton ID="btncancelar" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelar_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                            </asp:LinkButton>
                                        </div>
                                   </div>


                                </div>
                            </div>


                        </div>
           

            </li>
                     <!-- Optionally, you can add icons to the links -->
            <li class="treeview">
                <a id="admin" runat="server" href="#"><i class="fa fa-gears"></i>
                    <span>Activos a Cargo</span>

                </a>
                <ul class="treeview-menu">
                    <li class="treeview" id="panel">
                        <div class="table-responsive fondoblanco">
                             <asp:GridView ID="GridViewactivos_cargo" runat="server" GridLines="None"
                                        CssClass=" table gvuser table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>
                        </div>


                    </li>
                    <!-- /.sidebar-menu -->
                </ul>
            </li>
            <li class="treeview">
                <a href="admin2" runat="server" hreflang="#"><i class="fa fa-plus-circle"></i>
                    <span>Incapacidades</span>
                </a>
                <ul class="treeview-menu" id="ulnovedad" runat="server">
                    <li class="treeview">
                        <div class="box box-default">
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


                        </div>


                      

                    </li>
                </ul>

            </li>





            </ul>
            </div>
        </section>
    </form>
     <script type="text/javascript">

         function ComprobarAcentos(inputtext) {
             if (!inputtext) return false;
             if (inputtext.value.match('[á,é,í,ó,ú]|[Á,É,Í,Ó,Ú]')) {
                 alert('No se permiten acentos en la casilla');
                 inputtext.value = '';
                 inputtext.focus();
                 return true;
             }
             return false;
         }

</script>
    <script>
        $(document).ready(function () {
            $('#gvusersd').DataTable({
             
        });

        $(document).ready(function () {
            var table = $('.gvusersd').DataTable();

            
            });

    </script>
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
