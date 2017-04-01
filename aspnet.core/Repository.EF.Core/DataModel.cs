using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Repository.EF.Core.Models;

namespace Repository.EF.Core
{
    public class DataModel : DbContext
    {
        public DataModel(DbContextOptions<DataModel> options) : base(options)
        {
        }

        public DbSet<Todo> TodoItems { get; set; }
    }
}
