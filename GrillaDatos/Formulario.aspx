<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="GrillaDatos.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Nuevo Disco
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="my-3">
            <h3>Disco Nuevo:</h3>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Titulo:</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Lanzamiento:</label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Canciones:</label>
                <asp:TextBox ID="txtCanciones" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Estilo:</label>
                <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-4">
                <label class="form-label">Edición:</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-5 ">
                <asp:Button Text="Guardar" CssClass="btn btn-primary" runat="server" />
                <asp:Button Text="Cancelar" CssClass="btn btn-warning" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Portada:</label>
                <asp:TextBox ID="txtPortada" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png" Width="300" runat="server" />
            </div>
        </div>
    </div>
   
    
</asp:Content>
