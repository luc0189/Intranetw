<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Kardex.aspx.cs" Inherits="Intranet.Vista.Kardex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | kardex</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="estilo_imprimir.css" media="print">
    <script type="text/javascript">
        function miFuncion() {
            var fecha;
            fecha = document.getElementById("#fecha_entrada").value;
            if (fecha = "") {
                alert("El campo del nombre esta vacío");
                document.getElementById("fecha_entrada").focus();
                return false;
            } else {
                document.getElementById('#Ingreso').style.display = 'block';
            }
        }
    </script>
     <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
        <div class="margin">
        </div>
        <div class="box">
            <div class="box-body" id="contenido">
                <div class="box-header with-border ">
                    <h3 class="box-title"><b>Kardex Consumibles</b></h3>
                </div>
                <div class="col-md-3">
                    <div class="box box-danger">
                        <div class="box-body -info">
                            <div class="small-box bg-red-active">
                                <div class="inner">
                                    <asp:LinkButton runat="server" Text="Volver" data-toggle="modal" data-target="#Ingreso" class="btn btn-app">
                                 <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo Ingreso
                                    </asp:LinkButton>
                                    <p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-android-arrow-down"></i>
                                </div>
                                <a href="#" role="button" data-toggle="modal" data-target="#Ingreso" class=" small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Nueva Entrada</font></font></a>
                                <%-- <input type="button" 
onclick="miFuncion()" 
value="Activar Función">--%>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="box box-success">

                        <div class="box-body">
                            <div class="small-box bg-green">
                                <div class="inner">
                                    <asp:LinkButton runat="server" Text="Volver" class="btn btn-app" role="button" data-toggle="modal" data-target="#translados">
                              <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo Traslado
                                    </asp:LinkButton>
                                    <p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-reply"></i>
                                </div>
                                <a href="#" role="button" data-toggle="modal" data-target="#translados" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Traslados</font></font></a>
                            </div>


                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="box box-warning">

                        <div class="box-body">
                            <div class="small-box bg-orange">
                                <div class="inner">
                                    <asp:LinkButton runat="server" Text="Volver" class="btn btn-app" role="button" data-toggle="modal" data-target="#Consumo">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo Consumo
                                    </asp:LinkButton>

                                    <p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-ios-arrow-back"></i>
                                </div>
                                <a href="#" role="button" data-toggle="modal" data-target="#Consumo" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Consumo</font></font></a>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="box">

                        <div class="box-body">
                            <a href="1.aspx" class="btn btn-app">
                                <i aria-hidden="true" class="fa fa-home"></i>Inicio 
                            </a>
                            <asp:LinkButton ID="LinkButton7" role="button" data-toggle="modal" data-target="#NuevaUbicacion" runat="server" Text="Volver" class="btn btn-app" >
                                    <i aria-hidden="true"  class="fa fa-plane"></i>Nueva Ubic.
                            </asp:LinkButton>

                        </div>
                    </div>
                </div>

            </div>
            <div class="box box-danger ">
                <div class="box-header with-border">
                    <h3 class="box-title"><b>Saldos...</b></h3>
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
                        <asp:GridView ID="Gridsaldos" runat="server" GridLines="None"
                            CssClass="gvuser table table-striped table-bordered text-sm"
                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>



        
       
        <div class="modal modal-info fade in" id="NuevaUbicacion"  role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Nueva Ubicacion</h4>
                    </div>
                    <div class="modal-body">
                        <p>Nombre Ubicacion</p>
                        <input id="TextUbicacion" runat="server" type="text" class="form-control" placeholder="Nombre Ubicacion">
                    </div>
                    <div class="modal-footer">
                           <asp:Button ID="Button5" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaUbicacion_Click" />
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="modal modal-danger fade in" id="Ingreso" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <b class="box-title">Ingresar Datos</b>
                        <div class="box-tools pull-right">
                            <input type="date" name="fecha" id="fecha_entrada" runat="server" class=" form-control" style="width: 100%" />
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>ARTICULO:</b></span>
                                <select runat="server" id="Selectarticulo_entrada" class="js-example-basic-single form-control" name="state">
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>BODEGA:</b></span>
                                <select runat="server" id="selectbodega_entrada" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>CANTIDAD:</b></span>
                                <input id="cantEntrada" runat="server" type="number" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>DETALLES:</b></span>
                                <input id="txtObserva" runat="server" type="text" placeholder="Observacion" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="btncancelaingreso" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancelaingreso_Click" />--%>

                        <asp:Button ID="btnIngreso" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btnIngreso_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="modal modal-success fade in" id="translados" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">

                        <b class="modal-title">Traslados</b>
                        <div class="box-tools pull-right">
                            <input type="date" name="fecha" id="fecha_translados" runat="server" class=" form-control" style="width: 100%" />
                        </div>

                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>ARTICULO:</b></span>
                                <select runat="server" id="Selectarticulotranslado" class="js-example-basic-single" name="state" style="width: 100%;"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>BODEGA DE SALIDA</b></span>
                                <select runat="server" id="selectbodega_salida_trans" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>BODEGA DE ENTRADA:</b></span>
                                <select runat="server" id="selectbodega_entrada_trans" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>CANTIDAD:</b></span>
                                <input id="cant_translado" runat="server" type="number" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>DETALLES:</b></span>
                                <input id="detalle_translado" runat="server" type="text" placeholder="Observacion" class="form-control" />
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Btncancelatranslados" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="Btncancelatranslados_Click" />--%>

                        <asp:Button ID="btntranslado" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btntranslado_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="modal modal-warning fade in" id="Consumo"  role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <b class="modal-title">Consumos</b>
                        <div class="box-tools pull-right">
                            <input type="date" name="fecha" id="fecha_consumo" runat="server" class=" form-control" style="width: 100%" />
                        </div>

                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>ARTICULO:</b></span>
                                <select runat="server" id="Selectarticulo_consumo" class="js-example-basic-single" name="state" style="width: 100%" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>BODEGA:</b></span>
                                <select runat="server" id="selectbodega_consumo" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                            </div>

                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>CANTIDAD:</b></span>
                                <input id="cant_consumo" runat="server" type="number" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>DETALLES:</b></span>
                                <input id="detalle_consumo" runat="server" type="text" placeholder="Observacion" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:Button ID="btnagregaconsumo" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btnagregaconsumo_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
       
    </form>
        </div>
         </section>
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
