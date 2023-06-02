
using DataAccess;
using Entity.Entity;
using Logic.Repository;
using System.Linq;
using Logic.Concrete_Service;
using Logic.Abstract_Service;
using MVC.Models;

public class Program
{
	private static void Main(string[] args)
    {
        SwalMessages test = new("Example");
       
        using StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        //All console outputs goes here
        Console.WriteLine("You are travelling north at a speed of 10m/s");
        Console.WriteLine(test.CreatedMsg);

        string consoleOutput = stringWriter.ToString();

        File.WriteAllText(consoleOutput, test.CreatedMsg);
    }
}