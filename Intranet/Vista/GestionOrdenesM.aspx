<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="GestionOrdenesM.aspx.cs" Async="true" Inherits="Intranet.Vista.GestionOrdenesM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8">  
     <section class="content">
        <div class="container bootstrap snippet">
    <form runat="server" method="post">
        <%-- <div class="box box-warning box-solid notifica" runat="server" id="excepcion">
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
        <div class="box box-warning box-solid " runat="server" id="notificacion">
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
              <label id="txtnotifica" runat="server">Recuerde verificar la lista de SMS enviados</label>
            </font></font>
            </div>
            <!-- /.box-body -->
        </div>--%>
        <asp:scriptmanager runat="server"></asp:scriptmanager>

        <div class="box">
             <div class="box-header with-border">
                            <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <b><h3 class="box-title">Pendientes Asignar</h3></b>
                                    
                                </button>
                            </div>
                            <div class="box-tools pull-right">
                               <asp:LinkButton ID="btnbuscarpendientes" runat="server" Text="Volver" class="form-control" OnClick="btnbuscarpendientes_Click">
                                                    <i aria-hidden="true"  class="fa fa-search"></i>
                                            </asp:LinkButton>
                              
                            </div>
                        </div>
                  <div class="box-body">
                          <div class="table-responsive">
                                        <asp:GridView ID="GridViewpendientes" runat="server" GridLines="None"
                                            CssClass="gvuser table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewpendientes_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />

                                            </Columns>
                                        </asp:GridView>
                            </div>
                    </div>

                                </div>
            
            <div class="box">
                   <div class="box-header with-border">
                            <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <h3 class="box-title">Asignados y pendientes por ejecutar la labor</h3>
                                </button>
                            </div>
                            <div class="box-tools pull-right">
                                            <asp:LinkButton ID="btnbuscarasignados" runat="server" Text="Volver" class="form-control" OnClick="btnbuscarasignados_Click">
                                                    <i aria-hidden="true"  class="fa fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                        </div>
                <div class="box-body">
                     <div class="table-responsive">
                                        <asp:GridView ID="GridViewasignados" runat="server" GridLines="None"
                                            CssClass=" table table-striped table-bordered text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>
                                           </div>
                </div>

            </div>
           

              <asp:updatepanel runat="server" id="UpdatePanel1">
             <ContentTemplate>
        <div class="box">
                  <div class="box-header with-border">
                            <div class=" pull-left">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="" data-original-title="Click Aqui">
                                    <h3 class="box-title">Agregar Novedades y Finalizar Mantenimiento</h3>

                                </button>
                                  <input type="text" id="Textidacta" disabled name="name" value="" runat="server" style="width: 40px;" />
                                        <input id="fechaacta" class="box-tools" runat="server" type="date" disabled />
                            </div>
                            
                        </div>

                
             <div class="box-body">
                 <div class="col-md-6">
                      <input runat="server" id="Selectordenes" class="form-control" type="text" name="state" disabled tyle="width: 100%" />
                  <div class="form-group">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">Tercero:</span>
                                                        <input runat="server" id="Selectproveedor" class="form-control" name="state" disabled style="width: 100%" />

                                                    </div>


                                                </div>
                 </div>
                 
                  <div class="col-md-4">
                                                <!-- /OBSERVACION GENERAL -->
                                                <div class="form-group ">
                                                    <textarea id="OBSERVACIONG" runat="server" placeholder="Trabajo Realizado" rows="3" disabled onkeyup="this.value=this.value.toUpperCase();" class="form-control"></textarea>
                                                </div>
                                            </div>
                   <div class="col-md-2">

                                                <div class="btn-group">
                                                    <a href='javascript:window.print(); void 0;' class="btn btn-app">
                                                        <i aria-hidden="true" class="disabled fa fa-print"></i>Imprimir
                                                    </a>
                                                </div>
                                            </div>
                 
             </div>
             <div class="fade in" id="view_detalles" runat="server" role="dialog"  >
            <div class="modal-dialog" style="width:90%;">
                <div class="modal-content" >
                    <div class="modal-header">
                        <b class="box-title">Detalles del Mantenimiento</b>
                        <div class="box-tools pull-right">
                           <input type="text" disabled runat="server" id="txtid" class="box-tools" name="name" value="" />
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-6">

                    
                        <div class="input-group margin">
                             <input type="text" id="clasetrabajo" runat="server" disabled class="form-control" style="width: 100%" >
                           
                           
                        </div>
                  
                    
                        <div class="input-group"  id="Selectarticulodiv" runat="server">
                            <span class="input-group-addon">Activo:</span>
                            <input type="text"  runat="server" id="Selectarticulo" style="width: 100%" disabled name="name"/>
                      
                        </div>
                        
                    <div class="input-group">
                        <span class="input-group-addon">Tipo Mantenimiento:</span>
                         <input type="text"  runat="server" id="SelecttipoMant" style="width: 100%" disabled name="name" value="" />
                       
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Garantia:</span>
                        <input id="Textgarantia" runat="server" type="number" placeholder="Meses de Garantia" class="form-control" disabled />
                    </div>
                </div>
                
                <div class="col-md-6">
                    <!-- /tipo de mantenimiento-->
                    <div class="input-group">
                        <span class="input-group-addon">Detalles:</span>
                        <textarea id="txtobserva" runat="server" onKeyUp="this.value=this.value.toUpperCase();" placeholder="Descripcion del Mantenimiento" class="form-control" disabled></textarea>

                    </div>
                     <div class="input-group">
                        <span class="input-group-addon">Valor Mano de Obra:</span>
                        <input id="Textmano_obra" runat="server" type="number" Value="0"  class="form-control" />
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Repuestos:</span>
                        <input id="txtRepuestos" runat="server" type="text" onKeyUp="this.value=this.value.toUpperCase();" placeholder="Repuestos Utilizados" class="form-control" disabled />

                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Valor Repuestos:</span>
                        <input id="Valor_Repuestos" runat="server" type="number" Value="0"  class="form-control" />
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">Numero Externo:</span>
                        <input id="txtnumeroexterno_act" runat="server" type="text" placeholder="#" class="form-control" />
                    </div>
                </div>

                        <div class="col-md-12">
                            <div class="table-responsive">
                                <asp:Button ID="cancel" runat="server" class="btn btn-app" Text="Cancelar" OnClick="buttoncancel" />
                                <asp:Button ID="consultar" runat="server" class="btn btn-app" Text="Consultar" OnClick="consultar_Click" />
                                <asp:GridView ID="GridViewdetalles_preaprob" runat="server" GridLines="None"
                                    CssClass=" table table-striped table-bordered text-sm"
                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalles_preaprob_SelectedIndexChanged">
                                    <Columns>

                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Seleccion" SelectImageUrl="~/dist/img/edit.png" ControlStyle-CssClass="c" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                            


                       <%-- <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>Sms:</b></span>
                                 <textarea id="txtsms" class="form-control" runat="server" >En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://bit.ly/2Bgdf8X</textarea>
                            </div>
                        </div>--%>
                        
                        
                    </div>
                    <div class="modal-footer">
                        
                        <asp:LinkButton ID="btnactualizar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnactualizar_Click" >
                              Actualizar
                        </asp:LinkButton>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div> 
              <div class="table-responsive">
                                                            <asp:GridView ID="GridViewlista" runat="server" GridLines="None"
                                                                CssClass="table table-striped table-bordered  text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewlista_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
            
        </div>
           </ContentTemplate>
            </asp:updatepanel>  
           
           
                
                    
            <asp:updateprogress id="UpdateProgress1" runat="server" associatedupdatepanelid="UpdatePanel1">
                <ProgressTemplate>
                    <div id="backgroud">

                    </div>
                    <div id="Progress">
                        <h6>
                            <p style="text-align:center"><b>Espere por favor...</b></p>
                        </h6>
                    </div>
                    
                </ProgressTemplate>
            </asp:updateprogress>
            <div class="modal modal-info fade in" id="panelAsignaciones" style="display: block;" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Asignacion Ordenes de Trabajo</h4>
                    </div>
                    <div class="modal-body">
                        <p>
                            <label id="lbltarea" runat="server">#</label>
                        </p>
                        <div class="input-group">
                            <span class="input-group-addon">ID Orden: </span>
                            <input id="textidorden" runat="server" type="text" class="form-control" disabled>
                        </div>

                        <div class="form-group has-feedback">
                            <div class="input-group">
                                <span class="input-group-addon">Proveedor</span>
                                <select runat="server" id="SelectProveedores" class="js-example-basic-single" name="state" style="width: 100%">
                                </select>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="btnnuevoproveedor" runat="server" Text="Nuevo" class="btn btn-success btn-flat">+</asp:LinkButton>
                                </span>
                            </div>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">Programar Fecha</span>
                            <input id="txtfecha" runat="server" min="" type="date" class="form-control">
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button7" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="Button7_Click" />

                        <asp:Button ID="Button5" runat="server" class="btn btn-outline" Text="Guardar" OnClick="Button5_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
           <div class="modal modal-info fade in" id="panelEditardetalles" style="display: block;" runat="server">
            <div class="modal-dialog" style="width: 70%;">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Detalles De Items</h4>
                    </div>
                    <div class="modal-body">
                        <p>#</p>
                                <div class="box" id="insert">
            <div class="box-header with-border">
                <h3 class="box-title"> <b>Insertar Datos</b></h3>
                
                
            </div>
            <div class="box-body">
                
                

            </div>
        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btncancela_detalles" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancela_detalles_Click" />

<%--                        <asp:Button ID="Button2" runat="server" class="btn btn-outline" Text="Guardar" OnClick="Button5_Click" />--%>
                         

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
