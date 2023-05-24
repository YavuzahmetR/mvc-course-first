using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün Adı en az 2 karakter olabilir.");
            RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage("Stok Sayısı boş geçilemez");

        }
    }
}
