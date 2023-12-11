using Core.Persistence.EntityBaseModel;
using Models.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Block : Entity<int>
{
    public char BlockNo { get; set; }
    public List<Apartment> Apartments { get; set; }

    public static implicit operator Block (BlockAddRequest blockAddRequest) =>
        new Block { BlockNo = blockAddRequest.BlockNo };

    public static implicit operator Block (BlockUpdateRequest request)=>
        new Block { BlockNo = request.BlockNo,Id = request.Id };


}
