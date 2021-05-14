<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/COVID/COVID.Master" AutoEventWireup="true" CodeBehind="Plan_E_Covid.aspx.cs" Inherits="Intranet.Vista.COVID.Plan_E_Covid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <div id="Encabezado" class="tools" runat="server">
                    <a href="#lienzo" data-tool="marker">Firmar</a> <a href="#lienzo" data-tool="eraser">Limpiar</a>
                    </div>
                    <canvas id="lienzo" runat="server" width="460" height="220"></canvas>
                   <script src="js/Fima2.js"></script>
<script src="js/Firma.min.js"></script>
                    <script type="text/javascript">
                        $(function () {
                            $('#lienzo').sketch();
                            $(".tools a").eq(0).attr("style", "color:#000");
                            $(".tools a").click(function () {
                                $(".tools a").removeAttr("style");
                                $(this).attr("style", "color:#000");
                            });
                        });
                        function SaveSketch() {
                            var dataUri = $("#lienzo")[0].toDataURL();
                            $("#ruta").val(dataUri);
                            window.close();
                        };
                    </script>                            

        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" OnClientClick="SaveSketch()"   />
        <input  id="ruta" type="hidden"  name="ruta" />
</asp:Content>
