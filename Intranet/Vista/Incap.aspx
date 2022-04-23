<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Incap.aspx.cs" Inherits="Intranet.Vista.Incap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Incapacidades</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <section class="content">
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title"><b>Reporte Incapacidades</b></h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                    </div>
                </div>
                <div class="box-footer">

                    <div class="col-md-4">
                        <!-- /articulo a mantenimiento-->

                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Empleado:</span>
                                <select runat="server" id="selectempleado" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>

                            </div>

                        </div>

                        <div class="form-group has-feedback">

                            <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Comentarios" rows="6"></textarea>
                        </div>


                    </div>
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Fecha Inicial:</span>
                                <input id="txtfechaini" runat="server" type="date" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Fecha Final:</span>
                                <input id="txtfechafin" runat="server" type="date" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                         <div class="btn-group">
                        <asp:LinkButton ID="btnnuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnnuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardar_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                        </asp:LinkButton>
                    </div>
                    <asp:LinkButton ID="btnnuevoempleado" runat="server" Text="Volver" class="btn btn-app" OnClick="btnnuevoempleado_Click">
                                    <i aria-hidden="true"  class="fa fa-user-circle"></i>Nuevo Empleado
                    </asp:LinkButton>
                        <a href="1.aspx" class="btn btn-app botonesx">
                                            <i aria-hidden="true" class="fa fa-home"></i>Inicio
                                        </a>
                    </div>
                </div>
            </div>
            <div class="modal modal-warning fade in" id="Nuevotercero" style="display: block;" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                            </div>
                            <h4 class="modal-title">Nuevo Empleado</h4>
                        </div>
                        <div class="modal-body">
                            <p>Detalles Empleado</p>
                            <input id="txtccoNit" runat="server" type="text" class="form-control" placeholder="Cedula o Nit">
                            <input id="txtNomb" runat="server" type="text" class="form-control" placeholder="Nombre Completo">
                            <input id="txtdir" runat="server" type="text" class="form-control" placeholder="Direccion">
                            <input id="txttel" runat="server" type="number" class="form-control" placeholder="Telefono">
                            <input id="txtCiudad" runat="server" type="text" class="form-control" placeholder="Ciudad- Ingrese el #1 ">
                            <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="Correo Electronico">
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Btncancela" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="Btncancela_Click" />

                            <asp:Button ID="btnguardaempleado" runat="server" class="btn btn-outline" Text="Guardar" OnClick="btnguardaempleado_Click" />

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </section>

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
