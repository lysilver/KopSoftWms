using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class CustomerFluent : AbstractValidator<Wms_Customer>
    {
        public CustomerFluent()
        {
            RuleFor(x => x.CustomerNo).NotNull().NotEmpty().WithMessage("客户编号不能为空").Length(1, 20).WithMessage("客户编号长度不能超过20");
            RuleFor(x => x.CustomerName).NotNull().NotEmpty().WithMessage("客户名称不能为空").Length(1, 50).WithMessage("客户名称长度不能超过50");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email长度不能超过50");
            RuleFor(x => x.CustomerPerson).MaximumLength(50).WithMessage("联系人长度不能超过30");
            RuleFor(x => x.Tel).MaximumLength(13).WithMessage("号码长度不能超过13");
            RuleFor(x => x.Address).MaximumLength(200).WithMessage("地址长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}