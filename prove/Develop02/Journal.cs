using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

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
        {
            writer.WriteLine("Date,Prompt,Response,AdditionalInfo");
            foreach (var entry in _entries)
            {
                string[] values = new string[]
                {
                    entry.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    EscapeCsv(entry.Prompt),
                    EscapeCsv(entry.Response),
                    EscapeCsv(entry.AdditionalInfo)
                };
                writer.WriteLine(string.Join(",", values));
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            using (var reader = new StreamReader(filename))
            {
                reader.ReadLine(); // Skip header line
                _entries.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] values = ParseCsvLine(line);
                    if (values.Length == 4)
                    {
                        DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        string prompt = values[1];
                        string response = values[2];
                        string additionalInfo = values[3];
                        _entries.Add(new Entry(date, prompt, response,additionalInfo));
                    }
                }
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

    private static string EscapeCsv(string value)
    {
        if (string.IsNullOrEmpty(value))
            return "\"\"";

        bool needsQuotes = value.Contains(",") || value.Contains("\"") || value.Contains("\n");
        if (needsQuotes)
        {
            value = value.Replace("\"", "\"\"");
            value = $"\"{value}\"";
        }
        return value;
    }

    // Parse a line of CSV correctly considering quotes
    private static string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder field = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '\"')
                {
                    // Handle double quotes
                    if (i + 1 < line.Length && line[i + 1] == '\"')
                    {
                        field.Append('\"');
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    field.Append(c);
                }
            }
            else
            {
                if (c == '\"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(field.ToString());
                    field.Clear();
                }
                else
                {
                    field.Append(c);
                }
            }
        }

        fields.Add(field.ToString());
        return fields.ToArray();
    }
}