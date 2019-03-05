using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class StockInDetailFluent : AbstractValidator<Wms_stockindetail>
    {
        public StockInDetailFluent()
        {
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}