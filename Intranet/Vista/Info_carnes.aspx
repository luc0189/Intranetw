<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Info_carnes.aspx.cs" Inherits="Intranet.Vista.Info_carnes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Informe Carnes</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                        <li class="breadcrumb-item active">Informes</li>
                        <li class="breadcrumb-item active">Informe Carnes </li>

                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <form method="post" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-dark">
                                <div class="card-header">
                                    Filtros:
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-8">
                                           
                                             
                                                  
                                                        <label for="selectgrupo" class="col-sm-2 control-label">Grupo</label>

                                                        <select id="selectgrupo" runat="server" class="js-example-basic-single form-control" style="width: 100%">
                                                            <option value="00000356">CERDO</option>
                                                            <option value="360">CARNE DE RES </option>
                                                            <option value="00000357">POLLO</option>
                                                            <option value="00000351">MAC-POLLO</option>
                                                            <option value="329">PECES Y MAR</option>
                                                            <option value="368">VISCERAS</option>
                                                        </select>

                                           
                                                
                                           
                                      
                                          
                                      
                                            


                                            <label>Sala de Ventas </label>
                                            <select id="selectSucursal" runat="server" class="js-example-basic-single sm" style="width: 100%">
                                                <option value="000001">SUPERMIO LA 16</option>
                                                <option value="000002">SUPERMIO LA 13</option>
                                                <option value="000004">SUPERMIO VERSALLES</option>
                                                <option value="000005">SUPERMIO CIUDADELA</option>

                                            </select>
                                        </div>
                                        <div class="col-md-4">

                                            <label>Fecha Inicio</label>
                                            <input runat="server" id="txtfechaini" type="date" class="form-control input-sm" label="Fecha inicio">

                                            <label>Fecha Fin</label>
                                            <input runat="server" id="txtfechafin" type="date" class="form-control">
                                        </div>
                                    </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                  
                   
                           

                            
            
               

            

                    <div class="col-md-12">
                        <!-- MAP & BOX PANE -->
                        <div class="card card-dark">
                            <div class="card-header with-border">
                                <h3 class="card-title">Reportes Bnet Empresarial</h3>

                                <div class="card-tools pull-right">
                                    <asp:LinkButton ID="activos" runat="server" Text="Listar Datos" class="btn btn-info"
                                        OnClick="Buscararticulo">
                                    </asp:LinkButton>
                                    
                                    
                                </div>
                            </div>
                           
                            <div class="card-body no-padding">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card card-dark">
                                            <div class="card-header">
                                                Ventas
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridViewBnet" runat="server" GridLines="None"
                                                        CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                          
                                        </div>
                                    </div> 
                                    <div class="col-md-6">
                                        <div class="card card-danger">
                                            <div class="card-header">
                                                Devoluciones
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridViewdV" runat="server" GridLines="None"
                                                        CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                        CellSpacing="0" EmptyDataText="No se realizo ninguna Devolucion.">
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                          
                                        </div>
                                    </div>
                                    
                                 
                                </div>
                               

                            </div>

                        </div>

                    </div>

                    <div class="col-md-12">
                        <div class="card card-dark">
                            <div class="card-header with-border">
                                <h3 class="card-title">Reportes Basculas</h3>

                                <div class="card-tools pull-right">
                                   <asp:LinkButton ID="LinkButton1" runat="server" Text="Listar Datos" class="btn btn-info btn-flat-sm"
                            OnClick="BuscaBasculas">
                        </asp:LinkButton>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="card-body no-padding">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridViewBasculas" runat="server" GridLines="None"
                                                    CssClass="gvuser1 table table-striped table-bordered text-sm"
                                                    CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                


                               
                                <!-- /.row -->


                                <!-- /.box -->

                            </div>

                        </div>
                    </div>
               



                <!-- MAP & BOX PANE -->






            </form>
        </div>
    </section>
    <script type="text/javascript">
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

                    return "No hay resultados - Clic en Nuevo"

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
</asp:Content>
