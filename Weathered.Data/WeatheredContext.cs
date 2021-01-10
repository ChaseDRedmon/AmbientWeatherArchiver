using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Weathered.API.Models;
using Weathered.Data.Models.Core;
using Weathered.Data.Utilities;

namespace Weathered.Data
{
    public class WeatheredContext : DbContext
    {
        public WeatheredContext(DbContextOptions<WeatheredContext> options) : base(options)
        {
        }

        // For building fakes during testing
        public WeatheredContext()
        {
        }
        
        /// <summary>
        /// Array of DbSet entities that allow interactions with each data context, and, ultimately database table manipulation
        /// </summary>
        public DbSet<Device> Devices { get; set; }
        
        public DbSet<UserDevice> UserDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var onModelCreatingMethods = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(x => x.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(x => !(x.GetCustomAttribute<OnModelCreatingAttribute>() is null));

            var relationships = modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var method in onModelCreatingMethods)
            {
                method.Invoke(null, new[] {modelBuilder});
            }
            
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}