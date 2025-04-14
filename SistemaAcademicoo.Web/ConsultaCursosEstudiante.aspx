<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCursosEstudiante.aspx.cs" Inherits="SistemaAcademicoo.Web.ConsultaCursosEstudiante" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de Cursos por Estudiante</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f8;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 16px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
            width: 500px;
        }

        h2 {
            font-size: 24px;
            color: #2c3e50;
            margin-bottom: 30px;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label, .form-group label, .message {
            display: block;
            margin-bottom: 6px;
            font-weight: 600;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border-radius: 8px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        .btn {
            padding: 12px 20px;
            font-size: 16px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            color: white;
        }

        #btnBuscar {
            background-color: #3498db;
        }

        #btnBuscar:hover {
            background-color: #2980b9;
        }

        #btnSalir {
            background-color: #e74c3c;
        }

        #btnSalir:hover {
            background-color: #c0392b;
        }

        .message {
            margin-top: 10px;
            color: red;
            font-weight: bold;
            white-space: pre-line;
        }

        .success {
            color: green;
        }

        .grid {
            margin-top: 25px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        .table th,
        .table td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: left;
        }

        .table th {
            background-color: #ecf0f1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Consulta de Cursos por Cédula</h2>

            <div class="form-group">
                <asp:Label ID="lblCedula" runat="server" Text="Cédula del Estudiante:" AssociatedControlID="txtCedula" />
                <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group" style="display: flex; gap: 10px;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Cursos" CssClass="btn" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnSalir" runat="server" Text="Salir" CssClass="btn" OnClick="btnSalir_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="message" />

            <div class="grid">
                <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="CursoId" HeaderText="ID Curso" />
                        <asp:BoundField DataField="NombreCurso" HeaderText="Nombre del Curso" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
