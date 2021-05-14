<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="salir.aspx.cs" Inherits="Intranet.Vista.salir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <script>
function esconde_div(){
   var elemento = document.getElementById("capa");
   elemento.style.display = 'none';
}
 
function visible_div(){
   var elemento = document.getElementById("capa");
   elemento.style.display = 'block';
}
</script>
</head>
<body>

 
<input type="button" onclick="javascript:esconde_div();" value="Ocultar div" />
<input type="button" onclick="javascript:visible_div();" value="div visible" />
<div id="capa">esto es una capa</div>
</body>
</html>
