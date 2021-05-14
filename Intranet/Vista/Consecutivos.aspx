<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Consecutivos.aspx.cs" Inherits="Intranet.Vista.Consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">

         <form  method="post" runat="server">
               <div class="row">
               
                    <div class="box-success">
                        <div class="box-header">
                            <label>Consecutivos Actas de Entrega</label>
                            <div class="box-tools pull-right">
                                <a href="1.aspx" class="fa fa-home">Inicio</a>
                    </div>
                        </div>
                    </div>
                     
              
                
            </div>
        <div class="box box-default">
                  
        <div class="box-body">
            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive">

                    <asp:GridView ID="GridViewactas" runat="server" GridLines="None"
                        CssClass="gvuser table table-striped table-bordered text-sm"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView> 
            
            </div>
                </div>
                
                
            </div>
            </div>
            </div>
             </form>
        </div>
    </section>
</asp:Content>
