<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Application.ascx.cs" Inherits="adisware.Layouts.juipp.Controllers.Container" %>
<%@ Register TagPrefix="juip" Namespace="adisware.Layouts.juipp.Controllers" Assembly="adisware.Layouts.juipp" %>


 <%@Register src="~/Views/MyView.ascx" tagName="MyView" tagPrefix="juipp" %>
 
 <juipp:ApplicationController runat="server" ID="Controller" />

  <juipp:MyView  Visible="false" ID="MyView" runat="server" />   
 