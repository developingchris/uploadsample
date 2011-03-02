<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Zombie Chase Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<strong>
Have you played every level of every zombie game?
<br />
Seen Zombieland so much that you just call it z-land and tallahassee is your second home.
<br />
Maybe it's time for another way to waste time on the internet.
<br />
Zombie chase is a site where you can upload photos. And then those photos get scaled down and chased by zombies.
</strong>

<% Html.RenderPartial("uploadForm"); %>


</asp:Content>
