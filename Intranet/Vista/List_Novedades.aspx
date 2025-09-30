<%@ Page Title="Listado Novedades" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="List_Novedades.aspx.cs" Inherits="Intranet.Vista.List_Novedades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .fondoblanco {
            margin-right: 2px;
            background: #CCD1D1;
            border: solid;
        }

        .menuabierto {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Lista de Novedades</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                        <li class="breadcrumb-item active">Recursos Humanos</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <form method="post" runat="server">
    <div class="modal fade show " id="Imprime" style="display: block;" runat="server">
        <div class="modal-dialog modal-lg modalprint " runat="server">
            <div class="modal-content">
                <div class="modal-header">
                    
                    <h4 class="modal-title">Imprimir</h4>
                    <div class="card-tools">
                        <asp:LinkButton ID="btncerrarimprime" class="close" data-dismiss="modal" runat="server" Text="Salir"  OnClick="btncerrarimprime_Click">
           <span aria-hidden="true" class="fa fa-times"></span>
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="card card-body">
                        <div class="table-responsive-lg">
                            <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None"
                                CssClass="table gvuser2  table-hover table-responsive text-sm"
                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>.">
                                
                            </asp:GridView>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
           
                <div class="content">
                        <div class="row ">
                            <div class="col-md-4">
                                <div class="card card-dark">
                                    <div class="card-header">
                                        Filtro...
                                    </div>
                                    <div class="card-body">

                                        <div class="form-group has-feedback">
                                            <div class="input-group">
                                                <span class="input-group-addon">Fecha desde:</span>
                                                <input id="txtfechaini" runat="server" type="date" class="form-control" />
                                                <span aria-hidden="true" class="fa fa-hand-stop-o form-control-feedback"></span>
                                            </div>
                                        </div>
                                        <div class="form-group has-feedback">
                                            <div class="input-group">
                                                <span class="input-group-addon">Fecha Hasta:</span>
                                                <input id="txtfechafin" runat="server" type="date" class="form-control" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="card-footer">
                                        <asp:LinkButton ID="btnguardar_Click" runat="server" OnClick="btnguardar_Click_Click" Text="Volver" class="btn btn-app">
                                            <i aria-hidden="true"  class="fa fa-search"></i>Consultar
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="card card-dark ">
                                    <div class="card-header">
                                        Lista de Novedades
                                    </div>
                                    <div class="card-body">

                                        <asp:GridView ID="GridView" runat="server" GridLines="None"
                                            CssClass="table gvuser  table-hover table-responsive text-sm"
                                            CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros <b>indicados</b>." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/ok.png" ControlStyle-CssClass="c" />
                                              
                                            </Columns>
                                        </asp:GridView>


                                        </div>

                                    </div>

                                </div>
                                
                            </div>
                           
                        </div>

           
         </div>
        
    </section>
        </form>
    <script>


        $('#btnProcesar').on('click', function () {

        });

        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');
                    btnProcesar.hidden = false;
                    return "No hay resultados - agregar Nuevo ->"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });



    </script>
</asp:Content>
