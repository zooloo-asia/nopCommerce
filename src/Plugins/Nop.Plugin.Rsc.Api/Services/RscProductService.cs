using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Services.Catalog;
using NUglify.Helpers;
using Org.BouncyCastle.Utilities;

namespace Nop.Plugin.Rsc.Api.Services
{
    public class RscProductService:IRscProductService
    {
        private IProductService _productService;

        public RscProductService(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<RscProduct> GetProducts(IEnumerable<int> ids)
        {
            var products = _productService.GetProductsByIds(ids.ToArray());
            var rscProducts = from product in products
                select AutoMapperConfiguration.Mapper.Map<RscProduct>(product);
            return rscProducts;
        }
    }
}