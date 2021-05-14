<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Sistema/Sistema.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Intranet.Vista.Sistema.User" %>

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
                    <div class="alert alert-success alert-dismissible" id="notificacion" runat="server">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">×</font></font></button>
            <h5><i class="icon fa fa-check"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> ¡Alerta!</font></font></h5>
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                <label runat="server" id="alertant"></label></font></font>
        </div>
                    <div class="card">
                        <div class="card-header">
                            <h3>Gestion de Usuarios</h3>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-xl-6 col-sm-6 mb-6">
                                    <div class="card text-white bg-primary o-hidden h-100">
                                        <div class="card-body">
                                            <div class="card-body-icon">
                                                <i class="fas fa-fw fa-user"></i>
                                            </div>
                                            <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Principal</font></font></div>
                                            <div class="form-group">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Empleado:</span>
                                                    </div>
                                                    <select runat="server" id="select_cc" class="select2-container--focus form-control">
                                                    </select>
                                                   
                                                </div>


                                            </div>
                                            <div class="form-group">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Usuario:</span>
                                                    </div>
                                                    <input id="txtusuario" runat="server" type="text" class="form-control" placeholder="Usuario">
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Contraseña:</span>
                                                    </div>
                                                    <input id="txtpass" runat="server" type="password" class="form-control" placeholder="Contraseña">
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6 col-sm-6 mb-6">
                                    <div class="card text-white bg-warning o-hidden h-100">
                                        <div class="card-body">
                                            <div class="card-body-icon">
                                                <i class="fas fa-fw fa-list"></i>
                                            </div>
                                            <div class="mr-5">
                                                <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Mas!</font></font>
                                                <a class="btn btn-social-icon btn-dark" data-toggle="modal" href="#Buscador"><i class="fa fa-search"></i></a>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridViewsearh" runat="server" GridLines="None" class="display "
                                                    CssClass=" gvuser table table-hover table-responsive text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados."  OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" CancelText="Seleccion" />

                                                    </Columns>

                                                </asp:GridView>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="btn-group">

                                <div class="btn-group">

                                <asp:LinkButton ID="btnactualizar" runat="server" Text="Volver" class="btn btn-app" OnClick="btnactualizar_Click" >
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Actualizar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnguardanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="Buttonguardar" >
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btncancelanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelanuevo_Click" >
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                </asp:LinkButton>

                            </div>
                                 

                            </div>
                        </div>
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal modal-warning fade left" id="Buscador" role="dialog">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Buscador</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>

                                </div>
                                <div class="modal-body">
                                     <div class="input-group">
                                        <input runat="server" type="text" id="txtcc" name="seriales" class="form-control" placeholder="C.C">
                                        <span class="input-group-btn">

                                            <asp:LinkButton ID="btncc" runat="server" Text="Nuevo" class="btn btn-success btn-flat" OnClick="LinkButton1_Click">Buscar</asp:LinkButton>

                                        </span>
                                    </div>
                                    <div class="input-group">
                                        <input runat="server" type="text" id="txtuser" name="seriales" class="form-control" placeholder="Usuario">
                                        <span class="input-group-btn">

                                            <asp:LinkButton ID="btnuser" runat="server" Text="Nuevo" class="btn btn-success btn-flat" OnClick="btnuser_Click">Buscar</asp:LinkButton>

                                        </span>
                                    </div>
                                    


                                </div>

                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
        </form>
    </div>
</asp:Content>
