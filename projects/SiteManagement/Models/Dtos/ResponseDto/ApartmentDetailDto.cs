using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDto;

public record ApartmentDetailDto
{
    
    public Guid Id { get; init; }
    public int ApartmentNo { get; init; }
    public string TenantName { get; init; }
    public int Rent { get; init; }
    public char BlockNo { get; init; }
}
