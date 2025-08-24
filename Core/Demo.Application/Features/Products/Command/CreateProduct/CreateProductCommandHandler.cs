using Demo.Application.Interfaces.UnitOfWorks;
using Demo.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            Product product = new(request.Title, request.Description, request.Price, request.Discount);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();

        }
    }
}
