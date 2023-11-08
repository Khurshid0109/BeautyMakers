using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.DTOs.Users;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.Interfaces.Users;

namespace BeautyMakers.Services.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await _repository.SelectAll()
            .FirstOrDefaultAsync(u => u.Email== dto.Email);

        if (user is not null)
            throw new CustomException(409, "User is already exists!");

        var mapped = _mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var res = await _repository.InsertAsync(mapped);
        return _mapper.Map<UserForResultDto>(res);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await _repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        var mapped = _mapper.Map(dto, user);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<UserForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await _repository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByEmailAsync(string email)
    {
        var user = await _repository.SelectAll()
            .Where(u => u.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await _repository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found!");

        return _mapper.Map<UserForResultDto>(user) ;
    }
}
