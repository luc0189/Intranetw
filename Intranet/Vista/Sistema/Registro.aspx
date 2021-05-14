<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Sistema/Sistema.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Intranet.Vista.Sistema.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
          
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="permisosapp.aspx">Tablero Admin</a>
          </li> 
           
          <li class="breadcrumb-item active">Registro</li>
        </ol>

        <form method="post" runat="server">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                             <div class="alert alert-warning alert-dismissible" id="notificacion" runat="server">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">×</font></font></button>
            <h5><i class="icon fa fa-check"></i><font style="vertical-align: inherit;"><font style="vertical-align: inherit;"> ¡Alerta!</font></font></h5>
            <font style="vertical-align: inherit;"><font style="vertical-align: inherit;">
                <label runat="server" id="alertant">aqui</label></font></font>
        </div>
            <div class="card">
            <div class="card-header">
                <h3>Registro</h3>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               
            </div>
            <div class="card-body">
                <div class="row">
          <div class="col-xl-6 col-sm-6 mb-6">
            <div class="card text-white bg-primary o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-user"></i>
                </div>
                <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Principal</font></font></div>
                  <div class="form-group ">
                       
                  
                            <input id="txtcc" runat="server" type="number" class="form-control" placeholder="No Documento de Indentidad">
                  </div>
                        <div class="form-group has-feedback">
                            <input id="txtname1" runat="server" type="text" class="form-control" placeholder="Primer Nombre">
                           
                        </div>
                   <div class="form-group has-feedback">
                            <input id="txtname2" runat="server" type="text" class="form-control" placeholder="Segundo Nombre">
                           
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtapellido1" runat="server" type="text" class="form-control" placeholder="Primer apellido">
                            
                        </div>
                        <div class="form-group has-feedback">
                            <input id="txtapellido2" runat="server" type="text" class="form-control" placeholder="Segundo apellido">
                           
                        </div>
                  
              </div>
               
            </div>
          </div>
                    
          <div class="col-xl-6 col-sm-6 mb-6">
            <div class="card text-white bg-warning o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-list"></i>
                </div>
                <div class="mr-5"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Mas!</font></font></div>
                  <div class="form-group ">
                      
                            <input id="txttel" type="number" runat="server" class="form-control" placeholder="Telefono">
                          
                        </div>
                   <div class="form-group has-feedback">
                            <input id="txtdir" runat="server" type="text" class="form-control" placeholder="Direccion">
                           
                        </div>
                        <div class="form-group has-feedback">
                            <select id="Select" runat="server" class="js-example-basic-single form-control">
                                <option>Sexo</option>
                                <option value="F">Femenino</option>
                                <option value="M">Masculino</option>
                            </select>
                        </div>
                        <div class="form-group has-feedback">

                            <select runat="server" id="SelectTipopersona" class="js-example-basic-single form-control" name="state">
                            </select>
                        </div>
              </div>
             
            </div>
          </div>
        
        
        </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
            <div class="card-footer">
                <div class="form-group has-feedback">
                            <div class="btn-group">

                                <asp:LinkButton ID="btnnuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnnuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-plus-circle"></i>Nuevo
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnguardanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btnguardanuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btncancelanuevo" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelanuevo_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                </asp:LinkButton>

                            </div>
                            <div class="btn-group">
                                <asp:LinkButton ID="btneditar" runat="server" Text="Volver" class="btn btn-app" OnClick="btneditar_Click">
                                    <i aria-hidden="true"  class="fa fa-edit"></i>Editar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnguardaeditar" runat="server" Text="Volver" class="btn btn-app">
                                    <i aria-hidden="true"  class="fa fa-save"></i>Guardar
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btncancelareditar" runat="server" Text="Volver" class="btn btn-app" OnClick="btncancelareditar_Click">
                                    <i aria-hidden="true"  class="fa fa-stop"></i>Cancelar
                                </asp:LinkButton>
                            </div>
                    <a href="User.aspx"><i aria-hidden="true"  class="fa fa-lock"></i>Gestion Ingreso</a>
                           
                            <asp:LinkButton ID="btnborra" runat="server" class="btn btn-app " Text="Insertar">
                                     <i aria-hidden="true" class="fa  fa-recycle"></i>Borrar Usuario
                            </asp:LinkButton>

                        </div>
            </div>
            </ContentTemplate>
                </asp:UpdatePanel>
        </div>
           
                  <div class="card">
                <div class="card-header">
                    <div class="form-group">
                        <label>Lista</label>
                     <asp:LinkButton ID="listausuarios" runat="server" Text="Volver" class="btn btn-success" OnClick="listausuarios_Click">
                                    <span aria-hidden="true"  class="fa fa-info-circle">Listar</span>
                        </asp:LinkButton>
                    </div>
                     
                </div>
               
                   <div class="card-body">

                                <div>
                                    <asp:GridView ID="GridViewdetalle" runat="server" GridLines="None" class="display compact"
                                        CssClass="gvuser table table-striped table-bordered text-sm"
                                        CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." OnSelectedIndexChanged="GridViewdetalle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Selecciona" SelectImageUrl="~/dist/img/edit1.png" ControlStyle-CssClass="c" />

                                        </Columns>

                                    </asp:GridView>

                                </div>
                            </div>
            </div>
           </ContentTemplate>
               </asp:UpdatePanel>
          
    
      
    </form>
        </div>
    <script type="text/javascript">


        $('select').select2({
            language: {

                noResults: function () {

                    $('p').slideToggle('slow');

                    return "No hay resultados - Clic en Nuevo"

                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });
        var lenguaje_espanol = {
            "sProcessing": "Procesando...",
        }


    </script>

</asp:Content>
