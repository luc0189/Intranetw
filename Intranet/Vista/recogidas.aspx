<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="recogidas.aspx.cs" Inherits="Intranet.Vista.recogidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Recogidas</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Recogidas</h1>

        
    </section>
    
     <form action=" " runat="server" method="post">
       
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-danger">
                        <div class="card-header with-border">
                          
                            <div class="box-tools">
                                <strong>Recogidas de Efectivo</strong>
                            </div>
                        </div>
                        
                              <div class="card-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="card">
                                        <div class="card-body">
                                            
                                                        <div class="table table-responsive">
                                                            <asp:GridView ID="GridViewnovedades" runat="server" GridLines="None" OnSelectedIndexChanged="GridViewnovedades_SelectedIndexChanged"
                                                                CssClass=" table gvuser table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                                <Columns>
                                                                    <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="../dist/img/ok.png" />
                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>
                                              
                                               

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong>10 - 20</strong>
                                        </div>
                                        <div class="card-body">
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
                                        <div class="card-footer">
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
                        <div class="card-footer">
                            Pagina Online cada 60s
                        </div>
                        </div>
                          
                      
                    </div>
                    
                </div>
            </div>
       
        
    </form>


    
</asp:Content>
