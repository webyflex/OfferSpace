using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfferSpace.Web.Models
{
  public class EditProfileModel
  {
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(100, ErrorMessage = "The value {0} must contain at least {2} characters.", MinimumLength = 6)]
    public string FirstName { get; set; }

    [StringLength(100, ErrorMessage = "The value {0} must contain at least {2} characters.", MinimumLength = 6)]
    public string LastName { get; set; }

    public string Image { get; set; }

    public bool MarkAsDeleted { get; set; }
  }
}
