// using System;
// using System.Collections.Generic;
// using System.Globalization;
// using System.IO;

// class Journal
// {
//     private List<Entry> _entries = new List<Entry>();

//     public void AddEntry(string prompt, string response)
//     {
//         _entries.Add(new Entry(DateTime.Now,prompt, response,additionalInfo));
//     }

//     public void Display()
//     {
//         foreach (var entry in _entries)
//         {
//             entry.Display();
//         }
//     }

//     public void SaveToFile(string filename)
//     {
//         using (StreamWriter writer = new StreamWriter(filename))
//         using (var csv =new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//         {
//             ConcurrentExclusiveSchedulerPair.WriteRecords(_entries);
//             // foreach (var entry in _entries)
//             // {
//             //     writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
//             // }
//         }
//         Console.WriteLine("Journal saved.");
//     }

//         public void LoadFromFile(string filename)
//     {
//         using (var reader = new StreamReader(filename))
//         using (var csv = new CsvReader(reader,new CsvConfiguration(CultureInfo.InvariantCulture)))
//         {
//             _entries = csv.GetRecords<Entry>().ToList();
//         }
//         Console.WriteLine("Journal loaded from CSV");
//         // _entries.Clear(); 
//         try
//         {
//             string[] lines = File.ReadAllLines(filename);
//             foreach (string line in lines)
//             {
//                 string[] parts = line.Split("|");
//                 if (parts.Length == 3)
//                 {
//                     if (DateTime.TryParseExact(parts[0], "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
//                     {
//                         _entries.Add(new Entry(parts[1], parts[2], date));
//                     }
//                     else
//                     {
//                         Console.WriteLine($"Invalid date format: {parts[0]}");
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine($"Invalid line format: {line}");
//                 }
//             }
//             Console.WriteLine("Journal loaded.");
//         }
//         catch (FileNotFoundException)
//         {
//             Console.WriteLine("File not found. Please try again.");
//         }
//         catch (IOException ex)
//         {
//             Console.WriteLine($"Error reading file: {ex.Message}");
//         }
//     }
// }


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string additionalInfo)
    {
        _entries.Add(new Entry(DateTime.Now, prompt, response, additionalInfo));
    }

    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(_entries);
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                _entries = csv.GetRecords<Entry>().ToList();
            }
            Console.WriteLine("Journal loaded from CSV.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please try again.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}