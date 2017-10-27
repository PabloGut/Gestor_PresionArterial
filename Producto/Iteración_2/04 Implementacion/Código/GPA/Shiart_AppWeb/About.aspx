<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Shiart_AppWeb.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Página de descripción de su aplicación.</h2>
    </hgroup>

    <article>
        <p>        
            Use esta área para proporcionar información adicional.
        </p>

        <p>        
            Use esta área para proporcionar información adicional.
        </p>

        <p>        
            Use esta área para proporcionar información adicional.
        </p>
    </article>

    <aside>
        <h3>Título complementario</h3>
        <p>        
            Use esta área para proporcionar información adicional.
        </p>
        <ul>
            <li><a runat="server" href="~/">Inicio</a></li>
            <li><a runat="server" href="~/About.aspx">Acerca de</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contacto</a></li>
        </ul>
    </aside>
</asp:Content>