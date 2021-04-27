using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IDENTITY_MEMBERSHIP.Infastructure.Identity
{
    // The role id and role name are defined from the IdendityRole class.
    // You don't need to create your own webrole class.
    // When you want to add extra structures, you can define it as a property and send it to the base.

    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }     // Role description as extra.

        public ApplicationRole()
        {
            // Leave a blank constructor for it to work without taking extra structure.
        }

        public ApplicationRole(string roleName, string description)
            : base(roleName)
            // When sending the extra structure to base, also link it to role name, that is the description of the roleName.
        {
            this.Description = description;
        }
    }
}