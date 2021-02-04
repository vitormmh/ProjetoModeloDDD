using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    //como não sei qual o repositorio que vai tratar vou criar um generico 
    //TEntity e tratá-lo como se fosse uma classe
    // O contrato diz o que repositorio base tem que fazer
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);
       
        void Remove(TEntity obj);

        void Dispose();
    }
}
