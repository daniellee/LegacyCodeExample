﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <%: Html.ActionLink("Send Order Confirmation", "SendOrderConfirmation", "Order", new { @orderId = 1}, null)%>
    <br />
    <%: Html.ActionLink("Save Order", "SaveOrder", "Order")%>

</asp:Content>
