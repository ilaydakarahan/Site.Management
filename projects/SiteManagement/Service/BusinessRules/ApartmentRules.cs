using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules;

public class ApartmentRules
{
    private readonly IApartmentRepository _apartmentRepository;

    public ApartmentRules(IApartmentRepository apartmentRepository)
    {
        _apartmentRepository = apartmentRepository;
    }

    public void TenantNameMustBeUnique(string tenantName)
    {
        var apartment = _apartmentRepository.GetByFilter(x=>x.TenantName == tenantName);
        if(apartment != null )
        {
            throw new BusinessException("Kiracı adı benzersiz olmalı");
        }
    }

    public void ApartmentIsPresent(Guid id)
    {
        var apartment = _apartmentRepository.GetById(id);

        if(apartment is null)
        {
            throw new BusinessException($"Id si : {id} olan daire bulunamadı");
        }
    }
}
