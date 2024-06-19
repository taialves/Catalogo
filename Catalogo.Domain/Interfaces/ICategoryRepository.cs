using Catalogo.Domain.Entities;

namespace Catalogo.Domain.Interfaces
{
    public interface ICategoryRepository
    {
     // Definindo as assinaturas dos metodos que serao implementados
     // O Task significa que todas as operacoes serao asyncronas
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById(int? id);

        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);

    }
} 
