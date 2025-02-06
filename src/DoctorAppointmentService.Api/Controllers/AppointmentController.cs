using DoctorAppointmentService.Api.DTOs.Requests;
using DoctorAppointmentService.Application.Commands.Appoinment.UpdateAppointment;
using DoctorAppointmentService.Application.Commands.Appointment.CancelAppointment;
using DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;
using DoctorAppointmentService.Application.Queries.Appointment.GetAllAppoinments;
using DoctorAppointmentService.Application.Queries.Appointment.GetAppointment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentService.Api.Controllers
{
    /// <summary>
    /// [Route("api/[controller]")]
    /// </summary>
    [Authorize]
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments([FromQuery] GetAllAppointmentsRequest request)
        {
            var query = new GetAllAppoinmentsQuery
            {
                SearchText = request.SearchText ?? string.Empty,
                Page = request.Page,
                PageSize = request.PageSize,
                SortBy = request.SortBy ?? "CreatedAt",
                SortOrder = request.SortOrder
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }



        /// <summary>   
        /// Create a new appointment
        /// </summary>
        /// <param name="request">The appointment to create</param>
        /// <returns>The created appointment</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAppoinment([FromBody] CreateAppoinmentRequest request)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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

                return Ok(new { Message = "Appointment created" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromBody] UpdateAppointmentRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new UpdateAppointmentCommand
                {
                    Id = id,
                    PatientName = request.PatientName,
                    DoctorId = request.DoctorId,
                    AppointmentDate = request.AppointmentDate
                };


                var result = await _mediator.Send(command);

                if (!result.IsSuccess)
                {
                    return BadRequest(new { Message = result.Message });
                }

                return await Task.FromResult(Ok(new { Message = result.Message }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAppointment(string id)
        {
            try
            {
                var command = new CancelAppointmentCommand
                {
                    Id = id
                };

                var result = await _mediator.Send(command);

                if (!result.IsSuccess)
                {
                    return BadRequest(new { Message = result.Message });
                }

                return Ok(new { Message = "Appointment deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

