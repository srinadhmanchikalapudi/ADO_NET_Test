<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQL_Queries.aspx.cs" Inherits="ADO_NET_Test.SQL_Queries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <container>
            <h1>.NET SQL Queries</h1>

                <div>
                    <asp:GridView ID="GridView1" runat="server" Width="50%" CssClass="table table-hover table-striped"></asp:GridView>
                </div>
        </container>
    </form>
</body>
</html>

