using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveConfigEnforcer
{
    class DCEMain
    {
        static void DriveTemplateCheck(string dirname)
        {
            // 'Documents and Settings', "Program Files", "RECYCLER", "System Volume Information", "Temp", "Utilities", "WINDOWS", "wmpub"
            string DirTemplateNameList = "Documents and Settings,Program Files,RECYCLER,System Volume Information,Temp,Utilities,WINDOWS,wmpub";
            string[] DirTemplateName = DirTemplateNameList.Split(',');
            bool bDirNameFound = false;
            foreach (string strDirTemplName in DirTemplateName)
            {
                if (strDirTemplName == dirname)
                {
                    bDirNameFound = true;
                }
            }
            if (!bDirNameFound)
            {
                Console.WriteLine("***Unauthorized directory found!*** - " + dirname);
            }
            else
            {
                Console.WriteLine(dirname);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("[Start] This program lists all the subdirectories in the directory:");

            System.IO.DirectoryInfo dirs = new System.IO.DirectoryInfo(@"C:\");

            foreach (System.IO.DirectoryInfo directory in dirs.GetDirectories())
            {
                DriveTemplateCheck(directory.Name);
            }

            Console.WriteLine("[End] Directory listing complete.");
        }
    }
}
