<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/INVENTARIO/Inventario.Master" AutoEventWireup="true" CodeBehind="Deta_conteos.aspx.cs" Inherits="Intranet.Vista.INVENTARIO.Deta_conteos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-cyan">
      <div class="card-header">
        <h3 class="card-title">P1L1M1 - CONTEO-1 - SALA DE VENTAS</h3>
      </div>
       <div class="card card-dark">
        <div class="card-header">
            <h3 class="card-title">NOMBRE DEL ARTICULO X 300 ML</h3>
        </div>
        <div class="card-body">
            <div class="input-group input-group">
                
                <input type="text" runat="server" class="form-control" id="Text1" placeholder="PLU O CODIGO DE BARRAS" autofocus>
                <span class="input-group-append">
                    <button type="button" class="btn btn-info btn-flat">>></button>
                </span>
            </div>
            <div class="input-group input-group">
                <input type="number" runat="server" class="form-control" id="txtcant" placeholder="SOLO NUMERO Y DECIMAL CON (,)">
                <span class="input-group-append">
                    <button type="button" class="btn btn-info btn-flat">Insertar</button>
                </span>
            </div>

        </div>
      <div class="card-footer">
        <label for="txtUsuario">Factor de presentacion: (1) </label>
      </div>
    </div>
    <div class="card">

        <!-- /.card-header -->
        <div class="card-body">
            <table class="table table-responsive">
                <thead>
                    <tr>
                        <th style="width: 10px">#</th>
                        <th>ARTICULO</th>
                        <th>CP</th>
                        <th style="width: 40px">CD</th>
                        <th style="width: 40px">TOTAL</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1.</td>
                        <td>HUEVOS 1A</td>
                        <td>1</td>
                        <td>6</td>
                        <td><span class="badge bg-danger">6</span></td>
                    </tr>
                    <tr>
                        <td>2.</td>
                        <td>PANELA</td>
                        <td>6</td>
                        <td>6</td>
                        <td><span class="badge bg-danger">36</span></td>
                    </tr>
                    <tr>
                        <td>3.</td>
                        <td>ATUN</td>
                        <td>2</td>
                        <td>6</td>
                        <td><span class="badge bg-danger">12</span></td>
                    </tr>
                    <tr>
                        <td>4.</td>
                        <td>PASTAS DORIA</td>
                        <td>6</td>
                        <td>20</td>
                        <td><span class="badge bg-danger">120</span></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- /.card-body -->
        <div class="card-footer clearfix">
            <button type="submit" class="btn btn-primary">Guardar y Salir</button>
        </div>
    </div>
    </div>
 
</asp:Content>
