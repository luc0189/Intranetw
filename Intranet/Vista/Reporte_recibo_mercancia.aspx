<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Reporte_recibo_mercancia.aspx.cs" Inherits="Intranet.Vista.Reporte_recibo_mercancia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form id="form1" runat="server">
           <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                    <div class="box">
                        <div class="box-header">
                            <label>Reportes</label>
                            <input type="text" name="name" id="txtidfactura" runat="server" value="" />
                            <asp:Button ID="Btnir" class="btn btn-success btn-block btn-flat" runat="server" Text="Ir"
                                OnClick="Btnir_Click" />
                        </div>
                        <div class="box-body">

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="box">
                                            <div class="box-header">
                                                <label>Mercancia Recibida</label>
                                            </div>
                                            <div class="box-body">
                                                 <div class="table-responsive">
                                            <asp:GridView ID="GridViewnovedades" runat="server" GridLines="None"
                                                CssClass=" table gvuser table-striped table-bordered text-sm"
                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                            </asp:GridView>
                                        </div>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="box">
                                            <div class="box-header">
                                                <label>Mercancia Devuelta</label>
                                            </div>
                                            <div class="box-body">
                                                 <div class="table-responsive">
                                                <asp:GridView ID="GridViewnovedades2" runat="server" GridLines="None"
                                                    CssClass=" table gvuser table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                            </div>
                                           
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </form>
    </div>
</asp:Content>
