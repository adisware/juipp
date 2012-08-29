<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Application.ascx.cs" Inherits="adisware.juipp.Web._layouts.app.Controllers.Container" %>
<%@ Register TagPrefix="juipp" Namespace="adisware.juipp.Web._layouts.app.Controllers" Assembly="adisware.juipp.Web._layouts.app" %>


 <%@Register src="~/_layouts/app/Views/MyView.ascx" tagName="MyView" tagPrefix="juipp" %>
 
 <juipp:Controller runat="server" ID="Controller" />

  <juipp:MyView  Visible="false" ID="MyView" runat="server" />   
 