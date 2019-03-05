using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class InventoryMoveFluent : AbstractValidator<Wms_inventorymove>
    {
        public InventoryMoveFluent()
        {
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}