<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/RH/RH.Master" AutoEventWireup="true" CodeBehind="RH1.aspx.cs" Inherits="Intranet.Vista.RH.RH1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 class="box-title"><b>Menu Principal</b></h3>
    <section class="content-header">
     
        <section class="content">
    
        <form method="post" runat="server">

             
            <div class="row"> 
                <div class="col-lg-3 col-xs-6">   <!-- Ventas comparativo -->
                  
                    <div class="small-box bg-green-active botonesx" >
                        <div class="inner">
                            <h3>Ventas</h3>

                            <p>Comparativo</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="infocomparativo.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div> 
                <div class="col-lg-3 col-xs-6 " >
                    <!-- small ventas por hora -->
                    <div id="botonesx" runat="server" class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Ventas</h3>

                            <p>Por Hora</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="VentasXhora.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
               
              
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Actas</h3>

                            <p>Activos Fijos</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <a href="../Acta_entrega.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                 <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Actas</h3>

                            <p>Mantenimiento</p>

                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <a href="../act_Mant.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                
                <div class="col-lg-3 col-xs-6">
                    <!-- kardex consumibles -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Kardex</h3>

                            <p>Consumibles</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="../Kardex.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                 <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Kardex</h3>

                            <p>Consolidado</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-search"></i>
                        </div>
                        <a href="Rep_Kardexg.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                   <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>POS</h3>

                            <p>Cierre Pos Versalles</p>
                            
                        </div>
                        <div class="icon">
                            <i class="ion ion-search"></i>
                        </div>
                        <a href="ventasversalles.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                 <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Activos</h3>

                            <p>Hoja Vida Activos</p>
                            
                        </div>
                        <div class="icon">
                            <i class="ion ion-android-archive"></i>
                        </div>
                        <a href="H_VidaEquipos.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green-active botonesx">
                        <div class="inner">
                            <h3>Carnicos</h3>

                            <p>Informes</p>
                            
                        </div>
                        <div class="icon">
                            <i class="ion ion-android-archive"></i>
                        </div>
                        <a href="Info_carnes.aspx" class="small-box-footer">ir... <i class="fa fa-arrow-circle-right"></i></a>
                    </div>

                </div>
            </div>

        </form>

            </section>
    </section>
</asp:Content>
