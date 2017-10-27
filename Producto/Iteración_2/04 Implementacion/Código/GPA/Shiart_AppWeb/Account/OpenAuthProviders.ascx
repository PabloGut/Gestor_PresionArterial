﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="Shiart_AppWeb.Account.OpenAuthProviders" %>

<fieldset class="open-auth-providers">
    <legend>Iniciar sesión con otro servicio</legend>
    
    <asp:ListView runat="server" ID="providerDetails" ItemType="Microsoft.AspNet.Membership.OpenAuth.ProviderDetails"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <button type="submit" name="provider" value="<%#: Item.ProviderName %>"
                title="Iniciar sesión con su <%#: Item.ProviderDisplayName %> cuenta.">
                <%#: Item.ProviderDisplayName %>
            </button>
        </ItemTemplate>
    
        <EmptyDataTemplate>
            <div class="message-info">
                <p>No hay ningún servicio de autenticación externa configurado. Consulte <a href="http://go.microsoft.com/fwlink/?LinkId=252803">este artículo</a> para obtener más detalles sobre la configuración de esta aplicación ASP.NET para que admita el inicio de sesión a través de servicios externos.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</fieldset>