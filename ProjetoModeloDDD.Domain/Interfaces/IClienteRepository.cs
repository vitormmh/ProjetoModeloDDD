using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    //herda o Irepositorio de cliente
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {

    }
}
