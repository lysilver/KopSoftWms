using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YL.Core.Entity.Fluent.Validation
{
    public class SysLogFluent : AbstractValidator<Sys_log>
    {
        public SysLogFluent()
        {
            RuleFor(x => x.Browser).MaximumLength(460).WithMessage("浏览器长度不能超过460");
            RuleFor(x => x.Description).MaximumLength(990).WithMessage("描述不能超过990");
            RuleFor(x => x.Url).MaximumLength(140).WithMessage("Url长度不能超过140");
        }
    }
}