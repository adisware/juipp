<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Application.ascx.cs" Inherits="TargetName@juipp.Controllers.Container" %>
<%@ Register TagPrefix="juipp" Namespace="TargetName@juipp.Controllers" Assembly="TargetName@juipp" %>


 <%@Register src="~/Views/MyView.ascx" tagName="MyView" tagPrefix="juipp" %>
 
 <juipp:Controller runat="server" ID="Controller" />

  <juipp:MyView  Visible="false" ID="MyView" runat="server" />   
 