using System.Diagnostics;

namespace PartsUnlimited.HRCost.Tests;

public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        
        // var dockerCommand = "docker exec -it sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P Evolve11! -i /database/Initialize.sql";
        //
        // var process = new Process
        // {
        //     StartInfo = new ProcessStartInfo
        //     {
        //         FileName = "cmd.exe", // Use "bash" if you're on Linux or macOS
        //         Arguments = $"/c {dockerCommand}",
        //         RedirectStandardOutput = true,
        //         RedirectStandardError = true,
        //         UseShellExecute = false,
        //         CreateNoWindow = true
        //     }
        // };
        //
        // process.OutputDataReceived += (sender, args) => Console.WriteLine("Output: " + args.Data);
        // process.ErrorDataReceived += (sender, args) => throw new Exception("Error: " + args.Data);
        //
        // process.Start();
        // process.BeginOutputReadLine();
        // process.BeginErrorReadLine();
        //
        // process.WaitForExit();
    }
    public void Dispose()
    {
        
    }
}