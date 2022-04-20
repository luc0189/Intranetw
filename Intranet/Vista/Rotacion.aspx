<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rotacion.aspx.cs" Inherits="Intranet.Vista.Rotacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <title>Rotacion de Inventario  - Lcs</title>
      
    <!-- Bootstrap CSS -->
   
    <link href = "https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css" rel = "stylesheet" />
            <link href="../dist/DataTables/datatables.css" rel="stylesheet" />
      <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
     
    <style>
        /*estilos para la tabla*/
        table th {
            background-color: #ee0000;
            color: white;
        }
    </style>
  </head>
<body>
    <section class="container">
      
    <form id="form1" runat="server">
        <asp:Label Text="Fecha inicial" runat="server" />
        <input type="date" name="name" value="" id="fechaIni" runat="server" />
        <asp:Label Text="Fecha Final" runat="server" />
        <input type="date" name="name" value="" id="fechaFin" runat="server" />
        <asp:Label Text="Nit" runat="server" />
        <input type="text" name="name" value="" id="nits" runat="server" />
      <%--  <asp:Button runat="server" ID="UploadButton" Text="Consultar" CssClass="btn btn-success" OnClick="UploadButton_Click" />--%>

        <div class="card card">
            <div class="card-body">
                <div class="table-responsive">
                  
                    <asp:GridView ID="GridView1" runat="server"  GridLines="None" class="gvuser" style="width:100%"
                     
                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                    </asp:GridView>
                </div>
            </div>
            <div class="card-footer">  
                <label runat="server" id="txtestado"></label>
            </div>
        </div>


    </form>
        </section>
       
    
      
       <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
   
   

    <script src="bootstrap/js/bootstrap.js"></script>
    <%--  <script src="assets/plugins/jquery/dist/jquery.min.js"></script>--%>

    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="../bower_components/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <!-- Bootstrap 3.3.7 -->
   
    <script src="../bower_components/jquery-knob/dist/jquery.knob.min.js"></script>
   
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../bower_components/fastclick/lib/fastclick.js"></script>


           <script src="../dist/DataTables/datatables.js"></script>
  
 
    
    <script type="text/javascript">


        $(document).ready(function () {
            $('.js-example-basic-single').select2();
        });

        $(document).ready(function () {


            var readURL = function (input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('.avatar').attr('src', e.target.result);
                    }

                    reader.readAsDataURL(input.files[0]);
                }
            }


            $(".file-upload").on('change', function () {
                readURL(this);
            });
        });

        $(document).ready(function () {
            $('#gvuser').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'print'
                ]
            });



        });

        $(document).ready(function () {
            GridGeneral();
            GridGeneral2();

        });
        var GridGeneral = function () {
            $(".gvuser3").prepend($("<thead></thead>").append($(".gvuser3").find("tr:first"))).dataTable({
                "language": lenguaje_espanol,
                "dom": "Bfrtip",
                responsive: true
            });
        }
        var GridGeneral = function () {
            $(".gvuser").prepend($("<thead></thead>").append($(".gvuser").find("tr:first"))).dataTable({
                "language": lenguaje_espanol,
                "dom": "Bfrtip",
                "buttons": botoneraExport,
                responsive: true
            });
        }
        var GridGeneral2 = function () {
            $(".gvuser2").prepend($("<thead></thead>").append($(".gvuser2").find("tr:first"))).dataTable({
                "language": lenguaje_espanol,
                "dom": "Bfrtip",
                "buttons": botoneraExport,
                responsive: true
            });
        }
     
        $(document).ready(function () {
            $('#gvuser').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });


        // variables comunes

        var lenguaje_espanol = {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados ",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }

        var botoneraExport =
            [
                {
                    extend: 'copy',
                    className: 'copyButton',
                    text: '<i class="fa fa-clone"></i> Copiar'
                },
                {
                    extend: 'excel',
                    text: '<i class="fa fa-file-excel-o"></i> Excel'
                },
                  
                {
                    extend: 'csv',
                    text: '<i class="fa fa-file-excel-o"></i> CSV'
                },
                 {
                    extend: 'pdf',
                    text: '<i class="fa fa-file-pdf-o"></i> PDF'
                },
                {
                    extend: 'print',
                    text: '<i class="fa fa-print"></i> Imprimir',
                    customize: function (win) {
                        $(win.document.body)
                            .css('font-size', '10pt')
                            .prepend(
                                '<img src="../dist/img/ws.png" style="position:absolute; top:0; left:1;" />'

                            );

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
                
            ]

         var botonera =
            [
               
               
            ]

    </script>

    <script type="text/javascript">

        function ComprobarAcentos(inputtext) {
            if (!inputtext) return false;
            if (inputtext.value.match('[á,é,í,ó,ú]|[Á,É,Í,Ó,Ú]')) {
                alert('No se permiten acentos en la casilla');
                inputtext.value = '';
                inputtext.focus();
                return true;
            }
            return false;
        }

    </script>
    <script>


        $('#btnProcesar').on('click', function () {

        });


    </script>

  

</body>
    


</html>