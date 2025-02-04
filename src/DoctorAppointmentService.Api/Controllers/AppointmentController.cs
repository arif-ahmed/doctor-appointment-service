using Azure;
using DoctorAppointmentService.Api.DTOs.Requests;
using DoctorAppointmentService.Application.Commands.Appoinment.CreateAppoinment;
using DoctorAppointmentService.Application.Commands.Appoinment.UpdateAppointment;
using DoctorAppointmentService.Application.Queries.Appointment.GetAllAppoinments;
using DoctorAppointmentService.Application.Queries.Appointment.GetAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentService.Api.Controllers
{
    /// <summary>
    /// [Route("api/[controller]")]
    /// </summary>
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(string id)
        {
            try
            {
                var query = new GetAppointmentByIdQuery
                {
                    Id = id
                };

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)    
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ GET: /api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments([FromQuery] GetAllAppoinmentsQuery request)
        {
            // var query = new GetAllAppoinmentsQuery 
            // {
            //     Page = 1,
            //     PageSize = 10
            // };
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAppoinment([FromBody] CreateAppoinmentRequest request)
        {
            //var validator = new CreateAppoinmentRequestValidator();
            //var validationResult = await validator.ValidateAsync(request);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}

            var command = new CreateAppoinmentCommand
            {
                PatientName = request.PatientName,
                DoctorId = request.DoctorId,
                AppointmentDate = request.AppointmentDate

            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return BadRequest(new { Message = "Appointment not created" });
            }

            return await Task.FromResult(Ok(new { Message = "Appointment created" }));
        }

        [HttpPut("{id}")] // This will map to /api/appointments/{id}
        public async Task<IActionResult> UpdateAppointment(string id, [FromBody] UpdateAppointmentDto request)
        {
            var command = new UpdateAppointmentCommand
            {
                Id = id,
                PatientName = request.PatientName,
                DoctorId = request.DoctorId,
                AppointmentDateTime = request.AppointmentDateTime
            };

            var result = await _mediator.Send(command);  

            if (!result.IsSuccess)  
            {
                return BadRequest(new { Message = result.Message });
            }

            return await Task.FromResult(Ok(new { Message = result.Message }));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAppointment(string id)
        {
            return await Task.FromResult(Ok(new { Message = "Appointment deleted" }));
        }
    }
}
