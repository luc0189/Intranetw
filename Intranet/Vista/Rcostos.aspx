<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Rcostos.aspx.cs" Inherits="Intranet.Vista.Rcostos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 25%;
            left: -285px;
            top: -865px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

            <form id="form1" runat="server">
     <%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">--%>
              <%--     <ContentTemplate>--%>
                       <div class="content">
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
                                                <input id="Lnumero" runat="server" type="text" class="form-control" placeholder="Numero">
                                                <span class="fa fa-hashtag form-control-feedback"></span>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="box-footer">
                                        <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"> </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Label Text="" ID="lbestado" runat="server" />
                                <div class="box">
                                    <div class="table table-responsive">
                                         <asp:LinkButton ID="BtnExportar" runat="server" Text="Exportar Recibidos" OnClick="BtnExportar_Click" class="btn btn-primary"> </asp:LinkButton>
                                         <asp:LinkButton ID="BtnExportarDev" runat="server" Text="Exportar Devoluciones" OnClick="BtnExportarDev_Click" class="btn btn-primary"> </asp:LinkButton>
                                        <div class="btn-group">
                                            <input type="text" name="name" value="" id="txtbuscadorplu" runat="server" placeholder="Digite Plu" />
                                        <asp:LinkButton ID="Btnbuscaitems" runat="server" Text="Buscar" OnClick="Btnbuscaitems_Click" > </asp:LinkButton>
                                        </div> 
                                        
                                        <asp:GridView runat="server" ID="GridviewItemsCompra" GridLines="None"
                                            CssClass=" table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados." OnRowCancelingEdit="GridviewItemsCompra_RowCancelingEdit" OnRowDeleted="GridviewItemsCompra_RowDeleted" OnRowEditing="GridviewItemsCompra_RowEditing" OnRowUpdating="GridviewItemsCompra_RowUpdating" AutoGenerateColumns="False" PageSize="14" OnDataBound="GridviewItemsCompra_DataBound" Height="0px"  OnSelectedIndexChanged="GridviewItemsCompra_SelectedIndexChanged" BorderColor="#669999" Font-Size="8px">
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" ShowEditButton="True" EditImageUrl="~/dist/img/edit1.png" UpdateImageUrl="~/dist/img/update.png" CancelImageUrl="~/dist/img/cancel.png" />

                                                <asp:BoundField DataField="id" HeaderText="Id" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Oc" HeaderText="Oc"  >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Plu" HeaderText="PLU" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Detalle" HeaderText="Detalle" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cant" HeaderText="Cant">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CantoC" HeaderText="CantoC">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Costo_Ant" HeaderText="Ct. Ant" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Costo_New" HeaderText="Ct. Nuevo">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                
                                                 <asp:BoundField DataField="estado" HeaderText="E">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="es" HeaderText="Estado">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                               
                                                <asp:BoundField DataField="Und_Falt" HeaderText="Falt" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dif_Costo" HeaderText="Dif_Costo" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Porc" HeaderText="%" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="F" HeaderText="F" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NP" HeaderText="NP" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField> 
                                                <asp:BoundField DataField="MaV" HeaderText="MaV" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField> 
                                                <asp:BoundField DataField="MeV" HeaderText="MeV" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NLL" HeaderText="NLL" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Dev" HeaderText="Dev" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="SLL" HeaderText="-SLL-" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IsDev" HeaderText="IsDev" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Piva" HeaderText="Piva" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PivaCodigo" HeaderText="PivaCodigo" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Presentacion" HeaderText="Prs" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NamePresentacion" HeaderText="Npres" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="../dist/img/plus.png" ShowSelectButton="True" />
                                              
                                            </Columns>
                                            <PagerSettings FirstPageText="&amp;lt ; &amp;lt;" LastPageText="&amp;gt ; &amp;gt;" PageButtonCount="5" />
                                            <RowStyle Font-Size="Small" Height="4px" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                     
                         <div class="row shadow p-3 mb-5 bg-body rounded">
                             <div class="box">
                                 <div class="col-md-3">
                                     <strong>
                                           <asp:Label Text="Valor Faltantes" runat="server" />
                                     </strong>
                                   
                                     <input type="text" name="name" runat="server" id="txtF" value="" disabled />
                                 </div>
                                 <div class="col-md-3">
                                     <strong>
                                          <asp:Label Text="No Pedidos" runat="server" />
                                     </strong>
                                    
                                     <input type="text" name="name" runat="server" id="txtNP" value="" disabled />
                                 </div>
                                 <div class="col-md-3">
                                     <strong>
                                            <asp:Label Text="Mayor Valor" runat="server" />
                                     </strong>
                                  
                                     <input type="text" name="name" runat="server" id="txtMaV" value="" disabled />
                                 </div>
                                 <div class="col-md-3">
                                     <strong>
                                        <asp:Label Text="Menor Valor" runat="server" />
                                     </strong>
                                     
                                     <input type="text" name="name" runat="server" id="txtMeV" value="" disabled />
                                 </div>
                                 <div class="col-md-3">
                                     <strong>
                                        <asp:Label Text="No Llego" runat="server" />
                                     </strong>
                                     
                                     <input type="text" name="name" runat="server" id="txtNLL" value="" disabled />
                                 </div> <div class="col-md-3">
                                     <strong>
                                        <asp:Label Text="Devoluciones" runat="server" />
                                     </strong>
                                     
                                     <input type="text" name="name" runat="server" id="txtDev" value="" disabled />
                                 </div>
                                 <div class="col-md-3">
                                     <strong>
                                        <asp:Label Text="Recibida" runat="server" />
                                     </strong>
                                     
                                     <input type="text" name="name" runat="server" id="txtSll" value="" disabled />
                                 </div>
                             </div>
                    
                </div>
                       </div>
                           
                  <%--  </ContentTemplate>--%>
               <%-- </asp:UpdatePanel>

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
                </asp:UpdateProgress>--%>

               
            </form>
       
    </div>
</asp:Content>
