using TTMStest.Server.Models;
using System.Collections.Generic;
using TTMStest.Server.DTOs.PhoneDTOs;
    
namespace TTMStest.Server.Interfaces.IRepositories
{

    public interface IPhoneRepository
    {
        Task<IEnumerable<Phone>> GetAllPhonesAsync();
        Task<Phone?> GetPhoneByIdAsync(int id);
        Task<Phone> AddPhoneAsync(CreatePhoneRequestDto phoneDto);
        Task<Phone?> UpdatePhoneAsync(int id, UpdatePhoneRequestDto phoneDto);
        Task<Phone?> DeletePhoneAsync(int id);
    }
}