using Core.Shared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IApartmentService
{
    Response<ApartmentResponseDto> Add(ApartmentAddRequest request);
    Response<ApartmentResponseDto> Update(ApartmentUpdateRequest request);
    Response<ApartmentResponseDto> Delete(Guid id);
    Response<ApartmentResponseDto> GetById(Guid id);
    Response<List<ApartmentResponseDto>> GetAll();
    Response<List<ApartmentResponseDto>> GetAllByRentRange(int min,int max);
    Response<ApartmentDetailDto> GetByDetailId(Guid id);
    Response<List<ApartmentDetailDto>> GetAllDetails();
    Response<List<ApartmentDetailDto>> GetAllDetailsByBlockId(int blockId);

}
