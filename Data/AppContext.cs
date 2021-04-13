using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<SubjectModel> SubjectModel { get; set; }

    }
}
