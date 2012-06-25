<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Application.ascx.cs" Inherits="TargetName@juip.Controllers.Main" %>
<%@ Register TagPrefix="juip" Namespace="TargetName@juip.Controllers" Assembly="TargetName@juip" %>


 <%@Register src="~/Views/HomeView.ascx" tagName="HomeView" tagPrefix="juip" %>
 <%@Register src="~/Views/StudentBrowseView.ascx" tagName="StudentBrowseView" tagPrefix="juip" %>
 <%@Register src="~/Views/StudentProfileAddView.ascx" tagName="StudentProfileAddView" tagPrefix="juip" %>
 <%@Register src="~/Views/StudentProfileEditView.ascx" tagName="StudentProfileEditView" tagPrefix="juip" %>
 <%@Register src="~/Views/StudentProfileView.ascx" tagName="StudentProfileView" tagPrefix="juip" %>
 <%@Register src="~/Views/WorkView.ascx" tagName="WorkView" tagPrefix="juip" %>
 
 <juip:ApplicationController runat="server" ID="Controller" />

  <juip:HomeView  Visible="false" ID="HomeView" runat="server" />   
  <juip:StudentBrowseView  Visible="false" ID="StudentBrowseView" runat="server" />   
  <juip:StudentProfileAddView  Visible="false" ID="StudentProfileAddView" runat="server" />   
  <juip:StudentProfileEditView  Visible="false" ID="StudentProfileEditView" runat="server" />   
  <juip:StudentProfileView  Visible="false" ID="StudentProfileView" runat="server" />   
  <juip:WorkView  Visible="false" ID="WorkView" runat="server" />   
 