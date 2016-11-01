using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Options
{
    class Program
    {
        public static Options TestOptions = new Options();

        static void Main(string[] args)
        {
            Console.WriteLine(
                "This is just a quick test program to ensure that the options are parsing correctly in my ParseOptions Class");

            Console.WriteLine($"There are {args.Length} command line options");
            if (args.Length != 0) TestOptions.ParseOptions(args);

            TestOptions.DebugPrint();

            var files = Directory.EnumerateFiles(TestOptions.WorkingDirectory);

            foreach (var f in files) Console.WriteLine($">> {f} <<");

            var n = new Options();
            n.ParseOptions( "/-w /z /7 /t /d /s".Split( ' ' ) );
            n.DebugPrint();
            n.ParseOptions( "/-w /-z /-7 /-t /-d /-s".Split( ' ' ) );
            n.DebugPrint( );
            n.ParseOptions( @"/-w /z /7 /t /d /s ""c:\""".Split( ' ' ) );
            n.DebugPrint( );
            n.ParseOptions( @"/-w /z /7 /t /d /s ""c:\"" thist+thing+on? "".\..\..\.""".Split( ' ' ) );
            n.DebugPrint( );
            n.ParseOptions( @"/-w /z /7 /t /d /s thist+thing+on? "".\..\..\.""".Split( ' ' ) );
            n.DebugPrint( );
            n.ParseOptions( @"/-w /z /7 /t /d /s thist+thing+on? tesinganotherinvaliddir".Split( ' ' ) );
            n.DebugPrint( );

            foreach (var f in TestOptions.GetType().GetProperties())
            {
                Console.WriteLine($">> {f.Name} is type: {f.PropertyType.Name}");

            }

            Console.ReadLine();

        }


    }

}