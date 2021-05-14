<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Intranet.Login" %>

<!DOCTYPE html>
<!--
This is a starter template page. Use this page to start your new project from
scratch. This page gets rid of all links and provides the needed markup only.
-->
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Plataforma Web Lcsystem`s</title>
    <link rel="apple-touch-icon" href="/dist/img/LCS.png">
    <link rel="shortcut icon" href="/dist/img/LCS.PNG" type="image/PNG" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <script src="https://code.jquery.com/jquery-1.9.1.js"></script>
    <link rel="stylesheet" href="/bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="/bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="/bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css">
   
    <!-- AdminLTE Skins. We have chosen the skin-blue for this starter
        page. However, you can choose any other skin. Make sure you
        apply the skin class to the body tag so the changes take effect. -->
    <link rel="stylesheet" href="/dist/css/skins/skin-blue.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
    <style type="text/css">
        .cajalogin {
            border-radius:5px;
           border: 5px solid #ccc;
            left:50%;
            top:50%;
            -webkit-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
            -moz-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
            box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
            background-color: white;
         
           
            
        }
        img{
            left:50%;
            top:50%;
        }
        


        .login-logo a {
            color: #e6dddd;
        }

        .notifica {
            float: right;
            width: 280px;
        }

        .image {
           
            background-repeat: no-repeat;
            background-position: center;
            background-size: cover;
            width: calc(100% - 430px);
            position: absolute;
            z-index: -1;
            height: calc(100% - 1px);
        }
        h1{
            position:center;
        }
        .loginluis {
          
           
            min-height: 100vh;
            position: relative;
            background: #fff;
            float: right;
      
            font-family: raleway;
           
            padding: 30px 40px 25px 20px;
            width: 430px;
            background-color: darkgreen;
            -webkit-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
            -moz-box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
            box-shadow: -2px 3px 22px 7px rgba(0,0,0,0.80);
        }
           @media only screen and (max-width: 430px) {
 
   }
   img{
       width: 100px; height: 100px;
   }

}
            @media only screen and (max-width: 700px) {
   .loginluis{
       width:100%;
 
      padding:80px 20px 10px 20px;
   }
   img{
       width: 100px; height: 100px;
   }

}
               

    </style>

</head>

<body class="hold-transition login-page" style="background-image:url('/dist/img/se.jpg');   height:100%;  width:100%; background-repeat: no-repeat;background-size:100%;">
    <div class="box box-info box-solid notifica " id="notificacion" runat="server" style="display: block;">
        <div class="box-header with-border">
            <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excepcion</font></font></h3>

            <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label runat="server" id="error"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div>
    <%--<div class="image" >
        <img src="/dist/img/se.jpg" alt="Alternate Text" style=""/>
    </div>--%>
    

        <div class="login-box cajalogin" style="">


            <!-- /.login-logo -->
            <div class="login-box-body">

                <h1 class="login-logo">
                    <b>INICIAR SESIÓN</b> </h1>
                <form runat="server" method="post">
                    <div class="form-group has-feedback">
                        <input id="txtususario" runat="server" type="text" class="form-control" placeholder="Usuario">

                        <span class="fa fa-user-circle form-control-feedback"></span>

                    </div>
                    <div class="form-group has-feedback">
                        <input id="txtcontraseña" runat="server" type="password" class="form-control" placeholder="Contraseña">
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <select runat="server" id="selectbd" class="form-control">
                            <option value="lcsystem">Supermio</option>
                            <option value="la14">La 14 Distribuciones</option>
                        </select>
                    </div>
                    <div class="row">
                        <div class="col-xs-8">
                            <div class="checkbox icheck">
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4">
                             <a href="#">olvidaste tu contraseña?</a>
                            <asp:Button ID="Entrar" class="btn btn-success btn-block btn-flat" runat="server" Text="Entrar"
                                OnClick="validarUsuario_Click" />
                        </div>
                        <!-- /.col -->
                    </div>

                </form>
            </div>

            <!-- /.login-box-body -->
        </div>
   

</body>
<script type="text/javascript">

    $(document).ready(function () {
        setTimeout(function () {
            $(".notifica").fadeOut(6000);
        }, 3000);
    });
</script>
<script src="/bower_components/jquery/dist/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="bower_components/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script src="/bower_components/raphael/raphael.min.js"></script>
<script src="/bower_components/morris.js/morris.min.js"></script>
<script src="/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<script src="https://cdn.datatables.net/plug-ins/1.10.16/api/sum().js"></script>

<!-- jQuery Knob Chart -->
<script src="/bower_components/jquery-knob/dist/jquery.knob.min.js"></script>

<script src="/bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
<!-- datepicker -->
<script src="/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<!-- Bootstrap WYSIHTML5 -->
<script src="/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<!-- Slimscroll -->
<script src="/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="/bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="/dist/js/adminlte.min.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="/dist/js/pages/dashboard.js"></script>
<!-- DataTables -->


</html>
