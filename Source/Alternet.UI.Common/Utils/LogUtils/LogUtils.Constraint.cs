﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alternet.UI
{
    public static partial class LogUtils
    {
        internal static void LogConstraintHasConstructorNoParams(Type type)
        {
            if (!AssemblyUtils.HasConstructorNoParams(type))
            {
                App.Log($"No constructor '{type}()'");
            }
        }

        internal static void LogConstraintHasConstructorWithParams(Type type, Type[] paramTypes)
        {
            if (!AssemblyUtils.HasConstructorWithParams(type, paramTypes))
            {
                App.Log($"No constructor '{type}{StringUtils.ToString(paramTypes)}'");
            }
        }

        internal static void LogCheckConstraintsForControl(Type type)
        {
            LogConstraintHasConstructorNoParams(type);
            LogConstraintHasConstructorWithParams(type, [typeof(Control)]);
        }

        internal static void LogCheckConstraints()
        {
            App.LogBeginSection();

            App.Log("Checking constraints...");
            App.LogEmptyLine();

            var controls = AssemblyUtils.AllControlDescendants.Values;
            foreach (var control in controls)
            {
                LogCheckConstraintsForControl(control);
            }

            App.LogEmptyLine();
            App.Log("Check constraints done.");
            App.LogEndSection();
        }
    }
}
