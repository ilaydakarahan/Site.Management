using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDto
{
    public record ApartmentUpdateRequest(Guid Id, int ApartmentNo, string TenantName, int Rent, int BlockId)
    {
        public static Apartment ConvertToEntity(ApartmentUpdateRequest request)
        {
            return new Apartment
            {
                Id = request.Id,
                ApartmentNo = request.ApartmentNo,
                TenantName = request.TenantName,
                Rent = request.Rent,
                BlockId = request.BlockId
            };
        }
    }
}
