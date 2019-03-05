using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SysDeptFluent : AbstractValidator<Sys_dept>
    {
        public SysDeptFluent()
        {
            RuleFor(x => x.DeptNo).NotNull().NotEmpty().WithMessage("部门编号不能为空").Length(1, 20).WithMessage("部门编号长度不能超过20");
            RuleFor(x => x.DeptName).NotNull().NotEmpty().WithMessage("部门名称不能为空").Length(1, 50).WithMessage("部门名称长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}