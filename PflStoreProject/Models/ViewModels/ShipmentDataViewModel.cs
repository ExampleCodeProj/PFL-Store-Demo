using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class ShipmentDataViewModel
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

        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(55, ErrorMessage = "Must not exceed 55 characters.")]
        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Phone:")]
        public long? Phone { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address Line 1:")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2 (Apt, Suite, Floor, Unit):")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "City or Province:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "State:")]
        public string State { get; set; }

        //TODO: match international codes or change fields when country is chosen
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^\d{5}([\-]?\d{4})?$", ErrorMessage = "Invalid zipcode")]
        [Required(ErrorMessage = "Required")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Country:")]
        public string CountryCode { get; set; }

        public string ShippingMethod { get; set; }
    }
}
