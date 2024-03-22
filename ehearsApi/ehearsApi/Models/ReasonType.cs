using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehearsApi.Models
{
    public class ReasonType
    {
        [Key]
        public Guid reasonTypeId { get; set; }
        public string? reasonTypeName { get; set; }
    }
}
