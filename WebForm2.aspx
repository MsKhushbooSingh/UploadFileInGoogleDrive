<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 </head>
<body>
    <form id="form1" runat="server">
    File:
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br /><br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" />
        <br />
    <hr />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </form>
</body>
</html>
