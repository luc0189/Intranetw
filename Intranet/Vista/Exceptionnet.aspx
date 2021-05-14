<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Exceptionnet.aspx.cs" Inherits="Intranet.Vista.Exceptionnet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <a href="1.aspx" class="fa fa-home">Inicio</a>
    <p class="error-page">
      <b> El servidor Se encuentra con problemas de conectividad</b>
            </p>
    <a href="javascript:window.history.back();">&laquo; Volver atrás</a>
   
</asp:Content>
