using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SysRoleFluent : AbstractValidator<Sys_role>
    {
        public SysRoleFluent()
        {
            RuleFor(x => x.RoleName).NotNull().NotEmpty().WithMessage("角色名称不能为空").Length(1, 50).WithMessage("角色名称长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}