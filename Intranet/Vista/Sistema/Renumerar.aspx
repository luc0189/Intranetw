<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Sistema/Sistema.Master" AutoEventWireup="true" CodeBehind="Renumerar.aspx.cs" Inherits="Intranet.Vista.Sistema.Renumerar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="permisosapp.aspx">Tablero Admin</a>
            </li>
            <li class="breadcrumb-item">
                <a href="Registro.aspx">Utileria</a>
            </li>
            <li class="breadcrumb-item active">App</li>
        </ol>
        <div class="card">
            <div class="card-header">
                App para Renumerar consecutivos de documentos
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-header">
                                <strong>Setup</strong>
                            </div>
                            <div class="form">
                                <div class="card-body">
                                    <div class="form-group">
                                        <asp:Label Text="Direccion Servidor: " runat="server" />
                                        <input type="text" name="servidor" value="" class="form-control" />
                                        <asp:Label Text="Puerto" runat="server" />
                                        <input type="number" name="port" value="" class="form-control" />
                                    </div>
                                    <div class="form-group  ">
                                        <asp:Label Text="Base de datos: " runat="server" />
                                        <input type="text" name="db" value="" class="form-control" />
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <form method="post" runat="server">
                            <div class="card">
                                <div class="card-header">
                                    <strong>Ejecutar</strong>
                                </div>

                                
                                    <div class="card-body">
                                               <div class="form">
                                        <div class="form-group">
                                            <asp:Label Text="Documento: " runat="server" />
                                            <input type="text" name="doc" value="" class="form-control" />

                                        </div>
                                 
                                        <div class="form-group">
                                            <asp:Label Text="Rango" runat="server" />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control" placeholder="Desde">
                                                </div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control" placeholder="Hasta">
                                                </div>
                                                <div class="col-md-4 ">
                                                    <asp:Button Text="Listar" runat="server" ID="btnOn" CssClass="btn btn-primary form-control" />
                                                </div>
                                            </div>
                                        </div>
                                          </div>
                                    </div>
                                </div>
                                <div class="card-footer">
                                    <asp:Button Text="On" runat="server" ID="Button1" CssClass="btn btn-success" />
                                </div>
                          
                        </form>
                    </div>
                </div>

            </div>
            
            <div class="card">
                <div class="card-header">
                   Salida
                </div>
                <div class="card-body">
                    aqui el grid
                </div>

            </div>
        
        </div>
        
    </div>

</asp:Content>
