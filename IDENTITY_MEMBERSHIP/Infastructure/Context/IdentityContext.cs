using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IDENTITY_MEMBERSHIP.Infastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IDENTITY_MEMBERSHIP.Infastructure.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("Server=.; Database=IdentityMembershipDB; Integrated Security=SSPI")
        {
        }
    }
}