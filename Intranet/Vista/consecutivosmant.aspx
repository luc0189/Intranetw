<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="consecutivosmant.aspx.cs" Inherits="Intranet.Vista.consecutivosmant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
          <section class="content">
    <div class="container bootstrap snippet">
        <div class="row">
             <div class="row">
               
                    <div class=" box box-success">
                        <div class="box-header">
                            <label>Consecutivos Mantenimientos</label>
                            
                            <div class="box-tools pull-right">
                       <input type="text" id="txtNacta" name="name" value="" runat="server" disabled="disabled" />
                    </div>
                        </div>
                    </div>
                     
              
                
            </div>
            <div class="row">
                <div class="box box-default">
                    <div class="box-body">
                       
                        <div class="col-sm-6">
                              <div class="form-group row">
                                  <label for="txtfecha" class="col-sm-3">Fecha:</label>
                                <div class="input-group col-sm-9">
                                
                         <input id="txtfecha" type="date" name="name" runat="server" class="form-control" />
                             </div>

                           
                             </div>
                         <div class="form-group row">
                             <label for="Select1" class="col-sm-3">Tercero:</label>
                                <div class="input-group col-sm-9">
                                    
                                    <select runat="server" id="Select1" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                                <span class="fa fa-users form-control-feedback"></span>
                                </div>
                                
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group has-feedback">
                                <textarea id="txtobserva" runat="server" style="width: 100%;" placeholder="Comentarios" rows="4" disabled=""></textarea>
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-sm-12">
                                 <div class="center-block">
                                     <div class="btn-group">
                        <a href="1.aspx" class="btn btn-default fa fa-home"><b> Inicio</b></a>
                        <asp:LinkButton ID="btnNuevo" runat="server" Text=" Guardar" CssClass="fa fa-save btn btn-default" OnClick="updateacta">
                        <b> Guardar</b>
                        </asp:LinkButton>
                        <a href="Mod/Edicion_Mant.aspx" class="btn btn-default fa fa-list-alt" target="_blank"> <b> Editar Items</b></a>
                        
                      </div>
                                 </div>
                                 
                             </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-12">

                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title"><b>Mantenimientos</b></h3>
                        </div>
                        <div class="box-body">
                            <!-- Date dd/mm/yyyy -->
                            <div>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridViewactas" runat="server" GridLines="None" class="display compact"
                                        CssClass="gvuser table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />

                                        </Columns>

                                    </asp:GridView>
                                </div>

                            </div>


                        </div>
                        <!-- /.box-body -->
                    </div>

                </div>
                        </div>
                            
                    </div>
                </div>
            </div>
           

            </div>
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
