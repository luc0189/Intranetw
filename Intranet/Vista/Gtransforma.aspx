<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Gtransforma.aspx.cs" Inherits="Intranet.Vista.Gtransforma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <h1>Gestion de Transformaciones
        <small>Panel Principal</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="Menu.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
            <li class="active"><a href="Menu.aspx">Herramientas</a></li>
            <li class="active">Gestion de Transformaciones</li>
        </ol>
    </section>
    <form id="form1" runat="server">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header with-border">
                    <b>Listado</b>
                </div>
                <div class="box-body">
                    
                    
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewNovedades" runat="server" OnSelectedIndexChanged="btnenviar_Click" GridLines="None" class="display " 
                            CssClass=" gvuser table table-hover table-responsive text-sm" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                           <Columns>
                               <asp:TemplateField>
                                   <HeaderTemplate>
                                       
                                       <asp:CheckBox ID="chkheader" runat="server" OnCheckedChanged="chkheader_CheckedChanged" OnRowDeleting="" AutoPostBack="true" Text="Check" />
                                   </HeaderTemplate>
                                   <ItemTemplate>
                                       <asp:CheckBox ID="Chk" runat="server" OnCheckedChanged="Chk_CheckedChanged" />
                                   </ItemTemplate>
                               </asp:TemplateField>
                            

                               
                              

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="box-footer">
                    <div class="box-tools pull-right">
                        <asp:LinkButton ID="guardar" runat="server" Text="Guardar Cambios" CssClass="btn  btn-app" OnClick="guardar_Click" >
                                             
                                        </asp:LinkButton>
                    </div>
                    
            
                    
                </div>
            </div>

        </div>
    </form>
</asp:Content>
