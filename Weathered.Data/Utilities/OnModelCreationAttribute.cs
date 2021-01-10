using System;

namespace Weathered.Data.Utilities
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OnModelCreatingAttribute : Attribute { }
}