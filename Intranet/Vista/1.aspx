<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="Intranet.Vista._1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
   
   
   <div class="box box-warning box-solid notifica" runat="server" id="excepcion">
        <div class="box-header with-border">
            <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excp Controlada</font></font></h3>

            <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="error" runat="server"></label>
            </font></font>
        </div>
        <!-- /.box-body -->
    </div>
       <section class="content">
    <div class="container bootstrap snippet">
        <form method="post" runat="server">
           
             <div class="box">
                 <div class="box-header with-border">
                       <h3 class="box-title"><b>Menu Principal</b></h3>
                 </div>
            <div class="box-body">
                <a href="infocomparativo.aspx" ID="V1" class="btn btn-app botonesx " runat="server">
                                <i aria-hidden="true" class="fa fa-bar-chart "></i><b>Comparativo Ventas</b>
                            </a>
                 <a href="VentasXhora.aspx" ID="V2" class="btn btn-app botonesx " runat="server">
                                <i aria-hidden="true" class="fa  fa-pie-chart"></i><b>Ventas Por Hora</b>
                            </a>
                <a href="ventaXhora_linea.aspx"  ID="V3" class="btn btn-app botonesx " runat="server">
                                <i aria-hidden="true" class="fa  fa-pie-chart"></i><b>Ventas Por Hora <br />
                                -Linea-</b>
                            </a>
                 <a href="Ingactivos.aspx" ID="A1" class="btn btn-app botonesx" runat="server">
                                <i aria-hidden="true" class="fa fa-plus-square"></i><b>Ingreso Activos</b>
                            </a>
                     
                 <a href="Acta_entrega.aspx" id="AE1" class="btn btn-app botonesx " runat="server">
                                <i aria-hidden="true" class="fa fa-industry"></i><b>Acta Activos Fijos</b>
                            </a>
                 <a href="OrdenTrabajo.aspx" ID="AM3" class="btn btn-app botonesx" runat="server">
                                <i aria-hidden="true" class="fa fa-black-tie"></i><b>Solicitud <br /> Mantenimiento</b>
                            </a>
                <a href="Aprova_Manteni.aspx" id="AM4" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-gavel"></i><b>Aprobar<br />Mantenimiento</b>
                            </a>
                 <a href="act_Mant.aspx" id="AM1" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-support "></i><b>Actas Mantenimiento</b>
                            </a>
                
                 <a href="Kardex.aspx" id="K1" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-th-large"></i><b>Kardex</b>
                     </a>
                 <a href="ventasversalles.aspx" runat="server" class="btn btn-app botonesx" id="POS1">
                                <i aria-hidden="true" class="fa fa-laptop"></i><b>Cierre Pos Versalles</b>
                            </a>
                     
                
                 <a href="H_VidaEquipos.aspx" id="A4" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa  fa-folder-open"></i><b>Activos - Hoja de Vida</b>
                            </a>
                     
                
                     
                 <a href="Incap.aspx" id="RH1" class="btn btn-app botonesx" runat="server">
                                <i aria-hidden="true" class="fa fa-user-md"></i><b>Registro Incapacidad</b>
                            </a>
                     
                 <a href="List_Incap.aspx" id="RH3" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-user-md"></i><b>Gestion Incapacidades</b>
                            </a>
                     
                 <a href="RH/Rh2.aspx" id="RH4" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-file-excel-o"></i><b>Informes Biometrico</b>
                            </a>
                     
                 <a href="GestionOrdenesM.aspx" id="AM5" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa fa-th-list"></i><b>Aprobar Solicitudes</b>
                            </a>
                     <a href="La14_auxConta.aspx" id="LA141" runat="server" class="btn btn-app botonesx">
                                <i aria-hidden="true" class="fa  fa-book"></i><b>Informe Auxiliar<br/>Contabilidad La 14</b>
                            </a>
                     <a href="VentasGla14.aspx" id="LA142" class="btn btn-app botonesx" runat="server" >
                                <i aria-hidden="true" class="fa  fa-area-chart"></i><b>Informe Ventas<br/>La 14</b>
                            </a>
                            
                 
              
            </div>
        </div>
            <div class="box" id="LCS" runat="server">
                <div class="box-header with-border">
                    <b>Menu Administrador</b>
                </div>
                <div class="box box-body">
                    <a href="infocomparativo.aspx" class="btn btn-app botonesx" ID="LCS1" runat="server">
                                <i aria-hidden="true" class="fa fa-user-plus"></i><b>Registro</b>
                            </a>
                    <a href="1.aspx" class="btn btn-app botonesx" runat="server" id="LCS2">
                                <i aria-hidden="true" class="fa  fa-lock"></i><b>Ingreso</b>
                            </a>
                    <a href="Sistema/permisosLcs.aspx" class="btn btn-app botonesx" id="LCS3" runat="server">
                                <i aria-hidden="true" class="fa  fa-user-secret"></i><b>Roles</b>
                            </a>
                   
                </div>

            </div>
        </form>
        </div>
            </section>
    
     <div class="box box-success box-solid notifica" runat="server" id="notificacion" >
            <div class="box-header with-border">
              <h3 class="box-title"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Excp Controlada</font></font></h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
              <!-- /.box-tools -->
            </div>
            <!-- /.box-header -->
            <div class="box-body"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
              <label id="txtnotifica" runat="server"></label>
            </font></font></div>
            <!-- /.box-body -->
          </div>

</asp:Content>
