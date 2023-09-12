﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    internal class PropertyGridTypeRegistry : IPropertyGridTypeRegistry
    {
        private readonly AdvDictionary<PropertyInfo, IPropertyGridPropInfoRegistry> registry = new();
        private readonly Type type;

        public PropertyGridTypeRegistry(Type type)
        {
            this.type = type;
        }

        public Type InstanceType => type;

        public PropertyGridItemCreate? CreateFunc { get; set; }

        public IPropertyGridPropInfoRegistry? GetPropRegistryOrNull(PropertyInfo propInfo)
        {
            return registry.GetValueOrDefault(propInfo);
        }

        public IPropertyGridPropInfoRegistry GetPropRegistry(PropertyInfo propInfo)
        {
            return registry.GetOrCreate(
                propInfo,
                () => { return new PropertyGridPropInfoRegistry(propInfo); });
        }
    }
}