<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Transform.aspx.cs" Inherits="Intranet.Vista.Transform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="content-header">
        <h1>Transformacion 
        <small>Panel Principal</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="Menu.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
            <li class="active"><a href="Menu.aspx">Herramientas</a></li>
            <li class="active">Transformacion De Articulos</li>
        </ol>
    </section>
        <section class="content">
        <div class="container bootstrap snippet">
    <form  runat="server" action=" ">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header with-border">
                    <b>Fruver </b> 
                    <div class="box-tools pull-right">
                        <b>C.COSTO</b>
                        <select runat="server" id="txtccosto" required>
                            
                        </select>
                        <input type="text" name="name" runat="server" id="vcosto" visible="false" value="" />
                        <b>Fecha</b>
                        <input type="date" id="txtfecha" name="name" value="" runat="server" required="required"/>
                    </div>
                </div>
                <div class="box-body">

                    <div class="col-md-6">

                        <div class="input-group ">
                            <span class="input-group-addon"> <strong>Articulo</strong>     
                                <br />
                                Fruver</span>
                            <select runat="server" id="SelectarticuloF" class="js-example-basic-single form-control" required="required" name="state" style="width: 100%">
                            </select>
                            <input type="number" name="name" id="txtcant_articulo" runat="server" value="" placeholder="Cantidad" step="any" required="required"/>
                        </div>

                    </div>


                    <div class="col-md-6">
                        <div class="input-group  ">
                            <span class="input-group-addon"><b>Transformacion</b></span>
                            <select runat="server" id="Select_transf" class="js-example-basic-single form-control" name="state" style="width: 100%">
                                
                            </select>

                            <input type="number" name="name" step="any" id="txtcant_tranform" runat="server" class="form-control" placeholder="Cantidad" required="required"/>

                        </div>


                    </div>

                </div>
                

            </div>
        </div>
     
        <br />


        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <strong>Envios del dia</strong> 
                    <div class="box-tools pull-right">
                        <input id="txtestado" runat="server" disabled="disabled" ></input>
                          <input type="submit" onclick="btnenviar_Click" 
                                 runat="server" id="btnenvia" class="btn btn-dark" name="name" value=""  />
                        </div>
                </div>

                

                <div class="box-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewNovedades" runat="server" GridLines="None" class="display "  OnSelectedIndexChanged="OnRowDeleting"
                            CssClass=" gvuser table table-hover table-responsive text-sm" EmptyDataText="No se encontraron Registros con los parametros indicados." >
                            <Columns>
                                 
                                 <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/delete2.png" ControlStyle-CssClass="c" />
                              
                                
                             </Columns>

                        </asp:GridView>
                    </div>
                </div>
                                  
            </div>
        </div>


    </form>
            </div>
            </section>
</asp:Content>
