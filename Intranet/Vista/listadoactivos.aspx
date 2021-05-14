<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="listadoactivos.aspx.cs" Inherits="Intranet.Vista.listadoactivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
         <div class="container bootstrap snippet"> 
              
         <form  method="post" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
        <div class="box">
            <div class="box-header with-border">
                <label class="box-title">Listado Activos</label>
                <div class="box-tools pull-right">
                       <a href="1.aspx" class="fa fa-home">Inicio</a>
                    </div>
            </div>
             <div class="box-body">
                <div class="table-responsive">

                    <asp:GridView ID="GridViewGactivos" runat="server" GridLines="None"
                        CssClass="table gvuser  table-hover table-responsive text-sm"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView> 
            
            </div>
                  <asp:Button ID="Button3" runat="server" class="btn btn-block btn-success btn-sm " Text="Nuevo Activo" OnClick="Nuevo" />
           
            </div>
        </div>

       
                            </ContentTemplate>
               </asp:UpdatePanel>
             </form>

         </div>
        

          
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div id="backgroud">

                    </div>
                    <div id="Progress">
                        <h6>
                            <p style="text-align:center"><b>Procesando, Espere por favor...</b></p>
                        </h6>
                    </div>
                    
                </ProgressTemplate>
            </asp:UpdateProgress>

    </section>
</asp:Content>
