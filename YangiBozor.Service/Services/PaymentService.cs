using AutoMapper;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.PaymentDto;
using YangiBozor.Service.DTOs.ProductDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Payment> paymentRepository;
    private readonly IMapper mapper;

    public PaymentService(IRepository<Payment> paymentRepository, IMapper mapper)
    {
        this.paymentRepository = paymentRepository;
        this.mapper = mapper;
    }

    public async Task<PaymentForResultDto> AddAsync(PaymentForCreationDto dto)
    {
        
        var mappedPayment = mapper.Map<Payment>(dto);
        mappedPayment.CreatedAt = DateTime.UtcNow;
        var result = await paymentRepository.InsertAsync(mappedPayment);
        await paymentRepository.SaveAsync();
        return mapper.Map<PaymentForResultDto>(result);
    }


    public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> predicate)
    {
        var payment = await paymentRepository.SelectAsync(predicate);
        if (payment == null)
            throw new CustomExeption(404, "Not Found!");
        await paymentRepository.DeleteAsync(predicate);
        await paymentRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<PaymentForResultDto>> GetAllAsync(Expression<Func<Payment, bool>> predicate)
    {
        var payments = paymentRepository.SelectAllAsync();
        payments = predicate != null ? payments.Where(predicate) : payments;
        return mapper.Map<IEnumerable<PaymentForResultDto>>(payments);
    }

    public async Task<PaymentForResultDto> GetAsync(Expression<Func<Payment, bool>> predicate)
    {
        var payment = await paymentRepository.SelectAsync(predicate);
        if (payment == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<PaymentForResultDto>(payment);
    }

    public async Task<PaymentForResultDto> UpdateAsync(Expression<Func<Payment, bool>> predicate, PaymentForCreationDto dto)
    {
        var payment = await paymentRepository.SelectAsync(predicate);
        if (payment == null)
            throw new CustomExeption(404, "Not Found");
        var mappedPayment = mapper.Map(dto, payment);
        var updatedPayment = await paymentRepository.UpdateAsync(mappedPayment);
        await paymentRepository.SaveAsync();
        return mapper.Map<PaymentForResultDto>(updatedPayment);
    }
}
