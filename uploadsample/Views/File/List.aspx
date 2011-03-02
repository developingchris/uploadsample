<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    The Chase
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        $(function () {
            var z = $(".zombie");
            z.hide();
            setTimeout("toggleRandomZombie()", time);
            setTimeout("killHumans()", time * 3);
        });

        var time = 1000;

        function toggleRandomZombie() {
            var z = $(".zombie");
            max = z.size();
            rand = Math.floor(Math.random() * max + 1);
            $(z.get(rand)).toggle("slow");

            if ($(".human:visible").size() > 1) {
                setTimeout("toggleRandomZombie()", time);
            }
            else {
                alert("Zombies won");
            }
        }

        function killHumans() {
            var humans = $(".human")
            $(humans.get(Math.floor(Math.random() * humans.size() + 1))).hide();
            if ($(".human:visible").size() > 0) {
                setTimeout("killHumans()", time * 3);
            }
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    List<string> images = (ViewData["images"] as List<string>) ?? new List<string>();
 %>
<h2>The Chase is On</h2>
<%= Html.ActionLink("Fresh Brains", "CleanUpUserContent") %>

<div>
<ul id="chase_list">
    <% images.ForEach(i =>
       {  %>
       <li class="zombie"><img src="/content/images/horde_front.jpg" /></li>
       <li class="human"><a href="<%= i.Replace("_small","") %>"><img src="<%= i %>" /><a /></li>
       <li class="zombie"><img src="/content/images/zombie-horde_moving_left.jpg" /></li>
    <%}); %>
</ul>
</div>
</asp:Content>
