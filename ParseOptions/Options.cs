using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Options
{
    class Options
    {
        public string Errors { get; set; } = "";

        public string WorkingDirectory { get; set; } = ".";

        /// <summary>
        /// Archive each folder to a 7z archive
        /// </summary>
        public bool ArchiveTo7z { get; set; } = false;

        /// <summary>
        /// Archive each folder to a Zip archive?
        /// </summary>
        public bool ArchiveToZip { get; set; } = false;

        /// <summary>
        /// Arbitrary DateCode for creating the backup directories.
        /// </summary>
        public string DateCode { get; set; } = $"{DateTime.Now:yyyyMMdd}";

        /// <summary>
        /// Final Versions will be set to this number.  If zero, or left off, then leave latest version alone
        /// </summary>
        public int ReVersionTo { get; set; } = 0;

        public bool Test { get; set; } = false;

        public bool ArchiveSnapshots { get; set; } = false;

        public bool ArchiveDailyWips { get; set; } = false;

        public bool PurgeToJunk { get; set; } = false;

        public bool PurgeToExports { get; set; } = false;

        /// <summary>
        /// Delete folders after archiving
        /// </summary>
        public bool ArchiveDeleteAfter { get; set; } = false;

        /// <summary>
        /// 
        /// WiPScrub /w /s /{7|z} /1 /t {path}
        /// 
        /// /w = ArchiveDailyWips = true,
        /// /w = create a WIP backup of all files in {path}.  Place files in a folder called {path}/Archives/{path}_{dailycode}[a-z]_WIP
        /// 
        /// /s = ArchiveSnapshots = true,
        ///      purge first, then create a backup of all files.  Place in folder called {path}/Archives/{path}_{dailycode}[a-z]_Snapshot
        /// 
        /// /d = ArchiveDeleteAfter = true,
        /// 
        /// /7 = ArchiveTo7z = true,
        ///      archive folder to 7z.  7z name e.g. {path}/Archives{datecode}/{path}_{dailycode}[a-z]_WIP.7z
        /// 
        /// /z = ArchiveToZip = false,
        ///      archive folder to zip.  zip name e.g. {path}/Archives{datecode}/{path}_{dailycode}[a-z]_WIP.zip
        /// 
        /// /j = PurgeToJunk = true,
        /// 
        /// /t = Test = false,
        ///      test, but don't do.  Prints out exactly what woudl be done but does not do it.
        /// /x = PurgeToExports = true,
        /// 
        /// /v{version number} = ReVersionTo = 0,
        ///      rename all prt/drw/asm files to .{version number}
        /// 
        /// /d{yyyymmdd} DateCode = $"{DateTime.Now:yyyyMMdd}",
        /// 
        /// {path} = WorkingDirectory = "."
        /// 
        /// 
        /// WorkingDir\
        ///   Archive\
        ///     20161024\
        ///       WorkingDir_20161024_WIP
        ///       WorkingDir_20161024_Snapshot
        ///       WorkingDir_20161024_Junk
        ///       WorkingDir_20161024_Exports
        ///       WorkingDir_20161024_WIP
        /// 
        /// After archiving and deleting:
        /// WorkingDir\
        ///   Archive\
        ///     20161024\
        ///       WorkingDir_20161024_WIP.zip
        ///       WorkingDir_20161024_Snapshot.zip
        ///       WorkingDir_20161024_Junk.zip
        ///       WorkingDir_20161024_Exports.zip
        ///       WorkingDir_20161024_WIP.zip
        ///   
        /// 
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public void ParseOptions(IEnumerable<string> args)
        {
            Errors = "";
            var workingDirectory = ".";
            var haveWorkingDirectory = false;
            foreach (var s in args)
            {
                if (s[0] == '/')
                {
                    var tf = true;
                    var keyPos = 1;
                    var valPos = 2;
                    if (s[1] == '-')
                    {
                        keyPos = 2;
                        valPos = 3;
                        tf = false;
                    }
                    switch (s[keyPos])
                    {
                        case '7':
                            ArchiveTo7z = tf;
                            break;
                        case 'd':
                            if (s.Length > valPos)
                                DateCode = s.Substring(valPos);
                            break;
                        case 'j':
                            PurgeToJunk = tf;
                            break;
                        case 's':
                            ArchiveSnapshots = tf;
                            break;
                        case 't':
                            Test = true;
                            break;
                        case 'v':
                            ReVersionTo = 1;
                            var i = 0;
                            if (s.Length > valPos && int.TryParse(s.Substring(valPos), out i))
                                ReVersionTo = i;
                            break;
                        case 'w':
                            ArchiveDailyWips = tf;
                            break;
                        case 'x':
                            PurgeToExports = tf;
                            break;
                        case 'z':
                            ArchiveToZip = tf;
                            break;
                        default:

                            break;
                    }
                }
                else
                {
                    var fail = 0;
                    var wd = s.Replace("\"", "");
                    var ermsgs = new[]
                    {
                        $"\tthe folder \"{wd}\" has been set as the working directory.\n",
                        $"\talready have \"{WorkingDirectory}\" as working directory, but the folder \"{wd}\" is valid.\n",
                        $"\tthe folder \"{wd}\" is invalid.\n",
                        $"\talready have \"{WorkingDirectory}\" as working directory, and the folder \"{wd}\" is invalid.\n"
                    };

                    if (haveWorkingDirectory)
                    {
                        fail += 1;  // Failure mode: Already have working dir.  Err Msg 1 or 3.
                    }
                    if (!Directory.Exists(wd))
                    {
                        fail += 2;  // Failure mode: Folder is invalid.  Err Msg 2 or 3.
                    }
                    
                    if ( fail == 0 )
                    {
                        WorkingDirectory = wd;
                        haveWorkingDirectory = true;
                        //  Console.WriteLine(ermsgs[fail]); // Success: Dir is valid and first dir listed.
                    }
                    else // fail > 0 set appropriate error message.
                    {
                        Errors += ermsgs[fail];
                    }
                }
            }

            return;
        }

        public void DebugPrint()
        {
            var defaults = new Options();
            Console.WriteLine($"ArchiveDailyWips = {ArchiveDailyWips} (def: {defaults.ArchiveDailyWips})");
            Console.WriteLine($"ArchiveDeleteAfter = {ArchiveDeleteAfter} (def: {defaults.ArchiveDeleteAfter})");
            Console.WriteLine($"ArchiveSnapshots = {ArchiveSnapshots} (def: {defaults.ArchiveSnapshots})");
            Console.WriteLine($"ArchiveTo7z = {ArchiveTo7z} (def: {defaults.ArchiveTo7z})");
            Console.WriteLine($"ArchiveToZip = {ArchiveToZip} (def: {defaults.ArchiveToZip})");
            Console.WriteLine($"PurgeToExports = {PurgeToExports} (def: {defaults.PurgeToExports})");
            Console.WriteLine($"PurgeToJunk = {PurgeToJunk} (def: {defaults.PurgeToJunk})");
            Console.WriteLine($"Test = {Test} (def: {defaults.Test})");
            Console.WriteLine($"ReVersionTo = {ReVersionTo} (def: {defaults.ReVersionTo})");
            Console.WriteLine($"DateCode = {DateCode} (def: {defaults.DateCode})");
            Console.WriteLine($"WorkingDirectory = {WorkingDirectory} (def: {defaults.WorkingDirectory})");
            if (Errors.Length == 0)
                Console.WriteLine("No Errors!!!");
            else
            {
                Console.WriteLine($"\n\nThere were Errors, probably best to abort out and show instructions\n\n");
                Console.WriteLine($"The following errors occurred:\n\n{Errors}\n\n");
            }
        }
    }
}