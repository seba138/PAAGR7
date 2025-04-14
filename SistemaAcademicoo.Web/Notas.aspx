<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="SistemaAcademicoo.Web.Notas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar Notas de Estudiantes</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 850px;
            margin: auto;
            background: #fff;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        h2, h3 {
            color: #2c3e50;
            margin-bottom: 20px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 12px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .btn {
            padding: 10px 16px;
            margin-right: 10px;
            margin-top: 10px;
            border: none;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
        }

        .btn-primary {
            background-color: #3498db;
            color: white;
        }

        .btn-success {
            background-color: #2ecc71;
            color: white;
        }

        .btn-warning {
            background-color: #f39c12;
            color: white;
        }

        .btn-danger {
            background-color: #e74c3c;
            color: white;
        }

        .btn-secondary {
            background-color: #95a5a6;
            color: white;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }

        .table th {
            background-color: #2980b9;
            color: white;
        }

        fieldset {
            border: 2px solid #ccc;
            border-radius: 10px;
            padding: 15px;
            margin-bottom: 20px;
        }

        legend {
            font-weight: bold;
            font-size: 1.2em;
            padding: 0 10px;
        }
        .message {
    margin: 15px 0;
    font-weight: bold;
    color: green;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Registrar Notas de Estudiantes</h2>

            <fieldset>
                <legend> Buscar Profesor</legend>
                <asp:TextBox ID="txtCedulaProfesor" runat="server" CssClass="form-control" Placeholder="Cédula del Profesor" />
                <asp:Button ID="btnBuscarCursos" runat="server" Text="Buscar Profesor" OnClick="btnBuscarCursos_Click" CssClass="btn btn-primary" />
            </fieldset>

            <fieldset>
                <legend> Seleccionar Curso</legend>
                <asp:DropDownList ID="ddlCursos" runat="server" AutoPostBack="true" CssClass="form-control"
                    OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged">
                </asp:DropDownList>
            </fieldset>

            <fieldset>
                <legend> Listado de Estudiantes</legend>
                <asp:GridView ID="gvEstudiantes" runat="server" AutoGenerateColumns="False" CssClass="table"
                    OnRowDataBound="gvEstudiantes_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:TemplateField HeaderText="Cédula">
                            <ItemTemplate>
                                <asp:Label ID="lblCedulaId" runat="server" Text='<%# Eval("CedulaId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Curso">
                            <ItemTemplate>
                                <asp:Label ID="lblIdCurso" runat="server" Text='<%# ddlCursos.SelectedValue %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nota">
                            <ItemTemplate>
                                <asp:TextBox ID="txtNota" runat="server" CssClass="form-control" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>

            <asp:Button ID="btnGuardarNotas" runat="server" Text="Guardar Notas" OnClick="btnGuardarNotas_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnSalir" runat="server" Text="Volver al Inicio" OnClick="btnSalir_Click" CssClass="btn btn-secondary" />
         <asp:Label ID="lblMensaje" runat="server" CssClass="message" />
        </div> 

    </form>
</body>
</html>
