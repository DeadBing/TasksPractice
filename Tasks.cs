using System.Net.Http.Headers;

class Program {
    static void Main(String[] args) {
        Console.WriteLine("Задание:");
        Console.WriteLine("1. FizzBuzz \n2. Римские цифры");
        int x = Convert.ToInt32(Console.ReadLine());
        if (x == 1) {
            FizzBuzz();
        }
        if (x == 2) {
            Console.Write("Введите римское число: ");
            ConvertRomanToNumber(Console.ReadLine());
        }
    }

    static void FizzBuzz() {
        for (int i = 1; i < 101; i++) {
            if (i % 3 == 0 && i % 5 == 0) {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            if (i % 3 == 0) {
                Console.WriteLine("Fizz");
            }
            if (i % 5 == 0) {
                Console.WriteLine("Buzz");
            }
        }
    }

    static void ConvertRomanToNumber(string text) {
        var romanNums = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
        int totalValue = 0, previousValue = 0;
        foreach (var currentNumber in text) {
            if (!romanNums.ContainsKey(currentNumber)) {
                totalValue = 0;
                break;
            }
            var currentValue = romanNums[currentNumber];
            if (previousValue != 0 && previousValue < currentValue) {
                if (previousValue == 1 && (currentValue == 5 || currentValue == 10)
                    || previousValue == 10 && (currentValue == 50 || currentValue == 100)
                    || previousValue == 100 && (currentValue == 500 || currentValue == 1000))
                    totalValue -= 2 * previousValue;
                else {
                    totalValue = 0;
                    break;
                }
            }
            totalValue += currentValue;
            previousValue = currentValue;
        }
        if(totalValue != 0) Console.WriteLine("Римская цифра {0} = {1} ", text, totalValue);
        else Console.WriteLine("Вы ввели недопустимое число");
    }
}