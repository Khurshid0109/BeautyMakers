﻿using BeautyMakers.Services.DTOs.Salons;
using BeautyMakers.Services.DTOs.Users;

namespace BeautyMakers.Services.Interfaces.Salons;
public interface ISalonService
{
    Task<bool> RemoveAsync(long id);
    Task<SalonForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<SalonForResultDto>> RetrieveAllAsync();
    Task<SalonForResultDto> AddAsync(SalonForCreationDto dto);
    Task<SalonForResultDto> ModifyAsync(long id, SalonForUpdateDto dto);
}
