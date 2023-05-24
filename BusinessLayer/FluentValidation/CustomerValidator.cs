using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri İsmi Boş Geçilemez");
            RuleFor(x => x.CustomerName).MinimumLength(2).WithMessage("En az 2 karakter gerekli.");
            RuleFor(x => x.CustomerCity).NotEmpty().WithMessage("Müşteri Şehri Boş Geçilemez.");

        }
    }
}
