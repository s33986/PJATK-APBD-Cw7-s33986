namespace PJATK_APBD_Cw7_s33986.DTOs;

public record GetAllResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);
