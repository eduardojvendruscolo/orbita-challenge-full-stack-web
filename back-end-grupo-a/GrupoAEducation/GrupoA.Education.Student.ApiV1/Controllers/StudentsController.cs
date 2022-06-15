using System;
using System.Threading.Tasks;
using GrupoA.Education.Student.Api.Controllers.Generic;
using GrupoA.Education.Student.Application.AcademicStudent.Command;
using GrupoA.Education.Student.Application.AcademicStudent.Queries;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Common.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoA.Education.Student.Api.Controllers
{
    [Route("api/v{version:apiVersion}/students")]
    [Produces("application/json")]
    public class StudentsController : GenericApiController
    {
        public StudentsController(
            INotificationContext notificationContext, 
            IMediator mediator) : base(notificationContext, mediator)
        {
        }
        
        /// <summary>
        /// Retrieve a academic student by id
        /// </summary>
        /// <returns>AcademicStudentViewModel</returns>
        /// <response code="200">Return a academic student</response>
        /// <response code="400">Return error when try to return a student</response>
        /// <response code="404">Student not found</response> 
        /// <response code="500">Unexpected server error</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AcademicStudentViewModel>> GetAcademicStudentById(Guid id)
            => Ok(await mediator.Send(new GetAcademicStudentByIdQuery(id)));
        
        /// <summary>
        /// Retrieve a academic student list
        /// </summary>
        /// <returns>AcademicStudentViewModel</returns>
        /// <response code="200">Return a academic student list</response>
        /// <response code="400">Return error when try to return a academic student list</response>
        /// <response code="404">Empty list</response> 
        /// <response code="500">Unexpected server error</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<PaginatedViewModel<AcademicStudentViewModel>>> GetListAcademicStudent(
            [FromQuery(Name = "filter")] string filter, 
            [FromQuery(Name = "pageSize")] int pageSize = 20, 
            [FromQuery(Name = "pageOffset")] int pageOffset = 1,
            [FromQuery(Name = "orderByField")] string orderByField = "name",
            [FromQuery(Name = "orderType")] string orderType = "asc")
            => Ok(await mediator.Send(new GetAcademicStudentListQuery(filter, pageSize, pageOffset, orderByField, orderType)));        

        /// <summary>
        /// Insert a new studend
        /// </summary>
        /// <param name="insertAcademicStudentCommand">Payload with student's data</param>
        /// <returns>AcademicStudentViewModel</returns>
        /// <response code="201">Success on insert new student</response>
        /// <response code="400">Error when insert new student</response>
        /// <response code="500">Unexpected server error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        
        [HttpPost]
        public async Task<ActionResult<AcademicStudentViewModel>> InsertStudent([FromBody] InsertAcademicStudentCommand insertAcademicStudentCommand)
            => Created(nameof(InsertStudent), await mediator.Send(insertAcademicStudentCommand));
        
        /// <summary>
        /// Update a new studend
        /// </summary>
        /// <param name="insertAcademicStudentCommand">Payload with student's data</param>
        /// <returns>AcademicStudentViewModel</returns>
        /// <response code="201">Success on insert new student</response>
        /// <response code="400">Error when insert new student</response>
        /// <response code="500">Unexpected server error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AcademicStudentViewModel>> UpdateStudent(Guid id, [FromBody] UpdateAcademicStudentCommand updateAcademicStudentCommand)
            => Ok(await mediator.Send(updateAcademicStudentCommand.SetKey(id)));        

        /// <summary>
        /// Delete a academic student
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        /// <response code="204">Academic student successfully removed</response>        
        /// <response code="400">Error trying to remove a student</response>
        /// <response code="404">Student no found</response>
        /// <response code="500">Unexptected error when trying to remove student</response> 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await mediator.Send(new DeleteAcademicStudentCommand(id));
            return NoContent();
        }        
        
    }
}