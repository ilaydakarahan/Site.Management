using Core.Shared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IBlockService
{
    Response<BlockResponseDto> Add(BlockAddRequest blockAddRequest);
    Response<BlockResponseDto> Update(BlockUpdateRequest blockUpdateRequest);
    Response<BlockResponseDto> Delete(int id);
    Response<BlockResponseDto> GetById(int id);
    Response<List<BlockResponseDto>> GetAll();

}
