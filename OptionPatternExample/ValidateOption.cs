using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class ValidateOption
    {
        public const string SectionName = "OptionsValidationSection";
        [Required]
        [RegularExpression("^[a-zA-Z'\\s]{1,50}$")]
        public string Title { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "이메일 형식이 아닙니다")]
        public string Email { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Qty { get; set; }
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2030-12-31")]
        public DateTime DueDate { get; set; }
    }
}
