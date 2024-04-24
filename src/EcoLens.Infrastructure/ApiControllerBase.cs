using Asp.Versioning;
using EcoLens.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EcoLens.Infrastructure;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;

    public async Task<IActionResult> Execute<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<Result<TResponse>>
    {
        var result = await Mediator.Send(request);
        if (result.IsFailure)
            return Problem(detail: result.Error?.Message, statusCode: 400);

        if (result.Value is bool)
            return Ok();

        return Ok(result.Value);
    }
}
