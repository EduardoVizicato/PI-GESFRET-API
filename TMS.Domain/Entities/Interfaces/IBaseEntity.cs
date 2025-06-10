namespace TMS.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

public interface IBaseEntity
{
    [Key]
    Guid Id { get; set; }
    bool IsActive { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}