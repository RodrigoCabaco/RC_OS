using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.ComponentModel;

namespace TerminalBasedOs_Try
{
    class Compiler
    {
        public static void Compile(string code)
        {

            //variable types
            List<string> intgrsValue = new List<string>();
            List<string> intgrsName = new List<string>();
            string compilingLine;


            //code reader
            StringReader reader;
            reader = new StringReader(code);
            while ((compilingLine = reader.ReadLine()) != "endCode" && (compilingLine = reader.ReadLine()) != null)
            {

                
                intgrsName.Add(compilingLine.Split("intgr").Last().Split(' ').Last().Split(">>").First());
                try
                {
                    Console.WriteLine(compilingLine.Split(">>").Last());
                    intgrsValue.Add(compilingLine.Split(">>").Last());

                }
                catch
                {
                    Console.WriteLine("Invalid Syntax (intgr name>>5)");
                }


                compilingLine = reader.ReadLine();


                
                       string getWrite = compilingLine.Split("Write").Last().Split("&>").Last().Split("<&").First();
                       Console.WriteLine(getWrite);
                   

                Console.WriteLine(compilingLine);

            }

            foreach (var item in intgrsValue)
            {
                Console.WriteLine(item);
            }

        }
    }
}
