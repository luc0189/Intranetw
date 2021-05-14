

//$('#example').DataTable(); //Para inicializar datatables de la manera más simple

//$(document).ready(function () {
   

//    $(document).ready(function () {
//        $('.js-example-basic-single').select2();
//        });


//        });

//        $(document).ready(function () {
//        //GridGeneral();
//            GridGeneral2();

          

//        });
       
//        //var GridGeneral = function () {
//        //$(".gvuser").prepend($("<thead></thead>").append($(".gvuser").find("tr:first"))).dataTable({
//        //    "language": lenguaje_espanol,
//        //    "dom": "Bfrtip",
//        //    "buttons": botoneraExport,
//        //    responsive: true
//        //});
//        //}
//        var GridGeneral2 = function () {
//            //$("#GridView1").prepend($("<thead></thead>").append($("#GridView1").find("tr:first"))).dataTable({
//            //"language": lenguaje_espanol,
//            //"dom": "Bfrtip",
//            //"buttons": botoneraExport,
//            //responsive: true
//            //});
//            $('#GridView1 tfoot th').each(function () {
//                var title = $(this).text();
//                $(this).html('<input type="text" placeholder="Search ' + title + '" />');
//            });
         
//}
//var table = $('#GridView1').DataTable({
//    initComplete: function () {
//        // Apply the search
//        this.api().columns().every(function () {
//            var that = this;

//            $('input', this.footer()).on('keyup change clear', function () {
//                if (that.search() !== this.value) {
//                    that
//                        .search(this.value)
//                        .draw();
//                }
//            });
//        });
//    }
//});

//var botoneraExport =
//    [
//        {
//            extend: 'copy',
//            className: 'copyButton',
//            text: '<i class="fa fa-clone"></i> Copiar'
//        },
//        {
//            extend: 'excel',
//            text: '<i class="fa fa-file-excel-o"></i> Excel'
//        },

//        {
//            extend: 'csv',
//            text: '<i class="fa fa-file-excel-o"></i> CSV'
//        },
//        {
//            extend: 'pdf',
//            text: '<i class="fa fa-file-pdf-o"></i> PDF'
//        },
//        {
//            extend: 'print',
//            text: '<i class="fa fa-print"></i> Imprimir',
//            customize: function (win) {
//                $(win.document.body)
//                    .css('font-size', '10pt')
//                    .prepend(
//                        '<img src="../dist/img/ws.png" style="position:absolute; top:0; left:1;" />'

//                    );

//                $(win.document.body).find('table')
//                    .addClass('compact')
//                    .css('font-size', 'inherit');
//            }
//        }

//    ]
     
//        var lenguaje_espanol = {
//        "sProcessing": "Procesando...",
//            "sLengthMenu": "Mostrar _MENU_ registros",
//            "sZeroRecords": "No se encontraron resultados ",
//            "sEmptyTable": "Ningún dato disponible en esta tabla",
//            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
//            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
//            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
//            "sInfoPostFix": "",
//            "sSearch": "Buscar:",
//            "sUrl": "",
//            "sInfoThousands": ",",
//            "sLoadingRecords": "Cargando...",
//            "oPaginate": {
//        "sFirst": "Primero",
//                "sLast": "Último",
//                "sNext": "Siguiente",
//                "sPrevious": "Anterior"
//            },
//            "oAria": {
//        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
//                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
//            }
//        }

//         var botonera =
//            [


//            ]


initComplete: function () {
    var r = $('#GridView1 tfoot tr');
    r.find('th').each(function () {
        $(this).css('padding', 8);
    });
    $('#GridView1 thead').append(r);
    $('#search_0').css('text-align', 'center');
},

$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#GridView1 tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $('#GridView1').DataTable({
        initComplete: function () {
            // Apply the search
            this.api().columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change clear', function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            });
        }
    });

});