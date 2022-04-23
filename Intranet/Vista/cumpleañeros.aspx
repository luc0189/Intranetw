<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="cumpleañeros.aspx.cs" Async="true" Inherits="Intranet.Vista.cumpleañeros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <head>
        <title>LCSystem 3 | Cumpleañeros</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
    <form method="post" runat="server">
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
        </div>
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <asp:updatepanel runat="server" id="UpdatePanel1">
             <ContentTemplate>
        
        <div class="box">
            <div class="box-header with-border">
                
                <h1 class="box-title"><b>Cumpleaños Clientes y Empleados SUPERMIO S.A.S</b></h1>
              
               
            </div>
            <div class="box-body">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-header">
                            
                            <div  id="Ingreso" runat="server" role="dialog" >
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <b class="box-title">Cuerpo del SMS</b>
                        <div class="box-tools pull-right">
                           
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>Para: </b></span>
                               <label id="txtnombre" runat="server"></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>Tel: </b></span>
                               <label id="txttel" runat="server"></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><b>Sms:</b></span>
                                 <textarea id="txtsms" class="form-control" runat="server" >En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://hab.me/vvMcI9g</textarea>
                            </div>
                        </div>
                        
                        
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="btncancelaingreso" runat="server" class="btn btn-outline" Text="Cancelar" OnClick="btncancelaingreso_Click" />--%>
                         <asp:Button ID="cancel" runat="server" class="btn btn-app" Text="Cancelar" OnClick="buttoncancel" />
                        <asp:Button ID="Sendsms" runat="server" class="btn btn-app" Text="Enviar" OnClick="ButtonSend" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div> 
                                <div class="box-body">
                                   
                                    <div class="table-responsive">
                                         <asp:gridview runat="server" id="Gridviewcumpleañeros" gridlines="None"
                                        cssclass=" table table-striped dysplay" onselectedindexchanged="LinkButton1_Click" emptydatatext="No se encontraron Registros con los parametros indicados.">
                                             <Columns>
  
                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../dist/img/iconfinder_sms_43332.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Envio SMS" >

                                              
                                              </asp:CommandField>
                                            

                                        </Columns>
                                  </asp:gridview>
                                    </div>
                                   
                                    
                                </div>
                        </div>
                    </div>

                </div>
                
               
                <div class="col-md-12">
                    <div class="box">
                         <div class="box-header ">
                                        <label>SMS enviados</label>
                         </div>
                        <div class="box-body">
                            <div class="table-responsive">
                        <asp:gridview id="gridviewsms_send" runat="server" gridlines="None" CssClass=" table table-striped dysplay">

                        </asp:gridview>
                    </div>
                        </div>
                    </div>
                    
                    
                </div>
                             
                  
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
                            <p style="text-align:center"><b>Enviando SMS, Espere por favor...</b></p>
                        </h6>
                    </div>
                    
                </ProgressTemplate>
            </asp:updateprogress>
    </form>
        </div>
         </section>
</asp:Content>
