using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model.Translation
{
    public class Translation
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string KeyWord { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public string Translations { get; set; }
    }
}
