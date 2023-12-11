using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Apartment : Entity<Guid>
{
    public int ApartmentNo { get; set; }
    public string TenantName { get; set; }
    public int Rent { get; set; }

    public int BlockId { get; set; }
    public Block Block { get; set; }
}
