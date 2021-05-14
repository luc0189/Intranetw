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

	
		

		<title>CONSULTOR</title>

		<!-- Mobile Meta -->
		
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
      <!-- select2 -->
  <link rel="stylesheet" href="bower_components/select2/dist/css/select2.min.css">
    <link rel="stylesheet" href="bower_components/select2/dist/css/select2.css">
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
	<body>
	<div class="body">

	<!-- Header -->
	<header>
	   <div class="container">
	      	
                
	            <form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">

	<input type="text" autofocus id="codbarr" name="name">

                      <button type="submit" name="submit" class="btn btn-info btn-flat">Go!</button>
                   

</form>
<script>

 if( ! ("autofocus" in document.createElement( "input" ) ) )

 {

 document.getElementById( "codbarr" ).focus();

 }

 </script>


	<?php


	 $serverName = "192.168.2.115"; //serverName\instanceName, portNumber (por defecto es 1433)
				$connectionInfo = array( "Database"=>"supermioversalles", "UID"=>"dba", "PWD"=>"Supermioserver123*");
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
	 				where inactivo = 0 and cd.CODBARRA ='$name' and pc.listprecioID='002'";
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
	 						$sqlsaldo="SELECT cast(sum(cantidad) as int) as cant From dbo.vwsaldosart with (noexpand) where articuloID='$cod' and bodegaID='014'";
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
	

		
	</style>
		<div class="callout callout-info" style="color-profile: :green">

		<div class="box bg-green">
		
			<?php
				if($sino>=1)
				{
					echo "Antes= $".number_format( "$valor");?>
<div class="box" >
<div class="box header with-border">
				<?php echo	"Descuento del:".$desy."% = $"." ". $total2; ?>
	<?php echo "Ml o Gramos: $p"; ?> 
	<?php echo "PLU: $cod"; ?>
	
	<?php echo "Cantidad: $can"; ?>
	<div class="box bg-green">
		
	<?php 
	}else{
				echo   "Valor: $ ".number_format("$valor");?>
				<div class="box bg-green"><?php echo "Ml o Gramos: $p"; ?><div class="box bg-green"><?php 
					 echo "PLU: $cod"; ?> 
					 <div class="box bg-green" >
					 <?php
					 echo "Cantidad: $can";
			}

			?> </div>

				
			</div>
		</div>
	</div>
	<!-- Footer - Copyright -->
	</div>
	</div>
<div>
	<div class="callout callout-info" style="color-profile: :green">

		<div class="box bg-green">
	<?php $sql4 = "SELECT a.codigo, cd.codbarra,cast(valormiva as int)as
	 				valormiva from articulo a 
	 				
	 				
	 				
	 				left join codbar cd on cd.articuloID = a.codigo 
	 				left join precio pc on pc.articuloID=a.codigo and (pc.presentacionID=cd.presentacionID or (pc.presentacionID is null and cd.presentacionID is null))
	 				where inactivo = 0 and cd.CODBARRA ='$name' and pc.listprecioID='BX1'";
	 				$stmt4 = sqlsrv_query( $conn, $sql4 );
	 				if( $stmt4 === false) {
	 					die( print_r( sqlsrv_errors(), true) );
	 				}

	 				while( $row4 = sqlsrv_fetch_array( $stmt4, SQLSRV_FETCH_ASSOC) ) {
	 					
	 					$valor4=$row4['valormiva'];
	 					$numero4 = number_format($valor4);
	 					
	 					 
	 					} ?>
	 					<div class="box bg-green" >
					 <?php
					 echo "Supermio la16: $numero4";
	 					?>	
	 					
<div class="box bg-green">
	<?php $sql5 = "SELECT a.codigo, cd.codbarra,cast(valormiva as int)as
	 				valormiva from articulo a 
	 				
	 				
	 				
	 				left join codbar cd on cd.articuloID = a.codigo 
	 				left join precio pc on pc.articuloID=a.codigo and (pc.presentacionID=cd.presentacionID or (pc.presentacionID is null and cd.presentacionID is null))
	 				where inactivo = 0 and cd.CODBARRA ='$name' and pc.listprecioID='001'";
	 				$stmt5 = sqlsrv_query( $conn, $sql5 );
	 				if( $stmt4 === false) {
	 					die( print_r( sqlsrv_errors(), true) );
	 				}

	 				while( $row5 = sqlsrv_fetch_array( $stmt5, SQLSRV_FETCH_ASSOC) ) {
	 					
	 					$valor5=$row5['valormiva'];
	 					$numero5 = number_format($valor5);
	 					
	 					 
	 					} ?>
	 					<div class="box bg-green" >
					 <?php
					 echo "Supermio la 12: $numero5";
	 					?>	
	 					</div>

</div>
</div>

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
	</html>