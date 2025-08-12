<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="ListaNovedades.aspx.cs" Inherits="Intranet.Vista.ListaNovedades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Incapacidades</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Ingreso de Novedades</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                        <li class="breadcrumb-item active">Recursos Humanos</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
    <form runat="server">
        <section class="content">
            <div class="col-md-6">
                <div class="card card-dark">
                    <div class="card-header">
                        <h3 class="card-title">Mas...</h3>
                    </div>
                    <div class="card-body">

                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Empleado:</span>
                                <select runat="server" id="selectempleado" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                            </div>

                        </div>
                            
                        <div class="row">
                            <div class="col-4">
                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon">Fecha:</span>
                                        <input id="txtfechaini" runat="server" type="date" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="input-group">
                                    <span class="input-group-addon">Horas:</span>
                                    <input type="number" name="Horas" value="1" class="form-control" />
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="form-group">


                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="radio1" data-has-listeners="true" wfd-id="id39">
                                        <label class="form-check-label">Diurno</label>
                                    </div>
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="radio1" checked="" data-has-listeners="true" wfd-id="id40">
                                        <label class="form-check-label">Nocturno</label>
                                    </div>



                                </div>
                            </div>
                           
                        </div>
                       
                           
                            <div class="form-group has-feedback">

                                <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Novedad" rows="4"></textarea>
                            </div>
                      
                        </div>
                    <div class="card-footer">
                        <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-app" >
                             <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                        </asp:LinkButton>
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
            </div>
        </section>
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
