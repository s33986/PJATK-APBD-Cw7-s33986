using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33986.DTOs;
using PJATK_APBD_Cw7_s33986.Exceptions;
using PJATK_APBD_Cw7_s33986.Infrastructure;
using PJATK_APBD_Cw7_s33986.Models;

namespace PJATK_APBD_Cw7_s33986.Service;

public class PcsService(AppDbContext dbContext) : IPcsService
{
    public async Task<IReadOnlyList<GetAllResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.PCs
            .AsNoTracking()
            .Select(pc => new GetAllResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock))
            .ToListAsync(cancellationToken);
    }

    public async Task<GetPcWithComponentsResponse> GetComponentsByPcIdAsync(int pcId, CancellationToken cancellationToken)
    {
        var result = await dbContext.PCs
            .AsNoTracking()
            .Where(pc => pc.Id == pcId)
            .Select(pc => new GetPcWithComponentsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcComponent => new PcComponentDto(
                    pcComponent.Amount,
                    new ComponentDto(
                        pcComponent.Component.Code,
                        pcComponent.Component.Name,
                        pcComponent.Component.Description,
                        new ManufacturerDto(
                            pcComponent.Component.ComponentManufacturer.Id,
                            pcComponent.Component.ComponentManufacturer.Abbreviation,
                            pcComponent.Component.ComponentManufacturer.FullName,
                            pcComponent.Component.ComponentManufacturer.FoundationDate),
                        new ComponentTypeDto(
                            pcComponent.Component.ComponentType.Id,
                            pcComponent.Component.ComponentType.Abbreviation,
                            pcComponent.Component.ComponentType.Name)
                    )
                ))
            ))
            .SingleOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            throw new NotFoundException($"PC with id {pcId} not found.");
        }

        return result;
    }

    public async Task<GetAllResponse> CreateAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        dbContext.PCs.Add(pc);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new GetAllResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock);
    }

    public async Task UpdateAsync(int pcId, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await dbContext.PCs.FirstOrDefaultAsync(p => p.Id == pcId, cancellationToken);

        if (pc is null)
        {
            throw new NotFoundException($"PC with id {pcId} not found.");
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int pcId, CancellationToken cancellationToken)
    {
        var pc = await dbContext.PCs.FirstOrDefaultAsync(p => p.Id == pcId, cancellationToken);

        if (pc is null)
        {
            throw new NotFoundException($"PC with id {pcId} not found.");
        }

        dbContext.PCs.Remove(pc);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
