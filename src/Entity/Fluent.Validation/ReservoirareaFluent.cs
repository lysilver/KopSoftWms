using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class ReservoirareaFluent : AbstractValidator<Wms_reservoirarea>
    {
        public ReservoirareaFluent()
        {
            RuleFor(x => x.ReservoirAreaNo).NotNull().NotEmpty().WithMessage("库区编号不能为空").Length(1, 20).WithMessage("库区编号长度不能超过20");
            RuleFor(x => x.ReservoirAreaName).NotNull().NotEmpty().WithMessage("库区名称不能为空").Length(1, 50).WithMessage("库区编号长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}