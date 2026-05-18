namespace PJATK_APBD_Cw7_s33986.DTOs;

public record ComponentDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturer,
    ComponentTypeDto Type
);
