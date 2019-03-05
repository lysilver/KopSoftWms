using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YL.Core.Entity.Fluent.Validation
{
    public class DeliveryFluent : AbstractValidator<Wms_delivery>
    {
        public DeliveryFluent()
        {
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}