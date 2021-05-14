    <%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Intranet.Vista.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container bootstrap snippet">
    <div class="row">
  		<div class="col-sm-10"><h1>Perfil</h1></div>
    	<%--<div class="col-sm-2"><a href="/users" class="pull-right"><img title="profile image" class="img-circle img-responsive" src="http://www.gravatar.com/avatar/28fd20ccec6865e2d5f0e1f4446eb7bf?s=100"></a></div>--%>
    </div>
    <div class="row">
  		<div class="col-sm-3"><!--left col-->
              

      <div class="text-center">
      <%--  <img src="http://ssl.gstatic.com/accounts/ui/avatar_2x.png"  class="avatar img-circle img-thumbnail" id="foto" runat="server" alt="avatar">--%>
          <%--<asp:Image ID="Image1"  runat="server" class="avatar img-circle img-thumbnail" />--%>
      

          <img id="foto" runat="server" class="avatar img-circle img-thumbnail"  alt="avatar" src="~/dist/img/avatar2.png" />
       <%-- <img src="<%#Eval("foto") %>" class="avatar img-circle img-thumbnail" id="foto" runat="server" alt="avatar">--%>
        <h6>Subir Una foto Diferente</h6>
        <input type="file" class="text-center center-block file-upload">
      </div><br>

               
          <div class="panel panel-default">
            <div class="panel-heading">Varios <i class="fa fa-link fa-1x"></i></div>
           <%-- <div class="panel-body"><a href="http://bootnipets.com">bootnipets.com</a></div>--%>
              <ul>
             <li class="list-group-item text-right"><span class="pull-left"><strong>Activos a cargo</strong></span><label id="lblactivos" runat="server"></label></li>
            <li class="list-group-item text-right"><span class="pull-left"><strong>Incapacidades</strong></span><label id="lblincap" runat="server"></label></li>
                  <li class="list-group-item text-right"><span class="pull-left"><strong>Creditos</strong></span> <label id="lblcreditos" runat="server"></label></li>
                  <li class="list-group-item text-right"><span class="pull-left"><strong>Hijos</strong></span><label id="lblhijos" runat="server"></label></li>

        </ul>
                   
          </div>
          <%--<div class="panel panel-default">
            <div class="panel-heading">Social Media</div>
            <div class="panel-body">
            	<i class="fa fa-facebook fa-2x"></i> <i class="fa fa-github fa-2x"></i> <i class="fa fa-twitter fa-2x"></i> <i class="fa fa-pinterest fa-2x"></i> <i class="fa fa-google-plus fa-2x"></i>
            </div>
          </div>--%>
          
        </div><!--/col-3-->
    	<div class="col-sm-9">
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#home">Principal</a></li>
                <li><a data-toggle="tab" href="#messages">Laborales</a></li>
                <li><a data-toggle="tab" href="#settings">$</a></li>
                <li><a data-toggle="tab" href="#Contacto">Contacto</a></li>
                <li><a data-toggle="tab" href="#Hijos">Hijos</a></li>
              </ul>

              
          <div class="tab-content">
            <div class="tab-pane active" id="home">
                <hr>
                  <form class="form" action="##" method="post" id="HomeForm">
                      <div class="form-group">
                          
                          <div class="col-md-6">
                              <label for="first_name"><h4>Cedula</h4></label>
                              <input type="number" class="form-control" name="first_name" runat="server" id="txtcc" placeholder="Cedula" title="Ingrese su numero de documento">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-md-6">
                            <label for="name_all"><h4>Nombre Completo</h4></label>
                              <input type="text" class="form-control" name="last_name" runat="server" id="txtnombreall" placeholder="Nombre Completo" title="Ingrese su nombre completo">
                          </div>
                      </div>
          
                      <div class="form-group">
                          
                          <div class="col-md-6">
                              <label for="correo"><h4>correo</h4></label>
                              <input type="email" class="form-control" name="Email" runat="server" id="txtemail" placeholder="you@email.com" title="Ingrese su correo electronico">
                          </div>
                      </div>
          
                      <div class="form-group">
                          <div class="col-md-6">
                             <label for="mobile"><h4># Telefono</h4></label>
                              <input type="text" class="form-control" name="mobile" runat="server" id="txtcel" placeholder="Numero Telefonico" title="Ingrese su numero de telefono Completo">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-md-6">
                              <label for="dir"><h4>Direccion</h4></label>
                              <input type="dir" class="form-control" name="dir" runat="server" id="txtdir" placeholder="Direccion " title="Ingrese su Direccion">
                          </div>
                      </div>
                      
                      <div class="form-group">
                          
                          <div class="col-md-6">
                              <label for="usuario"><h4>Usuario</h4></label>
                              <input type="text" class="form-control" name="usuario" runat="server" id="Usuario" placeholder="Usuario" title="Ingrese Usuario Plataforma.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-md-6">
                            <label for="password"><h4>Contraseña</h4></label>
                              <input type="password" class="form-control" name="password" runat="server" id="password" placeholder="Contraseña" title="Repita la Contraseña.">
                          </div>
                      </div>
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                              	<button class="btn btn-lg btn-success" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Guardar</button>
                               	<button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Limpiar Datos</button>
                            </div>
                      </div>
              	</form>
              
              <hr>
              
             </div><!--/tab-pane-->
             <div class="tab-pane" id="messages">
               
               <h2></h2>
               
               <hr>
                  <form class="form" action="##" method="post" id="laboralForm">
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="Datevinculacion"><h4>Fecha Vinculacion</h4></label>
                              <input type="date" class="form-control" name="Datevinculacion" id="Datevinculacion" title="Ingrese la fecha de Vinculacion">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="DateRetiro"><h4>Fecha Retiro</h4></label>
                              <input type="date" class="form-control" name="DateRetiro" id="DateRetiro" title="Ingrese la fecha de Vinculacion">
                          </div>
                      </div>

                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="sede"><h4>Sede Pertenece</h4></label>
                              <input type="text" class="form-control" name="sede" id="sede" placeholder="Sede" title="Ingrese la Sede a la que pertenece">
                          </div>
                      </div>
          
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="area"><h4>Area</h4></label>
                              <input type="text" class="form-control" name="area" id="area" placeholder="Ingrese el Area" title="ingrese el Area al que pertenece">
                          </div>
                      </div>
          
                      <div class="form-group">
                          <div class="col-xs-6">
                             <label for="Salud"><h4>Salud</h4></label>
                              <input type="text" class="form-control" name="Salud" id="Salud" placeholder="Ingrese empresa de Salud" title="Ingrese la entidad prestadora de salud.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="Pension"><h4>Pension</h4></label>
                              <input type="text" class="form-control" name="Pension" id="Pension" placeholder="Ingrese empresa de Pension" title="Ingrese la entidad pension.">
                          </div>
                      </div>
                     
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="Cargo"><h4>Cargo</h4></label>
                              <input type="text" class="form-control" name="Cargo" id="Cargo" placeholder="Cargo" title="Seleccione el cargo">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="tipocontrato"><h4>Tipo Contrato</h4></label>
                              <input type="text" class="form-control" name="tipocontrato" id="tipocontrato" placeholder="tipo contrato" title="Seleccione el tipo de contrato.">
                          </div>
                      </div>
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                              	<button class="btn btn-lg btn-success" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Guardar</button>
                               	<button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Limpiar</button>
                            </div>
                      </div>
              	</form>
               
             </div><!--/tab-pane-->
             <div class="tab-pane" id="settings">
            		
               	
                  <hr>
                  <form class="form" action="##" method="post" id="pesosForm">
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="Salario"><h4>Salario</h4></label>
                              <input type="number" class="form-control" id="Salario" placeholder="Salario" title="Ingrese el salario">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="fpago"><h4>Forma de Pago</h4></label>
                              <input type="text" class="form-control" name="fpago" id="fpago" placeholder="Forma de pago" title="seleccione su Forma de pago">
                          </div>
                      </div>
          
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="ncuenta"><h4>Numero de Cuenta</h4></label>
                              <input type="number" class="form-control" name="ncuenta" id="ncuenta" placeholder="0000 0000 0000 0000" title="Ingrese el numero de cuenta.">
                          </div>
                      </div>
          
<%--                      <div class="form-group">
                          <div class="col-xs-6">
                             <label for="mobile"><h4>Mobile</h4></label>
                              <input type="text" class="form-control" name="mobile" id="mobile" placeholder="enter mobile number" title="enter your mobile number if any.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="email"><h4>Email</h4></label>
                              <input type="email" class="form-control" name="email" id="email" placeholder="you@email.com" title="enter your email.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="email"><h4>Location</h4></label>
                              <input type="email" class="form-control" id="location" placeholder="somewhere" title="enter a location">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="password"><h4>Password</h4></label>
                              <input type="password" class="form-control" name="password" id="password" placeholder="password" title="enter your password.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="password2"><h4>Verify</h4></label>
                              <input type="password" class="form-control" name="password2" id="password2" placeholder="password2" title="enter your password2.">
                          </div>
                      </div>--%>
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                              	<button class="btn btn-lg btn-success pull-right" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Guardar</button>
                              	<a class="btn btn-lg btn-info pull-right" data-toggle="modal" href="#creditos" ><i class="glyphicon glyphicon-ok-sign"></i> Creditos</a>
                               	<button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Limpiar</button>
                            </div>
                      </div>
              	</form>
              </div>
               <div class="tab-pane" id="Contacto">
            		
               	
                  <hr>
                  <form class="form" action="##" method="post" id="contactform">
                   
                            <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="pcontacto"><h4>Persona de Contacto</h4></label>
                              <input type="text" class="form-control" id="pcontacto" placeholder="Nombre Contacto" title="Ingrese una persona de contacto">
                          </div>
                      </div>
                             <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="Parentes"><h4>Parentesco</h4></label>
                              <input type="text" class="form-control" name="Parentes" id="Parentes" placeholder="Parentesco" title="Ingrese el parentesco">
                          </div>
                      </div>
                                                  <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="ntelefonocontacto"><h4># Telefono</h4></label>
                              <input type="number" class="form-control" name="ntelefonocontacto" id="ntelefonocontacto" placeholder="Telefono" title="Numero telefonico de persona de contacto">
                          </div>
                      </div>
                     
                     
<%--                      <div class="form-group">
                          <div class="col-xs-6">
                             <label for="mobile"><h4>Mobile</h4></label>
                              <input type="text" class="form-control" name="mobile" id="mobile" placeholder="enter mobile number" title="enter your mobile number if any.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="email"><h4>Email</h4></label>
                              <input type="email" class="form-control" name="email" id="email" placeholder="you@email.com" title="enter your email.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="email"><h4>Location</h4></label>
                              <input type="email" class="form-control" id="location" placeholder="somewhere" title="enter a location">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="password"><h4>Password</h4></label>
                              <input type="password" class="form-control" name="password" id="password" placeholder="password" title="enter your password.">
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="password2"><h4>Verify</h4></label>
                              <input type="password" class="form-control" name="password2" id="password2" placeholder="password2" title="enter your password2.">
                          </div>
                      </div>--%>

                      
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                               <a  class="btn btn-lg btn-info pull-right" href="#Listadocontacto" data-toggle="modal"  ><i class="glyphicon glyphicon-ok-sign"></i> Listado</a>
                              	<button class="btn btn-lg btn-success pull-right" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Guardar</button>
                               	<button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Limpiar</button>
                            </div>
                      </div>
              	</form>

              </div>
                <div class="tab-pane" id="Hijos">
            		
               	
                  <hr>
                  <form class="form" action="##" method="post" id="hijosform">
                   
                            <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="Nombre"><h4>Nombre</h4></label>
                              <input type="text" class="form-control" id="nombre" placeholder="Nombre Completo" title="Ingrese el nombre Completo del Hijo">
                          </div>
                      </div>
                             <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="fnace"><h4>Fecha nacimiento</h4></label>
                              <input type="date" class="form-control" name="fnace" id="fnace" placeholder="Fecha Nacimiento" title="Ingreses Fecha de Nacimiento">
                          </div>
                      </div>
                                                  <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="hgenero"><h4>Genero</h4></label>
                              <input type="text" class="form-control" name="hgenero" id="hgenero" placeholder="Genero" title="Ingrese M,F o Otros ">
                          </div>
                      </div>
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                               <a  class="btn btn-lg btn-info pull-right" href="#Listado" data-toggle="modal"  ><i class="glyphicon glyphicon-ok-sign"></i> Listado</a>
                              	<button class="btn btn-lg btn-success pull-right" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Guardar</button>
                               	<button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Limpiar</button>
                            </div>
                      </div>
                   
              	</form>

              </div>
              
          </div><!--/tab-content-->
        </div>
        </div><!--/col-9-->
    </div><!--/row-->
    <div class="modal fade" id="Listadocontacto" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header modal-header-lg dark bg-dark">
                        <div class="bg-image">
                            <img src="assets/img/photos/modal-add.jpg" alt="">
                        </div>
                        <h4 class="modal-title">Listado de contactos </h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><i class="ti-close"></i></button>
                    </div>
                    <div class="modal-product-details">
                        <div class="row align-items-center">
                            <div class="col-9">

                             Aqui la tabla con las personas de contacto
                            </div>
                            <div class="col-3 text-lg text-right"></div>
                        </div>
                    </div>
                  
                    <!-- Panel Details / Other -->
                    
                  

                </div>
                <%-- <input type="submit" onserverclick="creaPresentacionProducto" runat="server" id="guardapresentacion" class="btn btn btn-secondary btn-block btn-lg" name="name" value="" />--%>
            </div>
        </div>
      <div class="modal fade" id="creditos" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header modal-header-lg dark bg-dark">
                        <div class="bg-image">
                            <img src="assets/img/photos/modal-add.jpg" alt="">
                        </div>
                        <h4 class="modal-title">Informacion Creditos </h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><i class="ti-close"></i></button>
                    </div>
                    <div class="modal-product-details">
                        <div class="row align-items-center">
                         

                        
                                     <div class="form-group">
                                    <div class="input-group <%--input-group-sm mb-3--%>">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-id-card-o"></i></span>
                                        </div>
                                        <input type="text" id="txtnombreentidad" runat="server" aria-label="Small" placeholder="Entidad" class="form-control" />
                                    </div>
                                </div>
                                <%--nombre entidad--%>
                                
                                <div class="form-group">
                                    <div class="input-group <%--input-group-sm mb-3--%>">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-id-card-o"></i></span>
                                        </div>
                                        <input type="date" id="txtfecha" runat="server" aria-label="Small" placeholder="fecha" class="form-control" />
                                    </div>
                                </div>
                                <%--fecha--%>
                                  <div class="form-group">
                                    <div class="input-group <%--input-group-sm mb-3--%>">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-id-card-o"></i></span>
                                        </div>
                                        <input type="number" id="txtmonto" runat="server" aria-label="Small" placeholder="Monto" class="form-control" />
                                    </div>
                                </div>
                                <%--Monto--%>
                                     <div class="form-group">
                                    <div class="input-group <%--input-group-sm mb-3--%>">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-id-card-o"></i></span>
                                        </div>
                                        <input type="number" id="txtncuotas" runat="server" aria-label="Small" placeholder="Cuotas" class="form-control" />
                                    </div>
                                </div>
                                <%--Cuotas--%>
                         
                            <div class="col-3 text-lg text-right"> hola</div>
                        </div>
                    </div>
                    <div class="modal-body panel-details-container">
                                             
                        <!-- Panel Details / Additions -->
                        <div class="panel-details">
                            <h5 class="panel-details-title">
                                <label class="custom-control custom-radio">
                                    <input name="radio_title_additions" type="radio" class="custom-control-input">
                                    <span class="custom-control-indicator"></span>
                                </label>
                                <a href="#panelDetailsAdditions" data-toggle="collapse">Listado creditos</a>
                            </h5>
                            <div id="panelDetailsAdditions" class="collapse">
                                <div class="panel-details-content">

                                    hola panel detail detalles
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Panel Details / Other -->
                    
                  

                </div>
                <%-- <input type="submit" onserverclick="creaPresentacionProducto" runat="server" id="guardapresentacion" class="btn btn btn-secondary btn-block btn-lg" name="name" value="" />--%>
            </div>
        </div>


</asp:Content>
