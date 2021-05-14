<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="R_compras.aspx.cs" Inherits="Intranet.Vista.R_compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container">
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="container">
                            <div class="row">
                                <div class="box">
                                    <div class="box-header">
                                        <strong>Buscar Orden de Compra</strong>
                                    </div>
                                    <div class="box-body">
                                         <div class="form-group ">

                                                <label for="txtserial" class="col-sm-3 col-form-label">Tipo</label>
                                                <div class="input-group col-sm-9">
                                                    <input id="Ltipo" runat="server" type="text" class="form-control" placeholder="Tipo">
                                                    <span class="fa fa-archive form-control-feedback"></span>
                                                </div>
                                            </div>
                                            <div class="form-group ">

                                                <label for="txtserial" class="col-sm-3 col-form-label">Numero</label>
                                                <div class="input-group col-sm-9">
                                                    <input id="Lnumero" runat="server" type="number" class="form-control" placeholder="Numero">
                                                    <span class="fa fa-hashtag form-control-feedback"></span>
                                                </div>
                                            </div>
                                      
                                    </div>
                                    <div class="box-footer">
                                         <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click"  class="btn btn-primary"> </asp:LinkButton>
                                    </div>
                                </div>
                                <asp:Label Text="Estado" ID="txtestado" runat="server" />
                            </div>
                            <div class="row">
                                <div class="box">
                                    <div class="table table-responsive">
                                        <asp:gridview runat="server" id="GridviewCompra" gridlines="None"
                                        cssclass=" table table-striped dysplay" OnSelectedIndexChanged="GridviewCompra_SelectedIndexChanged" emptydatatext="No se encontraron Registros con los parametros indicados.">
                                             <Columns>
  
                                                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../dist/img/iconfinder_sms_43332.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Recibir" >

                                              
                                              </asp:CommandField>
                                            

                                        </Columns>
                                  </asp:gridview>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <div id="backgroud">
                        </div>
                        <div id="Progress">
                            <h6>
                                <p style="text-align: center"><b>Procesando, Espere por favor...</b></p>
                            </h6>
                        </div>

                    </ProgressTemplate>
                </asp:UpdateProgress>
            </form>
        </div>
    </div>

</asp:Content>
