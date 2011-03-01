<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        $(function () {
            $("#uploadMore").click(function () { $("#uploadArea").show(); });
        })
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Upload</h2>

<a href="javascript:void(0);" id="uploadMore">Upload another file</a> | <%= Html.ActionLink("Done", "List") %>

<div id="uploadArea" class="hidden">
    <% Html.RenderPartial("uploadForm"); %>
</div>


</asp:Content>
