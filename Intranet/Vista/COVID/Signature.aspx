<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signature.aspx.cs" Inherits="Intranet.Vista.COVID.Signature" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body data-rsssl="1" onload="DrawPad()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <input type="hidden" id="imageData" runat="server" class="image-data" />
        <canvas id="myCanvas" width="500" height="100"></canvas>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Submit" />
          <script src="js/Fima2.js"></script>
<script src="js/Firma.min.js"></script>
    </form>
    <script type="text/javascript" id="jsDraw">
        var canvas = document.getElementById('myCanvas');
        var ctx = canvas.getContext('2d');
        function DrawPad() {...} // see the bullet points for this one
        $("#btnSave").click(function () {
            var image = document.getElementById('myCanvas').toDataURL("image/png");
            image = image.replace('data:image/png;base64,', '');
            $.ajax({
                type: 'POST',
                url: 'Default.aspx/UploadImage',
                data: '{ imageData : "' + image + '" }',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        });
    </script>
</body>
</html>
