using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string all_text = File.ReadAllText("Text1.txt");
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        var noPunctuationText = new string(all_text.Where(c => !char.IsPunctuation(c)).ToArray());
        var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> words_dict = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (words_dict.ContainsKey(word))
            {
                words_dict[word]++;
            }
            else
            {
                words_dict.Add(word, 1);
            }
        }
        var words_dict_sorted = words_dict.OrderByDescending(word => word.Value);
        for (int i = 0; i < 10; i++)
            Console.WriteLine("{0}:\t{1}", words_dict_sorted.ElementAt(i).Key, words_dict_sorted.ElementAt(i).Value);
    }

}
