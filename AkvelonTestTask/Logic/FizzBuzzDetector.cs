using System.Text;

public class FizzBuzzOutput
{
    public string Output { get; set; }
    public int OverlapCount { get; set; }
}

public class FizzBuzzDetector()
{
    public FizzBuzzOutput getOverlappings(string input)
    {
        var output = new StringBuilder();
        var overlapCount = 0;
        var wordPosition = 1;

        if (input == null)
        {
            throw new ArgumentNullException("Input string cannot be null");
        }

        if (input.Length < 7 || input.Length > 100)
        {
            throw new ArgumentException("Length of the input string: 7 ≤ |s| ≤ 100");
        }

        var lines = input.Split("\n");

        for (int j = 0; j < lines.Length; j++)
        {
            var words = lines[j].Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                var cleanedWord = new string(words[i].Where(char.IsLetterOrDigit).ToArray());

                if (string.IsNullOrEmpty(cleanedWord))
                {
                    output.Append(words[i]);
                    if (i < words.Length - 1)
                    {
                        output.Append(" ");
                    }
                    continue;
                }

                var currentWord = cleanedWord;

                if (wordPosition % 3 == 0 && wordPosition % 5 == 0)
                {
                    currentWord = "FizzBuzz";
                }
                else if (wordPosition % 3 == 0)
                {
                    currentWord = "Fizz";
                }
                else if (wordPosition % 5 == 0)
                {
                    currentWord = "Buzz";
                }
                else
                {
                    currentWord = words[i];
                }

                if (currentWord == "Fizz" ||
                    currentWord == "Buzz" ||
                    currentWord == "FizzBuzz")
                {
                    overlapCount++;
                }


                output.Append(currentWord);
                if (i < words.Length - 1)
                {
                    output.Append(" ");
                }

                wordPosition++;

            }
            if (j < lines.Length - 1)
            {
                output.Append("\n");
            }
        }

        return new FizzBuzzOutput
        {
            Output = output.ToString(),
            OverlapCount = overlapCount
        };
    }
}