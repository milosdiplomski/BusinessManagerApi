using BusinessManager.Models.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BusinessManager.Shared.Validations
{
    public class ProductValidator : AbstractValidator<Products>
    {
        public ProductValidator()
        {

        }
    }
}
