<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Sistema/Sistema.Master" AutoEventWireup="true" CodeBehind="PermisosApp.aspx.cs" Inherits="Intranet.Vista.Sistema.PermisosApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" runat="server" >
    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="permisosapp.aspx">Tablero Admin</a>
          </li>
          <li class="breadcrumb-item active">Principal</li>
        </ol>

        <div class="card">
            <div class="card-header">
                <label>Sincronizacion BNET POS</label>
            </div>
            <div class="card-body">
                <div class="btn-group">
          <asp:Button Text="On" runat="server" ID="btnOn" CssClass="btn btn-success" OnClick="btnOn_Click" />
          <asp:Button Text="Off" runat="server" ID="btnOff" CssClass="btn btn-primary" OnClick="btnOff_Click" />

      </div>
            </div>
            
        </div>
        </div>
  </form>
</asp:Content>
