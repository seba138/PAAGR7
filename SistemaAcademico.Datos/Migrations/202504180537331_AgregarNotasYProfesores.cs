namespace SistemaAcademico.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarNotasYProfesores : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.EstudianteCursoes", "CedulaId", "dbo.Estudiantes");
            DropIndex("dbo.EstudianteCursoes", new[] { "CedulaId" });
            DropIndex("dbo.EstudianteCursoes", new[] { "CursoId" });
            DropPrimaryKey("dbo.Cursoes");
            DropPrimaryKey("dbo.EstudianteCursoes");
            DropPrimaryKey("dbo.Estudiantes");
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CedulaEstudiante = c.String(nullable: false, maxLength: 128),
                        IdCurso = c.String(nullable: false, maxLength: 128),
                        ValorNota = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.IdCurso, cascadeDelete: true)
                .ForeignKey("dbo.Estudiantes", t => t.CedulaEstudiante, cascadeDelete: true)
                .Index(t => t.CedulaEstudiante)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        CedulaId = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.CedulaId);
            
            AddColumn("dbo.Cursoes", "NombreCurso", c => c.String());
            AddColumn("dbo.Cursoes", "CedulaProfesor", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cursoes", "CursoId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EstudianteCursoes", "CedulaId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EstudianteCursoes", "CursoId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Estudiantes", "CedulaId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cursoes", "CursoId");
            AddPrimaryKey("dbo.EstudianteCursoes", new[] { "CedulaId", "CursoId" });
            AddPrimaryKey("dbo.Estudiantes", "CedulaId");
            CreateIndex("dbo.Cursoes", "CedulaProfesor");
            CreateIndex("dbo.EstudianteCursoes", "CedulaId");
            CreateIndex("dbo.EstudianteCursoes", "CursoId");
            AddForeignKey("dbo.Cursoes", "CedulaProfesor", "dbo.Profesors", "CedulaId", cascadeDelete: true);
            AddForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes", "CursoId", cascadeDelete: true);
            AddForeignKey("dbo.EstudianteCursoes", "CedulaId", "dbo.Estudiantes", "CedulaId", cascadeDelete: true);
            DropColumn("dbo.Cursoes", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursoes", "Nombre", c => c.String());
            DropForeignKey("dbo.EstudianteCursoes", "CedulaId", "dbo.Estudiantes");
            DropForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Cursoes", "CedulaProfesor", "dbo.Profesors");
            DropForeignKey("dbo.Notas", "CedulaEstudiante", "dbo.Estudiantes");
            DropForeignKey("dbo.Notas", "IdCurso", "dbo.Cursoes");
            DropIndex("dbo.Notas", new[] { "IdCurso" });
            DropIndex("dbo.Notas", new[] { "CedulaEstudiante" });
            DropIndex("dbo.EstudianteCursoes", new[] { "CursoId" });
            DropIndex("dbo.EstudianteCursoes", new[] { "CedulaId" });
            DropIndex("dbo.Cursoes", new[] { "CedulaProfesor" });
            DropPrimaryKey("dbo.Estudiantes");
            DropPrimaryKey("dbo.EstudianteCursoes");
            DropPrimaryKey("dbo.Cursoes");
            AlterColumn("dbo.Estudiantes", "CedulaId", c => c.Int(nullable: false));
            AlterColumn("dbo.EstudianteCursoes", "CursoId", c => c.Int(nullable: false));
            AlterColumn("dbo.EstudianteCursoes", "CedulaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cursoes", "CursoId", c => c.Int(nullable: false));
            DropColumn("dbo.Cursoes", "CedulaProfesor");
            DropColumn("dbo.Cursoes", "NombreCurso");
            DropTable("dbo.Profesors");
            DropTable("dbo.Notas");
            AddPrimaryKey("dbo.Estudiantes", "CedulaId");
            AddPrimaryKey("dbo.EstudianteCursoes", new[] { "CedulaId", "CursoId" });
            AddPrimaryKey("dbo.Cursoes", "CursoId");
            CreateIndex("dbo.EstudianteCursoes", "CursoId");
            CreateIndex("dbo.EstudianteCursoes", "CedulaId");
            AddForeignKey("dbo.EstudianteCursoes", "CedulaId", "dbo.Estudiantes", "CedulaId", cascadeDelete: true);
            AddForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes", "CursoId", cascadeDelete: true);
        }
    }
}
