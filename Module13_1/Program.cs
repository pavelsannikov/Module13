using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        string all_text = File.ReadAllText("Text1.txt");
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        var words = all_text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        List<string> words_list = new List<string>(words);
        LinkedList<string> words_linkedlist = new LinkedList<string>(words);

        Random rnd = new Random();
        int num_measure = 10000;

        var watch = Stopwatch.StartNew();
        for (int i = 0; i < num_measure; i++)
        {
            words_list.Insert(rnd.Next(0, words_list.Count), "MyText");
        }
        Console.WriteLine("Время выполения {1} случайных вставок в List: {0}", watch.Elapsed, num_measure);

        watch = Stopwatch.StartNew();
        for (int i = 0; i < num_measure; i++)
        {
            int index = rnd.Next(0, words_linkedlist.Count);
            LinkedListNode<string> node = words_linkedlist.First;
            for (int j = 0; j < index; j++) node = node.Next;
            words_linkedlist.AddAfter(node, "MyText");
        }
        Console.WriteLine("Время выполения {1} случайных вставок в LinkedList: {0}", watch.Elapsed, num_measure);
    }

}
