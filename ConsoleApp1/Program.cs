using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static readonly Dictionary<char, string> KeyMap = new()
    {
        { '1', "1&'(" },
        { '2', "2ABC" },
        { '3', "3DEF" },
        { '4', "4GHI" },
        { '5', "5JKL" },
        { '6', "6MNO" },
        { '7', "7PQRS" },
        { '8', "8TUV" },
        { '9', "9WXYZ" }
    };
    public static String OldPhonePad(string input)
    {
        var result = "";
        var ConvertIndex = CountConsecutiveCharacters(input);
        foreach (var item in ConvertIndex)
        {
            if (item.Character == '*')
            {
                result = result.Substring(0, result.Length - 1);
            }
            else if (item.Character == '#')
            {
                result += "\n";
            }
            if (!KeyMap.TryGetValue(item.Character, out var group))
                continue;

            int index = item.Count % group.Length;
            result += group[index];
        }
        return result;
    }
    public static List<(char Character, int Count)> CountConsecutiveCharacters(string text)
    {
        var result = new List<(char, int)>();

        if (string.IsNullOrEmpty(text))
            return result;

        int i = 0;

        while (i < text.Length)
        {
            char current = text[i];
            int count = 1;

            int j = i + 1;
            while (j < text.Length && text[j] == current)
            {
                count++;
                j++;
            }

            if (current != ' ')
            {
                result.Add((current, count));
            }

            i = j;
        }

        return result;
    }



    static void Main(string[] args)
    {
        string v = "11111";
        Console.WriteLine(v);
        Console.WriteLine("=======");
        var r = OldPhonePad(v);
      

    }
}
