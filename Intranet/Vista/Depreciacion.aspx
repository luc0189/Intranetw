<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Depreciacion.aspx.cs" Inherits="Intranet.Vista.Depreciacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <head>
        <title>LCSystem 3 | Depreciacion Activos</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
    <div class="container bootstrap snippet">
    <form  runat="server" >
    <section class="content">
    
    <div class="box box-default">
        <div class="box-header with-border">
            <label class="box-title">Depreciacion Activos</label>
           
        </div>
        <div class="box-body">
              <div class="col-md-12">
            <div class="row">
            <div class="table-responsive">

                    <asp:GridView ID="GridViewDepreciacion" runat="server" GridLines="None"
                        CssClass="gvuser table table-striped table-bordered text-sm"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView> 
            
            </div>
                </div>
                  </div>
        </div>
    </div>
          </section>
        </form>
       </div>
         </section>
</asp:Content>
