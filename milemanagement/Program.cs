using System;
using System.IO;
using System.Net.Mime;



namespace FileManagementSystem
{
  class Program
  {
    static void Main(string[] args)
    {
        string directoryPath = @"c:\Users\orlan\OneDrive\Desktop\testingFolderForInputOutput";
        Console.WriteLine("File Directory Path\n");

        DisplayFilesInDirectory(directoryPath);


        Console.WriteLine("\nOptions: ");
        Console.WriteLine("1. Create file: ");
        Console.WriteLine("2. Delete file: ");
        Console.WriteLine("Enter option number (1, 2): ");

        char option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch(option) 
        {
          case '1':
          Console.WriteLine("Enter a file name to create file: ");
          string fileName = Console.ReadLine();
          Console.WriteLine("Enter text in for created file: ");
          string text = Console.ReadLine();
          CreateFile(directoryPath, fileName, text);
          break;
          case '2':
          Console.WriteLine("Enter a file name to create file: ");
          string fileNameToDelete = Console.ReadLine();
          DeleteFile(directoryPath, fileNameToDelete);
          break;
          default:
          Console.WriteLine("Invalid option");
          break;
        }

        Console.WriteLine("\nUpdated File List: ");
        DisplayFilesInDirectory(directoryPath);

    }


    static void DisplayFilesInDirectory(string path) {
      try 
      {
        string[] files = Directory.GetFiles(path);
        Console.WriteLine("Files in directory: ");
        foreach(string file in files) 
        {
          Console.WriteLine(Path.GetFileName(file));

        }

      }
      catch (Exception e) 
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }


    static void CreateFile(string path, string fileName, string content) {
      try
      {
        string filePath = Path.Combine(path, fileName);
        if(!File.Exists(filePath))
        {
          File.Create(filePath).Close();
          using(StreamWriter writer = File.CreateText(filePath)) 
          {
            writer.WriteLine(content);
          }
          Console.WriteLine($"{fileName} created successfully ");
        }
        else
        {
          Console.WriteLine($"{fileName} already exist");
        }

      }
      catch (Exception e) 
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }


    static void DeleteFile(string path, string fileName) {
      try 
      {
         string filePath = Path.Combine(path, fileName);
        if(File.Exists(filePath))
        {
          File.Delete(filePath);
          Console.WriteLine($"{fileName} was deleted ");
        }
        else
        {
          Console.WriteLine($"{fileName} no longer exist");
        }

      }
      catch (Exception e) 
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }







  }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");