using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltTab.Identity
{
	public class IdentityDataContext : IdentityDbContext<ApplicationUser>
	{
        public IdentityDataContext():base("IdentityConnection")
        {
            
        }
    }
}