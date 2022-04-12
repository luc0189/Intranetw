<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="Intranet.Vista._1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
       
        <div class="content" style="min-height: 1113.69px;margin-top:20px">
            <div class="container-fluid">
                <div class="col-lg-12">
                </div>
                <div class="row">
                    <div class="col-md-3 col-sm-6 col-12">
                        <div class="info-box ">
                            <span class="info-box-icon bg-info">
                                <label runat="server" id="porcentaje"></label>
                                        %</span>
                            <div class="info-box-content">
                                <span class="info-box-text">Cumplimiento</span>
                                
                                <span class="info-box-number"> Ventas:
                                            <label runat="server" id="lblventasr"></label>
                                        </span>
                                <div class="progress danger">
                                    <div class="progress-bar " style="width: 70%"></div>
                                </div>
                                <span class="progress-description"> <span class="info-box-number">Ppto: <label runat="server" id="lblvrproyectado"></label> </span>
                                </span>
                            </div>

                        </div>

                    </div>
                    <div class="col-md-3 col-sm-6 col-12">
                        <div class="info-box ">
                            <span class="info-box-icon bg-info">
                                <label runat="server" id="lblporcen_Proyectado"></label>
                                                                %
                                </span>
                            <div class="info-box-content">
                                <span class="info-box-text">Proyectado</span>
                                <span class="info-box-number">Proyecta:
                                        <label runat="server" id="lblproyectado"></label></span>
                                <div class="progress">
                                    <div class="progress-bar" style="width: 70%"></div>
                                </div>
                                <span class="progress-description">Ppto:
                                        <label runat="server" id="Label1"></label>
                                </span>
                            </div>

                        </div>

                    </div>
                    <div class="col-md-3 col-sm-6 col-12">
                        <div class="info-box ">
                            <span class="info-box-icon bg-info"><i class="far fa-thumbs-up"></i> </span>
                            <div class="info-box-content">
                                <span class="info-box-text">Tendencia</span>
                                <span class="info-box-number">
                                    <h2><label runat="server" id="txtporcentaMesAnterior"></label>%</h2>
                                    
                                        </span>
                                <div class="progress">
                                    <div class="progress-bar" style="width: 70%"></div>
                                </div>
                                <span class="progress-description"> Mes Anterior:
                                    <label runat="server" id="Label3">$ ---------</label>
                                </span>
                            </div>

                        </div>

                    </div>
                    <div class="col-md-3 col-sm-6 col-12">
                        <div class="info-box bg-info">
                            <span class="info-box-icon bg-info">
                                        </span>
                            <div class="info-box-content">
                                <span class="info-box-text">Variacion Anual</span>
                                <span class="info-box-number">
                                    <h2><label runat="server" id="Label2"></label>%</h2>
                                    </span>
                                <div class="progress">
                                    <div class="progress-bar" style="width: 70%"></div>
                                </div>
                                <span class="progress-description"><span class="info-box-number">
                                    $ <asp:Label Text="text" runat="server" ID="ventasañoanterior" /> </span>
                                </span>
                            </div>

                        </div>

                    </div>
                
                    <div class="col-lg-3 col-md-3">
                     
                        
                        <div class="card card-dark">
                            <div class="card-header">
                                <div class="card-title">Compra por Cliente</div>

                            </div>
                            <div class="card-body">
                                <div class="overlay">
                                    <h1>
                                        <label runat="server" id="lblcompraclientes"></label>
                                    </h1>
                                </div>

                            </div>
                            <div class="card-footer">
                                <div class="row">
                                    <div class="col-6">
                                        <span class="info-box-number">Año Actual: </span>
                                        20.000.000
                                    </div>
                                    <div class="col-6">
                                        <span class="info-box-number">Año Anterior: </span>
                                        <strong>19.000.000</strong>
                                    </div>
                                </div>


                            </div>
                        </div>

                       <div class="card card-dark">
                            <div class="card-header">
                                <div class="card-title">Ventas Por Metro Cuadrado</div>

                            </div>
                            <div class="card-body">
                                <div class="overlay">
                                    <h1>
                                        <label runat="server" id="lblventasmetroc"></label>
                                    </h1>
                                </div>

                            </div>
                            <div class="card-footer">
                                <div class="row">
                                    <div class="col-6">
                                        <span class="info-box-number">Año Actual: </span>
                                        20.000.000
                                    </div>
                                    <div class="col-6">
                                        <span class="info-box-number">Año Anterior: </span>
                                        <strong>19.000.000</strong>
                                    </div>
                                </div>


                            </div>
                        </div>

                    </div>
                    <div class="col-lg-9">
                        <style type="text/css">
                            #global {
                                height: 600px;
                                width: 100%;
                                border: 1px solid #ddd;
                                background: #f1f1f1;
                                overflow-y: scroll;
                            }

                            #mensajes {
                                height: auto;
                            }
                        </style>
                    
                        
                        <div class="card card-dark">
                            <div class="card-header">
                                <div class="card-title">
                                      Datos Estadisiticos  
                              
                                </div>
                                <div class="card-tools">
                                    <div class="row">
                                         <div class="form-group row">
                                            <label class="label-ad" for="txtdesde">
                                                Desde:</label>
                                            <input type="date" runat="server" id="txtdesde" name="name" value="" class="col-sm-9 form-control " />

                                        </div>
                                    <div class="form-group row">
                                            <label class="col-form-label" for="txthasta">
                                                Hasta:</label>
                                            <input type="date" runat="server" id="txthasta" name="name" value="" class="col-sm-9 form-control " />

                                        </div>
                                      <asp:LinkButton ID="Btnconsulta" runat="server" Text="Listar Activos" CssClass="btn btn" OnClick="Btnconsulta_Click">
                                    <i aria-hidden="true"  class="fas fa-search"></i>
                                        </asp:LinkButton>
                                    </div>
                                    
                                </div>
                              
                            </div>
                            <div id="global">
                                <div id="mensajes">
                                    <div class="card-body p-0">
                                        <div id="accordion">

                                            <div class="card card-default" >
                                                <div class="card-body">
                                                    <div class="card card-dark" >
                                                <div class="card-header">
                                                    <h4 class="card-title ">
                                                        <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseOne" aria-expanded="false">Ventas Por Hora
                                                        </a>
                                                    </h4>
                                                    <div class="card-tools">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Listar Activos" OnClick="LinkButton1_Click">
                                                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                                <div id="collapseOne" class="collapse" data-parent="#accordion" style="">
                                                    <div class="card-body">
                                                        <div class="table table-responsive" style="max-width:996px;">
                                                             <div class="dataTables_wrapper dt-bootstrap4">

                                                            <asp:GridView ID="Gridsuper" runat="server" GridLines="None" ShowFooter="true"
                                                                CssClass="table table-bordered table-striped dataTable dtr-inline"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>

                                                        </div>
                                                        </div>
                                                          
                                                        <div class="table table-responsive">
                                                            <asp:GridView runat="server" ID="grid" AllowCustomPaging="True" ShowFooter="true" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                                                                <RowStyle CssClass="nav-link" />
                                                                
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card card-dark">
                                                <div class="card-header">
                                                    <h4 class="card-title ">
                                                        <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseTwo" aria-expanded="false">Ventas rango de Tiempo
                                                        </a>
                                                    </h4>
                                                             <div class="card-tools">
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Listar Activos" OnClick="LinkButton2_Click">
                                            <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                                    </asp:LinkButton>
                                </div>
                                                </div>
                                                <div id="collapseTwo" class="collapse" data-parent="#accordion" style="">
                                                    <div class="card-body">
                                                         <div class="table-responsive">
                                                <asp:GridView ID="Gridsupermio" ShowFooter="true" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="Gridsupermiototal" ShowFooter="true" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card card-dark">
                                                <div class="card-header">
                                                    <h4 class="card-title ">
                                                        <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseThree" aria-expanded="false">Ventas por Linea
                                                        </a>
                                                    </h4>
                                                     <div class="card-tools">
                                                        <asp:LinkButton ID="Ventaslinea" runat="server" Text="Listar Activos" OnClick="Ventaslinea_Click">
                                                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div id="collapseThree" class="collapse" data-parent="#accordion" style="">
                                                    <div class="card-body">
                                                        <asp:GridView runat="server" ID="Gridviewresumido" GridLines="None" ShowFooter="true"
                                                                CssClass=" table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                                     <div class="card card-dark">
                                                <div class="card-header">
                                                    <h4 class="card-title ">
                                                        <a class="d-block w-100 collapsed" data-toggle="collapse" href="#collapseThree3" aria-expanded="false">Ventas por Grupo
                                                        </a>
                                                    </h4>
                                                     <div class="card-tools">
                                                         <select class="select2-dark" id="select_Grupo" runat="server">
                                                            
                                                         </select>
                                                        <asp:LinkButton ID="Ventasgrupo" runat="server" Text="Ventas grupo" OnClick="Ventasgrupo_Click">
                                                                    <i aria-hidden="true"  class="fa fa-refresh"></i>Actualizar
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div id="collapseThree3" class="collapse" data-parent="#accordion" style="">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="card-title">Ventas</div>
                                                                    <asp:GridView runat="server" ID="GridviewVentas" GridLines="None" ShowFooter="true"
                                                                CssClass="table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="card-title">Devoluciones</div>
                                                                <asp:GridView runat="server" ID="GridviewDev" GridLines="None" ShowFooter="true"
                                                                CssClass=" table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                            </asp:GridView>
                                                            </div>
                                                        </div>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                                </div>
                                                  
                                            </div>
                                          
                                        </div>
                                     


                                    </div>
                              
                                  
                                </div>
                            </div>
                        </div>




                    </div>
                </div>

            </div>


        </div>





    </form>



    <script type="text/javascript">
        // Delete item


        $(document).ready(function () {
            var table = $('#tendencias').DataTable({
                "createdRow": function (row, data, index) {

                    console.log(data[3]);

                }
            });





            var item_to_delete;
            var action_to_delete;


            $('.deleteProductBon').click((e) => {
                item_to_delete = e.currentTarget.dataset.id;
                action_to_delete = 1;
            });

            $('.deleteExam').click((e) => {
                item_to_delete = e.currentTarget.dataset.id;
                action_to_delete = 2;
            });


            $("#btnYesDelete").click(function () {
                if (action_to_delete == 1) {
                    window.location.href = '/Negociations/DeleteProductBon/' + item_to_delete;
                }

            });
        });
    </script>


</asp:Content>
