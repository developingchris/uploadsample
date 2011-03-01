<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    List<string> images = (ViewData["images"] as List<string>) ?? new List<string>();
 %>

<h2>List</h2>

<ul>
    <% images.ForEach(i =>
       {  %>
       <li><a href="<%= i.Replace("_small","") %>"><img src="<%= i %>" /><a /></li>
    <%}); %>
</ul>


<%= Html.ActionLink("Start Over", "CleanUpUserContent") %>

</asp:Content>
