using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class InvmovedetailFluent : AbstractValidator<Wms_invmovedetail>
    {
        public InvmovedetailFluent()
        {
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}