<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%using (Html.BeginForm("Upload", "File", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <input type="file" id="picture" name="picture" />
    <br />
    <input type="submit" value="upload" />
<%} %>