using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> UsersTable { get; set; }
        public DbSet<NoteEntity> NotesTable { get; set; }

    }
}
