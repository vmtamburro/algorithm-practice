public class Euler17
{
    public Dictionary<int, string> numbersAsLetters = new Dictionary<int, string>();

    public Euler17()
    {
        PopulateNumbersAsLetters();
    }

    public void PopulateNumbersAsLetters()
    {
        numbersAsLetters[0] = ""; // Placeholder for 0, won't be used
        numbersAsLetters[1] = "one";
        numbersAsLetters[2] = "two";
        numbersAsLetters[3] = "three";
        numbersAsLetters[4] = "four";
        numbersAsLetters[5] = "five";
        numbersAsLetters[6] = "six";
        numbersAsLetters[7] = "seven";
        numbersAsLetters[8] = "eight";
        numbersAsLetters[9] = "nine";
        numbersAsLetters[10] = "ten";
        numbersAsLetters[11] = "eleven";
        numbersAsLetters[12] = "twelve";
        numbersAsLetters[13] = "thirteen";
        numbersAsLetters[14] = "fourteen";
        numbersAsLetters[15] = "fifteen";
        numbersAsLetters[16] = "sixteen";
        numbersAsLetters[17] = "seventeen";
        numbersAsLetters[18] = "eighteen";
        numbersAsLetters[19] = "nineteen";
        numbersAsLetters[20] = "twenty";
        numbersAsLetters[30] = "thirty";
        numbersAsLetters[40] = "forty";
        numbersAsLetters[50] = "fifty";
        numbersAsLetters[60] = "sixty";
        numbersAsLetters[70] = "seventy";
        numbersAsLetters[80] = "eighty";
        numbersAsLetters[90] = "ninety";
    }

    // Method to calculate the total number of letters used
    public int CountLettersUsed()
    {
        int sum = 0;
        for (int i = 1; i <= 1000; i++)
        {
            string word = GetNumberWord(i);
            sum += word.Length;
        }
        return sum;
    }

    // Method to convert a number to its word representation
    public string GetNumberWord(int number)
    {
        if (number <= 20)
        {
            return numbersAsLetters[number];
        }
        else if (number < 100)
        {
            int tens = (number / 10) * 10;
            int units = number % 10;
            return numbersAsLetters[tens] + numbersAsLetters[units];
        }
        else if (number < 1000)
        {
            int hundreds = number / 100;
            int tens = number % 100;
            if (tens == 0)
            {
                return numbersAsLetters[hundreds] + "hundred";
            }
            else
            {
                return numbersAsLetters[hundreds] + "hundredand" + GetNumberWord(tens);
            }
        }
        else if (number == 1000)
        {
            return "onethousand";
        }

        throw new IndexOutOfRangeException("Number out of Range");
    }
}
