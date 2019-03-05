using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class StockInFluent : AbstractValidator<Wms_stockin>
    {
        public StockInFluent()
        {
            //RuleFor(x => x.StockInNo).NotNull().NotEmpty().WithMessage("入库单号不能为空").Length(1, 32).WithMessage("入库单号不能超过32");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}