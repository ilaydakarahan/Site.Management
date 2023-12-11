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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly ApartmentRules _rules;

    public ApartmentService(IApartmentRepository apartmentRepository, ApartmentRules rules)
    {
        _apartmentRepository = apartmentRepository;
        _rules = rules;
    }

    public Response<ApartmentResponseDto> Add(ApartmentAddRequest request)
    {
        try
        {
            Apartment apartment = ApartmentAddRequest.ConvertToEntity(request);

            _rules.TenantNameMustBeUnique(apartment.TenantName);

            apartment.Id = new Guid();
            _apartmentRepository.Add(apartment);

            var data = ApartmentResponseDto.ConvertToResponse(apartment);

            return new Response<ApartmentResponseDto>()
            {
                Data = data,
                Message = "Daire Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };

        }
        catch (BusinessException ex)
        {

            return new Response<ApartmentResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }       
    }

    public Response<ApartmentResponseDto> Delete(Guid id)
    {
        try
        {
            _rules.ApartmentIsPresent(id);

            var apartment = _apartmentRepository.GetById(id);
            _apartmentRepository.Delete(apartment);

            var data = ApartmentResponseDto.ConvertToResponse(apartment);

            return new Response<ApartmentResponseDto>()
            {
                Data = data,
                Message = "Daire bilgileri silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<ApartmentResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }        
    }

    public Response<List<ApartmentResponseDto>> GetAll()
    {
        var apartments = _apartmentRepository.GetAll();

        var response = apartments.Select(x=> ApartmentResponseDto.ConvertToResponse(x)).ToList();

        return new Response<List<ApartmentResponseDto>>()
        {
            Data = response,
            StatusCode= System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ApartmentResponseDto>> GetAllByRentRange(int min, int max)
    {
        var apartments = _apartmentRepository.GetAll(x=>x.Rent<=max && x.Rent>=min);

        var response = apartments.Select(x => ApartmentResponseDto.ConvertToResponse(x)).ToList();

        return new Response<List<ApartmentResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ApartmentDetailDto>> GetAllDetails()
    {
        var details = _apartmentRepository.GetAllApartmentDetails();

        return new Response<List<ApartmentDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ApartmentDetailDto>> GetAllDetailsByBlockId(int blockId)
    {
        var details = _apartmentRepository.GetDetailsByBlockId(blockId);

        return new Response<List<ApartmentDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ApartmentDetailDto> GetByDetailId(Guid id)
    {
        try
        {
            _rules.ApartmentIsPresent(id);

            var detail = _apartmentRepository.GetApartmentDetail(id);

            return new Response<ApartmentDetailDto>()
            {
                Data = detail,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<ApartmentDetailDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }      
    }

    public Response<ApartmentResponseDto> GetById(Guid id)
    {
        try
        {
            _rules.ApartmentIsPresent(id);

            var apartment = _apartmentRepository.GetById(id);
            var response = ApartmentResponseDto.ConvertToResponse(apartment);
            return new Response<ApartmentResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<ApartmentResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }      
    }

    public Response<ApartmentResponseDto> Update(ApartmentUpdateRequest request)
    {
        try
        {
            Apartment apartment = ApartmentUpdateRequest.ConvertToEntity(request);

            _rules.TenantNameMustBeUnique(apartment.TenantName);
            _apartmentRepository.Update(apartment);

            var response = ApartmentResponseDto.ConvertToResponse(apartment);

            return new Response<ApartmentResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<ApartmentResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }        
    }
}
