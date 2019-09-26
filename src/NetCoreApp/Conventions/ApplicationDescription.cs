using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YL.NetCore.Conventions
{
    public class ApplicationDescription : IApplicationModelConvention
    {
        private readonly string _description;
        private readonly string _key;

        public ApplicationDescription(string key, string description)
        {
            _key = key;
            _description = description;
        }

        public void Apply(ApplicationModel application)
        {
            application.Properties[_key] = _description;
        }
    }
}