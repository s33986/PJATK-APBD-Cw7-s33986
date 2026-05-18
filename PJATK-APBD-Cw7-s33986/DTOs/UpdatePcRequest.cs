using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s33986.DTOs;

public record UpdatePcRequest(
    [Required]
    [MaxLength(50)]
    string Name,
    [Required]
    float Weight,
    [Required]
    int Warranty,
    [Required]
    DateTime CreatedAt,
    [Required]
    int Stock
);
