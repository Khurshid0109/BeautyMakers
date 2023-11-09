using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Services.Helpers;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.Extentions;
using BeautyMakers.Services.DTOs.Salons;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.Interfaces.Salons;

namespace BeautyMakers.Services.Services.Salons;
public class SalonService : ISalonService
{
    private readonly IMapper _mapper;
    private readonly ISalonRepository _repository;

    public SalonService(ISalonRepository repository, IMapper mapper, 
        IUserRepository userRepository, IBeautyProfessionalRepository beautyProfessionalRepository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<SalonForResultDto> AddAsync(SalonForCreationDto dto)
    {

        var mapped = _mapper.Map<Salon>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.SalonImg = await MediaHelper.UploadFile(dto.SalonImg);

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
        mapped.UpdatedAt = DateTime.UtcNow;

        if (dto.SalonImg is not null)
            mapped.SalonImg = await MediaHelper.UploadFile(dto.SalonImg);

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

    public async Task<IEnumerable<SalonForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var salons = await _repository.SelectAll()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<SalonForResultDto>>(salons);
    }

    public async Task<SalonForResultDto> RetrieveByIdAsync(long id)
    {
        var salon = await _repository.SelectByIdAsync(id);

        return _mapper.Map<SalonForResultDto>(salon);
    }
}
