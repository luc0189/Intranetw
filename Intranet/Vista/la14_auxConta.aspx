<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="la14_auxConta.aspx.cs" Inherits="Intranet.Vista.la14_auxConta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
          <a href="1.aspx" class="fa fa-home">Inicio</a>
        <div class="box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Auxiliar de Contabilidad1</h3>
            </div>
        </div>
        <div class="box-body">
            <div class="row">
                <form  method="post" runat="server">
               <div class="col-xs-4">
                  
                    <label>Fecha inicio </label>
                    <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">
                </div>
                <div class="col-xs-4">
                    <label>Fecha fin </label>
                    <input runat="server" id="txtfechafin" type="date" class="form-control" placeholder="Fecha fin">

                </div>
                <div class="col-xs-4">
                    <label>Cuenta </label>
                    <input runat="server" id="txtcuenta" type="number" class="form-control" placeholder="Cuenta">

                </div>
                                   
                     <asp:Button ID="Button1" runat="server" class="btn btn-block btn-success btn-sm " Text="Consulta" OnClick="consulta" />
               
           
                <div class="table-responsive">

                    <asp:GridView ID="GridViewLa14auxcontable" runat="server" GridLines="None"
                        CssClass="gvuser table table-striped table-bordered text-sm text-right"
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                    </asp:GridView>

                </div>
                   </form>
            </div>
        </div>
     
    </section>
</asp:Content>
