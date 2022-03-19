<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultor16.aspx.cs" Inherits="Intranet.Vista.Sistema.Consultor16" %>

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
        * {
	margin:0;
	padding: 0;
	box-sizing: border-box;
}
        
section {
	position: relative;
	width: 100%;
	height: 100vh;

}
section video{
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	object-fit: cover;
}
section .navegacion{
	position: absolute;
	bottom: 40px;
	left: 50%;
	transform: translateX(-50%);
	z-index: 100;
	display: flex;
	justify-content: center;
	align-items:  center;
}

section .navegacion li{
	list-style: none;
	cursor: pointer;
	margin: 0 10px;
	border-radius: 2px;
	background: #eee;
	padding: 3px 3px 0;
	opacity: 0.65;
	transition: 0.6s;
}

section .navegacion li:hover{
	opacity: 1;
	background: #fff;
}

section .navegacion li img{
	width: 150px;
	transition: 0.6s;
}

section .navegacion li img:hover{
	width: 200px;
}	
        .navbar {
            z-index: 1030;
            opacity: 0.1;
        }

        /*video {
            object-fit: cover;
            width: 100vw;
            height: 100vh;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 1;
        }*/
      #myCarousel {
            object-fit: cover;
            width: 100vw;
            height: 100vh;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 1;
        }
      modal{
 width: 50vw;
            height: 30vh;
      }
    </style>
</head>
<body>
    <form action="" method="post" runat="server">
        <nav class="navbar navbar-expand-md navbar-light bg-light fixed-top transbox">
            <div class="container-fluid">
                <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                 
                        <input class="form-control me-2" type="search" runat="server" id="txtbarra" placeholder="Buscar Articulo" autofocus="autofocus" />

                        <asp:Button ID="ir" type="submit" runat="server" class="btn btn-app" Text="" OnClick="ir_Click" />
                    
                </div>
            </div>
        </nav>
     

             
 <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
        <li data-target="#myCarousel" data-slide-to="3"></li>
        <li data-target="#myCarousel" data-slide-to="4"></li>
        <li data-target="#myCarousel" data-slide-to="5"></li>
        <li data-target="#myCarousel" data-slide-to="6"></li>
        <li data-target="#myCarousel" data-slide-to="7"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
          <img src="img/1.png" style="width:100%;" />
    
      </div>

      <div class="item">
          <img src="img/2.png" style="width:100%;" />
      
      </div>
    
      <div class="item">
          <img src="img/3.png" style="width:100%;" />
        
      </div>
         <div class="item">
          <img src="img/4.png" style="width:100%;" />
        
      </div>
         <div class="item">
          <img src="img/5.png" style="width:100%;" />
        
      </div>
         <div class="item">
          <img src="img/6.png" style="width:100%;" />
        
      </div>
         <div class="item">
          <img src="img/7.png" style="width:100%;" />
        
      </div>
         <div class="item">
          <img src="img/8.png" style="width:100%;" />
        
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>

         



                <script>

                    if (!("autofocus" in document.createElement("input"))) {

                        document.getElementById("codbarr").focus();

                    }

                </script>
        <div class="body">
      

            <div class="modal" id="moda" style="display: block; z-index: 2;">
                <div class=" modal-dialog modal" id="modal" runat="server">
                    <div class="modal-content">
                        <div class="modal-header">
                            <center>
                            <h1> <asp:LABEL text="Articulo" runat="server" ID="lbarticulo" /></h1>
                        </center>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12" runat="server" id="boxvalor">
                                    <center><h1>
                                     <strong>$ <asp:label text="0" ID="lbvalor" runat="server" /></strong>
                                </h1> </center>
                                </div>
                                <div class="col-md-4" runat="server" id="dvalor1">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong>Antes</strong>
                                        </div>
                                        <div class="card-body ">

                                            <h1 class="tamañoantes"><strong>$ 
                                                <asp:Label Text="-" runat="server" id="lbvalor1"/></strong></h1>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3" runat="server" id="ddescuento">
                                    <div class="card alert-danger ">
                                        <div class="card-header">
                                            <strong>Descuento</strong>
                                        </div>
                                        <div class="card-body ">
                                            <h1><strong>
                                                <asp:Label Text="-" runat="server"  ID="lbdescuento"/></strong></h1>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-5" runat="server" id="dvalor2">
                                    <div class="card ">
                                        <div class="card-header">
                                            <strong>Ahora</strong>
                                        </div>
                                        <div class="card-body ">

                                            <h1><strong>
                                                <asp:Label Text="-" ID="lbvalordes" runat="server" />
                                                </strong></h1>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="row">
                                 <div class="col-md-4">
                                    PLU: 
                                <asp:Label Text="-" ID="LblPlu" runat="server" />
                                </div>
                                <div class="col-md-4">
                                    Saldo: 
                                <asp:Label Text="-" ID="lbsaldo" runat="server" />
                                </div>
                                <div class="col-md-4">
                                    P*U.M: $
                                <asp:Label Text="-" ID="lbpxunidad" runat="server" />
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
           </div>
      
    </form>

   
</body>

     <script type="text/javascript">
         setTimeout(function () {
             document.getElementById('modal').style.display = 'none';
         }, 50000);
        
     </script>
<script src="vendor/jquery/jquery.min.js"></script>
<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

<!-- Core plugin JavaScript-->
<script src="vendor/jquery-easing/jquery.easing.min.js"></script>
<script src="vendor/fontawesome-free/js/all.js"></script>
<!-- Custom scripts for all pages-->
<script src="js/sb-admin.min.js"></script>

</html>
