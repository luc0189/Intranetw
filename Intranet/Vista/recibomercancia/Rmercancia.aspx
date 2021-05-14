<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rmercancia.aspx.cs" Inherits="Intranet.Vista.recibomercancia.Rmercancia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link id="theme" rel="stylesheet" href="../assets/css/themes/theme-beige.min.css" />
    <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css" />
    <!-- Morris chart -->
    <link rel="stylesheet" href="../../bower_components/morris.js/morris.css" />


    <!-- Date Picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../../bower_components/bootstrap-daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" href="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" />
    <link href="../plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/themes/theme-beige.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
   


    <title>RMercancia</title>
</head>
<body>

    <form id="form1" runat="server">
       
              <div class="card">
                  <div class="container">
                       <div class="col-sm-9">
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#home">Recibo</a></li>
                    <li ><a data-toggle="tab"  href="#Dev">Devoluciones</a></li>

                </ul>


                <div class="tab-content">

                    <div class="tab-pane active " id="home">
                             <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="card">
                                    <div class="card-header">

                                            <strong>
                                                <center>
                                                 <h4><label id="txtdetalle" class="fw-bold" runat="server">descripcion del articulo</label></h4>
                                            </center>
                                            </strong>
                                        <div class="shadow p-3 mb-2 bg-body rounded">
                                            <div class="row align-items-start">
                                                <div class="col">
                                                    <strong>
                                                        <label>#OC: </label>
                                                    </strong>
                                                    <asp:Label runat="server" ID="txtnombreProveedor" />
                                                </div>


                                                <div class="col">
                                                    <strong>
                                                        <label>PLU:</label>
                                                    </strong>

                                                    <asp:Label Text="text" ID="txtplu" runat="server" Style="max-width: 60px;" />
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                    <center>
                                    <strong>
                                        <label>CantOc:</label>
                                    </strong>

                                    <asp:Label Text="text" ID="txtCantOc" runat="server" Style="max-width: 60px;" />
                          <strong>
                                        <label>Costo:</label>
                                    </strong>

                                    <asp:Label Text="txtcosto" ID="txtcosto" runat="server" Style="max-width: 60px;" /> 
                                        
                                        <strong>
                                        <label>Piva:</label>
                                    </strong>

                                    <asp:Label Text="Piva" ID="Piva" runat="server" Style="max-width: 60px;" />
                                        <strong>
                                        <label>PcodigoIva:</label>
                                    </strong>

                                    <asp:Label Text="PcodigoIva" ID="PcodigoIva" runat="server" Style="max-width: 60px;" />
                                       <strong>
                                        <label> Factor:</label>
                                    </strong>

                                    <asp:Label Text="PcodigoIva" ID="pfactor" runat="server" Style="max-width: 60px;" /> 
                                        <strong>
                                        <label> P:</label>
                                    </strong>

                                    <asp:Label Text="PnamePres" ID="PnamePres" runat="server" Style="max-width: 60px;" />
                                </center>
                                    <div class="card-body">
                                       <div class="row align-items-start">
                                           
                                            <div class="col">
                                                   <div class="input-group mb-3">
                                                    <input type="text" name="name" value="" class="form-control" id="txtcodbarra" runat="server" placeholder="Barras"  />
                                                    <asp:Button ID="Btnir" class="btn btn-success" runat="server" Text="Ir"
                                                        OnClick="Actualiza_Click" />
                                            </div>

                                                <input type="number" name="name" id="txtcant" class="form-control" runat="server" placeholder="Cantidad" value="" />
                                                   
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                    <%--<textarea id="TextArea1" placeholder="Observacion" runat="server" cols="20" rows="2"></textarea>--%>
                             

                                <div class="card">
                                    <div class="card-header">
                                        <label>Estado:</label>
                                        <textarea runat="server" id="txtestado" disabled="disabled" style="width: 100%;"></textarea>

                                    </div>
                                    <div class="card-body">


                                        <a id="back" href="../R_compras.aspx" class="btn btn-primary" runat="server"><</a>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Recibir" OnClick="btnguarda_Click" class="btn btn-success"> </asp:LinkButton>
                                        <%-- <asp:LinkButton ID="btndevolucion" runat="server" Text="R. Dev." OnClick="btndevolucion_Click" class="btn btn-danger"> </asp:LinkButton>
                        <asp:LinkButton ID="btnRnPedido" runat="server" Text="R.N pedido" OnClick="btnRnPedido_Click" class="btn btn-warning"> </asp:LinkButton>--%>
                                    </div>

                                </div>
                                <div class="table table-responsive">
                                    <asp:GridView runat="server" ID="GridviewListaItems" GridLines="None"
                                        CssClass=" table table-striped dysplay" OnDataBound="GridviewItemsCompra_DataBound" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        <Columns>

                                            <%-- <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../dist/img/iconfinder_sms_43332.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Recibir" >

                                              
                                              </asp:CommandField>--%>
                                        </Columns>
                                    </asp:GridView>
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
                    </div>
                    <div class="tab-pane " id="Dev" >
                    
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="card">
                                    <div class="card-header">

                                            <strong>
                                                <center>
                                                 <h4><label id="Devnamearticulo" class="fw-bold" runat="server">descripcion del articulo</label></h4>
                                            </center>
                                            </strong>
                                        <div class="shadow p-3 mb-2 bg-body rounded">
                                            <div class="row align-items-start">
                                                <div class="col">
                                                    <strong>
                                                        <label>#OC: </label>
                                                    </strong>
                                                    <asp:Label runat="server" ID="DevOc" />
                                                </div>


                                                <div class="col">
                                                    <strong>
                                                        <label>PLU:</label>
                                                    </strong>

                                                    <asp:Label Text="text" ID="Dev_plu" runat="server" Style="max-width: 60px;" />
                                                </div>

                                            </div>
                                        </div>

                                    </div>

                                    <center>
                                    <strong>
                                        <label>CantOc:</label>
                                    </strong>

                                    <asp:Label Text="text" ID="Dev_CantOc" runat="server" Style="max-width: 60px;" />
                                       <strong>
                                        <label>Costo:</label>
                                    </strong>

                                    <asp:Label Text="txtcosto" ID="Dev_Costo" runat="server" Style="max-width: 60px;" /><strong>
                                        <label>iva:</label>
                                    </strong>

                                    <asp:Label Text="Dev_Piva" ID="Dev_Piva" runat="server" Style="max-width: 60px;" />
                                        
                                        <strong>
                                        <label>CodigoIva:</label>
                                    </strong>

                                    <asp:Label Text="Dev_PcodigoIva" ID="Dev_PcodigoIva" runat="server" Style="max-width: 60px;" />
                                        <strong>
                                        <label>Factor:</label>
                                    </strong>

                                    <asp:Label Text="Dev_Pfactor" ID="Dev_Pfactor" runat="server" Style="max-width: 60px;" /><strong>
                                        <label>P:</label>
                                    </strong>

                                    <asp:Label Text="Dev_PnamePres" ID="Dev_PnamePres" runat="server" Style="max-width: 60px;" />
                                </center>



                                    <div class="card-body">
                                        <div class="row align-items-start">
                                            <div class="col">
                                                <div class="input-group mb-3">
                                                    <input type="text" name="name" value="" class="form-control" id="Dev_barra" runat="server" placeholder="Barras" onfocusout="myFunction()" />
                                                    <asp:Button ID="BtnDevbuscar" class="btn btn-danger" runat="server" Text="Ir"
                                                        OnClick="BtnDevbuscar_Click" />
                                                </div>

                                                <input type="number" name="name" id="Dev_cantidad" class="form-control" runat="server" placeholder="Cantidad" value="" />
                                                <%--  <input type="text" name="name" id="costo" class="form-control" runat="server" placeholder="Costo" value="" />--%>
                                            </div>
                                          

                                        </div>






                                    </div>
                                    <%--<textarea id="TextArea1" placeholder="Observacion" runat="server" cols="20" rows="2"></textarea>--%>
                                </div>

                                <div class="card">
                                    <div class="card-header">
                                        <label>Estado:</label>
                                        <textarea runat="server" id="Dev_estado" disabled="disabled" style="width: 100%;"></textarea>

                                    </div>
                                    <div class="card-body">


                                        <a id="A1" href="../R_compras.aspx" class="btn btn-primary" runat="server"><</a>
                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Devolucion" OnClick="Devolucion_Click" class="btn btn-danger"> </asp:LinkButton>
                                        <%-- <asp:LinkButton ID="btndevolucion" runat="server" Text="R. Dev." OnClick="btndevolucion_Click" class="btn btn-danger"> </asp:LinkButton>
                        <asp:LinkButton ID="btnRnPedido" runat="server" Text="R.N pedido" OnClick="btnRnPedido_Click" class="btn btn-warning"> </asp:LinkButton>--%>
                                    </div>

                                </div>
                                <div class="table table-responsive">
                                    <asp:GridView runat="server" ID="Gridview_Dev" GridLines="None"
                                        CssClass=" table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        <Columns>

                                            <%-- <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="../dist/img/iconfinder_sms_43332.png" ControlStyle-CssClass="c" AccessibleHeaderText="Envio SMS" HeaderText="Recibir" >

                                              
                                              </asp:CommandField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
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
                    </div>
                </div>
            </div>
                  </div>
           
        </div>
      
      







    </form>
    <%-- <asp:LinkButton ID="btnguarda"  runat="server" OnClick="btnguarda_Click">Guardar</asp:LinkButton>--%>
</body>
<script type="text/javascript">
    function myFunction() {
        document.getElementById('<%= Btnir.ClientID %>').click();

    }
</script>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>



<script src="../../bower_components/jquery/dist/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="../../bower_components/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
    $.widget.bridge('uibutton', $.ui.button);
</script>
<!-- Bootstrap 3.3.7 -->
<script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Morris.js charts -->
<script src="../../bower_components/raphael/raphael.min.js"></script>
<script src="../../bower_components/morris.js/morris.min.js"></script>
<!-- Sparkline -->
<script src="../../bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"></script>

<!-- jQuery Knob Chart -->
<script src="../../bower_components/jquery-knob/dist/jquery.knob.min.js"></script>
<!-- daterangepicker -->
<script src="../../bower_components/moment/min/moment.min.js"></script>
<script src="../../bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
<!-- datepicker -->
<script src="../../bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<!-- Bootstrap WYSIHTML5 -->
<script src="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<!-- Slimscroll -->
<script src="../../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="../../bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="../../dist/js/pages/dashboard.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../../dist/js/demo.js"></script>
<script src="../../dist/select2/dist/js/select2.min.js"></script>



</html>
