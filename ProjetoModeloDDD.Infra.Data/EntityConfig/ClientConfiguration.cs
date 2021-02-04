using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    // Quando tiver criando a entidade Cliente quero que a tabela 
    //Clientes tenha comportamentpo exclusivos na tabela

        class ClientConfiguration : EntityTypeConfiguration<Cliente>
        {
            public ClientConfiguration()
            {
                HasKey(c => c.ClienteId);

                Property(c => c.Nome).IsRequired().HasMaxLength(150);
                Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);
                Property(c => c.Email).IsRequired();

            }
        }
}
