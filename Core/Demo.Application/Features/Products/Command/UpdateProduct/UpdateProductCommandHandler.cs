using Demo.Application.UnitOfWorks;
using Demo.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var entity = new Product()
            {
                Id = request.Id,
                Description = request.Description,
                Price = request.price,
                Discount = request.Discount,
                Title = request.Title,
            };

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(entity);
            await unitOfWork.SaveAsync();
        }
    }
}
