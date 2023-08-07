using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models
{
    public class Customer
    {
        [SwaggerSchema(ReadOnly = true)]
        public string? id { get; set; }
        
        public string? salutation { get; set; }
       
        public string? initials { get; set; }
        [Required]
        public string? firstname { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? firstname_ascii { get; set; }
        [Required]
        public string? gender { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? firstname_country_rank { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? firstname_country_frequency { get; set; }
        [Required]
        public string? lastname { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? lastname_ascii { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? lastname_country_rank { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? lastname_country_frequency { get; set; }
        [Required]
        public string email { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? password { get; set; }
        public string country_code { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? country_code_alpha { get; set; }
        [Required]
        public string country_name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? primary_language_code { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? primary_language { get; set; }
        [Required]
        public double? balance { get; set; }
        [Required]
        public string? phone_Number { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? currency { get; set; }
    }
}
