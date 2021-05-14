<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Aprova_Manteni.aspx.cs" Inherits="Intranet.Vista.Aprova_Manteni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
          <asp:scriptmanager runat="server"></asp:scriptmanager>
        <div class="box">
            <div class="box-header with-border">
                <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <Strong><h3 class="box-title"><b>ordenes de trabajo</b></h3></Strong>
                                    
                                </button>
                </div>
        </div>
            <div class="box-body">
              

                 <div class="fade in" id="view_detalles" runat="server" role="dialog"  >
            <div class="modal-dialog" style="width:90%;">
                <div class="modal-content" >
                    <div class="modal-header">
                        <b class="box-title">Detalles</b>
                     <input type="text" id="txtnumeromanteni" disabled name="name" value="" runat="server" style="width:40px;"/> -
                <input type="text" id="txtnumeroOrden" disabled name="name" value="" runat="server" style="width:40px;"/> -
                <input type="text" id="txtnumeroAsg" disabled name="name" value="" runat="server" style="width:40px;"/> 
                <div class="box-tools pull-right">
                    <input id="Txtfechamantenimiento" class="box-tools" runat="server" type="date" />
                  
                </div>
                           


                        </div>
                  
                    <div class="modal-body">

                          <div class="row">
                    <div class="col-md-6">
                     
                        <!-- /realizado por-->
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Tercero:</span>
                                <select runat="server" id="Selectproveedor" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                </select>
                            </div>


                        </div>
                            <div class="form-group">
                        <div class="input-group margin">
                            <div class="input-group-btn">
                                <button type="button" class="btn btn dropdown-toggle" data-toggle="dropdown" >
                                    Clase de Mant.
                                </button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton ID="btnselectelectrico" runat="server" Text="Elect." OnClick="btnselectelectrico_Click" >
                                            <span aria-hidden="true" class="fa fa-bolt">Electrico</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li><asp:LinkButton ID="btnobracivil" runat="server" Text="Elect." OnClick="btnobracivil_Click" >
                                            <span aria-hidden="true" class="fa fa-bolt">Obra Civil</span>
                                        </asp:LinkButton>

                                    </li>
                                    <li><asp:LinkButton ID="btnornamentacion" runat="server" Text="Elect." OnClick="btnornamentacion_Click" >
                                            <span aria-hidden="true" class="fa fa-bolt">Ornamentacion</span>
                                        </asp:LinkButton>

                                    </li>
                                    <li><asp:LinkButton ID="btnPintura" runat="server" Text="Elect." OnClick="btnPintura_Click" >
                                            <span aria-hidden="true" class="fa fa-bolt">Pintura</span>
                                        </asp:LinkButton>

                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <asp:LinkButton ID="btnactivosfijos" runat="server" Text="Insertar" OnClick="btnactivosfijos_Click" >
                                <span aria-hidden="true" class="fa  fa-bolt">Activos Fijos</span>
                                        </asp:LinkButton></li>
                                </ul>
                            </div>

                            <input type="text" id="clasetrabajo" runat="server" disabled class="form-control" style="width: 100%">
                        </div>
                    </div>

                        
                    <div class="form-group" id="Selectarticulodiv" runat="server">
                        <div class="input-group">
                            <span class="input-group-addon">Activo:</span>
                        <select runat="server" id="Selectarticulo" class="js-example-basic-single" name="state" style="width: 100%">
                        </select>
                        </div>
                        
                    </div>

                    <div class="input-group">
                        <span class="input-group-addon">Tipo Mantenimiento:</span>
                        <select runat="server" id="SelecttipoMant" class="js-example-basic-single" name="state" style="width: 100%">
                            <option value="P">Preventivo</option>
                            <option value="C">Correctivo</option>
                        </select>
                    </div>
                     <div class="form-group">
                        <input id="txtRepuestos" runat="server" type="text" onKeyUp="this.value=this.value.toUpperCase();" placeholder="Repuestos Utilizados" class="form-control" />
                    </div>
                    </div>
                    <div class="col-md-6">
                        <!-- /OBSERVACION GENERAL -->
                        <div class="form-group ">
                            <textarea id="OBSERVACIONG" runat="server" placeholder="Trabajo Realizado" rows="2" onKeyUp="this.value=this.value.toUpperCase();" class="form-control" disabled="disabled"></textarea>
                        </div>
                        
                    <div class="form-group ">
                        <textarea id="txtobserva" runat="server" onKeyUp="this.value=this.value.toUpperCase();" placeholder="Descripcion del Mantenimiento" class="form-control"></textarea>

                    </div>
                   
                    <div class="form-group has-feedback">
                        <input id="Textgarantia" runat="server" type="number" placeholder="Meses de Garantia" class="form-control" />
                    </div>
                    </div>
                    
                </div>
                        
                        
                    </div>
                    <div class="modal-footer">
                        
                       <div class="btn-group">
                            <asp:LinkButton ID="btnguardar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardar_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Aprobacion
                            </asp:LinkButton>
                        </div>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
                </div>
            <!-- /.modal-dialog -->
                 <div class="table-responsive">
                                        <asp:GridView ID="GridView_Ord_Work" runat="server" GridLines="None"
                                            CssClass="gvuser table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridView_Ord_Work_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />

                                            </Columns>
                                        </asp:GridView>
                            </div>
                 
                           
            
        </div> 
               
            </div>

        <label id="txtahora" runat="server"></label>

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
