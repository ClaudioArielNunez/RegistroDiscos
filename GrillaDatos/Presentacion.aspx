<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Presentacion.aspx.cs" Inherits="GrillaDatos.Presentacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Cards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-3">
        <h3>Lista de Portadas</h3>
    </div>
    <div class="row">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%if (lista != null)
                {%>
            <%foreach (var disco in lista)
                {%>

            <div class="col">
                <div class="card">
                    <img src="<%:disco.UrlImagenTapa %>" class="card-img-top" alt="<%:disco.Titulo %>">
                    <div class="card-body">
                        <h5 class="card-title"><%:disco.Titulo %></h5>
                        <h5 class="card-title">Canciones: <%:disco.CantidadCanciones %></h5>                          
                        <div>
                            <asp:Button Text="Ver Disco" CssClass="btn btn-sm btn-primary" runat="server" />
                            <asp:LinkButton ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-sm btn-warning" Text="Volver a grilla" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <% } %>

            <%}               
                 %>              
        </div>

    </div>
</asp:Content>
