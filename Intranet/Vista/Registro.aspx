<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Intranet.Vista.config.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" runat="server">
        <section class="content">

            <div class="box box-default">

                <div class="box-header with-border">
                    <h3 class="box-title"><b>Registro Usuarios</b></h3>



                    <div class="box-tools pull-right">
                        <asp:LinkButton ID="btnvolver" runat="server" Text="Volver" class="btn btn-success">
                                    <span aria-hidden="true"  class="fa fa-arrow-left"></span>
                        </asp:LinkButton>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>

                    </div>

                </div>
                <div class="box-footer">
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <input id="txtcc" runat="server" type="number" class="form-control" placeholder="No Documento de Indentidad">
                            <span class="fa fa-list-alt form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtname1" runat="server" type="text" class="form-control" placeholder="Primer Nombre">
                            <span class="glyphicon glyphicon-user form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtname2" runat="server" type="text" class="form-control" placeholder="Segundo Nombre">
                            <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtapellido1" runat="server" type="text" class="form-control" placeholder="Primer apellido">
                            <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtapellido2" runat="server" type="text" class="form-control" placeholder="Segundo apellido">
                            <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <input id="txttel" type="number" runat="server" class="form-control" placeholder="Telefono">
                            <span class="fa fa-phone-square form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtdir" runat="server" type="text" class="form-control" placeholder="Direccion">
                            <span class="fa fa-location-arrow form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <select id="Select" runat="server" class=" selectpicker form-control">
                                <option>Sexo</option>
                                <option value="F">Femenino</option>
                                <option value="M">Masculino</option>
                            </select>
                        </div>
                        <div class="form-group has-feedback">

                            <select runat="server" id="Select4" class="js-example-basic-single" name="state" style="width: 100%">
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group has-feedback">
                            <div class="btn-group">
                                <asp:LinkButton ID="btnnuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnnuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnguardanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardanuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btncancelanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelanuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                </asp:LinkButton>

                            </div>
                            <div class="btn-group">
                                <asp:LinkButton ID="btneditar" runat="server" Text="Volver" class="btn btn-app" OnClick="btneditar_Click">
                                    <i aria-hidden="true"  class="fa fa-edit"></i>Editar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnguardaeditar" runat="server" Text="Volver" class="btn btn-app" OnClick="validarUsuario_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btncancelareditar" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelareditar_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                </asp:LinkButton>
                            </div>
                            <asp:LinkButton ID="btningreso" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelareditar_Click">
                                    <i aria-hidden="true"  class="fa fa-lock"></i>Gestion Ingreso
                                </asp:LinkButton>
                            <asp:LinkButton ID="btnborra" runat="server" class="btn btn-app " Text="Insertar">
                                     <i aria-hidden="true" class="fa  fa-recycle"></i>Borrar Usuario
                            </asp:LinkButton>

                        </div>
                    </div>




                </div>
            </div>
            <div class="box box-default">

                <div class="box-header with-border">
                    <h3 class="box-title"><b>Lista</b></h3>
                     <div class="box-tools pull-right">
                    
                        <asp:LinkButton ID="listausuarios" runat="server" Text="Volver" class="btn btn-success" OnClick="listausuarios_Click">
                                    <span aria-hidden="true"  class="fa fa-info-circle">Listar</span>
                        </asp:LinkButton>
                       
                  
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>

                    </div>

                </div>
                <div class="box-footer">
                   <div class="box-body">

                                <div>
                                    <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None" class="display compact"
                                        CssClass="gvuser table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" />

                                        </Columns>

                                    </asp:GridView>

                                </div>
                            </div>
                    
                    
                    </div>




             
            </div>
        </section>
    </form>
    <script type="text/javascript">


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
