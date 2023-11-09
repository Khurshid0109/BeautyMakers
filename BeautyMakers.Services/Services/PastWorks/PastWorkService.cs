using AutoMapper;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.DTOs.PastWorks;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.Interfaces.PastWorks;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.Extentions;
using BeautyMakers.Services.DTOs.BeautyProfessionals;

namespace BeautyMakers.Services.Services.PastWorks;
public class PastWorkService : IPastWorkService
{
    private readonly IPastWorksRepository _repository;
    private readonly IBeautyProfessionalRepository _professionalRepository;
    private readonly IMapper _mapper;

    public PastWorkService(IPastWorksRepository repository,
        IBeautyProfessionalRepository professionalRepository,
        IMapper mapper)
    {
        _repository = repository;
        _professionalRepository = professionalRepository;
        _mapper = mapper;
    }

    public async Task<PastWorkForResultDto> AddAsync(PastWorkForCreationDto dto)
    {
        var servant = await _professionalRepository.SelectAll()
             .Where(s => s.Id == dto.BeautyProfessionalId)
             .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        var mapped = _mapper.Map<PastWork>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.ImageUrl = await  MediaHelper.UploadFile(dto.ImageUrl);

        var res = await _repository.InsertAsync(mapped);


        return _mapper.Map<PastWorkForResultDto>(res);
    }

    public async Task<PastWorkForResultDto> ModifyAsync(long id, PastWorkForUpdateDto dto)
    {
        var example = await _repository.SelectAll()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (example is null)
            throw new CustomException(404, "PastWork example is not found!");

        var mapped = _mapper.Map(dto, example);
        mapped.UpdatedAt = DateTime.UtcNow;

        if (dto.ImageUrl is not null)
            mapped.ImageUrl = await MediaHelper.UploadFile(dto.ImageUrl);

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<PastWorkForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var example = await _repository.SelectAll()
              .Where(e => e.Id == id)
              .FirstOrDefaultAsync();

        if (example is null)
            throw new CustomException(404, "Example is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<PastWorkForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var examples = await _repository.SelectAll()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<PastWorkForResultDto>>(examples);
    }

    public async Task<PastWorkForResultDto> RetrieveByIdAsync(long id)
    {
        var example = await _repository.SelectAll()
             .Where(e => e.Id == id)
             .FirstOrDefaultAsync();

        if (example is null)
            throw new CustomException(404, "Example is not found!");

        return _mapper.Map<PastWorkForResultDto>(example);
    }
}
