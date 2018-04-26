using System;
using Microsoft.Win32;


public class GetDotNetVersion
{
    public static void Main()
    {
        GetDotNetVersion.Get45PlusFromRegistry();
    }

    private static void Get45PlusFromRegistry()
    {
        const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

        using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
        {
            if (ndpKey != null && ndpKey.GetValue("Release") != null)
            {
                Console.WriteLine(".NET Framework Version: " + CheckFor45PlusVersion((int)ndpKey.GetValue("Release")));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter to leave application...");
                Console.ReadLine();
            }
            else //new dotNet14();
            {

                Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");
                Console.WriteLine();
                Console.WriteLine("You should have at least version 4.5 to use TLS 1.2!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to leave application...");
                Console.ReadLine();
            }
        }
    }


    // Checking the version using >= will enable forward compatibility.
    private static string CheckFor45PlusVersion(int releaseKey)
    {
        if (releaseKey >= 461308)
            return "4.7.1 or later";
        if (releaseKey >= 460798)
            return "4.7";
        if (releaseKey >= 394802)
            return "4.6.2";
        if (releaseKey >= 394254)
        {
            return "4.6.1";
        }
        if (releaseKey >= 393295)
        {
            return "4.6";
        }
        if ((releaseKey >= 379893))
        {
            return "4.5.2";
        }
        if ((releaseKey >= 378675))
        {
            return "4.5.1";
        }
        if ((releaseKey >= 378389))
        {
            return "4.5";
        }
        // This code should never execute. A non-null release key should mean
        // that 4.5 or later is installed.
        return "No 4.5 or later version detected.";
    }

    //public class dotNet14
    //{
    //    private static void GetVersionFromRegistry()
    //    {
    //        // Opens the registry key for the .NET Framework entry.
    //        using (RegistryKey ndpKey =
    //            RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
    //            OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
    //        {
    //            foreach (string versionKeyName in ndpKey.GetSubKeyNames())
    //            {
    //                if (versionKeyName.StartsWith("v"))
    //                {

    //                    RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
    //                    string name = (string)versionKey.GetValue("Version", "");
    //                    string sp = versionKey.GetValue("SP", "").ToString();
    //                    string install = versionKey.GetValue("Install", "").ToString();

    //                    if (install == "") //no install info, must be later.
    //                    {
    //                        Console.WriteLine(versionKeyName + "  " + name);
    //                        Console.ReadLine();
    //                    }


    //                    else
    //                    {
    //                        if (sp != "" && install == "1")
    //                        {
    //                            Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
    //                            Console.ReadLine();
    //                        }

    //                    }
    //                    if (name != "")
    //                    {
    //                        continue;
    //                    }
    //                    foreach (string subKeyName in versionKey.GetSubKeyNames())
    //                    {
    //                        RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
    //                        name = (string)subKey.GetValue("Version", "");
    //                        if (name != "")
    //                            sp = subKey.GetValue("SP", "").ToString();
    //                        install = subKey.GetValue("Install", "").ToString();
    //                        //ToDo: Check
    //                        Console.WriteLine("hier ist was falsch!!!");
    //                        Console.ReadLine();

    //                        if (install == "") //no install info, must be later.
    //                        {
    //                            Console.WriteLine(versionKeyName + "  " + name);
    //                            Console.ReadLine();
    //                        }
    //                        else
    //                        {
    //                            if (sp != "" && install == "1")
    //                            {
    //                                Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
    //                                Console.ReadLine();
    //                            }
    //                            else if (install == "1")
    //                            {
    //                                Console.WriteLine("  " + subKeyName + "  " + name);
    //                                Console.ReadLine();
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
// This example displays output like the following:
//       .NET Framework Version: 4.6.1