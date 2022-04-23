<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="VentasXLinea.aspx.cs" Inherits="Intranet.Vista.VentasXLinea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <head>
        <title>LCSystem 3 | Ventas por Linea</title>
    </head>
    <style type="text/css">
        .auto-style2 {
            width: 184px;
        }

        .auto-style3 {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0,0,0,0.1);
            left: 0px;
            top: 6px;
        }

        .auto-style4 {
            width: 135px;
        }

        .auto-style5 {
            width: 237px;
        }

        .auto-style6 {
            width: 184px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">
                <div class="box box-warning box-solid " runat="server" id="notificacion">
                    <div class="box-header with-border">
                        <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Notificacion</font></font></h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="txtnotifica" runat="server">Recuerde verificar la lista de SMS enviados</label>
            </font></font>
                    </div>
                    <!-- /.box-body -->
                </div>
                <div class="row">
                    <div class="box box-default" id="data">
                        <div class="box-header with-border">
                            <h3 class="box-title"><b>Cumplimiento de ventas </b></h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="col-md-5">

                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon">Centro de Costo:</span>
                                        <select runat="server" id="selectBodega" class="js-example-basic-single" name="state" style="width: 100%">
                                        </select>

                                    </div>

                                </div>




                            </div>
                            <div class="col-md-4">
                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon">Desde:</span>
                                        <input type="date" runat="server" id="txtdesde" name="name" value="" class="form-control" style="width: 100%;" />

                                    </div>

                                </div>
                                <div class="form-group has-feedback">
                                    <div class="input-group">
                                        <span class="input-group-addon">hasta:</span>
                                        <input type="date" runat="server" id="txthasta" name="name" value="" class="form-control" style="width: 100%;" />

                                    </div>

                                </div>
                            </div>
                            <div class="col-md-3" id="boton">

                                <div class="box">

                                    <div class="box-body">
                                        <div class="btn-group">

                                            <asp:LinkButton ID="Btnconsulta" runat="server" Text="Listar Activos" CssClass="btn btn-app" OnClick="Btnconsulta_Click">
                                    <i aria-hidden="true"  class="fa fa-search"></i>Consultar
                                            </asp:LinkButton>


                                        </div>
                                        <div class="btn-group">
                                            <a href='javascript:window.print(); void 0;' class="btn btn-app">
                                                <i aria-hidden="true" class=" fa fa-print"></i>Imprimir
                                            </a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box">
                                            <div class="box-header with-border">
                                                <h3 class="box-title"><b>Informe resumido</b></h3>

                                                <div class="box-tools pull-right">
                                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                        <i class="fa fa-minus"></i>
                                                    </button>
                                                    <div class="btn-group">
                                                        <button type="button" class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown">
                                                            <i class="fa fa-wrench"></i>
                                                        </button>
                                                        <ul class="dropdown-menu" role="menu">
                                                            <li><a href="#">Action</a></li>
                                                            <li><a href="#">Another action</a></li>
                                                            <li><a href="#">Something else here</a></li>
                                                            <li class="divider"></li>
                                                            <li><a href="#">Separated link</a></li>
                                                        </ul>
                                                    </div>
                                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                </div>
                                            </div>
                                            <!-- /.box-header -->
                                            <div class="box-body">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <p class="text-center">
                                                            <strong><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Ventas: desde <label runat="server" id="labelFechainicio"></label> - Hasta: <label runat="server" id="labelfechafin"></label></font></font></strong>
                                                        </p>

                                                        <div class="table-responsive">
                                                            <asp:GridView runat="server" ID="Gridviewresumido" GridLines="None"
                                                                CssClass=" table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>
                                                        </div>
                                                        <!-- /.chart-responsive -->
                                                    </div>
                                                    <!-- /.col -->
                                                    <div class="col-md-8">
                                                        <p class="text-center">
                                                            <strong><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Cumplimiento de Objetivos</font></font></strong>
                                                        </p>
                                                        <div class="box">
                                                            <div class="box-body">
                                                                       <div class="small-box ">
                                                                <div class="inner">
                                                                    <span class="progress-description">
                                                                        <div class="col-md-6">
                                                                            <div class="auto-style3">
                                                                                <div class="box-header">
                                                                                    <h5>Ventas: </h5>
                                                                                    <div class="box-tools">
                                                                                        <h1><b>
                                                                                            <label runat="server" id="porcentaje"></label>
                                                                                            %</b></h1>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="box-body">
                                                                                    <td>
                                                                                        <label runat="server" id="lblventasr"></label>
                                                                                    </td>
                                                                                    <div class="progress active">
                                                                                        <div class="progress-bar progress-bar-success progress-bar-striped" style="width: 1%" id="bar1" runat="server"></div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="box">
                                                                                <div class="box-header">
                                                                                    <h5>Proyectado: </h5>
                                                                                    <div class="box-tools">
                                                                                        <h1><b>
                                                                                            <label runat="server" id="lblporcen_Proyectado"></label>
                                                                                            %</b></h1>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="box-body">
                                                                                    <label runat="server" id="lblproyectado"></label>
                                                                                    <div class="progress active">
                                                                                        <div class="progress-bar progress-bar-success progress-bar-striped" style="width: 1%" id="bar2" runat="server"></div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                        </div>
                                                                    </span>
                                                                    <div class="text-center">
                                                                          <h4>Meta:  <label runat="server" id="lblvrproyectado"></label></h4>
                                                                    </div>




                                                                </div>


                                                            </div>
                                                           
                                                            </div>
                                                     

                                                        </div>
                                                        <!-- small box -->




                                                    </div>
                                                    <!-- /.col -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- ./box-body -->
                                            <div class="box-footer">
                                                <div class="row">
                                                    <div class="col-sm-3 col-xs-6">
                                                        <div class="description-block border-right">
                                                           <%-- <i class="fa fa-caret-up"></i>--%>
                                                            <span class="description-percentage text-green"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><label runat="server" id="txtporcentaMesAnterior"></label>%</font></font></span>
                                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></h5>
                                                            <span class="description-text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">VARIACION MENSUAL</font></font></span>
                                                        </div>
                                                        <!-- /.description-block -->
                                                    </div>
                                                    <!-- /.col -->
                                                    <div class="col-sm-3 col-xs-6">
                                                        <div class="description-block border-right">
                                                            <%--<span class="description-percentage text-yellow"><i class="fa fa-caret-left"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> 0%</font></font></span>--%>
                                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><label runat="server" id="lblcompraclientes"></label> </font></font></h5>
                                                            <span class="description-text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">PROMEDIO COMPRA CLIENTES</font></font></span>
                                                        </div>
                                                        <!-- /.description-block -->
                                                    </div>
                                                    <!-- /.col -->
                                                    <div class="col-sm-3 col-xs-6">
                                                        <div class="description-block border-right">
                                                            <%--<span class="description-percentage text-green"><i class="fa fa-caret-up"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> </font></font></span>--%>
                                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><LABEL runat="server" id="lblpromventadiaria"></LABEL></font></font></h5>
                                                            <span class="description-text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">PROMEDIO VENTA DIARIA</font></font></span>
                                                        </div>
                                                        <!-- /.description-block -->
                                                    </div>
                                                    <!-- /.col -->
                                                    <div class="col-sm-3 col-xs-6">
                                                        <div class="description-block">
                                                           <%-- <span class="description-percentage text-red"><i class="fa fa-caret-down"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></span>--%>
                                                            <h5 class="description-header"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><LABEL runat="server" id="lblventasmetroc"></LABEL></font></font></h5>
                                                            <span class="description-text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">VENTAS/ METRO CUADRADO</font></font></span>
                                                        </div>
                                                        <!-- /.description-block -->
                                                    </div>
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.box-footer -->
                                        </div>
                                        <!-- /.box -->
                                    </div>
                                    <!-- /.col -->
                                </div>


                            </div>


                            <div class="box box-default">
                                <div class="box-header with-border">

                                    <div class="form-group">
                                        <h3 class="box-title"><b>Detallado</b></h3>
                                        <div class="input-group">
                                            <span class="input-group-addon">Linea:</span>
                                            <select runat="server" id="selectLinea" class="js-example-basic-single" name="state">
                                            </select>

                                        </div>

                                    </div>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div class="table-responsive">
                                        <asp:GridView runat="server" ID="Gridviewventaslinea" GridLines="None"
                                            CssClass="gvuser table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </form>
        </div>
    </section>
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
</asp:Content>
