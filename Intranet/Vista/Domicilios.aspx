<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Domicilios.aspx.cs" Inherits="Intranet.Vista.Domicilios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">
                <div class="box box">
                    <div class="box-header">
                        <div class="box-title"><strong>Informe Domicilios</strong></div>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Fecha desde:</label>
                            <input type="date" name="name"  id="txtfechadesde" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Fecha Hasta:</label>
                            <input type="date" name="name"  id="txtfechahasta" runat="server" />
                        </div>
                    </div>
                    <div class="box-footer">
                        <asp:button runat="server" id="UploadButton" text="Consultar" cssclass="btn btn-success" OnClick="consulta" />
                    </div>
                </div>
                <div class="row">
                    <div class="box box-comment">
                        <div class="box-body">
                                <div class="table-responsive">
                                                            <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                                                CssClass="gvuser table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>
                                                        </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        </section>
</asp:Content>
