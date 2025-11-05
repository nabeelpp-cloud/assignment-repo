using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Payments.Query
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery,List<PaymentDto>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetAllPaymentsQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments =await dbContext.Payments.ToListAsync();
            List<PaymentDto> paymentDtos = new List<PaymentDto>();
            foreach(var payment in payments)
            {
                paymentDtos.Add(new PaymentDto
                {
                    Id = payment.Id,
                    BookingId = payment.BookingId,
                    PaymentDate = payment.PaymentDate,
                    Amount = payment.Amount,
                    Method = payment.Method,
                    Status = payment.Status
                });
            }
            return paymentDtos;
        }
    }

}
