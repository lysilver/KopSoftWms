using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SysDictFluent : AbstractValidator<Sys_dict>
    {
        public SysDictFluent()
        {
            RuleFor(x => x.DictName).NotNull().NotEmpty().WithMessage("字典名称不能为空").Length(1, 50).WithMessage("字典名称长度不能超过50");
            RuleFor(x => x.DictType).NotNull().NotEmpty().WithMessage("字典类型不能为空");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}