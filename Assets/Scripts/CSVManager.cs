using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class CSVManagerCG
{

    
    private static string reportDirectoryName = "Reports";
    private static string reportFileName = "ReportCG" + TaskManagerCG.increment + ".csv";
    private static string reportSeparator = ";";
    private static string[] reportHeaders = new string[3]
    {
        "Condition",
        "Displacement Level",
        "Answer",
    };
    private static string timeStampHeader = "Time stamp";

    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.ToString();
    }

    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";

            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();

        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }


    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();

        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
}
