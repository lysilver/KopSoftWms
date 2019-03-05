using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class StorageRackFluent : AbstractValidator<Wms_storagerack>
    {
        public StorageRackFluent()
        {
            RuleFor(x => x.StorageRackNo).NotNull().NotEmpty().WithMessage("货架编号不能为空").Length(1, 20).WithMessage("货架编号长度不能超过20");
            RuleFor(x => x.StorageRackName).NotNull().NotEmpty().WithMessage("货架名称不能为空").Length(1, 50).WithMessage("货架编号长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}