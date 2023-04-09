using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.PaymentDto;

namespace YangiBozor.Service.Interfaces;

public interface IPaymentService
{

    Task<PaymentForResultDto> AddAsync(PaymentForCreationDto dto);
    Task<PaymentForResultDto> UpdateAsync(Expression<Func<Payment, bool>> predicate, PaymentForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Payment, bool>> predicate);
    Task<PaymentForResultDto> GetAsync(Expression<Func<Payment, bool>> predicate);
    Task<IEnumerable<PaymentForResultDto>> GetAllAsync(Expression<Func<Payment, bool>> predicate);
}
