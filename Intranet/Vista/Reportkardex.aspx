<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Reportkardex.aspx.cs" Inherits="Intranet.Vista.Reportkardex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="estilo_imprimir.css" media="print">      
    <section class="content">
    <div class="container bootstrap snippet">  
   
    <section class="content">
                
        
      
         <form  method="post" runat="server">
             <h3 class="box-title"><b>Reporte Kardex</b></h3>
             <div class="row">

                
                 <div class="col-md-12">
                     <div class="card">
                         <div class="card-default">
                             <div class="card-header">
                                 Filtros:
                             </div>
                             <div class="card-body">
                                 <div class="row">
                                     <div class="col-md-4">


                                         <label>Fecha inicio</label>
                                         <input runat="server" id="txtfechaini" type="date" class="form-control" label="Fecha inicio">


                                         <label>Fecha fin </label>
                                         <input runat="server" id="txtfechafin" type="date" class="form-control" placeholder="Fecha fin">
                                     </div>
                                     <div class="col-md-8">

                                         <label>Articulo</label>
                                         <select runat="server" id="Select1" class="js-example-basic-single" name="state" style="width: 100%">
                                         </select>

                                         <label>Bodega</label>
                                         <select runat="server" id="selectbodega" class="js-example-basic-single" name="state" style="width: 100%">
                                         </select>



                                     </div>
                                 </div>

                             </div>


                         </div>
                     </div>
                     <div class="card">

                         <div class="card-body">
                             <div class="btn-group">

                                 <asp:LinkButton ID="activos" runat="server" Text="Listar Activos" CssClass="btn btn-app"
                                     OnClick="llenasaldokardex">
                                            <i aria-hidden="true"  class="fa fa-search"></i>Consultar
                                 </asp:LinkButton>


                             </div>
                             <div class="btn-group">
                                 <a href='javascript:window.print(); void 0;' class="btn btn-app">
                                     <i aria-hidden="true" class=" fa fa-print"></i>Imprimir
                                 </a>
                             </div>
                             <div class="btn-group">
                                 <a href="1.aspx" class="btn btn-app">
                                     <i aria-hidden="true" class=" fa fa-home"></i>Inicio
                                 </a>
                             </div>
                             <div class="btn-group">
                                 <label class="btn btn-app">Saldo A/F:
                                     <label id="sald" class="form-control" runat="server"></label>

                                 </label> 
                                
                             </div>
                             <div class="btn-group">
                                 <label class="btn btn-app">Saldo Actual: 
                                     <label id="saldoactual" class="form-control" runat="server"></label>
                                 </label> 
                                  
                             </div>
                         </div>


                     </div>
                     <div class="card">
                         <div class="card-body">
                             <div class="table table-responsive">
                                 <asp:GridView ID="Gridkardex" runat="server" GridLines="None" OnSelectedIndexChanged="GridViewnovedades_SelectedIndexChanged"
                                     CssClass="table gvuser table-striped table-bordered text-sm" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                     <Columns>

                                         <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                                     </Columns>
                                 </asp:GridView>
                             </div>
                         </div>
                     </div>
                 </div>
                 
                
             </div>
           
                  
                        
                       
                            
             
              
                  
      <div class="alert alert-success alert-dismissible" id="lblalerta" runat="server">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">x</font></font></button>
            <h5><i class="icon fa fa-check"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Registro </font></font></h5>
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                <label runat="server" id="alertant"></label></font></font>
        </div>
      
       
         <div class="box box-warning box-solid notifica" runat="server" id="excepcion">
        <div class="box-header with-border">
            <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excp Controlada</font></font></h3>

            <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="error" runat="server"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div>
    <div class="box box-success box-solid notifica" runat="server" id="notificacion">
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
              <label id="txtnotifica" runat="server"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div> 
             </form>
    </section>
        </div>
        </section>
    <script type="text/javascript">
       

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
