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
            
            RunTeleprompter().Wait();

        }

        static IEnumerable<string> ReadFrom(string FileName){
            string line;
            using(var reader = File.OpenText(FileName)){//reader is a StreamReader object , decide at compile time
                while( (line = reader.ReadLine()) != null){
                    
                    var words = line.Split(' ');
                    var lineLength = 0;

                    foreach (var word in words)
                    {
                        yield return word + " ";
                        lineLength += word.Length + 1;
                        if (lineLength > 70)
                        {
                            yield return Environment.NewLine;
                            lineLength = 0;
                        }
                    }
                    yield return Environment.NewLine;
                    
                    /*
                    yield return line;//What the hell is this ?
                    //lazy return reads when required/called by the code to do so.
                     */
                }
            }
        }

        /*added async modifier to the method signature */
        private static async Task ShowTeleprompter(TelePrompterConfig config)
        {
            var words = ReadFrom("sampleQuotes.txt");
            foreach (var line in words)
            {
                Console.Write(line);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    await Task.Delay(config.DelayInMilliseconds);
                }
            }
            config.SetDone();
            // Synchronously waiting on a task is an
            // anti-pattern. This will get fixed in later
            // steps.
            // var words = ReadFrom("sampleQuotes.txt");
            // foreach (var line in words)
            // {
            //     Console.Write(line);
            //     if (!string.IsNullOrWhiteSpace(line))
            //     {
            //         await Task.Delay(200);
            //     }
            // }
        }
        /* FOR THE ABOVE METHOD~Commented
        You’ll notice two changes. First, in the body of the method, instead of calling Wait() to synchronously wait for a task to finish,
        this version uses the await keyword. In order to do that, you need to add the async modifier to the method signature.
        This method returns a Task. Notice that there are no return statements that return a Task object.
        Instead, that Task object is created by code the compiler generates when you use the await operator.
        You can imagine that this method returns when it reaches an await. The returned Task indicates that the work has not completed.
        The method resumes when the awaited task completes. When it has executed to completion, the returned Task indicates that it is complete.
        Calling code can monitor that returned Task to determine when it has completed. 
        */

        private static async Task GetInput(TelePrompterConfig config)
        {
            // var delay = 200;
            Action work = () =>
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '>')
                    {
                        config.UpdateDelay(-10);
                        // delay -= 10;
                    }
                    else if (key.KeyChar == '<')
                    {
                        config.UpdateDelay(10);
                        // delay += 10;
                    }
                } while (!config.Done);
            };
            await Task.Run(work);
        }

        private static async Task RunTeleprompter()
        {
            var config = new TelePrompterConfig();
            var displayTask = ShowTeleprompter(config);

            var speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);
            /*Finishes as soon as any of the tasks in the argument list is completed */
        }


    }

}