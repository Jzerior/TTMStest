using TTMStest.Server.Models;
using System.Collections.Generic;

    
namespace TTMStest.Server.Interfaces.IRepositories
{

    public interface IPhoneRepository
    {
        Task<IEnumerable<Phone>> GetAllPhonesAsync();
        Task<Phone?> GetPhoneByIdAsync(int id);
        Task<Phone> AddPhoneAsync(Phone phone);
        Task<Phone?> UpdatePhoneAsync(int id, Phone phone);
        Task<Phone?> DeletePhoneAsync(int id);
    }
}