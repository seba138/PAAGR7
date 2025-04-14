<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="SistemaAcademicoo.Web.Profesores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Profesor - Sistema Académico</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f8;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: white;
            padding: 30px 40px;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 400px;
        }

        h1 {
            font-size: 2.5rem;
            color: #2c3e50;
            margin-bottom: 20px;
        }

        .menu-container {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .menu-button {
            padding: 15px 25px;
            font-size: 18px;
            background-color: #3498db;
            color: white;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s, transform 0.3s;
        }

        .menu-button:hover {
            background-color: #2980b9;
            transform: translateY(-5px);
        }

        .menu-button:active {
            transform: translateY(2px);
        }

        .menu-button:focus {
            outline: none;
        }

        .menu-button:nth-child(1) {
            background-color: #3498db;
        }

        .menu-button:nth-child(2) {
            background-color: #2ecc71;
        }

        .menu-button:nth-child(3) {
            background-color: #f39c12;
        }

        .menu-button:nth-child(4) {
            background-color: #e74c3c;
        }

        .menu-button:nth-child(5) {
            background-color: #9b59b6; /* Color para Agregar Profesores */
        }

        .menu-button:hover:nth-child(1) {
            background-color: #2980b9;
        }

        .menu-button:hover:nth-child(2) {
            background-color: #27ae60;
        }

        .menu-button:hover:nth-child(3) {
            background-color: #f39c12;
        }

        .menu-button:hover:nth-child(4) {
            background-color: #c0392b;
        }

        .menu-button:hover:nth-child(5) {
            background-color: #8e44ad; /* Hover para Agregar Profesores */
        }

        .form-container {
            margin-top: 20px;
            text-align: left;
        }

        .form-container input {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .form-container label {
            font-size: 18px;
            margin-bottom: 5px;
            display: block;
            text-align: left;
        }

        .form-container .form-actions {
            display: flex;
            justify-content: space-between;
        }

        .form-container .form-actions input {
            width: 48%;
        }

        .message-container {
            margin-top: 20px;
            color: #27ae60;
            font-size: 18px;
            font-weight: bold;
            text-align: center;
        }

        .message-container.error {
            color: #e74c3c;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Agregar Profesor</h1>

             <!-- Formulario para agregar profesor -->
            <div class="form-container">
                <label for="txtCedula">Cédula:</label>
                <asp:TextBox ID="txtCedula" runat="server" CssClass="form-input" placeholder="Ingrese cédula"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtCedula" InitialValue="" ErrorMessage="La cédula es obligatoria." ForeColor="Red" ValidationGroup="AgregarProfesor" />
                
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-input" placeholder="Ingrese nombre y apellido"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" InitialValue="" ErrorMessage="El nombre es obligatorio." ForeColor="Red" ValidationGroup="AgregarProfesor" />

                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-input" placeholder="Ingrese correo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" InitialValue="" ErrorMessage="El correo es obligatorio." ForeColor="Red" ValidationGroup="AgregarProfesor" />
                <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="Correo no válido" ForeColor="Red" ValidationGroup="AgregarProfesor" />

                <div class="form-actions">
                   

                    <asp:Button ID="btnAgregarProfesor" runat="server" CssClass="menu-button" Text="Agregar Profesor" OnClick="btnAgregarProfesor_Click" ValidationGroup="AgregarProfesor" />
                    
                    

                    <asp:Button ID="btnSalir" runat="server" CssClass="menu-button" Text="Salir" OnClick="btnSalir_Click" />
                </div>
            </div>

           

            <asp:Label ID="lblMensaje" runat="server" class="message-container"></asp:Label>
        </div>
    </form>
</body>
</html>
