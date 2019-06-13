using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SFC.Infrastructure;

namespace SFC
{
  public class Program
  {
    public static void Main(string[] args)
    {
      try
      {
        Bootstrap.Run(args);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
      }

      Console.ReadKey();
    }
  }
}
