﻿using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Services.Helpers;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.Extentions;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.BeautyProfessionals;
using BeautyMakers.Services.Interfaces.BeautyProfessionals;

namespace BeautyMakers.Services.Services.BeautyProfessionals;
public class BeautyProfessionalService : IBeautyProfessionalService
{
    private readonly IBeautyProfessionalRepository _repository;
    private readonly IMapper _mapper;

    public BeautyProfessionalService(IBeautyProfessionalRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BeautyProfessionalForResultDto> AddAsync(BeautyProfessionalForCreationDto dto)
    {
        var servant = await _repository.SelectAll()
            .Where(s => s.Email == dto.Email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (servant is not null)
            throw new CustomException(409, "BeautyProfessional is already exist!");

        var mapped = _mapper.Map<BeautyProfessional>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        
        if (dto.ProfessionalImg is not null)
            mapped.ProfessionalImage = await MediaHelper.UploadFile(dto.ProfessionalImg);

        var res = await _repository.InsertAsync(mapped);

        if (res != null)
        {
            var beautyProfessionalWithSalon = await _repository.SelectAll()
                .Where(bp => bp.Id == res.Id)
                .Include(bp => bp.Salon)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<BeautyProfessionalForResultDto>(beautyProfessionalWithSalon);
        }

        return _mapper.Map<BeautyProfessionalForResultDto>(res);
    }

    public async Task<BeautyProfessionalForResultDto> ModifyAsync(long id, BeautyProfessionalForUpdateDto dto)
    {
        var servant = await _repository.SelectAll()
             .Where(s => s.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        var mapped = _mapper.Map(dto, servant);
        mapped.UpdatedAt = DateTime.UtcNow;

        if (dto.ProfessionalImg is not null)
            mapped.ProfessionalImage = await MediaHelper.UploadFile(dto.ProfessionalImg);

        await _repository.UpdateAsync(mapped);

        if (mapped != null)
        {
            var beautyProfessionalWithSalon = await _repository.SelectAll()
                .Where(bp => bp.Id == mapped.Id)
                .Include(bp => bp.Salon)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<BeautyProfessionalForResultDto>(beautyProfessionalWithSalon);
        }

        return _mapper.Map<BeautyProfessionalForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var servant = await _repository.SelectAll()
              .Where(s => s.Id == id)
              .AsNoTracking()
              .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<BeautyProfessionalForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var servants = await _repository.SelectAll()
            .Include(bp => bp.Salon)
            .ToPagedList(@params)
            .ToListAsync();
        return _mapper.Map<IEnumerable<BeautyProfessionalForResultDto>>(servants);
    }

    public async Task<BeautyProfessionalForResultDto> RetrieveByEmailAsync(string email)
    {
        var servant = await _repository.SelectAll()
            .Where(s => s.Email == email)
            .Include(bp => bp.Salon)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        return _mapper.Map<BeautyProfessionalForResultDto>(servant);
    }

    public async Task<BeautyProfessionalForResultDto> RetrieveByIdAsync(long id)
    {
        var servant = await _repository.SelectAll()
               .Where(s => s.Id == id)
               .Include(bp => bp.Salon)
               .AsNoTracking()
               .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        return _mapper.Map<BeautyProfessionalForResultDto>(servant);
    }
}
