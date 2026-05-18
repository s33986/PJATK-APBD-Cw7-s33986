using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33986.DTOs;
using PJATK_APBD_Cw7_s33986.Exceptions;
using PJATK_APBD_Cw7_s33986.Service;

namespace PJATK_APBD_Cw7_s33986.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcsService pcsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetAllResponse>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            var result = await pcsService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id:int}/components")]
    public async Task<ActionResult<GetPcWithComponentsResponse>> GetComponents(int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await pcsService.GetComponentsByPcIdAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<GetAllResponse>> Create([FromBody] CreatePcRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var created = await pcsService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetAll), created);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePcRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await pcsService.UpdateAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await pcsService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
