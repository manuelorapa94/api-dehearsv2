using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ehearsApi.Models
{
    public class QRInformation
    {
        [Key]
        public string? qrCode { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public string? extName { get; set; }
        public int Age { get; set; }
        public bool sex { get; set; }
        public string? fullAddress { get; set; }
        public string? contactNo { get; set; }
        public string? formattedBirthdate { get; set; }
        public string? civilStatus { get; set; }
    }
}
