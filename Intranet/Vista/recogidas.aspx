<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="recogidas.aspx.cs" Inherits="Intranet.Vista.recogidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Recogidas</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Recogidas

        <small>Panel Principal</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="Menu.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
            <li class="active"><a href="Menu.aspx">Ventas</a></li>
            <li class="active">Recogidas</li>
        </ol>
    </section>
    
     <form action=" " runat="server" method="post">
       
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-danger">
                        <div class="box-header with-border">
                            <strong>Actualizado cada 60s</strong>
                            <div class="box-tools">
                                <strong>Recogidas de Efectivo</strong>
                            </div>
                        </div>
                        
                              <div class="box-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="box">
                                        <div class="box-body">
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:gridview id="GridViewnovedades" runat="server" gridlines="None" OnSelectedIndexChanged="GridViewnovedades_SelectedIndexChanged"
                                                        
                                                        cssclass=" table gvuser table-striped table-bordered text-sm"
                                                        cellspacing="0" emptydatatext="No se encontraron Registros con los parametros indicados.">
                                                  <Columns>
                                                     <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="../dist/img/ok.png" />
                                                                            </Columns>
                                    </asp:gridview>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="box">
                                        <div class="box-header">
                                            <strong>10 - 20</strong>
                                        </div>
                                        <div class="box-body">
                                            <div class="form-group has-feedback">
                                            <div class="input-group">
                                                <span class="input-group-addon"><b>Sala de Ventas:</b></span>
                                                <select id="selectccosto"  runat="server" required="required" class="js-example-basic-single" style="width:100%">
                                                    <option value="000001">SUPERMIO LA 16</option>
                                                    <option value="000002">SUPERMIO LA 13</option>
                                                    <option value="000004">SUPERMIO VERSALLES</option>
                                                    <option value="000005">SUPERMIO CIUDADELA</option>

                                                </select>
                                               
                                            </div>
                                        </div>
                                            <div class="form-group has-feedback" id="div_tercero">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><b>Empleado:</b></span>
                                                    <input type="text" id="txtnombres" runat="server" name="name" class="form-control" required="required" value="" disabled="disabled" />
                                                  
                                                </div>
                                            </div>
                                           <div class="form-group has-feedback">
                                            <div class="input-group">
                                                <span class="input-group-addon"><b>Valor Recogido:</b></span>
                                                <input id="txtvalo" required="required" runat="server" type="text"  class="txtvalo form-control" >
                                                
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-footer">
                                        <div class="form-group has-feedback">
                                            <asp:LinkButton ID="btnenviar" runat="server" Text="Enviar" OnClick="btnenvia_Click" class="btn btn-success btn-flat">
                                             <i class="glyphicon glyphicon-repeat"></i>Enviar
                                </asp:LinkButton>
                                            <asp:LinkButton ID="Actualiza" runat="server" Text="Actualiza" OnClick="Actualiza_Click" class="btn btn-lg">
                                             
                                </asp:LinkButton>
                              
                                        </div>
                                    </div>
                                        </div>
                                        

                                    </div>
                                    
                                </div>
                            </div>

                        </div>
                          
                      
                    </div>
                    <div class="box-footer">
                        Pagina Online cada 60s
                    </div>
                </div>
            </div>
       
        
    </form>


    
</asp:Content>
