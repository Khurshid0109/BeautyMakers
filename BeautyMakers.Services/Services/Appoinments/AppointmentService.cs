using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.DTOs.Appoinments;
using BeautyMakers.Services.Interfaces.Appoinments;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.Extentions;

namespace BeautyMakers.Services.Services.Appoinments;
public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IBeautyProfessionalRepository _beautyProfessionalRepository;

    public AppointmentService(IAppointmentRepository repository, 
        IMapper mapper, IUserRepository userRepository, 
        IBeautyProfessionalRepository beautyProfessionalRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
        _beautyProfessionalRepository = beautyProfessionalRepository;
    }

    public async Task<AppointmentForResultDto> AddAsync(AppointmentForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
             .Where(u => u.Id == dto.CustomerId)
             .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        var servant = await _beautyProfessionalRepository.SelectAll()
            .Where(s => s.Id == dto.BeautyProfessionalId)
            .FirstOrDefaultAsync();

        if (servant is null)
            throw new CustomException(404, "BeautyProfessional is not found!");

        var mapped = _mapper.Map<Appointment>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var res = await _repository.InsertAsync(mapped);

        return _mapper.Map<AppointmentForResultDto>(res);
    }

    public async Task<AppointmentForResultDto> ModifyAsync(long id, AppointmentForUpdateDto dto)
    {
        var app = await _repository.SelectAll()
             .Where(a => a.Id == id)
             .FirstOrDefaultAsync();

        if (app is null)
            throw new CustomException(404, "Appointment is not found!");

        var mapped = _mapper.Map(dto, app);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<AppointmentForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
      var app = await _repository.SelectAll()
            .Where(a => a.Id==id)
            .FirstOrDefaultAsync();

        if (app is null)
            throw new CustomException(404, "Appointment is not found!");

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<AppointmentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var appointments = await _repository.SelectAll()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AppointmentForResultDto>>(appointments);
    }

    public async Task<AppointmentForResultDto> RetrieveByIdAsync(long id)
    {
        var app = await _repository.SelectAll()
               .Where(a => a.Id == id)
               .FirstOrDefaultAsync();

        if (app is null)
            throw new CustomException(404, "Appointment is not found!");

        return _mapper.Map<AppointmentForResultDto>(app);
    }
}
