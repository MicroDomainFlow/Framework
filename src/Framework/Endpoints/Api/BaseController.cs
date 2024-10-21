using AutoMapper;

using MDF.Framework.Extensions.Results;
using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ContentService.Endpoints.API.Controllers;
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase

{
	private readonly IMediator _mediator;
	protected readonly IMapper Mapper;

	protected BaseController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		Mapper = mapper;
	}

	private IActionResult FluentResult<T>(FluentResults.Result<T> result)
	{
		if (result.IsSuccess)
		{
			return Ok(value: result.ConvertToCustomResult());
		}

		return BadRequest(error: result.ToResult().ConvertToCustomResult());
	}

	private IActionResult FluentResult(FluentResults.Result result)
	{
		if (result.IsSuccess)
		{
			return Ok(value: result.ConvertToCustomResult());
		}

		return BadRequest(error: result.ConvertToCustomResult());
	}

	//موارد کامنت شده را باید در کنترلر مشتق شده استفاده کرد
	//[ProducesResponseType(type: typeof(FluentResults.Result<Guid>), statusCode: StatusCodes.Status200OK)]
	//[ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
	//[HttpPost("[action]")]
	protected async Task<IActionResult> CreateAsync<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult>
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}
	protected async Task<IActionResult> CreateAsync<TCommand>(TCommand command) where TCommand : ICommand
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}

	//[ProducesResponseType(type: typeof(FluentResults.Result<Guid>), statusCode: StatusCodes.Status200OK)]
	//[ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
	//[HttpPut("[action]")]
	protected async Task<IActionResult> EditAsync<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult>
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}
	protected async Task<IActionResult> EditAsync<TCommand>(TCommand command) where TCommand : ICommand
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}


	//[ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status200OK)]
	//[ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
	//[HttpDelete("[action]")]
	protected async Task<IActionResult> DeleteAsync<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult>
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}
	protected async Task<IActionResult> DeleteAsync<TCommand>(TCommand command) where TCommand : ICommand
	{
		var result = await _mediator.Send(command);
		return FluentResult(result: result);
	}

	protected async Task<IActionResult> QueryAsync<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
	{
		var result = await _mediator.Send(query);
		return FluentResult(result: result);
	}
}
