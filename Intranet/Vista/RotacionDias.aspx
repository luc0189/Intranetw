<%@ Page Title="Dias Sin Rotacion" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="RotacionDias.aspx.cs" Inherits="Intranet.Vista.RotacionDias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <head>
        <title>LCSystem 3 | Dias sin Venta</title>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lds-roller {
            display: inline-block;
            position: relative;
            width: 80px;
            height: 80px;
        }

            .lds-roller div {
                animation: lds-roller 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
                transform-origin: 40px 40px;
            }

                .lds-roller div:after {
                    content: " ";
                    display: block;
                    position: absolute;
                    width: 7px;
                    height: 7px;
                    border-radius: 50%;
                    background: #fed;
                    margin: -4px 0 0 -4px;
                }

                .lds-roller div:nth-child(1) {
                    animation-delay: -0.036s;
                }

                    .lds-roller div:nth-child(1):after {
                        top: 63px;
                        left: 63px;
                    }

                .lds-roller div:nth-child(2) {
                    animation-delay: -0.072s;
                }

                    .lds-roller div:nth-child(2):after {
                        top: 68px;
                        left: 56px;
                    }

                .lds-roller div:nth-child(3) {
                    animation-delay: -0.108s;
                }

                    .lds-roller div:nth-child(3):after {
                        top: 71px;
                        left: 48px;
                    }

                .lds-roller div:nth-child(4) {
                    animation-delay: -0.144s;
                }

                    .lds-roller div:nth-child(4):after {
                        top: 72px;
                        left: 40px;
                    }

                .lds-roller div:nth-child(5) {
                    animation-delay: -0.18s;
                }

                    .lds-roller div:nth-child(5):after {
                        top: 71px;
                        left: 32px;
                    }

                .lds-roller div:nth-child(6) {
                    animation-delay: -0.216s;
                }

                    .lds-roller div:nth-child(6):after {
                        top: 68px;
                        left: 24px;
                    }

                .lds-roller div:nth-child(7) {
                    animation-delay: -0.252s;
                }

                    .lds-roller div:nth-child(7):after {
                        top: 63px;
                        left: 17px;
                    }

                .lds-roller div:nth-child(8) {
                    animation-delay: -0.288s;
                }

                    .lds-roller div:nth-child(8):after {
                        top: 56px;
                        left: 12px;
                    }

        @keyframes lds-roller {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>

    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Reporte Dias sin Venta Articulos</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="1.aspx">Inicio</a></li>
                        <li class="breadcrumb-item active">Reportes</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <form runat="server">
                <div class="row">

                    <div class="col-md-4">



                        <div class="card card-dark">
                            <div class="card-header">
                                Parametros
                            </div>
                            <div class="card-body">

                                <div class="form-group row">
                                    <label for="date1" runat="server" class="col-sm-3 col-form-label">Fecha Inicio:</label>
                                    <input type="date" class="col-sm-9 form-control" name="name" value="" runat="server" id="date1" />


                                </div>
                                <div class="form-group row">
                                    <label for="date1" runat="server" class="col-sm-3 col-form-label">Fecha Fin:</label>
                                    <input type="date" name="name" class="col-sm-9 form-control" value="" runat="server" id="date2" />
                                </div>


                            </div>
                            <div class="card-footer">
                                <div class="form-group">
                                    <asp:Button ID="LinkButton3" runat="server" class="btn btn-dark" Text="Consultar" OnClick="Consultar_Click" />
                                     <button type="button" id="consultaadmon" runat="server" class="btn btn-dark"  data-toggle="modal" data-target="#modal-default">
                                        Consultar
                                    </button>
                                </div>
                                      <div class="modal fade" id="modal-default" style="display: none;" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title">Seleccione la Sala de Ventas</h4>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                           <select runat="server" id="Selectsala" class="js-example-basic-single form-control">
                                               
                                            </select>
                                        </div>
                                        <div class="modal-footer justify-content-between">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Salir</button>
                                             <asp:LinkButton ID="Consultadmon" runat="server" Text="Nuevo" OnClick="Consultaadmon_Click">
                                         <span aria-hidden="true" class="btn btn-dark">Consultar</span>
                                    </asp:LinkButton>
                                         
                                        </div>
                                    </div>

                                </div>

                            </div>
                           
                            </div>
                        </div>

                    </div>
                    <div class="col-md-8">
                        <div class="card card-dark">
                            <div class="card-header">
                                Datos
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <asp:GridView runat="server" ID="GridviewRotacion" GridLines="None" 
                                        CssClass="gvuser table table-striped dysplay" EmptyDataText="No se encontraron Registros con los parametros indicados.">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </form>

        </div>



    </section>

</asp:Content>
