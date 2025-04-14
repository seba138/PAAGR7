namespace SistemaAcademico.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarEstructuraNotas : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Notas");
            AddPrimaryKey("dbo.Notas", new[] { "CedulaEstudiante", "IdCurso" });
            DropColumn("dbo.Notas", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notas", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Notas");
            AddPrimaryKey("dbo.Notas", "Id");
        }
    }
}
