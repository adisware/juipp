<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Application.ascx.cs" Inherits="adisware.juipp.Web._layouts.app.Controllers.Container" %>
<%@ Register TagPrefix="juipp" Namespace="adisware.juipp.Web._layouts.app.Controllers" Assembly="adisware.juipp.Web._layouts.app" %>


 <%@Register src="~/_layouts/app/Views/HomeAdminView.ascx" tagName="HomeAdminView" tagPrefix="juipp" %>
 <%@Register src="~/_layouts/app/Views/HomeView.ascx" tagName="HomeView" tagPrefix="juipp" %>
 <%@Register src="~/_layouts/app/Views/MyView.ascx" tagName="MyView" tagPrefix="juipp" %>
 <%@Register src="~/_layouts/app/Views/StudentProfileView.ascx" tagName="StudentProfileView" tagPrefix="juipp" %>
 
 <juipp:Controller runat="server" ID="Controller" />

  <juipp:HomeAdminView  Visible="false" ID="HomeAdminView" runat="server" />   
  <juipp:HomeView  Visible="false" ID="HomeView" runat="server" />   
  <juipp:MyView  Visible="false" ID="MyView" runat="server" />   
  <juipp:StudentProfileView  Visible="false" ID="StudentProfileView" runat="server" />   
 