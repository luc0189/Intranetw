<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="ventasversalles.aspx.cs" Inherits="Intranet.Vista.ventasversalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form  method="post" runat="server">
 <div id="div_datosempresa">
            <center>
            <H4>SUPERMIO SAS</H4>
            <br />
            <label>Nit: 900618398-4</label>
            <br />
            <label>Calle 16 No 13-53 FLORENCIA PBX-4344737</label>
            <br />
               </center>
        </div>
        <div id="logosimbolo">
            <img src="../../dist/img/logo.png" alt="Alternate Text" />
        </div>
        <div class="margin">
            <div class="box-header">


                <table class="auto-style5">
                    <tr>
                        <td class="auto-style4">
                            <div class="btn-group" id="botonera">
                                <button type="button" class="btn btn-success">Opciones</button>
                                <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                    <span class="caret"></span>
                                    <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="1.aspx" class="fa fa-home">Inicio</a></li>
                                   <li>
                                        <a href='javascript:window.print(); void 0;'>
                                            <span aria-hidden="true" class="disabled fa fa-print">Imprimir</span>
                                        </a></li>
                                   
                                </ul>

                            </div>
                        </td>

                        <td class="auto-style4">
                            <div id="div_nombredocumento">
                                <b>CIERRE POS</b>
                            </div>

                        </td>
                        

                    </tr>
                </table>
            </div>


        </div>
  
        
       
        <div class="box-body">
            <div class="row">
                
               <div class="col-xs-4">
                  
                    <label>Fecha inicio </label>
                    <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">
                </div>
                <div class="col-xs-4">
                    <label>Fecha fin </label>
                    <input runat="server" id="txtfechafin" type="date" class="form-control" placeholder="Fecha fin">

                </div>
                <div class="col-xs-4">
                    <label>CAJER@</label>
                    <input runat="server" id="txtcuenta" type="text" class="form-control" placeholder="Usuario Cajera">

                </div>
                    <br />
                <div id="insert">  
                     <asp:Button ID="Button1" runat="server" class="btn btn-block btn-success btn-sm " Text="Consulta" OnClick="consulta" />
               </div>
           </div>
                <div class="table-responsive">
                    <p>TOTAL:</p>
                    <asp:GridView ID="GridViewVentasVersa" runat="server" GridLines="None"
                        CssClass="gvuser3 table table-striped table-bordered text-sm text-right"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView>

                </div>
                    <p>FORMAS DE PAGO</p>
                       <div class="table-responsive">

                    <asp:GridView ID="GridViewVentadetallesVersa" runat="server" GridLines="None"
                        CssClass="gvuser6a table table-striped table-bordered text-sm text-right"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView>

                </div>
                   
            </div>
        
    
   
        </form>
</asp:Content>
