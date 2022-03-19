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
           
          SITIO EN CONSTRUCCION
         
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
