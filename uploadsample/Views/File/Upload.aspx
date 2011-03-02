<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload More Brains
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        $(function () {
            $("#uploadMore").click(function () { $("#uploadArea").toggle(); });
            if ($(".error:visible").length) {
                $("#uploadArea").show("slow");
            }

        })
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<h2>BRAIIIIIINNNNNNSS!!!(photos)</h2>
You can either upload another photo to be chased, or begin the chase.
<br />
<a href="javascript:void(0);" id="uploadMore">Upload another Brain</a> | <%= Html.ActionLink("Begin The Chase", "List") %>

<div id="uploadArea" class="hidden">
    <% Html.RenderPartial("uploadForm"); %>
</div>


</asp:Content>
