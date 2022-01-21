<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="V_linea.aspx.cs" Inherits="Intranet.Vista.V_linea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
   <form  runat="server" >
        <a href="1.aspx" class="fa fa-home">Inicio</a>
        <div class="box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Ventas Por Linea</h3>
            </div>
        </div>
        <div class="row">
            <div class="box">
                 <div class="box box-header">
                    
                           <asp:Label Text="Fecha desde" runat="server" />
                <input type="date" name="name" value="" runat="server" id="txtdesde" />
                          <asp:Label Text="Fecha Hasta" runat="server" />
                <input type="date" name="name" runat="server" value="" id="txthasta" />
                         <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar" OnClick="Consulta" class="btn btn-primary"> </asp:LinkButton>

                   
                    

                   
            </div>
            
            </div>
           
           
        </div>
 
    <div class="row">
        <div class="col-md-12">
             <div class="card card-widget widget-user-2 shadow-sm">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                  <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                </div>
                <!-- /.widget-user-image -->
                <h3 class="widget-user-username">SUPERMIO </h3>
                <h5 class="widget-user-desc">S.A.S</h5>
              </div>
              <div class="box-footer p-0">
                  <div class="table table-responsive">
                  <asp:GridView runat="server" ID="GridGeneral" AllowCustomPaging="True" AllowPaging="True" CssClass=" table table-bordered table-hover dataTable dtr-inline">
                      <RowStyle CssClass="nav-link" />

                  </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card card-widget widget-user-2 shadow-sm">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                  <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                </div>
                <!-- /.widget-user-image -->
                <h3 class="widget-user-username">SUPERMIO </h3>
                <h5 class="widget-user-desc">LA 16</h5>
              </div>
              <div class="box-footer p-0">
                  <div class="table table-responsive">
                  <asp:GridView runat="server" ID="gridla16" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                      <RowStyle CssClass="nav-link" />

                  </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
         <div class="col-md-3">
            <div class="card card-widget widget-user-2 shadow-sm">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                  <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                </div>
                <!-- /.widget-user-image -->
                <h3 class="widget-user-username">SUPERMIO</h3>
                <h5 class="widget-user-desc">LA 13</h5>
              </div>
              <div class="box-footer p-0">
                <div class="table table-responsive">
                  <asp:GridView runat="server" ID="Gridla13" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                      <RowStyle CssClass="nav-link" />

                  </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
         <div class="col-md-3">
            <div class="card card-widget widget-user-2 shadow-sm">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                  <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                </div>
                <!-- /.widget-user-image -->
                <h3 class="widget-user-username">SUPERMIO</h3>
                <h5 class="widget-user-desc">VERSALLES</h5>
              </div>
              <div class="card-footer p-0">
               <div class="table table-responsive">
                  <asp:GridView runat="server" ID="GridVersalles" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                      <RowStyle CssClass="nav-link" />

                  </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
         <div class="col-md-3">
            <div class="card card-widget widget-user-2 shadow-sm">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                  <img class="img-circle elevation-2" src="../dist/img/logo.png" alt="User Avatar">
                </div>
                <!-- /.widget-user-image -->
                <h3 class="widget-user-username">SUPERMIO</h3>
                <h5 class="widget-user-desc">CIUDADELA</h5>
              </div>
              <div class="card-footer p-0">
               <div class="table table-responsive">
                  <asp:GridView runat="server" ID="GridCiudadela" AllowCustomPaging="True" AllowPaging="True" CssClass="table table-bordered table-hover dataTable dtr-inline">
                      <RowStyle CssClass="nav-link" />

                  </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
    </div>
        .  </form>
        </section>
</asp:Content>
