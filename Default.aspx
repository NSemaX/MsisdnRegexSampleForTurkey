<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regex Sample</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox Height="40" Width="600px" runat="server" ID="message_box"></asp:TextBox>
            <asp:Button runat="server" ID="create_btn" Text="Create" OnClick="create_btn_Click" />
            <asp:Label runat="server" ID="alert_lbl" />

        </div>
    </form>
</body>
</html>
