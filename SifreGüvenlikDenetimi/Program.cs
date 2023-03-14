
while (true)
{

    Console.WriteLine("Bir sifre giriniz");
    string word = Console.ReadLine();
    int digits = 0;
    int letters = 0;
    int specialCharacters = 0;
    if (word != null && word.Length >= 6)
    {
        foreach (char c in word)
        {
            if (char.IsDigit(c))
            {
                digits++;
            }
            else if (char.IsLetter(c))
            {
                letters++;
            }
            else
            {
                specialCharacters++;
            }
        }

        if (digits == word.Length || letters == word.Length || specialCharacters == word.Length)
        {
            Console.WriteLine("Zayıf Sifre");

        }
        else if (specialCharacters == 0)
        {
            Console.WriteLine("Orta Sifre");
        }
        else
        {
            Console.WriteLine("Güçlü Sifre");
        }
    }
    else
    {
        Console.WriteLine("Sifre en az 6 karakter olmali");
    }
}