using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Services.Helpers;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.DTOs.Salons;
using BeautyMakers.Services.Interfaces.Salons;

namespace BeautyMakers.Services.Services.Salons;
public class SalonService : ISalonService
{
    private readonly ISalonRepository _repository;
    private readonly MediaHelper _helper;
    private readonly IMapper _mapper;

    public SalonService(ISalonRepository repository, IMapper mapper, 
        MediaHelper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }

    public async Task<SalonForResultDto> AddAsync(SalonForCreationDto dto)
    {
        var mapped = _mapper.Map<Salon>(dto);
        mapped.CreatedAt = DateTime.Now;
        mapped.SalonImg = await _helper.UploadFile(dto.SalonImg);

        var res = await _repository.InsertAsync(mapped);

        return _mapper.Map<SalonForResultDto>(res);
    }

    public async Task<SalonForResultDto> ModifyAsync(long id, SalonForUpdateDto dto)
    {
        var salon = await _repository.SelectAll()
             .Where(s => s.Id == id)
             .FirstOrDefaultAsync();

        if (salon is null)
            throw new CustomException(404, "Salon is not found!");

        var mapped = _mapper.Map(dto, salon);
        mapped.UpdatedAt = DateTime.Now;

        if (dto.SalonImg is not null)
            mapped.SalonImg = await _helper.UploadFile(dto.SalonImg);

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<SalonForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var salon = await _repository.SelectAll()
             .Where(s => s.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (salon is null)
            throw new CustomException(404, "Salon is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<SalonForResultDto>> RetrieveAllAsync()
    {
        var salons = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<SalonForResultDto>>(salons);
    }

    public async Task<SalonForResultDto> RetrieveByIdAsync(long id)
    {
        var salon = await _repository.SelectByIdAsync(id);

        return _mapper.Map<SalonForResultDto>(salon);
    }
}
