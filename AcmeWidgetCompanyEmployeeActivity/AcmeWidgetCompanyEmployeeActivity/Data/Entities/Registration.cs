using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetCompanyEmployeeActivity.Data.Entities
{
    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Must be provided")]
        [StringLength(200, MinimumLength = 5,ErrorMessage ="First Name must be in between 5 and 200 characters.")]
        public string  FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Must be provided")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Last Name must be in between 5 and 200 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address Must be provided")]
        [EmailAddress(ErrorMessage ="Email Address is not in correct format")]
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Activity id Must be provided")]
        [Range(1, 6, ErrorMessage = "Value for Activity ID must be between 1 and 6.")]
        public int ActivityId { get; set; }
    }
}
