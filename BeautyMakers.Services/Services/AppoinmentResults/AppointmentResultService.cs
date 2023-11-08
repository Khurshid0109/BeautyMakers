using AutoMapper;
using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Exceptions;
using BeautyMakers.Services.DTOs.AppoinmentResults;
using BeautyMakers.Services.Interfaces.AppoinmentResults;

namespace BeautyMakers.Services.Services.AppoinmentResults;
public class AppointmentResultService : IAppointmentResultService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentResultRepository _repository;
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentResultService(IMapper mapper,
        IAppointmentResultRepository repository, 
        IAppointmentRepository appointmentRepository)
    {
        _repository = repository;
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<AppointmentResultDto> AddAsync(AppointmentResultForCreationDto dto)
    {
        var app = await _appointmentRepository.SelectAll()
            .Where(a => a.Id == dto.AppointmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (app is null)
            throw new CustomException(404, "Appointment is not found!");

        var mapped = _mapper.Map<AppointmentResult>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var res = await _repository.InsertAsync(mapped);

        return _mapper.Map<AppointmentResultDto>(res);
    }

    public async Task<AppointmentResultDto> ModifyAsync(long id, AppointmentResultForUpdateDto dto)
    {
        var appResult= await _repository.SelectAll()
             .Where(a => a.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (appResult is null)
            throw new CustomException(404, "AppointmentResult is not found!");

        var mapped = _mapper.Map(dto, appResult);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<AppointmentResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var appResult = await _repository.SelectAll()
             .Where(a => a.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (appResult is null)
            throw new CustomException(404, "AppointmentResult is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<AppointmentResultDto>> RetrieveAllAsync()
    {
        var appResults = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<AppointmentResultDto>>(appResults);
    }

    public async Task<AppointmentResultDto> RetrieveByIdAsync(long id)
    {
        var appResult = await _repository.SelectAll()
              .Where(a => a.Id == id)
              .AsNoTracking()
              .FirstOrDefaultAsync();

        if (appResult is null)
            throw new CustomException(404, "AppointmentResult is not found!");

        return _mapper.Map<AppointmentResultDto>(appResult);
    }
}
