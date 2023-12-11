using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDto;

public record ApartmentResponseDto(Guid Id, int ApartmentNo, string TenantName, int Rent, int BlockId)
{
    public static ApartmentResponseDto ConvertToResponse(Apartment apartment)
    {
        return new ApartmentResponseDto(
            Id : apartment.Id,
            ApartmentNo : apartment.ApartmentNo,
            TenantName : apartment.TenantName,
            Rent : apartment.Rent,
            BlockId : apartment.BlockId
            );
    }
}
