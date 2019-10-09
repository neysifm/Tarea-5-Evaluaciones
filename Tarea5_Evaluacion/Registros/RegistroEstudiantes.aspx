<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEstudiantes.aspx.cs" Inherits="Tarea5_Evaluacion.Registros.RegistroEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header text-center">
    <h2>Registro de Estudiantes</h2>
</div>

<div class="container-fluid">
<div class="card text-center bg-light">

            <%--ID--%>
            <div class="form-group" display: inline-block>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="EstudianteIDTextBox" class="col-sm-2 col-form-label" runat="server">ID</label>
                <asp:TextBox ID="EstudianteIDTextBox" runat="server" TextMode="Number" CssClass="form-control" placeHolder="ID"></asp:TextBox>
                <asp:Button ID="BuscarButton" class="btn btn-info btn-lg" Text="Buscar" OnClick="BuscarButton_Click" runat="server" />
               </div>
             </div>
            </div>


            <%--FECHA--%>
             <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="FechaTextBox" class="col-sm-2 col-form-label" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
               </div>
              </div>
            </div>
           </div>


            <%--NOMBRE--%>
            <div class="form-group" display: inline-block>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="NombreTextBox" CssClass="col-md-2 control-label">Nombre</asp:Label>
                <asp:TextBox runat="server" ID="NombreTextBox" CssClass="form-control" placeHolder="Descripcion"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreTextBox" CssClass="text-danger" ErrorMessage="Este Nombre no es Valido."/>
                </div>   
              </div>
            </div>
          </div>

            <%--APELLIDO--%>
            <div class="form-group" display: inline-block>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="ApellidoTextBox" CssClass="col-md-2 control-label">Apellido</asp:Label>
                <asp:TextBox runat="server" ID="ApellidoTextBox" CssClass="form-control" placeHolder="Apellido"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ApellidoTextBox" CssClass="text-danger" ErrorMessage="Este Apellido no es Valido."/>
                </div>   
              </div>
            </div>
          </div>

            <%--TODOS LOS PUNTOS PERDIDOS--%>
             <div class="form-group" display: inline-block>
             <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="PuntosPerdidosTextBox" class="col-sm-2 col-form-label" runat="server">Puntos Perdidos</label>
                <asp:TextBox ID="PuntosPerdidosTextBox" runat="server" TextMode="Number" CssClass="form-control" placeHolder="Puntos Pedidos"></asp:TextBox>
               </div>
             </div>
            </div>
            </div>

            <%--BOTONES--%>
            <div class="form-group" display: inline-block>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" display: inline-block>
                        <asp:Button Text="Nuevo" class="btn btn-warning btn-lg" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-success btn-lg" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-danger btn-lg" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
            </div>

            <%--MENSAJES--%>
            <asp:Label ID="MostrarMensajes" runat="server" Text="Label" Visible="false"></asp:Label>
     </div> 
</div>
</asp:Content>
