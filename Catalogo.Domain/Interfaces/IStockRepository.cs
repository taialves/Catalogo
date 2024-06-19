using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IStockRepository
    {
        // Operações CRUD
        Task CreateAsync(Stock stock);
        Task UpdateAsync(Stock stock);

        // Operações Específicas de Estoque
        Task<Stock> GetStockByProductIdAsync(int productId);
        Task IncreaseStockAsync(int productId, int quantity);
        Task DecreaseStockAsync(int productId, int quantity);
    }
}
