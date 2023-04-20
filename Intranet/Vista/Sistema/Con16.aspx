<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con16.aspx.cs" Inherits="Intranet.Vista.Sistema.Con16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="LCSystem">
    <link href="css/sb-admin.css" rel="stylesheet" />
    <link href="vendor/fontawesome-free/css/all.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <title>Consultor</title>

 <style>
        html {
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
            font-size: 150%;
            line-height: 1.4;
        }


      
    </style>
</head>
<body>
    <form action="" method="post" runat="server">
        <nav class="navbar navbar-expand-xl navbar-dark bg-dark">
            <img style="padding: 5px" src="https://supermio.co/wp-content/uploads/2021/07/cropped-logo_supermio.png" width="300" height="75" class="d-inline-block align-top" alt="">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample06" aria-controls="navbarsExample06" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExample06">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="dropdown-item" href="#">Registro</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="supermio.co">Vovler a Supermio</a>
                    </li>
                   
                    
                </ul>
               
            </div>
        </nav>


         



                <script>

                    if (!("autofocus" in document.createElement("input"))) {

                        document.getElementById("codbarr").focus();

                    }

                </script>

        <div class="row">
            <form class="form-horizontal" role="form" asp-action="Register" method="post">
                <div class="card alert-success">
                    <div class="card-header">
                        <section class="content-header">
                            <div class="container-fluid">
                                <div class="row mb-2">
                                    <div class="col-sm-6">
                                        <h1>Registro Clientes SuperMio</h1>

                                    </div>

                                </div>
                            </div>
                        </section>


                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="card ">

                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-5">

                                            <div class="card alert-info">
                                                <div class="card-header">
                                                    <label><strong>Datos Personales</strong></label>
                                                </div>
                                                <div class="card-body">
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4"># Documento:</label>
                                                        <div class="col-sm-8">
                                                            <input type="number" class="form-control" placeholder="Ej: 22222222">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Primer Nombre:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: Miguel">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Segundo Nombre:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: Andres">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Primer Apellido:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: Henao">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Segundo Apellido:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: Rojas">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Telefono (sin espacios)</label>
                                                        <div class="col-sm-8">
                                                            <input type="number" class="form-control" placeholder="Ej: 3104444444">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Correo Electronico:</label>
                                                        <div class="col-sm-8">
                                                            <input type="email" class="form-control" placeholder="Ej: miguelandresrojas99@gmail.com">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Direccion:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: CL 13 # 13 - 53">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Ciudad:</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control" placeholder="Ej: Florencia - Caqueta">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-4">Fecha Nacimiento:</label>

                                                        <div class="col-sm-8">

                                                            <input type="date" class="form-control" placeholder="">
                                                        </div>
                                                    </div>

                                                </div>



                                            </div>


                                        </div>


                                        <div class="col-md-7">
                                            <div class="card alert-danger">
                                                <div class="card-header">
                                                    <label><strong>Politica de Tratamiento de Datos Personales</strong></label>

                                                </div>
                                                <div class="card-body">

                                                    <p>
                                                        Dando cumplimiento a lo dispuesto en la Ley 1581 de 2012,  (la cual tiene por objeto desarrollar el
                                    derecho constitucional que tienen todas las personas a conocer, actualizar y rectificar las
                                    informaciones que se hayan recogido sobre ellas en bases de datos o archivos, y los demás
                                    derechos, libertades y garantías constitucionales a que se refiere el artículo 15 de la Constitución
                                    Política; así como el derecho a la información consagrado en el artículo 20 de la misma) y de
                                    conformidad con lo señalado en el Decreto 1377 de 2013, por la cual se dictan disposiciones
                                    generales para la protección de datos personales, es decir, los derechos que tienen los terceros de
                                    conocer, actualizar y rectificar todo tipo de información que haya sido objeto de tratamiento de
                                    datos personales en bancos o bases de datos y en general en archivos públicos y/o privados;
                                                    </p>
                                                    <p>
                                                        Manifiesto que he sido informado de:"
                                                    </p>
                                                    <ul>
                                                        <li>A) Que SUPERMIO S.A.S, como responsable del tratamiento
                                        de los datos personales obtenidos a través de sus distintos canales, ha puesto a mi disposición la
                                        línea de atención 4343231 EXT 106-107-115-101, el correo electrónico:
                                        supermiosas@gmail.com, las oficinas de atención ubicadas en la Calle 16 No. 12-42 Barrio El
                                        Centro y la página web www.supermio.co
                                                        </li>
                                                        <li>B) Que esta autorización permitirá a SUPERMIO
                                        S.A.S, recolectar, transferir, almacenar, usar, circular, suprimir, compartir, actualizar y transmitir
                                        información de acuerdo con el procedimiento para el tratamiento de los datos personales en
                                        procura de cumplir con el desarrollo normal de su objeto social.
                                                        </li>
                                                        <li>Por lo tanto, SUPERMIO S.A.S queda autorizada de manera libre, expresa e inequívoca para
                                        mantener y manejar toda su información; En caso de que usted considere que SUPERMIO S.A.S
                                        dio un uso contrario al autorizado y a las leyes aplicables; según el presente documento, usted
                                        podrá contactarnos a través de cualquiera de nuestros canales de atención mencionados
                                        anteriormente.
                                                        </li>
                                                    </ul>
                                                    <p>
                                                        Nuestra politica de tratamiento de datos puede ser consultada en la pagina Web <a href="https://supermio.co/informacion/">Supermio.co</a>
                                                    </p>


                                                </div>
                                                <div class="card-footer">
                                                    <div class="form-group">
                                                        <div class="col-sm-offset-2 col-sm-10">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox">
                                                                    Permitir Envio Notificaciones
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-offset-2 col-sm-10">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox">Acepto los términos y Condiciones
                                                                </label>
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
                    <div class="card-footer">
                        <div class="row">
                            <div class="col-sm-offset-1 btn-group">
                                <button type="submit" class="btn btn-success">Registrar</button>
                            </div>
                        </div>

                    </div>
                </div>

            </form>
        </div>


    </form>

   
</body>
<script type="text/javascript">
    setTimeout(function () {
        document.getElementById('modal').style.display = 'none';
    }, 5000);


</script>
<script src="vendor/jquery/jquery.min.js"></script>
<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

<!-- Core plugin JavaScript-->
<script src="vendor/jquery-easing/jquery.easing.min.js"></script>
<script src="vendor/fontawesome-free/js/all.js"></script>
<!-- Custom scripts for all pages-->
<script src="js/sb-admin.min.js"></script>

</html>