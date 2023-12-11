using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using Service.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class BlockService : IBlockService
{
    private readonly IBlockRepository _blockRepository;
    private readonly BlockRules _blockRules;

    public BlockService(IBlockRepository blockRepository, BlockRules blockRules)
    {
        _blockRepository = blockRepository;
        _blockRules = blockRules;
    }

    public Response<BlockResponseDto> Add(BlockAddRequest blockAddRequest)
    {
        try
        {
            Block block = blockAddRequest;

            _blockRules.BlockNoMustBeUnique(block.BlockNo);
            _blockRepository.Add(block);

            BlockResponseDto response = block;

            return new Response<BlockResponseDto>
            {
                Data = response,
                Message = "Blok eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (BusinessException ex)
        {
            return new Response<BlockResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }       
    }

    public Response<BlockResponseDto> Delete(int id)
    {
        try
        {
            _blockRules.BlockIsPresent(id);

            Block block = _blockRepository.GetById(id);
            _blockRepository.Delete(block);

            BlockResponseDto responseDto = block;
            return new Response<BlockResponseDto>
            {
                Data = responseDto,
                Message = "Blok silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<BlockResponseDto>
            {
                Message = ex.Message,
                StatusCode= System.Net.HttpStatusCode.BadRequest
            };
        }      
    }

    public Response<List<BlockResponseDto>> GetAll()
    {
        List<Block> blocks = _blockRepository.GetAll();

        List<BlockResponseDto> response = blocks.Select(x=> (BlockResponseDto)x).ToList();

        return new Response<List<BlockResponseDto>>() 
        { 
            Data = response,
            StatusCode =System.Net.HttpStatusCode.OK
        };
    }

    public Response<BlockResponseDto> GetById(int id)
    {
        try
        {
            _blockRules.BlockIsPresent(id);
            Block? block = _blockRepository.GetById(id);

            BlockResponseDto response = block;
            return new Response<BlockResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<BlockResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }        
    }

    public Response<BlockResponseDto> Update(BlockUpdateRequest blockUpdateRequest)
    {
        try
        {
            Block block = blockUpdateRequest;

            _blockRules.BlockNoMustBeUnique(block.BlockNo);
            _blockRepository.Update(block);

            BlockResponseDto blockResponseDto = block;
            return new Response<BlockResponseDto>()
            {
                Data = blockResponseDto,
                Message = "Blok bilgileri güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<BlockResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }        
    }
}
