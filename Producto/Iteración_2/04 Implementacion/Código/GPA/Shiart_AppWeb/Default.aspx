<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shiart_AppWeb._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modifique esta plantilla para poner en marcha su aplicación ASP.NET.</h2>
            </hgroup>
            <p>
                Para obtener más información sobre ASP.NET, visite <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                La página incluye <mark>vídeos, cursos y ejemplos</mark> para ayudarle a sacar el máximo partido a ASP.NET.
                Si tiene alguna pregunta relacionada con ASP.NET, visite
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">nuestros foros</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Recomendamos lo siguiente:</h3>
    <ol class="round">
        <li class="one">
            <h5>Introducción</h5>
            Los formularios Web Forms de ASP.NET permiten crear sitios web dinámicos mediante modelos basados en eventos y de arrastrar y colocar.
            La superficie de diseño y los cientos de controles y componentes permiten crear rápidamente sitios sofisticados y controlados mediante UI con acceso de datos.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Más información…</a>
        </li>
        <li class="two">
            <h5>Agregar paquetes NuGet y poner en marcha su codificación</h5>
            NuGet facilita la instalación y actualización de herramientas y bibliotecas gratuitas.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Más información…</a>
        </li>
        <li class="three">
            <h5>Buscar hospedaje de sitios web</h5>
            Encuentre fácilmente empresas de alojamiento web que ofrezcan la mejor relación de características y precio para sus aplicaciones.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Más información…</a>
        </li>
    </ol>
</asp:Content>
