<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="listadoactivos.aspx.cs" Inherits="Intranet.Vista.listadoactivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Listado de Activos</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Activos Fijos</li>
                            <li class="breadcrumb-item active">Listado de Activos</li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </section>


     <section class="content">
         <div class="container-fluid"> 
              
         <form  method="post" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="card card-dark">
                                    <div class="card-header">
                                        <h3 class="card-title">Mas</h3>
                                    </div>
                                    <div class="card-body">
                                         <div class="table-responsive">

                    <asp:GridView ID="GridViewGactivos" runat="server" GridLines="None"
                        CssClass="table gvuser  table-hover table-responsive text-sm"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView> 
            
            </div>
                                    </div>
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
