<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Inactivos.aspx.cs" Inherits="Intranet.Inactivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <link rel="stylesheet" type="text/css" href="estilo_imprimir.css" media="print">
    <div class="register-box-body" id="contenido">
       <form method="post" runat="server"> 
           <asp:LinkButton ID="btnNuevo" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="CreaActivo_Click"  style="height: 34px">
                <span aria-hidden="true" class="fa fa-magic"> Guardar</span>
                </asp:LinkButton>
           
         <asp:LinkButton ID="guardar" runat="server" Text="Nuevo" CssClass="btn btn-toolbar" OnClick="mostrarmenuModelo">
                <span aria-hidden="true" class="fa fa-cubes"> Nuevo Modelo</span>
                </asp:LinkButton>
           <asp:LinkButton ID="LinkButton1" runat="server" Text="Nuevo" CssClass="btn btn-toolbar" OnClick="mostrarmenuFabricante">
                <span aria-hidden="true" class="fa  fa-industry"> Nuevo Fabricante</span>
                </asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" Text="Nuevo" CssClass="btn btn-toolbar" OnClick="mostrarmenucategoria">
                <span aria-hidden="true" class="fa  fa-spinner"> Nueva Categoria</span>
                </asp:LinkButton>
        <p class="login-box-msg"><b>Registro Activos</b></p>
        <div class="row">
            
                <div class="col-xs-6">

                    <div class="form-group has-feedback">
                        <input id="txtserial" runat="server" type="text" class="form-control" placeholder="Serial" >
                        <span class="fa fa-list-alt form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input id="txtnombre" runat="server" type="text" class="form-control" placeholder="Nombre" >
                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                    </div>
                
                    <div class="form-group has-feedback">
                       
                        <select runat="server" id="Select1" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                          
                       </div>
                   
                    <div class="form-group has-feedback">
                        <select runat="server" id="Select2" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                       
                    </div>
                    <div class="form-group has-feedback">
                        <select runat="server" id="Select3" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>

                    </div>

                </div>
                <div class="col-xs-6">
                    <div class="form-group has-feedback">
                        <input id="txtcoment" runat="server" type="text" class="form-control" placeholder="Comentarios" >
                        <span class="glyphicon glyphicon-comment form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <select runat="server" id="Select4" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                    </div>
                    <div class="form-group has-feedback">
                        <input id="txtfechacompra" runat="server" type="date" class="form-control" >
                        <span class="glyphicon glyphicon-calendar form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input id="txtvalor" type="number" runat="server" class="form-control" placeholder="Valor" >
                        <span class="fa fa-dollar form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">

                        <input id="txtgarantia" type="number" runat="server" min="1" class="form-control" placeholder="Tiempo garantia (Meses)" >
                        <span class="fa fa-calendar form-control-feedback"></span>

                    </div>

                </div>
                <div id="botones_barner"> 
                <div class="col-xs-3" id="a1">
                   
                </div>
                <div class="col-xs-3">
                 
                </div>
                <div class="col-xs-3">

                    <asp:Button ID="Button1" runat="server" class="btn btn-block btn-info btn-sm " Text="Listar Activo" />

                </div>

                <div class="col-xs-3">

                    <asp:Button ID="Button4" runat="server" class="btn btn-block btn-info btn-sm " Text="Limpiar" />
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
               
                  <div class="modal modal-info fade in" id="Nuevomodelo" style="display: block;" runat="server">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                    <h4 class="modal-title">Nuevo modelo</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Modelo del Activo</p>
                                    <input id="Textmodelo" runat="server" type="text" class="form-control" placeholder="Nombre Modelo" >
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button7" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenuModelo" />
                                   
                                    <asp:Button ID="Button5" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaMOdelo_Click" />

                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
             <div class="modal modal-success fade in" id="NuevoFabricante" style="display: block;" runat="server">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                    <h4 class="modal-title">Nuevo Fabricante</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Fabricante del Activo</p>
                                    <input id="Text1" runat="server" type="text" class="form-control" placeholder="Nombre Fabricante" >
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button2" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenufabrica" />
                                   
                                    <asp:Button ID="Button3" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaFabrica_Click" />

                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                       <div class="modal modal-warning fade in" id="NuevoCategoria" style="display: block;" runat="server">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                    <h4 class="modal-title">Nueva Categoria</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Categoria del Activo</p>
                                    <input id="Text2" runat="server" type="text" class="form-control" placeholder="Nombre Categoria" >
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button8" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="ocultarmenucategoria" />
                                   
                                    <asp:Button ID="Button9" runat="server" class="btn btn-outline" Text="Guardar" OnClick="CreaCategoria_Click" />

                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
            </div>
            </form>
        </div>
       
        <div class="alert alert-danger" id="alerta" runat="server">
            <strong>Error al Guardar!</strong> El activo con el serial indicado Ya existe!.
        </div>
        <label id="txtaviso" runat="server" class="danger"></label>
    
<script type="text/javascript">
            function esconde_div() {
                var elemento = document.getElementById("Nuevomodelo");
                elemento.style.display = 'none';
            }

            function visible_div() {
                var elemento = document.getElementById("Nuevomodelo");
                elemento.style.display = 'block';
            }

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
