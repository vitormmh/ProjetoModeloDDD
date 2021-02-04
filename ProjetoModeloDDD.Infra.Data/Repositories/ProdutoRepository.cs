using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.Repositories;
using System.Linq;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> ProcuraNome(string nome)
        {
            return Db.Produtos.Where(x => x.Nome == nome);
       
        }
    }
}
