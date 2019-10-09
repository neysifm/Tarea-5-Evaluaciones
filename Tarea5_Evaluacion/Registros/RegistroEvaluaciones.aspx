<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEvaluaciones.aspx.cs" Inherits="Tarea5_Evaluacion.Registros.RegistroEvaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header text-center">
    <h2>Registro de Evaluaciones</h2>
    </div>
<div class="container-fluid">
<div class="card text-center bg-light">

            <%--ID--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="EvaluacionIDTextBox" class="col-sm-2 col-form-label" runat="server">ID</label>
                <asp:TextBox ID="EvaluacionIDTextBox" runat="server" TextMode="Number" CssClass="form-control" placeHolder="ID"></asp:TextBox>
                <asp:Button ID="BuscarButton" class="btn btn-info btn-lg" Text="Buscar" OnClick="BuscarButton_Click" runat="server" />
               </div>
             </div>
            </div>

            <%--FECHA--%>
             <div class="col-lg-6">
             <div class="form-group">
                <div>
                <div class="col-sm-10">
                <label for="FechaTextBox" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server" TextMode="Date"></asp:TextBox>
               </div>
              </div>
             </div>
            </div>


            <%--ESTUDIANTE--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="EstudianteTextBox" CssClass="col-md-2 control-label">Estudiante</asp:Label>
                 <asp:DropDownList ID="EstudianteDropdownList" CssClass=" form-control dropdown-item col-md-3" AppendDataBoundItems="true" runat="server" Height="2.5em">
                 </asp:DropDownList>
                <asp:TextBox runat="server" ID="EstudianteTextBox" CssClass="form-control" placeHolder="Nombre"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EstudianteTextBox" CssClass="text-danger" ErrorMessage="Este Estudiante no es Valido."/>
                </div>   
              </div>
            </div>

            <%--CATEGORIA--%>
             <div class="col-lg-6">
             <div class="form-group">
              <div>
                <div class="col-sm-10">
                <label for="CategoriaTextBox" runat="server">Categoria</label>
                 <asp:DropDownList ID="CategoriaDropDownList" CssClass=" form-control dropdown-item col-md-3" AppendDataBoundItems="true" runat="server" Height="2.5em">
                 </asp:DropDownList>
                <asp:TextBox ID="CategoriaTextBox" runat="server" placeHolder="Categoria"></asp:TextBox>
               </div>
              </div>
             </div>
             </div>  


            <%--VALOR--%>
             <div class="col-lg-6">
             <div class="form-group">
              <div>
                <div class="col-sm-10">
                <label for="ValorTextBox" runat="server">Valor</label>
                <asp:TextBox ID="ValorTextBox" runat="server" placeHolder="Valor"></asp:TextBox>
                </div>
               </div>
              </div>
            </div>

            <%--LOGRADO--%>
             <div class="col-lg-6">
             <div class="form-group">
              <div>
                <div class="col-sm-10">
                <label for="LogradoTextBox" runat="server">Logrado</label>
                <asp:TextBox ID="LogradoTextBox" runat="server" placeHolder="Logrado"></asp:TextBox>
               </div>
             </div>
            </div>
            </div>

            <%--BOTON AGREGAR--%>
            <div>
                <asp:Button ID="AgregarButton" Text="Agregar" runat="server" OnClick="AgregarButton_Click" />
            </div>

            <%--GRID--%>
            <div>
                <div class="row">
                    <div class="table table-responsive col-md-12">
                        <asp:GridView ID="DetalleGridView" runat="server"
                            CssClass="table table-condensed table-bordered table-responsive"
                            GridLines="None" CellPadding="4" ForeColor="#333333" 
                            AllowPaging="true" PageSize="5">
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <%--TOTAL PERDIDO--%>
            <div>
                <label for="TotalPerdidoTextBox" runat="server">Total Perdido</label>
                <asp:TextBox ID="TotalPerdidoTextBox" AutoPostBack="true" runat="server" ReadOnly="true" placeHolder="Total Perdido"></asp:TextBox>
            </div>

            <%--BOTONES--%>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" display: inline-block>
                        <asp:Button Text="Nuevo" class="btn btn-warning btn-lg" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-success btn-lg" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-danger btn-lg" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>

            <%--MENSAJES--%>
            <asp:Label ID="MostrarMensajes" runat="server" Text="Label" Visible="false"></asp:Label>
      </div>   
</div>
</asp:Content>
