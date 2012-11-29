<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Container.behind.juipp.cs" Inherits="WebApplication1._layouts.Controllers.Container" %>


 <%@Register src="../Views/Default1View.ascx" tagName="Default1View" tagPrefix="juipp" %>
 <%@Register src="../Views/DefaultView.ascx" tagName="DefaultView" tagPrefix="juipp" %>
 
  <juipp:Default1View  Visible="false" ID="Default1View" runat="server" />   
  <juipp:DefaultView  Visible="false" ID="DefaultView" runat="server" />   
 