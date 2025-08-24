using Demo.Application.Interfaces.AutoMapper;
using Demo.Application.Interfaces.UnitOfWorks;
using Demo.Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(x=>x.IsDeleted==false);

            //AutoMapper Kullanmadım List olarak eklendi
            
            List<GetAllProductsQueryResponse> response = new();
            foreach (var product in products)
            {
                response.Add(new GetAllProductsQueryResponse()
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price - (product.Price * (product.Discount / 100)),
                });
            }
            
           // var map = mapper.Map<IList<GetAllProductsQueryResponse>>(products);

            return response;

        }
    }
}
