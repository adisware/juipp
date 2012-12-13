<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ output extension=".ascx" #>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Container.behind.juipp.cs" Inherits="$rootnamespace$.Controllers.Container" %>

<#
	var views = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Views\"));
#>

 <# 
    if(views != null && views.Length > 0)
    foreach(var view in views)
    {
        var fileName = System.IO.Path.GetFileName(view);
        var className =  System.IO.Path.GetFileName(view).Split('.')[0];
        if(fileName.EndsWith("View.ascx.cs") == false) continue;
 #>
<%@Register src="../Views/<#= className #>.ascx" tagName="<#= className #>" tagPrefix="juipp" %>
 <#
    }
 #>

 <#
    if(views != null && views.Length > 0)
    foreach(var view in views)
    {
        var fileName = System.IO.Path.GetFileName(view);
        var className =  System.IO.Path.GetFileName(view).Split('.')[0];
        if(fileName.EndsWith("View.ascx.cs") == false) continue;
 #>
 <juipp:<#= className #>  Visible="false" ID="<#= className #>" runat="server" />   
 <#
    }
 #>