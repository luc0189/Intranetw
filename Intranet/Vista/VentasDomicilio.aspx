<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="VentasDomicilio.aspx.cs" Inherits="Intranet.Vista.VentasDomicilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="box">
                    <div class="box-header">
                        titulo
                    </div>
                    <div class="box-body">
                        <div class="col-xl-12 col-sm-12 mb-12">
                                    <div class="card text-white bg-primary o-hidden h-100">
                                        <div class="card-body">
                                            <div class="card-body-icon">
                                                <i class="fas fa-fw fa-user"></i>
                                            </div>
                                            <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Principal</font></font></div>
                                            <div class="form-group ">


                                                <input id="txtcc" runat="server" type="number" class="form-control" placeholder="No Documento de Indentidad" required="required"/>
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="datoin" runat="server" type="text" class="form-control" placeholder="Dato in" />
                                            </div>
                                            <div class="form-group has-feedback">
                                                <input id="datoout" runat="server" type="number" class="form-control" placeholder="Dato Out" />
                                            </div>
                                           
                                            <div style="display: flex; justify-content: center; align-content: center;" class="card">
                                            
                                              
                                                                                           
                                            </div>


                                        </div>

                                    </div>
                                </div>
                        <div class="table-responsive">
                            aqui la tabla
                        </div>
                    </div>
                    <div class="box-footer">

                    </div>

                </div>
                </form>
         </div>
         </section>
</asp:Content>
