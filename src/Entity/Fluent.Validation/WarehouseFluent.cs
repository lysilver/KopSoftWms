using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class WarehouseFluent : AbstractValidator<Wms_warehouse>
    {
        public WarehouseFluent()
        {
            RuleFor(x => x.WarehouseNo).NotNull().NotEmpty().WithMessage("仓库编号不能为空").Length(1, 20).WithMessage("仓库编号长度不能超过20");
            RuleFor(x => x.WarehouseName).NotNull().NotEmpty().WithMessage("仓库名称不能为空").Length(1, 50).WithMessage("仓库编号长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}