<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Sistema/Sistema.Master" AutoEventWireup="true" CodeBehind="Menush.aspx.cs" Inherits="Intranet.Vista.Sistema.Menush" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="permisosapp.aspx">Tablero Admin</a>
            </li>
            <li class="breadcrumb-item">
                <a href="Registro.aspx">Registro</a>
            </li>
            <li class="breadcrumb-item active">Gestion de Usuario</li>
        </ol>
         <form method="post" runat="server">
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                      <div class="alert alert-success alert-dismissible" id="notificacion" runat="server">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">×</font></font></button>
            <h5><i class="icon fa fa-check"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> ¡Alerta!</font></font></h5>
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                <label runat="server" id="alertant"></label></font></font>
        </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>
             </form>

         </div>
</asp:Content>
