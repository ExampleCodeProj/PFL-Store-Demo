using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class OrderCustomerDataViewModel
    {
        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(55, ErrorMessage = "Must not exceed 55 characters.")]
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(55, ErrorMessage = "Must not exceed 55 characters.")]
        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]

        [Display(Name = "Phone:")]
        public long? Phone { get; set; }





        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address Line 1:")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2 (Apt, Suite, Floor, Unit):")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "State:")]
        public string State { get; set; }

        [Display(Name = "5-digit Zipcode:")]
        [RegularExpression(@"^\d{5}([\-]?\d{4})?$", ErrorMessage = "Invalid zipcode")]
        [Required(ErrorMessage = "Required")]
        public int? Zipcode { get; set; }
    }
}
