<%@ Page Title="Registro Categorias" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="RegistroCategorias.aspx.cs" 
    Inherits="Tarea5_Evaluacion.Registros.RegistroCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header text-center">
    <h2>Registro de Categorias</h2>
</div>

<div class="container-fluid">
<div class="card text-center bg-light">


            <%--ID--%>
            <div class="form-group" display: inline-block>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="CategoriaID" class="col-sm-2 col-form-label" runat="server">ID</label>
                <asp:TextBox ID="CategoriaID" runat="server" TextMode="Number" CssClass="form-control" placeHolder="ID"></asp:TextBox>
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


            <%--DESCRIPCION--%>
            <div class="form-group" display: inline-block>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="DescripcionTextBox" CssClass="col-md-2 control-label">Descripcion</asp:Label>
                <asp:TextBox runat="server" ID="DescripcionTextBox" CssClass="form-control" placeHolder="Descripcion"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DescripcionTextBox" CssClass="text-danger" ErrorMessage="Esta Descripcion no es Valida."/>
                </div>   
              </div>
            </div>
                </div>

            <%--PROMEDIO--%>
             <div class="form-group" display: inline-block>
             <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="PromedioTextBox" class="col-sm-2 col-form-label" runat="server">Promedio</label>
                <asp:TextBox ID="PromedioTextBox" runat="server" TextMode="Number" CssClass="form-control" placeHolder="Promedio"></asp:TextBox>
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
