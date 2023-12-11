using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules;

public class BlockRules
{
    private readonly IBlockRepository _blockRepository;

    public BlockRules(IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
    }

    public void BlockNoMustBeUnique(int blockNo)
    {
        var block = _blockRepository.GetByFilter(x => x.BlockNo == blockNo);
        if(block != null)
        {
            throw new BusinessException("Blok adı benzersiz olmalı");
        }
    }

    public void BlockIsPresent(int id)
    {
        var block = _blockRepository.GetById(id);
        if(block == null)
        {
            throw new BusinessException($"Id si : {id} olan blok bulunamadı");
        }
    }
}
