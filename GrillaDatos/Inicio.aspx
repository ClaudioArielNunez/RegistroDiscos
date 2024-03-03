<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="GrillaDatos.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Grilla 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="my-4 text-center">Grilla Principal</h3>
    <div class="mb-3">
        <asp:Button Text="Agregar Nuevo" ID="btnCreate" OnClick="btnCreate_Click" CssClass="btn btn-success" runat="server" />
    </div>
    <div class="mb-2 row">
        <div class="">
            <asp:GridView ID="dgvLista" AllowPaging="true" OnPageIndexChanging="dgvLista_PageIndexChanging" PageSize="10"  AutoGenerateColumns="false" CssClass="table table-bordered table-hover" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Titulo Del disco" DataField ="Titulo"/>
                    <asp:BoundField HeaderText="Lanzamiento" DataField="FechaLanzamiento" />
                    <asp:BoundField HeaderText="Canciones" DataField="CantidadCanciones"/>
                    <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
                    <asp:BoundField HeaderText="Edición" DataField="TipoEdicion.Descripcion" />                    
                    <asp:CheckBoxField HeaderText="Estado" DataField="Estado"  />
                    <asp:TemplateField HeaderText ="Acciones - CRUD">
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument="" cssClass="btn btn-sm btn-primary" ID="btnRead" runat="server" >Read</asp:LinkButton>
                            <asp:LinkButton CommandArgument="" cssClass="btn btn-sm btn-warning" ID="btnUpdate" runat="server" >Update</asp:LinkButton>
                            <asp:LinkButton CommandArgument="" cssClass="btn btn-sm btn-danger"  ID="btnDelete" runat="server" >Delete</asp:LinkButton>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
