<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Rep_Kardexg.aspx.cs" Inherits="Intranet.Vista.Rep_Kardexg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">  
    <form  method="post" runat="server">
        <div class="row">
               
                    <div class="box-success">
                        <div class="box-header">
                            <label>Karkex por Bodega</label>
                            <div class="box-tools pull-right">
                        <table class="auto-style5">
                        <tr>
                            <td class="auto-style4">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-success">Opciones</button>
                                    <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                       
                                        <li>
                                            <a href='javascript:window.print(); void 0;'>
                                            <span aria-hidden="true" class="disabled fa fa-print"> Imprimir</span>
                                            </a></li>
                                        
                                    </ul>

                                </div>
                            </td>
                              
                         
                          
                            
                        </tr>
                    </table>
                    </div>
                        </div>
                    </div>
                     
              
                
            </div>
         
        <div class="row">
            <div class="box box-success">
                
                   <div class="box-body">
                       <div class="row">
                           <div class="col-sm-12">
                               <div class="box">
                             <div class="table-responsive">
                            <asp:GridView ID="GridViewkardexg" runat="server" GridLines="None"
                                CssClass="gvuser table table-striped table-bordered text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                            </asp:GridView> 
                          </div>
                      </div>
                           </div>
                           
                    </div>
                </div>
            </div>
        </div>
     
      
 
                  </form>
        </div>
         </section>
</asp:Content>
