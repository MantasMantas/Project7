using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace WriteToCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            addRecord("124", "mercy", "56", "cake.txt");
        }

        public static void addRecord(string ID, string name, string age, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Assets/Scripts/Logs", true))
                {
                    file.WriteLine(ID + "," + name + "," + age);
                }
            } catch(Exception ex)
            {
                throw new ApplicationException("This program did an oopsie: " + ex);
            }
        }
    }
}
