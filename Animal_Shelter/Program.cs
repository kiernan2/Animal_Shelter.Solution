using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Animal_Shelter
{
  public class Program
  {
    public static void Main(string[] args)
    {
      IWebHost host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory)
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();
    
      host.Run();
    }
  }
}