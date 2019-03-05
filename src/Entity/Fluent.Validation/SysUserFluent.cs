using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SysUserFluent : AbstractValidator<Sys_user>
    {
        public SysUserFluent()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("姓名不能为空").Length(1, 50).WithMessage("姓名长度不能超过50");
            RuleFor(x => x.UserNickname).NotNull().NotEmpty().WithMessage("昵称不能为空").Length(1, 50).WithMessage("昵称长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
            RuleFor(x => x.Email).MaximumLength(20).WithMessage("邮件长度不能超过20");
            RuleFor(x => x.Tel).MaximumLength(200).WithMessage("手机长度不能超过12");
        }
    }
}