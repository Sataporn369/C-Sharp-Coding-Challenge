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
        //foreach (var item in a)
        //{
        //    Console.WriteLine($"{item.Character} : {item.Count}");
        //    if (item.Character == '1')
        //    {
        //        int count = item.Count % 4;
        //        if (count == 0)
        //        {
        //            result += "1";
        //        }
        //        else if (count == 1)
        //        {
        //            result += "&";
        //        }
        //        else if (count == 2)
        //        {
        //            result += "'";
        //        }
        //        else if (count == 3)
        //        {
        //            result += "(";
        //        }
        //    }
        //    else if (item.Character == '2')
        //    {
        //        int count = item.Count % 4;
        //        if (count == 0)
        //        {
        //            result += "2";
        //        }
        //        else if (count == 1)
        //        {
        //            result += "A";
        //        }
        //        else if (count == 2)
        //        {
        //            result += "B";
        //        }
        //        else if (count == 3)
        //        {
        //            result += "C";
        //        }
        //    }
        //    else if (item.Character == '3')
        //    {
        //        int count = item.Count % 4;
        //        if (count == 0)
        //        {
        //            result += "3";
        //        }
        //        else if (count == 1)
        //        {
        //            result += "D";
        //        }
        //        else if (count == 2)
        //        {
        //            result += "E";
        //        }
        //        else if (count == 3)
        //        {
        //            result += "F";
        //        }
        //    }

        //}
        //foreach (var item in a)
        //{
        //    Console.WriteLine($"{item.Character} : {item.Count}");
        //    if (item.Character == '*')
        //    {
        //        result = result.Substring(0, result.Length - 1);
        //        break;
        //    }
        //    else if(item.Character == ' ')
        //    {
        //        result += " ";
        //        break;
        //    }
        //        char key = item.Character;        // เช่น '1', '2', '3'
        //    int count = item.Count;

        //    // หา index ของปุ่ม
        //    int startIndex = CharPads.IndexOf(key);

        //    if (startIndex == -1) continue;

        //    // หา index ของปุ่มถัดไป
        //    int endIndex = startIndex + 1;
        //    while (endIndex < CharPads.Length && !char.IsDigit(CharPads[endIndex]))
        //    {
        //        endIndex++;
        //    }

        //    // ดึงชุดตัวอักษรของปุ่มนั้น
        //    string group = CharPads.Substring(startIndex, endIndex - startIndex);

        //    // คำนวณตำแหน่ง (multi-tap)
        //    int pos = count % group.Length;
        //    if (pos == 0) pos = group.Length;

        //    result += group[pos - 1];
        //}

        Console.WriteLine(r);

    }
}
