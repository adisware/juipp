<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="adisware.juipp.Web._layouts.app.Pages.Default" %>
 <%@Register src="~/_layouts/app/Controllers/Container.juipp.ascx" tagName="Container" tagPrefix="juipp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <juipp:Container ID="Container" runat="server" />
    </div>
    </form>
</body>
</html>
