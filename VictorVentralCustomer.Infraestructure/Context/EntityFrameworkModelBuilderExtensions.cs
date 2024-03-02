﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VictorVentralCustomer.Domain.Interfaces;

namespace VictorVentralCustomer.Infraestructure.Context
{
    public static class EntityFrameworkModelBuilderExtensions
    {
        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EntityFrameworkModelBuilderExtensions)
      .GetMethods(BindingFlags.Public | BindingFlags.Static)
      .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { modelBuilder });
        }

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : class, IBase
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}
