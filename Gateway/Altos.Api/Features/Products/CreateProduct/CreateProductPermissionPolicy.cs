﻿using System.Collections.Generic;
using Altos.Api.Framework.Infrastructure.Authorization;
using Altos.Domain.Features.Security;

namespace Altos.Api.Features.Products.CreateProduct
{
    public class CreateProductPermissionPolicy : BasePermissionPolicy
    {
        //private readonly ICompanyService _companyService;
        public CreateProductPermissionPolicy(
            //ICompanyService companyService,
            IPermissionRepository permissionRepository) : base(permissionRepository)
        {
            var test = "test";
            //_companyService = companyService;
        }

        public override bool CanAccessEndpoint(Dictionary<string, object> arguments)
        {
            //ToDo: check if current user is in the current company (Organization)
            return this.HaveAccess(Permission.CreateProducts);
        }
    }
}
