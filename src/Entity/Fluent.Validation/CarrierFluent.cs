using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class CarrierFluent : AbstractValidator<Wms_Carrier>
    {
        public CarrierFluent()
        {
            RuleFor(x => x.CarrierNo).NotNull().NotEmpty().WithMessage("承运商编号不能为空").Length(1, 20).WithMessage("承运商编号长度不能超过20");
            RuleFor(x => x.CarrierName).NotNull().NotEmpty().WithMessage("承运商名称不能为空").Length(1, 50).WithMessage("承运商编号长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}