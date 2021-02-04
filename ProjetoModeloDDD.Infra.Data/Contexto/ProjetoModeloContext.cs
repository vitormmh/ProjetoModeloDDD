using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() :base("ProjetoModelDDD")
        {

        }
         // Criar a tabela Cliente quando criar o meu contexto 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        // Entity remover Convenções das tabelas "ções" ~plural  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            //quando a propriedade tiver o Id no final , 
            //então configura para que seja primary key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            // todas as propriedades string que sejam varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            // com tamanho de 100 caracteres
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }



        // alterar DataRegisto -- quando estiver a adicionar a data do registo será a atual , ao modificar não mexe na data
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataRegisto") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataRegisto").CurrentValue = System.DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataRegisto").IsModified = false;
                }

            }

            return base.SaveChanges();
        }


    }
}
