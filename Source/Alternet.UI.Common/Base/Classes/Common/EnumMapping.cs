﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    public class EnumMapping<TSource, TDest>: BaseObject
        where TSource : struct, Enum
        where TDest : struct, Enum
    {
        private readonly TDest[] values;
        private readonly int maxValue;

        public EnumMapping()
        {
            maxValue = EnumUtils.GetMaxValueAsInt<TSource>();

            values = new TDest[maxValue + 1];
        }

        public void Add(TSource from, TDest to)
        {
            var intValue = System.Convert.ToInt32(from);
            values[intValue] = to;
        }

        public void Remove(TSource from)
        {
            var intValue = System.Convert.ToInt32(from);
            values[intValue] = default;
        }

        public TDest Convert(TSource value, TDest defaultValue = default)
        {
            var intValue = System.Convert.ToInt32(value);

            if (intValue < 0 || intValue > maxValue)
                return defaultValue;

            var result = values[intValue];

            if (result.Equals(default))
                return defaultValue;
            else
                return result;
        }
    }
}
