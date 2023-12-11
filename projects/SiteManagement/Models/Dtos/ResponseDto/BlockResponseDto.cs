using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDto;

public record BlockResponseDto(int Id, char BlockNo)
{
    public static implicit operator BlockResponseDto(Block block) 
    { 
        return new BlockResponseDto(Id : block.Id, BlockNo : block.BlockNo );
    }

}
