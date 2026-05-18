using PJATK_APBD_Cw7_s33986.DTOs;

namespace PJATK_APBD_Cw7_s33986.Service;

public interface IPcsService
{
    Task<IReadOnlyList<GetAllResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<GetPcWithComponentsResponse> GetComponentsByPcIdAsync(int pcId, CancellationToken cancellationToken);
    Task<GetAllResponse> CreateAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int pcId, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int pcId, CancellationToken cancellationToken);
}
