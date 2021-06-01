<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dummy.aspx.cs" Inherits="Hired_dotnet.dummy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>File upload testing.</h1>
            </div>

            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>

            <div>
                <asp:Button ID="Button2" runat="server" Text="Show file" OnClick="Button2_Click" />
            </div>
        </div>
    </form>
</body>
</html>
