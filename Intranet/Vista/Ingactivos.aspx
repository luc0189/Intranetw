<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Ingactivos.aspx.cs" Inherits="Intranet.Vista.Ingactivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        *, *:after, *:before {
            margin: 0;
            padding: 0;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        #contenedor_carga {
            background-color: rgba(254,240,245,0.9);
            height: 100%;
            width: 100%;
            position: fixed;
            -webkit-transition: all 1s ease;
            -o-transition: all 1s ease;
            transition: all 1s ease;
            z-index: 10000;
        }

        #carga {
            border: 15px solid #ccc;
            border-top-color: #f4266a;
            border-top-style: groove;
            height: 100px;
            width: 100px;
            border-radius: 100%;
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            margin: auto;
            -webkit-animation: girar 0.5s linear infinite;
            -o-animation: girar 0.5s linear infinite;
            animation: girar 0.5s linear infinite;
        }

        @keyframes girar {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
 
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Registro de Activos</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Activos Fijos</li>
                            <li class="breadcrumb-item active">ActivoID: <asp:Label Text="text" runat="server" name="name" id="textid" /></li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </section>
        <section class="content">
        <div class="container-fluid">
            <form method="post" runat="server">
            
              
                <div class="row ">
                    <div class="col-md-6">
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title">Activos</h3>
                            </div>
                            <div class="card-body">
                                    <div class="form-group row">
                                        <label class="col-sm-3 col-form-label" for="txtserial">
                                            Serial</label>
                                        <input type="text" id="txtserial" runat="server" class="col-sm-9 form-control is-valid"  placeholder="Serial ...">
                                    </div>
                                     <div class="form-group row">
                                        <label class="col-sm-3 col-form-label" for="txtnombre" >
                                            Nombre</label>
                                        <input type="text" id="txtnombre" runat="server" class="col-sm-9 form-control is-valid"  placeholder="Nombre">
                                    </div>
                                     <div class="form-group row">
                                                <label for="txtcoment" class="col-sm-3 col-form-label">
                                                    <i class="fas fa-pen"></i>Observaciones:</label>
                                                    <input id="txtcoment" runat="server" type="text" class="col-sm-9 form-control is-valid" placeholder="Comentarios">
                                                    
                                                </div>
                                     <div class="form-group row">
                                                <label for="txtgarantia" class="col-sm-3 col-form-label">
                                                    <i class="fas fa-check"></i>Garantia:</label>
                                                 <input id="txtgarantia" type="number" runat="server" min="1" class="col-sm-9 form-control is-valid" placeholder="Tiempo garantia (Meses)">
                                                    
                                            </div>
                                     <div class="form-group row">
                                                <label for="txtfechacompra" class="col-sm-3 col-form-label">
                                                    <i class="fas fa-calendar-day"></i>Fecha Compra:</label>
                                                
                                                    <input id="txtfechacompra" runat="server" type="date" class="col-sm-9 form-control is-valid">
                                                   
                                            </div>
                                     <div class="form-group row">
                                                <label for="txtvalor" class="col-sm-3 col-form-label">
                                                    <i class="fas fa-dollar-sign"></i>Valor:</label>
                                           
                                                    <input id="txtvalor" type="number" runat="server" class="col-sm-9 form-control is-valid" placeholder="Valor">
                                            </div>
                              
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card card-dark">
                            <div class="card-header">
                                <h3 class="card-title">Mas</h3>
                            </div>
                            <div class="card-body">
                               
                                      <div class="form-group row">
                                                <label for="Select1" class="col-sm-3 col-form-label">Modelo:<a class="btn btn-social-icon " data-toggle="modal" href="#Nuevomodelo"><i class="fa fa-plus-circle"></i></a></label>
                                         
                                                <div class="input-group col-sm-9">
                                                    <select runat="server" id="Selectmodelo" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                                    </select>
                                                  
                                                </div>
                                            </div>
                                      <div class="form-group row">
                                                <label for="Select2" class="col-sm-3 col-form-label">Fabricante: <a class="btn btn-social-icon " data-toggle="modal" href="#NuevoFabricante"><i class="fa fa-plus-circle"></i></a></label>
                                                <div class="input-group col-sm-9">
                                                    <select runat="server" id="SelectFabricante" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                                    </select>
                                                    
                                                </div>
                                            </div>
                                      <div class="form-group row">
                                                <label for="Select3" class="col-sm-3 col-form-label">Ctg.:   <a class="btn btn-social-icon " data-toggle="modal" href="#NuevoCategoria"><i class="fa fa-plus-circle"></i></a></label>
                                                <div class="input-group col-sm-9">

                                                    <select runat="server" id="SelectCategoria" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                                    </select>
                                                   
                                                </div>
                                            </div>
                                      <div class="form-group row">
                                                <label for="Select3" class="col-sm-3 col-form-label">Linea:    <a class="btn btn-social-icon " data-toggle="modal" href="#NuevaLinea"><i class="fa fa-plus-circle"></i></a></label>
                                                <div class="input-group col-sm-9">

                                                    <select runat="server" id="Selectlinea" class="js-example-basic-single form-control" name="state" >
                                                    </select>
                                                   
                                                </div>
                                            </div>
                                      <div class="form-group row">
                                                <label for="Select4" class="col-sm-3 col-form-label">Tercero: <a class="btn btn-social-icon " data-toggle="modal" href="#Nuevotercero"><i class="fa fa-plus-circle"></i></a></label>
                                                <div class="input-group col-sm-9">
                                                    <select runat="server" id="SelectTercero" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                                    </select>
                                                    
                                                </div>
                                            </div>
                               
                            </div>

                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-dark">
                            <div class="card-header ">
                                 <asp:LinkButton ID="btnNuevo" runat="server" Text="Volver" class="btn btn-dark" OnClick="btnNuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                                                        </asp:LinkButton>
                                <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-dark" OnClick="CreaActivo_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                                        </asp:LinkButton>
                                 <div class="btn-group">

                                                        <asp:LinkButton ID="btneditar" runat="server" Text="Volver" class="btn btn-dark" OnClick="btneditar_Click">
                                    <i aria-hidden="true"  class="fa fa-pencil"></i>Editar
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnactualizar" runat="server" Text="Volver" class="btn btn-dark" OnClick="btnactualizar_Click">
                                    <i aria-hidden="true"  class="fa fa-retweet"></i>Actualizar
                                                        </asp:LinkButton>

                                                    </div>
                                <a class="btn btn-social-icon btn-dark" data-toggle="modal" href="#Buscador"><i class="fa fa-search"></i></a>
                            </div>
                            <div class="card-body">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                 <div class="table-responsive">
                                                                <asp:GridView ID="GridViewNovedades" runat="server" GridLines="None" class="display "
                                                                    CssClass=" gvuser table table-hover table-responsive text-sm"
                                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_RowEditing">
                                                                    <Columns>
                                                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" CancelText="Seleccion" />

                                                                    </Columns>

                                                                </asp:GridView>
                                                            </div>
                            </div>
                        </div>

                    </div>
                   
                </div>

                <div class="modal modal-info fade in" id="modal" style="display: block;" runat="server">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Registro Exitoso</h4>
                            </div>
                            <div class="modal-body">
                                <p>Desea guardar la cantidad en Inventario del Activo?</p>
                                <input id="serialcantidad" runat="server" type="text" class="form-control" placeholder="Serial Producto" required>
                                <input id="canti" runat="server" type="number" placeholder="Cantidad" class="form-control" value="1" required>
                            </div>
                            <div class="modal-footer">

                                <asp:Button ID="Button6" runat="server" class="btn btn-outline" Text="Guardar" OnClick="si_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>

                <div class="modal modal-warning fade in" id="Nuevomodelo" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Nuevo modelo</h4>
                            </div>
                            <div class="modal-body">
                                <p>Modelo del Activo</p>
                                <input id="Textmodelo" runat="server" type="text" class="form-control" placeholder="Nombre Modelo">
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button5" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaMOdelo_Click" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal modal-success fade in" id="NuevoFabricante" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Nuevo Fabricante</h4>
                            </div>
                            <div class="modal-body">
                                <p>Fabricante del Activo</p>
                                <input id="Textfabricante" runat="server" type="text" class="form-control" placeholder="Nombre Fabricante">
                            </div>
                            <div class="modal-footer">
                                <%--<asp:Button ID="Button2" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenufabrica" />--%>

                                <asp:Button ID="Button3" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaFabrica_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal modal-warning fade in" id="NuevoCategoria" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Nueva Categoria</h4>
                            </div>
                            <div class="modal-body">
                                <p>Categoria del Activo</p>
                                <input id="Textcategoria" runat="server" type="text" class="form-control" placeholder="Nombre Categoria">
                                <input id="TxtVidaUtil" runat="server" type="text" class="form-control" placeholder="Vida Util">
                            </div>
                            <div class="modal-footer">

                                <asp:Button ID="Button9" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaCategoria_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal modal-warning fade in" id="NuevaLinea" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Nueva Linea</h4>

                            </div>
                            <div class="modal-body">
                                <p>Categoria del Activo</p>
                                <input id="Text1" runat="server" type="text" class="form-control" placeholder="Nombre Linea">
                            </div>
                            <div class="modal-footer">

                                <asp:Button ID="Btnguardalinea" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaCategoria_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal modal-warning fade left" id="Buscador" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Buscador</h4>
                            </div>
                            <div class="modal-body">
                                <p>Activos Fijos</p>
                                <div class="input-group">
                                    <input runat="server" type="text" id="searh_serial" name="seriales" class="form-control" placeholder="serial">
                                    <span class="input-group-btn">

                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Nuevo" class="btn btn-success btn-flat" OnClick="listadoactivosserial">Buscar</asp:LinkButton>

                                    </span>
                                </div>
                                <div class="input-group">
                                    <input id="buscadortxtnombre" runat="server" type="text" class="form-control" placeholder="Nombre">
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Nuevo" class="btn btn-success btn-flat" OnClick="listadoactivonombre">Buscar</asp:LinkButton>
                                    </span>
                                </div>


                            </div>

                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal modal-warning fade in" id="Nuevotercero" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">Nuevo tercero</h4>
                            </div>
                            <div class="modal-body">
                                <p>Detalles Tercero</p>
                                <input id="txtccoNit" runat="server" type="text" class="form-control" placeholder="Cedula o Nit">
                                <input id="txtNomb" runat="server" type="text" class="form-control" placeholder="Nombre o Razon Social">
                                <input id="txtdir" runat="server" type="text" class="form-control" placeholder="Direccion">
                                <input id="txttel" runat="server" type="number" class="form-control" placeholder="Telefono">
                                <input id="txtCiudad" runat="server" type="text" class="form-control" placeholder="Ciudad- Ingrese el #1 ">
                                <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="Correo Electronico">
                            </div>
                            <div class="modal-footer">


                                <asp:Button ID="Button11" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaTercero_Click" />

                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
            </form>
        </div>
    </section>
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
    <div class="box box-success box-solid notifica" runat="server" id="notificacion" role="dialog">
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

    <div class="alert alert-danger" id="alertaid" runat="server">
        <strong>Error al Guardar!</strong> El activo con el serial indicado Ya existe!.
    </div>
    <label id="txtaviso" runat="server" class="danger"></label>

    


    <script type="text/javascript">

        $('#btnProcesar').on('click', function () {

        });
        function mostrar() {
            document.getElementById('#Ingreso').style.display = 'block';
        };
        function validaringreso() {
            if (document.getElementById('#fecha_entrada') = " ") {
                document.getElementById('#Ingreso').style.display = 'block';
            } else {
                document.getElementById('#').style.display = 'block';
            }
        };
        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');

                    return "No hay resultados - Clic en Nuevo"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });
        var lenguaje_espanol = {
            "sProcessing": "Procesando...",
        }


    </script>
</asp:Content>
