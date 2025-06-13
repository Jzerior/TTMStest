using TTMStest.Server.Models;
using TTMStest.Server.DTOs.PhoneDTOs;

namespace TTMStest.Server.Mappers
{
    public static class PhoneMapper
    {
        public static Phone toPhoneFromCreateDto(this CreatePhoneRequestDto createPhoneRequestDto)
        {
            return new Phone
            {
                Number = createPhoneRequestDto.Number,
                Name = createPhoneRequestDto.Name
            };
        }
        public static Phone toPhoneFromUpdateDto(this UpdatePhoneRequestDto updatePhoneRequestDto)
        {
            return new Phone
            {
                Number = updatePhoneRequestDto.Number,
                Name = updatePhoneRequestDto.Name
            };
        }   
    }
}