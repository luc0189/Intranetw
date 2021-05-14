<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Intranet.Vista.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
  
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" rel="stylesheet" />
<script src="https://code.jquery.com/jquery-1.9.1.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>   
     
  <link rel="stylesheet" href="../bower_components/bootstrap/dist/css/bootstrap.min.css"/>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../bower_components/font-awesome/css/font-awesome.min.css"/>
  <!-- Ionicons -->
  <link rel="stylesheet" href="../bower_components/Ionicons/css/ionicons.min.css"/>
      <!-- select2 -->

  <!-- Theme style -->
  <link rel="stylesheet" href="../dist/css/AdminLTE.min.css"/>
  <!-- AdminLTE Skins. We have chosen the skin-blue for this starter
        page. However, you can choose any other skin. Make sure you
        apply the skin class to the body tag so the changes take effect. -->
 <!-- data tabless -->
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css"/>  
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.0/css/buttons.dataTables.min.css"/>  
    


    <link rel="stylesheet" href="../bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>    
    <link rel="stylesheet" href="../bower_components/datatables.net-bs/css/buttons.dataTables.min.css"  />
  <link rel="stylesheet" href="../dist/css/skins/skin-blue.min.css"/>

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <!-- Google Font -->
  
   
    <title>Prueba</title>
</head>
<body>
    <form runat="server" >
     <div class="col-xs-9">
         
<select style="width:200px;" class="js-example-basic-multiple" multiple="multiple">
    <option value="AL">Alabama</option>
    <option value="WY">Wyoming</option>
</select>
         <asp:GridView CssClass="gvuser1 table table-striped table-bordered text-sm" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PERS_ID" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:TemplateField ShowHeader="False">
                     <EditItemTemplate>
                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update" ImageUrl="~/dist/img/update.png" Text="Actualizar" />
                         &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/dist/img/cancel.png" Text="Cancelar" />
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/dist/img/edit1.png" Text="Editar" />
                         &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="PERS_ID" HeaderText="PERS_ID" ReadOnly="True" SortExpression="PERS_ID" />
                 <asp:BoundField DataField="PERS_NOMBRE1" HeaderText="PERS_NOMBRE1" SortExpression="PERS_NOMBRE1" />
                 <asp:BoundField DataField="PERS_NOMBRE2" HeaderText="PERS_NOMBRE2" SortExpression="PERS_NOMBRE2" />
                 <asp:BoundField DataField="PERS_APELLIDO1" HeaderText="PERS_APELLIDO1" SortExpression="PERS_APELLIDO1" />
                 <asp:BoundField DataField="PERS_APELLIDO2" HeaderText="PERS_APELLIDO2" SortExpression="PERS_APELLIDO2" />
                 <asp:BoundField DataField="PERS_TEL" HeaderText="PERS_TEL" SortExpression="PERS_TEL" />
                 <asp:BoundField DataField="PERS_DIRECCION" HeaderText="PERS_DIRECCION" SortExpression="PERS_DIRECCION" />
                 <asp:BoundField DataField="PERS_SEXO" HeaderText="PERS_SEXO" SortExpression="PERS_SEXO" />
                 <asp:BoundField DataField="PERS_TIPP_ID" HeaderText="PERS_TIPP_ID" SortExpression="PERS_TIPP_ID" />
                 <asp:BoundField DataField="PERS_EMPR_ID" HeaderText="PERS_EMPR_ID" SortExpression="PERS_EMPR_ID" />
                 <asp:BoundField DataField="PERS_CC" HeaderText="PERS_CC" SortExpression="PERS_CC" />
                 <asp:BoundField DataField="PERS_ESPROVEEDOR" HeaderText="PERS_ESPROVEEDOR" SortExpression="PERS_ESPROVEEDOR" />
                 <asp:BoundField DataField="PERS_REGISTRADOPOR" HeaderText="PERS_REGISTRADOPOR" SortExpression="PERS_REGISTRADOPOR" />
                 <asp:BoundField DataField="PERS_FECHACREADO" HeaderText="PERS_FECHACREADO" SortExpression="PERS_FECHACREADO" />
                 <asp:BoundField DataField="PERS_FECHACAMBIO" HeaderText="PERS_FECHACAMBIO" SortExpression="PERS_FECHACAMBIO" />
             </Columns>
             <EditRowStyle BackColor="#999999" />
             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
         </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:BD %>" DeleteCommand="DELETE FROM &quot;PERSONA&quot; WHERE &quot;PERS_ID&quot; = :original_PERS_ID AND ((&quot;PERS_NOMBRE1&quot; = :original_PERS_NOMBRE1) OR (&quot;PERS_NOMBRE1&quot; IS NULL AND :original_PERS_NOMBRE1 IS NULL)) AND ((&quot;PERS_NOMBRE2&quot; = :original_PERS_NOMBRE2) OR (&quot;PERS_NOMBRE2&quot; IS NULL AND :original_PERS_NOMBRE2 IS NULL)) AND ((&quot;PERS_APELLIDO1&quot; = :original_PERS_APELLIDO1) OR (&quot;PERS_APELLIDO1&quot; IS NULL AND :original_PERS_APELLIDO1 IS NULL)) AND ((&quot;PERS_APELLIDO2&quot; = :original_PERS_APELLIDO2) OR (&quot;PERS_APELLIDO2&quot; IS NULL AND :original_PERS_APELLIDO2 IS NULL)) AND ((&quot;PERS_TEL&quot; = :original_PERS_TEL) OR (&quot;PERS_TEL&quot; IS NULL AND :original_PERS_TEL IS NULL)) AND ((&quot;PERS_DIRECCION&quot; = :original_PERS_DIRECCION) OR (&quot;PERS_DIRECCION&quot; IS NULL AND :original_PERS_DIRECCION IS NULL)) AND ((&quot;PERS_SEXO&quot; = :original_PERS_SEXO) OR (&quot;PERS_SEXO&quot; IS NULL AND :original_PERS_SEXO IS NULL)) AND ((&quot;PERS_TIPP_ID&quot; = :original_PERS_TIPP_ID) OR (&quot;PERS_TIPP_ID&quot; IS NULL AND :original_PERS_TIPP_ID IS NULL)) AND ((&quot;PERS_EMPR_ID&quot; = :original_PERS_EMPR_ID) OR (&quot;PERS_EMPR_ID&quot; IS NULL AND :original_PERS_EMPR_ID IS NULL)) AND ((&quot;PERS_CC&quot; = :original_PERS_CC) OR (&quot;PERS_CC&quot; IS NULL AND :original_PERS_CC IS NULL)) AND ((&quot;PERS_ESPROVEEDOR&quot; = :original_PERS_ESPROVEEDOR) OR (&quot;PERS_ESPROVEEDOR&quot; IS NULL AND :original_PERS_ESPROVEEDOR IS NULL)) AND ((&quot;PERS_REGISTRADOPOR&quot; = :original_PERS_REGISTRADOPOR) OR (&quot;PERS_REGISTRADOPOR&quot; IS NULL AND :original_PERS_REGISTRADOPOR IS NULL)) AND ((&quot;PERS_FECHACREADO&quot; = :original_PERS_FECHACREADO) OR (&quot;PERS_FECHACREADO&quot; IS NULL AND :original_PERS_FECHACREADO IS NULL)) AND ((&quot;PERS_FECHACAMBIO&quot; = :original_PERS_FECHACAMBIO) OR (&quot;PERS_FECHACAMBIO&quot; IS NULL AND :original_PERS_FECHACAMBIO IS NULL))" InsertCommand="INSERT INTO &quot;PERSONA&quot; (&quot;PERS_ID&quot;, &quot;PERS_NOMBRE1&quot;, &quot;PERS_NOMBRE2&quot;, &quot;PERS_APELLIDO1&quot;, &quot;PERS_APELLIDO2&quot;, &quot;PERS_TEL&quot;, &quot;PERS_DIRECCION&quot;, &quot;PERS_SEXO&quot;, &quot;PERS_TIPP_ID&quot;, &quot;PERS_EMPR_ID&quot;, &quot;PERS_CC&quot;, &quot;PERS_ESPROVEEDOR&quot;, &quot;PERS_REGISTRADOPOR&quot;, &quot;PERS_FECHACREADO&quot;, &quot;PERS_FECHACAMBIO&quot;) VALUES (:PERS_ID, :PERS_NOMBRE1, :PERS_NOMBRE2, :PERS_APELLIDO1, :PERS_APELLIDO2, :PERS_TEL, :PERS_DIRECCION, :PERS_SEXO, :PERS_TIPP_ID, :PERS_EMPR_ID, :PERS_CC, :PERS_ESPROVEEDOR, :PERS_REGISTRADOPOR, :PERS_FECHACREADO, :PERS_FECHACAMBIO)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:BD.ProviderName %>" SelectCommand="SELECT * FROM &quot;PERSONA&quot;" UpdateCommand="UPDATE &quot;PERSONA&quot; SET &quot;PERS_NOMBRE1&quot; = :PERS_NOMBRE1, &quot;PERS_NOMBRE2&quot; = :PERS_NOMBRE2, &quot;PERS_APELLIDO1&quot; = :PERS_APELLIDO1, &quot;PERS_APELLIDO2&quot; = :PERS_APELLIDO2, &quot;PERS_TEL&quot; = :PERS_TEL, &quot;PERS_DIRECCION&quot; = :PERS_DIRECCION, &quot;PERS_SEXO&quot; = :PERS_SEXO, &quot;PERS_TIPP_ID&quot; = :PERS_TIPP_ID, &quot;PERS_EMPR_ID&quot; = :PERS_EMPR_ID, &quot;PERS_CC&quot; = :PERS_CC, &quot;PERS_ESPROVEEDOR&quot; = :PERS_ESPROVEEDOR, &quot;PERS_REGISTRADOPOR&quot; = :PERS_REGISTRADOPOR, &quot;PERS_FECHACREADO&quot; = :PERS_FECHACREADO, &quot;PERS_FECHACAMBIO&quot; = :PERS_FECHACAMBIO WHERE &quot;PERS_ID&quot; = :original_PERS_ID AND ((&quot;PERS_NOMBRE1&quot; = :original_PERS_NOMBRE1) OR (&quot;PERS_NOMBRE1&quot; IS NULL AND :original_PERS_NOMBRE1 IS NULL)) AND ((&quot;PERS_NOMBRE2&quot; = :original_PERS_NOMBRE2) OR (&quot;PERS_NOMBRE2&quot; IS NULL AND :original_PERS_NOMBRE2 IS NULL)) AND ((&quot;PERS_APELLIDO1&quot; = :original_PERS_APELLIDO1) OR (&quot;PERS_APELLIDO1&quot; IS NULL AND :original_PERS_APELLIDO1 IS NULL)) AND ((&quot;PERS_APELLIDO2&quot; = :original_PERS_APELLIDO2) OR (&quot;PERS_APELLIDO2&quot; IS NULL AND :original_PERS_APELLIDO2 IS NULL)) AND ((&quot;PERS_TEL&quot; = :original_PERS_TEL) OR (&quot;PERS_TEL&quot; IS NULL AND :original_PERS_TEL IS NULL)) AND ((&quot;PERS_DIRECCION&quot; = :original_PERS_DIRECCION) OR (&quot;PERS_DIRECCION&quot; IS NULL AND :original_PERS_DIRECCION IS NULL)) AND ((&quot;PERS_SEXO&quot; = :original_PERS_SEXO) OR (&quot;PERS_SEXO&quot; IS NULL AND :original_PERS_SEXO IS NULL)) AND ((&quot;PERS_TIPP_ID&quot; = :original_PERS_TIPP_ID) OR (&quot;PERS_TIPP_ID&quot; IS NULL AND :original_PERS_TIPP_ID IS NULL)) AND ((&quot;PERS_EMPR_ID&quot; = :original_PERS_EMPR_ID) OR (&quot;PERS_EMPR_ID&quot; IS NULL AND :original_PERS_EMPR_ID IS NULL)) AND ((&quot;PERS_CC&quot; = :original_PERS_CC) OR (&quot;PERS_CC&quot; IS NULL AND :original_PERS_CC IS NULL)) AND ((&quot;PERS_ESPROVEEDOR&quot; = :original_PERS_ESPROVEEDOR) OR (&quot;PERS_ESPROVEEDOR&quot; IS NULL AND :original_PERS_ESPROVEEDOR IS NULL)) AND ((&quot;PERS_REGISTRADOPOR&quot; = :original_PERS_REGISTRADOPOR) OR (&quot;PERS_REGISTRADOPOR&quot; IS NULL AND :original_PERS_REGISTRADOPOR IS NULL)) AND ((&quot;PERS_FECHACREADO&quot; = :original_PERS_FECHACREADO) OR (&quot;PERS_FECHACREADO&quot; IS NULL AND :original_PERS_FECHACREADO IS NULL)) AND ((&quot;PERS_FECHACAMBIO&quot; = :original_PERS_FECHACAMBIO) OR (&quot;PERS_FECHACAMBIO&quot; IS NULL AND :original_PERS_FECHACAMBIO IS NULL))">
             <DeleteParameters>
                 <asp:Parameter Name="original_PERS_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_NOMBRE1" Type="String" />
                 <asp:Parameter Name="original_PERS_NOMBRE2" Type="String" />
                 <asp:Parameter Name="original_PERS_APELLIDO1" Type="String" />
                 <asp:Parameter Name="original_PERS_APELLIDO2" Type="String" />
                 <asp:Parameter Name="original_PERS_TEL" Type="String" />
                 <asp:Parameter Name="original_PERS_DIRECCION" Type="String" />
                 <asp:Parameter Name="original_PERS_SEXO" Type="String" />
                 <asp:Parameter Name="original_PERS_TIPP_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_EMPR_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_CC" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_ESPROVEEDOR" Type="String" />
                 <asp:Parameter Name="original_PERS_REGISTRADOPOR" Type="String" />
                 <asp:Parameter Name="original_PERS_FECHACREADO" Type="DateTime" />
                 <asp:Parameter Name="original_PERS_FECHACAMBIO" Type="DateTime" />
             </DeleteParameters>
             <InsertParameters>
                 <asp:Parameter Name="PERS_ID" Type="Decimal" />
                 <asp:Parameter Name="PERS_NOMBRE1" Type="String" />
                 <asp:Parameter Name="PERS_NOMBRE2" Type="String" />
                 <asp:Parameter Name="PERS_APELLIDO1" Type="String" />
                 <asp:Parameter Name="PERS_APELLIDO2" Type="String" />
                 <asp:Parameter Name="PERS_TEL" Type="String" />
                 <asp:Parameter Name="PERS_DIRECCION" Type="String" />
                 <asp:Parameter Name="PERS_SEXO" Type="String" />
                 <asp:Parameter Name="PERS_TIPP_ID" Type="Decimal" />
                 <asp:Parameter Name="PERS_EMPR_ID" Type="Decimal" />
                 <asp:Parameter Name="PERS_CC" Type="Decimal" />
                 <asp:Parameter Name="PERS_ESPROVEEDOR" Type="String" />
                 <asp:Parameter Name="PERS_REGISTRADOPOR" Type="String" />
                 <asp:Parameter Name="PERS_FECHACREADO" Type="DateTime" />
                 <asp:Parameter Name="PERS_FECHACAMBIO" Type="DateTime" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="PERS_NOMBRE1" Type="String" />
                 <asp:Parameter Name="PERS_NOMBRE2" Type="String" />
                 <asp:Parameter Name="PERS_APELLIDO1" Type="String" />
                 <asp:Parameter Name="PERS_APELLIDO2" Type="String" />
                 <asp:Parameter Name="PERS_TEL" Type="String" />
                 <asp:Parameter Name="PERS_DIRECCION" Type="String" />
                 <asp:Parameter Name="PERS_SEXO" Type="String" />
                 <asp:Parameter Name="PERS_TIPP_ID" Type="Decimal" />
                 <asp:Parameter Name="PERS_EMPR_ID" Type="Decimal" />
                 <asp:Parameter Name="PERS_CC" Type="Decimal" />
                 <asp:Parameter Name="PERS_ESPROVEEDOR" Type="String" />
                 <asp:Parameter Name="PERS_REGISTRADOPOR" Type="String" />
                 <asp:Parameter Name="PERS_FECHACREADO" Type="DateTime" />
                 <asp:Parameter Name="PERS_FECHACAMBIO" Type="DateTime" />
                 <asp:Parameter Name="original_PERS_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_NOMBRE1" Type="String" />
                 <asp:Parameter Name="original_PERS_NOMBRE2" Type="String" />
                 <asp:Parameter Name="original_PERS_APELLIDO1" Type="String" />
                 <asp:Parameter Name="original_PERS_APELLIDO2" Type="String" />
                 <asp:Parameter Name="original_PERS_TEL" Type="String" />
                 <asp:Parameter Name="original_PERS_DIRECCION" Type="String" />
                 <asp:Parameter Name="original_PERS_SEXO" Type="String" />
                 <asp:Parameter Name="original_PERS_TIPP_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_EMPR_ID" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_CC" Type="Decimal" />
                 <asp:Parameter Name="original_PERS_ESPROVEEDOR" Type="String" />
                 <asp:Parameter Name="original_PERS_REGISTRADOPOR" Type="String" />
                 <asp:Parameter Name="original_PERS_FECHACREADO" Type="DateTime" />
                 <asp:Parameter Name="original_PERS_FECHACAMBIO" Type="DateTime" />
             </UpdateParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
   
         </div>
    
<input type="button" onclick="javascript:visible_div();" value="div visible" />
        
 <div class="modal modal-info fade in" id="Nuevomodelo" style="display: none;" runat="server">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                    <h4 class="modal-title">Nuevo modelo</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Modelo del Activo</p>
                                    <input id="Text1" runat="server" type="text" class="form-control" placeholder="Serial Producto" required>
                                    
                                </div>
                                <div class="modal-footer">
                                    <input type="button" onclick="javascript:esconde_div();" class="btn btn-outline" value="Cancelar" />
                                   
                                    <asp:Button ID="Button5" runat="server" class="btn btn-outline" Text="Guardar"  />

                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
          
          <div class="col-xs-3">
              <p hidden="true">Nuevo</p>
    <button id="btnProcesar" hidden="true" class="success" >+</button> </div>
    </form>
</body> <script>
            function esconde_div() {
                var elemento = document.getElementById("Nuevomodelo");
                elemento.style.display = 'none';
            }

            function visible_div() {
                var elemento = document.getElementById("Nuevomodelo");
                elemento.style.display = 'block';
            }

            $('#btnProcesar').on('click', function () {
               
            });

            $('select').select2({
       language: {

           noResults: function () {
               
               $('p').slideToggle('slow');
               visible_div();
               return "No hay resultados - agregar Nuevo ->"
               
           },
           searching: function () {

               return "Buscando..";
           }
       }
   });
            var lenguaje_espanol = {
                "sProcessing": "Procesando...",
            }


        </script> 
</html>
