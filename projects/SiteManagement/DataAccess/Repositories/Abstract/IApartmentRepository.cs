using Core.Persistence.Repositories;
using Models.Dtos.ResponseDto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IApartmentRepository : IEntityRepository<Apartment, Guid>
{
    List<ApartmentDetailDto> GetAllApartmentDetails();
    List<ApartmentDetailDto> GetDetailsByBlockId(int blockId);
    ApartmentDetailDto GetApartmentDetail(Guid id);

}
