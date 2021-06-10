﻿using System;
using System.IO;

namespace VersionTool
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                CheckArguments(args, out var buildNumber);
                BuildNumberSetter.SetBuildNumber(LocateVersionFile(), buildNumber);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return 1;
            }

            return 0;
        }

        private static void CheckArguments(string[] args, out int buildNumber)
        {
            if (args.Length != 2 || !args[0].Equals("set-build-number", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Usage: VersionTool.exe set-build-number <build-number>");
            buildNumber = int.Parse(args[1]);
        }

        private static string LocateVersionFile()
        {
            var repoRoot = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new Exception(),
                "../../../../../../");

            var versionFilePath = Path.GetFullPath(Path.Combine(repoRoot, @"Source\Mastering\Version\Version.props"));
            if (!File.Exists(versionFilePath))
                throw new InvalidOperationException("Cannot locate Version.props file at" + versionFilePath);
            return versionFilePath;
        }
    }
}