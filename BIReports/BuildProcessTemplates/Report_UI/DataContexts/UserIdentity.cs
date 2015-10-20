using Microsoft.AspNet.Identity.EntityFramework;
using Report_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data;

namespace Report_UI.DataContexts
{
    public class UserIdentity : IdentityDbContext<ApplicationUser>
    {
        public UserIdentity()
            : base("PMSReports")
        {
            Database.Log = sql => Debug.Write(sql);
        }        
    }
    
}