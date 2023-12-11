using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Dtos.ResponseDto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class ApartmentRepository : EfRepositoryBase<BaseDbContext, Apartment, Guid>, IApartmentRepository
{
    public ApartmentRepository(BaseDbContext context) : base(context)
    {
    }

    public List<ApartmentDetailDto> GetAllApartmentDetails()
    {
        var details = Context.Apartments.Join(
            Context.Blocks,
            p => p.BlockId,
            b => b.Id,
            (apartment, block) => new ApartmentDetailDto
            {
                Id = apartment.Id,
                ApartmentNo = apartment.ApartmentNo,
                TenantName = apartment.TenantName,
                Rent = apartment.Rent,
                BlockNo = block.BlockNo             
            }                                          
            ).ToList();
        return details;
    }

    public List<ApartmentDetailDto> GetDetailsByBlockId(int blockId)
    {
        var details = Context.Apartments.Where(x=>x.BlockId == blockId).Join(
            Context.Blocks,
            p => p.BlockId,
            c=>c.Id,
            (p,c) => new ApartmentDetailDto
            {
                BlockNo = c.BlockNo,
                Id = p.Id,
                ApartmentNo = p.ApartmentNo,
                Rent = p.Rent,
                TenantName= p.TenantName
            }                                             
            ).ToList();
        return details;
    }

    public ApartmentDetailDto GetApartmentDetail(Guid id)
    {
        var details = Context.Apartments.Join(
             Context.Blocks,
            p => p.BlockId,
            c => c.Id,
            (p, c) => new ApartmentDetailDto
            {
                BlockNo = c.BlockNo,
                Id = p.Id,
                ApartmentNo = p.ApartmentNo,
                Rent = p.Rent,
                TenantName = p.TenantName
            }
            ).SingleOrDefault(x=>x.Id == id);

        return details;
    }

}
