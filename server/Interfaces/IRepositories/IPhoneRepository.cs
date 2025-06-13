using TTMStest.Server.Models;
using System.Collections.Generic;
using TTMStest.Server.DTOs.PhoneDTOs;
    
namespace TTMStest.Server.Interfaces.IRepositories
{

    public interface IPhoneRepository
    {
        Task<IEnumerable<Phone>> GetAllPhonesAsync();
        Task<Phone?> GetPhoneByIdAsync(int id);
        Task<Phone> AddPhoneAsync(CreatePhoneRequestDto phone);
        Task<Phone?> UpdatePhoneAsync(int id, UpdatePhoneRequestDto phone);
        Task<Phone?> DeletePhoneAsync(int id);
    }
}