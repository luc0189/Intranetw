<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Main.Master" AutoEventWireup="true" CodeBehind="Formatos.aspx.cs" Inherits="Intranet.Vista.Formatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <section class="content">
        <div class="container bootstrap snippet">
            <form method="post" runat="server">

                <div class="box box-default">
                    <div class="box-header">
                        <div class="box-title">
                            <strong>Subir Formatos</strong>
                        </div>
                    </div>
                    <div class="box-body">


                        <div class="form-group">
                            <label for="FileUploadControl" class="col-sm-3">Archivo:</label>
                            <div class="input-group col-sm-9">
                                <asp:FileUpload ID="FileUploadControl" runat="server" />

                            </div>
                        </div>


                        <div class="form-group">
                            <label for="Selectmodelo" class="col-sm-3">Area:</label>
                            <div class="input-group col-sm-9">

                                <select runat="server" id="Selectmodelo" class="js-example-basic-single form-control" name="state" style="width: 90%">
                                    <option value="S.S.T">Recursos Humanos - S.S.T</option>
                                    <option value="P.E.S.V">Recursos Humanos - P.E.S.V</option>
                                    <option value="RRHH">Recursos Humanos - RRHH</option>
                                    <option value="Correspondencia">Recursos Humanos - Correspondencia</option>
                                    <option value="Plan_Contingencia">Sanida - Plan Contingencia</option>
                                    <option value="Covid_19">Covid-19</option>
                                    <option value="Examen_MA">Examen Manipulacion Alimentos</option>
                                    <option value="Plan_MA">Plan Capacitacion M. Alimentos</option>
                                    <option value="CursosMA">Curso Manipulacion Alimentos</option>
                                    <option value="Formatos_sanidad">Sanidad - Formatos</option>

                                </select>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="label" class="col-sm-3">Descripcion del Archivo:</label>
                            <div class="input-group col-sm-9">
                                <input type="text" name="label" value="" id="txtlabel" runat="server" class="form-control" />

                            </div>
                        </div>
                        <asp:Button runat="server" ID="UploadButton" Text="Subir" CssClass="btn btn-success" OnClick="UploadButton_Click" />
                        <asp:Label runat="server" ID="StatusLabel" Text="Estado: " />
                    </div>
                </div>
                <div class="nav-tabs-custom" style="cursor: move;">
                    <!-- Tabs within a box -->
                    <ul class="nav nav-tabs pull-right ui-sortable-handle">
                        <li class="active"><a href="#RecursosHumanos" data-toggle="tab" aria-expanded="true">Recursos Humanos</a></li>
                        <li class=""><a href="#menusanidad" data-toggle="tab" aria-expanded="false">Sanidad</a></li>
                      
                        <li class="pull-left header"><i class="fa fa-inbox"></i>Archivos</li>
                    </ul>
                    <div class="tab-content no-padding">
                        <!-- Morris chart - Sales -->
                        <div class="chart tab-pane active" id="RecursosHumanos" style="position: relative; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">

                            <div class="box box-comments">
                                <div class="box-body">
                                    <div class="nav-tabs-custom" style="cursor: move;">
                                        <!-- Tabs within a box -->
                                        <ul class="nav nav-tabs pull-right ui-sortable-handle">
                                            <li class="active"><a href="#sst" data-toggle="tab" aria-expanded="true">S.S.T</a></li>
                                            <li class=""><a href="#PESV" data-toggle="tab" aria-expanded="false">P.E.S.V</a></li>
                                            <li class=""><a href="#sales-RRHH" data-toggle="tab" aria-expanded="false">RRHH</a></li>
                                            <li class=""><a href="#send" data-toggle="tab" aria-expanded="false">Correspondencia Externa</a></li>
                                            <li class=""><a href="#covid" data-toggle="tab" aria-expanded="false">Covid-19</a></li>


                                        </ul>
                                        <div class="tab-content no-padding">

                                            <!-- Morris chart - Sales -->
                                            <div class="chart tab-pane active" id="sst" style="position: relative; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">


                                                <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView1" runat="server" GridLines="None"
                                                                CssClass="gv table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>



                                            </div>
                                            <div class="chart tab-pane" id="PESV" style="position: relative;">
                                                 <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView2" runat="server" GridLines="None"
                                                                CssClass="gv2 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            <div class="chart tab-pane" id="sales-RRHH" style="position: relative;">
                                               <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView3" runat="server" GridLines="None"
                                                                CssClass="gv3 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            <div class="chart tab-pane" id="send" style="position: relative;">
                                                <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView4" runat="server" GridLines="None"
                                                                CssClass="gv4 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                              <div class="chart tab-pane" id="covid" style="position: relative;">
                                                <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView6" runat="server" GridLines="None"
                                                                CssClass="gv6 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                          <div class="chart tab-pane" id="menusanidad" style="position: relative;">
                               <div class="box box-comments">
                                <div class="box-body">
                                    <div class="nav-tabs-custom" style="cursor: move;">
                                        <!-- Tabs within a box -->
                                        <ul class="nav nav-tabs pull-right ui-sortable-handle">
                                            <li class="active"><a href="#ExamenMa" data-toggle="tab" aria-expanded="true">Examen M.A</a></li>
                                            <li class=""><a href="#CapacitacionMa" data-toggle="tab" aria-expanded="false">Capacitacion M.A</a></li>
                                            <li class=""><a href="#CursoMa" data-toggle="tab" aria-expanded="false">Curso M.A</a></li>
                                            <li class=""><a href="#Formatos" data-toggle="tab" aria-expanded="false">Formatos</a></li>


                                        </ul>
                                        <div class="tab-content no-padding">

                                            <!-- Morris chart - Sales -->
                                            <div class="chart tab-pane active" id="ExamenMa" style="position: relative; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">
                                                 <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView7" runat="server" GridLines="None"
                                                                CssClass="gv7 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>



                                            </div>
                                            <div class="chart tab-pane" id="CapacitacionMa" style="position: relative;">
                                                 <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView8" runat="server" GridLines="None"
                                                                CssClass="gv8 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            <div class="chart tab-pane" id="CursoMa" style="position: relative;">
                                               <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView9" runat="server" GridLines="None"
                                                                CssClass="gv9 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            <div class="chart tab-pane" id="Formatos" style="position: relative;">
                                                <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView10" runat="server" GridLines="None"
                                                                CssClass="gv10 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         
                                   <div class="box box-default">
                                                    <div class="box-body">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView5" runat="server" GridLines="None"
                                                                CssClass="gvuser5 table table-striped table-bordered text-sm"
                                                                CellSpacing="0" EmptyDataText="No se encontraron Registros con los parametros indicados." AutoGenerateColumns="false">
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="Nombre Archivo">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_NAME") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subido Por">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_USER") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_DATE") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripcion">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FORM_LABEL") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descarga">
                                                                        <ItemTemplate> 
                                                                            <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "FORM_FULLPATH") %>'>
                                                                                <img src="../dist/img/pdf.png" /></a>
                                                                            
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>
                        </div>

                        </div>
                      
                       
                    </div>
                

            </form>
        </div>
    </section>
</asp:Content>
