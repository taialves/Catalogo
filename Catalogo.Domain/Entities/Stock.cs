using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public sealed class Stock : Entity
    {
        public int Quantity { get; private set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public Stock( int id, int quantity)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(quantity);
        }

        public Stock(int quantity)
        {
            ValidateDomain(quantity);
        }

        public void Update(int  quantity)
        {
            ValidateDomain(quantity);
        }
        private void ValidateDomain( int quantity)
        {
            DomainExceptionValidation.When(quantity < 0, "Invalid Quantity value");
            Quantity = quantity;
        }
    }
}
