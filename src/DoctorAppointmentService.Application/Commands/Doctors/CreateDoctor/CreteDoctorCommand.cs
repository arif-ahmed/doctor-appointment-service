using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Doctors.CreateDoctor;

public class CreateDoctorCommand : IRequest<Doctor>
{
    public required string Name { get; set; }

}

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Doctor>
{
    private readonly IDoctorRepository _doctorRepository;

    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            Name = request.Name
        };

        await _doctorRepository.AddAsync(doctor);

        return doctor;
    }

}

