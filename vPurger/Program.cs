using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace vPurger
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = ".";
            foreach (var a in args)
            {
                if (!Directory.Exists(a)) continue;
                workingDirectory = a;
                break;
            }
            Directory.SetCurrentDirectory(workingDirectory);

            Console.WriteLine($"The Working Directory is: {workingDirectory}");
            Console.WriteLine($"The Current Directory is: {Directory.GetCurrentDirectory()}");


            var lof = from f in Directory.EnumerateFiles(workingDirectory)
                where f.Length > 1
                select (f + "                                        ").Substring(0, 36);

            foreach (var f in lof.ToArray())
                Console.WriteLine($"{f}----");

            Console.ReadLine();
        }



        //class CreoFile
        //{
        //    public string[] ValidCreoExtensions = new[] { "prt","asm", "drw" };

        //    public string Name { get; set; } = null;
        //    public string Ext { get; set; } = null;
        //    public int[] Ver { get; set; } = null;
        //    public DateTime LastWritten { get; set; }

        //    public bool HasVersions => Ver != null;
        //    public bool IsCreo => ValidCreoExtensions.Contains(Ext);

        //    CreoFile(string filename)
        //    {
        //        var wd

        //    }

        //}

        string ColumnText( string text, int length ) => ( text + new string( ' ', length ) ).Substring( 0, length );
        
        static void Test()
        {
            string ct( string text, int length ) => ( text + new string( ' ', length )).Substring( 0, length );

            
            var ColumnWidths = new int[t[0].Length];
            foreach (var s in t)
            {
                for (int i = 0; i < s[0].Length; i++)
                {
                    ColumnWidths[i] = Math.Max(ColumnWidths[i], t[i].Length +3);
                }

            }

            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < t[i].Length; i++)
                {
                    t[i][j] = ct(t[i][j], ColumnWidths[j]);

                }
            }


        }

        }


    }


}
