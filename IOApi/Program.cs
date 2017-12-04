using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TeleprompterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of TeleprompterConsole App");

            var lines = ReadFrom("sampleQuotes.txt");
            foreach(var line in lines){

                //Console.WriteLine(line);

                Console.Write(line);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var pause = Task.Delay(100);
                    // Synchronously waiting on a task is an
                    // anti-pattern. This will get fixed in later
                    // steps.
                    pause.Wait();
                }

            }
        }

        static IEnumerable<string> ReadFrom(string FileName){
            string line;
            using(var reader = File.OpenText(FileName)){//reader is a StreamReader object , decide at compile time
                while( (line = reader.ReadLine()) != null){
                    
                    var words = line.Split(' ');
                    foreach (var word in words)
                    {
                        yield return word + " ";
                    }
                    yield return Environment.NewLine;
                    
                    /*
                    yield return line;//What the hell is this ?
                    //lazy return reads when required/called by the code to do so.
                     */
                }
            }
        }
    }
}
