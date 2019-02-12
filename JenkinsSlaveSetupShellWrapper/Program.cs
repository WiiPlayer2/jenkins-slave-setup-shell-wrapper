using System.Diagnostics;
using CommandLine;

namespace JenkinsSlaveSetupShellWrapper
{
    internal class Program
    {
        public class Options
        {
            [Option('x', Required = false, HelpText = "Write each command to standard error (preceded by a ‘+ ’) before it is executed.  Useful for debugging.")]
            public bool XTrace { get; set; }

            [Option('e', Required = false, HelpText = "If not interactive, exit immediately if any untested command fails. The exit status of a command is considered to be explicitly tested if the command is used to control an if, elif, while, or until; or if the command is the left hand operand of an “&&” or “||” operator.")]
            public bool ErrExit { get; set; }

            [Value(0, Required = true)]
            public string Command { get; set; }
        }

        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o => { Process.Start("powershell", $"-File {o.Command}"); });
        }
    }
}