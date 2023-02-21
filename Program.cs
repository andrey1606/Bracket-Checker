using System;
using System.Collections.Generic;
using System.IO;

class BracketChecker
{
    static void Main(string[] args)
    {
        var result = GetCodeFromFile();
        if (result.Item1)
        {
            var errors = FindErrors(result.Item2);
            if (errors.Count == 0)
                Console.WriteLine("Brackets are placed correctly.");
            else
            {
                Console.WriteLine("Brackets are NOT placed correctly.");
                foreach (var error in errors)
                    Console.WriteLine($"Error: '{error.Item1}' at position {error.Item2}.");
            }
        }
        else
            Console.WriteLine(result.Item2);
    }

    /// <summary>Find brackets-related errors</summary>
    /// <param name="code">A string containing the code to check</param>
    /// <returns>A list of tuples containing the character that is an error and its index in the string</returns>
    public static List<(char, int)> FindErrors(string code)
    {
        var stack = new Stack<(char, int)>();
        var errors = new List<(char, int)>();
        var bracketMap = new Dictionary<char, char>()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' },
            { '>', '<' }
        };

        for (int i = 0; i < code.Length; i++)
        {
            switch (code[i])
            {
                case '(':
                case '{':
                case '[':
                case '<':
                    stack.Push((code[i], i));
                    break;
                case ')':
                case '}':
                case ']':
                case '>':
                    if (stack.Count == 0 || stack.Peek().Item1 != bracketMap[code[i]])
                        errors.Add((code[i], i));
                    else
                        stack.Pop();
                    break;
            }
        }

        while (stack.Count > 0)
        {
            var bracket = stack.Pop();
            errors.Add(bracket);
        }
        return errors;
    }

    static (bool, string) GetCodeFromFile()
    {
        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();
        try
        {
            return (true, File.ReadAllText(filePath));
        }
        catch (FileNotFoundException)
        {
            return (false, "File not found.");
        }
        catch (Exception)
        {
            return (false, "An error occurred while reading the file.");
        }
    }
}
