using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class DeviceFluent : AbstractValidator<Wms_device>
    {
        public DeviceFluent()
        {
            RuleFor(x => x.PlatformNo).NotNull().NotEmpty().WithMessage("机台号不能为空").Length(1, 20).WithMessage("机台号长度不能超过20");
            RuleFor(x => x.SerialNo).NotNull().NotEmpty().WithMessage("机身号不能为空").Length(1, 50).WithMessage("机身号长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}