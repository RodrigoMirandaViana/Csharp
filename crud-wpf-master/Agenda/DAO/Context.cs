using Atleta.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atleta.DAO
{

    class Context : DbContext
    {
        public Context() : base("strConn")
        {
            // Padrao (se nao existir base de dados, cria)
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());

            // Apaga e recria a base toda vez que o projeto eh executado
            //Database.SetInitializer(new DropCreateDatabaseAlways<Contexto>());

            // Apaga e recria a base de dados se houver alteracoes nas modelos
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Model.Atleta> Atletas { get; set; }

    }
    /**class Context : DbContext
        {
            public Contexto ()
            public DbSet<>  { get; set; }

    }**/
}
