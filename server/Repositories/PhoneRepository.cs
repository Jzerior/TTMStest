using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTMStest.Server.Interfaces.IRepositories;
using TTMStest.Server.Models;
using TTMStest.Server.DTOs.PhoneDTOs;
using TTMStest.Server.Mappers;

namespace TTMStest.Server.Repositories;

public class PhoneRepository : IPhoneRepository
{
    private readonly List<Phone> _phones = new List<Phone>();
    private int _nextId = 1;

    public Task<IEnumerable<Phone>> GetAllPhonesAsync()
    {
        return Task.FromResult(_phones.AsEnumerable());
    }

    public Task<Phone?> GetPhoneByIdAsync(int id)
    {
        var phone = _phones.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(phone);
    }

    public Task<Phone> AddPhoneAsync(CreatePhoneRequestDto phoneDto)
    {
        Phone phone = phoneDto.toPhoneFromCreateDto();
        Console.WriteLine($"Dodawanie telefonu: Name={phone.Name}, Number={phone.Number}");
        phone.Id = _nextId++;
        _phones.Add(phone);
        Console.WriteLine(_phones.Count);
        return Task.FromResult(phone);
    }

    public Task<Phone?> UpdatePhoneAsync(int id, UpdatePhoneRequestDto phoneDto)
    {
        Phone phone = phoneDto.toPhoneFromUpdateDto();
        var existing = _phones.FirstOrDefault(p => p.Id == id);
        if (existing == null)
            return Task.FromResult<Phone?>(null);

        existing.Name = phone.Name;
        existing.Number = phone.Number;

        return Task.FromResult(existing);
    }

    public Task<Phone?> DeletePhoneAsync(int id)
    {
        var phone = _phones.FirstOrDefault(p => p.Id == id);
        if (phone != null)
        {
            _phones.Remove(phone);
        }
        return Task.FromResult(phone);
    }
}