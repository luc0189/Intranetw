<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Intranet.Vista.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
        

        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title"><b>Gestion de ingreso</b></h3>
            </div>
            <div class="box-body">
                <div class="row">

                    <div class="col-md-8">
                        <!-- /CEDULA DEL USUARIO-->
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Empleado:</span>
                                <select runat="server" id="select_cc" class="select2-container--focus form-control">
                                </select>
                            </div>
                        </div>
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Usuario:</span>
                                <input id="txtusuario" runat="server" type="text" class="form-control" placeholder="Usuario">
                                <span class="glyphicon glyphicon-user form-control-feedback"></span>
                            </div>
                        </div>
                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Contraseña:</span>
                                <input id="txtpass" runat="server" type="password" class="form-control" placeholder="Contraseña">
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                        </div>

                        <label id="txtaviso" runat="server" class="danger"></label>
                    </div>
                    <div class="col-md-4">
                        <div class="box">

                            <div class="box-body">
                                <a href="1.aspx" class="btn btn-app">
                                    <i aria-hidden="true" class="fa fa-home"></i>Inicio
                                </a>
                                <asp:LinkButton ID="LinkButton7" runat="server" Text="Volver" class="btn btn-app" OnClick="Button1_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title"><b>Listar </b></h3>
                            <div class="box-body">
                                <div class="table-responsive">
                                <asp:GridView ID="Gridempleados" runat="server" GridLines="None"
                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                </asp:GridView>
                            </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>



        </div>



    </form>
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
        </div>
            </section>
    <script type="text/javascript">


        $('#btnProcesar').on('click', function () {

        });

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
