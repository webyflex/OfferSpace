using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfferSpace.Web.Models
{
  public class UserCompanyRegisterViewModel
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    public string UserImage { get; set; }

    public string CompanyName { get; set; }

    public string CompanyImage { get; set; }
  }
}
