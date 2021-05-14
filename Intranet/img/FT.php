<?php

		if(isset($_POST['submit']))

		{

			$name = $_POST['name'];


		}

		?>

		<!DOCTYPE html>
		<!--[if IE 8]>			<html class="ie ie8"> <![endif]-->
		<!--[if IE 9]>			<html class="ie ie9"> <![endif]-->

		<!--[if gt IE 9]><!-->	<html> <!--<![endif]-->
		<head>

			<!-- Meta -->
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8" >


			

			<title>CONSULTOR2</title>

			<!-- Mobile Meta -->
			
			<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
			<link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
			<link rel="stylesheet" href="style.css">
			<!-- Font Awesome -->
			<link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
			<!-- Ionicons -->
			<link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
			<!-- select2 -->
			<link rel="stylesheet" href="bower_components/select2/dist/css/select2.min.css">
			<link rel="stylesheet" href="bower_components/select2/dist/css/select2.css">
			<link rel="stylesheet" href="styleS.css">
			<!-- Theme style -->
			<link rel="stylesheet" href="dist/css/AdminLTE.min.css">
		<!-- AdminLTE Skins. We have chosen the skin-blue for this starter
		    page. However, you can choose any other skin. Make sure you
		    apply the skin class to the body tag so the changes take effect. -->
		    <!-- data tabless -->




		    <link rel="stylesheet" href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css">    
		    <link rel="stylesheet" href="bower_components/datatables.net-bs/css/buttons.dataTables.min.css"  />
		    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css">

		    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
		    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
		<!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
		<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
	<![endif]-->
	<!-- Google Font -->

</head>
<body>	<video src="img/video.mp4" autoplay loop muted=""></video>

	<div class="body">

		<!-- Header -->
		<header>
			<div class="container">


				<form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">

					<input type="text" autofocus id="codbarr" name="name">

					<button type="submit" name="submit" class="btn btn-danger btn-flat">Go!</button>


				</form>
				<script>

					if( ! ("autofocus" in document.createElement( "input" ) ) )

					{

						document.getElementById( "codbarr" ).focus();

					}

				</script>


				<?php


		 $serverName = "192.168.1.113,7433"; //serverName\instanceName, portNumber (por defecto es 1433)
		 $connectionInfo = array( "Database"=>"supermio", "UID"=>"l.sanchez", "PWD"=>"Team0103");
		 $conn = sqlsrv_connect ( $serverName, $connectionInfo);

		 if( $conn ) {


		 }else{
		 	echo "Conexión no se pudo establecer";
		 	die( print_r( sqlsrv_errors(), true));
		 }

		 if($name==''){
		 	echo "Ingrese Codigo de barras";
		 }else{

		 	$sql = "SELECT a.codigo,  a.detalle, cd.codbarra,cast(valormiva as int)as
		 	valormiva,cast(a.peso as int)as peso, cast(condiprom.vrveneficio as int)as descuento from articulo a 
		 	left join dbo.artspromo aprom ON a.codigo=aprom.articuloID
		 	left join dbo.condicionpromo condiprom ON aprom.promocionID=condiprom.promocionID
		 	left JOIN dbo.promocion promo ON condiprom.promocionID=promo.id
		 	left join codbar cd on cd.articuloID = a.codigo 
		 	left join precio pc on pc.articuloID=a.codigo and (pc.presentacionID=cd.presentacionID or (pc.presentacionID is null and cd.presentacionID is null))
		 	where inactivo = 0 and cd.CODBARRA ='$name' and pc.listprecioID='BX1'";
		 	$stmt = sqlsrv_query( $conn, $sql );
		 	if( $stmt === false) {
		 		die( print_r( sqlsrv_errors(), true) );
		 	}

		 	while( $row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC) ) {
		 		$datatoencode = $row['codbarra'] ;
		 		$named = $row['detalle'];
		 		$seatnumber = $row['codigo'];
		 		$valor=$row['valormiva'];
		 		$numero = number_format($valor);
		 		$cod=$row['codigo'];
		 		$p=$row['peso'];
		 		$d=$row['descuento'];
		 		$total=$valor;
		 		$sqlsaldo="SELECT cast(sum(cantidad) as int) as cant From dbo.vwsaldosart with (noexpand) where articuloID='$cod' and bodegaID='011'";
		 		$stmtsaldos=sqlsrv_query($conn,$sqlsaldo);
		 		if(stmtsaldos===false){
		 			die(print_r(sqlsrv_errors(),true));
		 		}while($rowsaldos=sqlsrv_fetch_array($stmtsaldos,SQLSRV_FETCH_ASSOC)){
		 			$can=$rowsaldos['cant'];
		 		}
		 		if($d>=1){ 
		 			$sqldesc= " SELECT ap.articuloID,cast(condip.vrveneficio as int)as vrveneficio
		 			from artspromo ap inner join promocion p on ap.promocionID=p.id
		 			inner join dbo.condicionpromo condip on ap.promocionID=condip.promocionID
		 			where getdate()<= p.fhasta AND getdate()>=p.fdesde and activa=1 and ap.articuloID='$seatnumber'";
		 			$stmtdescuento=sqlsrv_query($conn,$sqldesc);
		 			if(stmtdescuento===false){
		 				die(print_r(sqlsrv_errors(),true));
		 			}
		 			while($rowdes=sqlsrv_fetch_array($stmtdescuento,SQLSRV_FETCH_ASSOC)){
		 				$desy=$rowdes['vrveneficio'];
		 				$opera=($valor*$desy)/100;
		 				$total2=number_format($valor-$opera);	
		 				$sino=1;

		 			}

		 		}
		 	}


		 }



		 ?>
		 <center>  <?php echo "<b> $named </b>"; ?></center>

		</div>
	</header>




	<?php
	if($sino>=1)
	{
		?>
		<div class="modal modal-danger fade in" id="modal" style="display: block; " >
			<div class="modal-dialog" style="width: 70%;">
				<div class="modal-content">
					<div class="modal-header">

						<h1 class="modal-title"><?php echo "<b> $named </b>";  ?>	</h1>
					</div>
					<div class="modal-body">
						<div class="col-md-4">
							<div class="box-modal ">
								<div class="box-body ">
									<div class="small-box bg-red-active">
										<div class="inner">
											<h1 class="tamañoantes"><b> <?php 
											echo "$".number_format( "$valor");?></b></h1>
											<br>
											<p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
										</div>
										<div class="icon">
											<i class="ion ion-android-arrow-down"></i>
										</div>
										<a href="#" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><b class="tamañofooter">Antes</b></font></font></a>
									</div>

								</div>

							</div>

						</div>


						<div class="col-md-3">
							<div class="box-modal ">
								<div class="box-body ">
									<div class="small-box bg-red-active">
										<div class="inner">
											<h1 class="tamañovalores"><b> <?php echo	"".$desy."%"; ?></b></h1>
											<p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
										</div>
										
										<a href="#" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><b class="tamañofooter">Descuento</b></font></font></a>
									</div>

								</div>

							</div>
						</div>
					<div class="col-md-5">
							<div class="box-modal ">
								<div class="box-body ">
									<div class="small-box bg-red-active">
										<div class="inner">
											<h1 class="tamañovalores"><b><?php 
											echo "$".( "$total2");?></h1></b>
											<p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
										</div>
										<div class="icon">
											<i class="ion ion-android-arrow-down"></i>
										</div>
										<a href="#" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><b class="tamañofooter">Ahora</b></font></font></a>
									</div>

								</div>

							</div>
						</div>

					</div>
					


				</div>

			</div>	
				
		</div>
	</div>


	<div class="box" >
		
			


			<?php echo "Cantidad: $can"; ?>
			

				<?php 
			}else{ ?><div class="modal modal-success fade in" id="modal2" style="display: block; " >
			<div class="modal-dialog" style="width: 70%;">
				<div class="modal-content">
					<div class="modal-header">

						<h1 class="modal-title"><?php echo "<b> $named </b>";  ?>	</h1>
					</div>
					<div class="modal-body">
						<div class="col-md-12">
							<div class="box-modal ">
								<div class="box-body ">
									<div class="small-box bg-green-active">
										<div class="inner">
											<h1 class="tamañoantes"><b> <?php  
											echo   "$ ".number_format("$valor");?></b></h1>
											<br>
											<p><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"></font></font></p>
										</div>
										<div class="icon">
											<i class="ion ion-android-arrow-down"></i>
										</div>
										<a href="#" class="small-box-footer"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"><b class="tamañofooter"><?php echo "Ml o Gramos: $p "; echo " PLU: $cod";?></b></font></font></a>
									</div>

								</div>

							</div>

						</div>

					

					</div>
					


				</div>

			</div>	
				
		</div>
				<div class="box bg-green-active"><div class="box bg-green-active"> 
				
					<?php
					echo "$can";
				}

				?><style type="text/css">
				#modal {
					visibility:visible;
				}
			</style> </div>


		</div>
	</div>
</div>
<!-- Footer - Copyright -->
</div>
</div>
<div>
	
	</body>
	<script src="bower_components/jquery/dist/jquery.min.js"></script>
	<!-- Bootstrap 3.3.7 -->
	<script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
	<!-- DataTables -->
	<script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>  
	<script src="bower_components/datatables.net-bs/js/buttons.html5.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/buttons.print.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/dataTables.buttons.flash.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/dataTables.buttons.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/jszip.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/pdfmake.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/vfs_fonts.js"></script>
	<script src="bower_components/select2/dist/js/select2.full.js"></script>
	<script src="bower_components/select2/dist/js/select2.min.js"></script>

	<!-- AdminLTE App -->
	<script src="dist/js/adminlte.min.js"></script>
<script type="text/javascript">
$(document).ready(function() {
    setTimeout(function() {
        $(".modal").fadeOut(6500);
    },5000);
});
$(document).ready(function() {
    setTimeout(function() {
        $(".modal2").fadeOut(6500);
    },5000);
});
</script>
	</html>