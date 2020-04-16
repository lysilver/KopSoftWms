using FluentValidation;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SupplierFluent : AbstractValidator<Wms_supplier>
    {
        public SupplierFluent()
        {
            RuleFor(x => x.SupplierNo).NotNull().NotEmpty().WithMessage("供应商编号不能为空").Length(1, 20).WithMessage("供应商编号长度不能超过20");
            RuleFor(x => x.SupplierName).NotNull().NotEmpty().WithMessage("供应商名称不能为空").Length(1, 50).WithMessage("供应商名称长度不能超过50");
            RuleFor(x => x.Remark).MaximumLength(200).WithMessage("备注长度不能超过200");
        }
    }
}