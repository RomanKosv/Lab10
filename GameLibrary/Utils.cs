namespace GameLibrary;



    public class Input
    {
        public static string InputString()
        {
            string str = Console.ReadLine();
            if (str == null || str =="")
            {
                Console.WriteLine("Input cant be empty");
                return InputString();
            }
            else return str;
        }
        public static int InputInt()
        {
            int rez;
            while(! int.TryParse(Console.ReadLine(), out rez))
            {
                Console.WriteLine("Input must be integer number");
            }
            return rez;
        }
        public static int InputNoLess(int num)
        {
            int rez = InputInt();
            if (rez < num)
            {
                Console.WriteLine($"Input cant be less {num}");
                return InputNoLess(num);
            }
            else return rez;
        }
        public static string[] InputList(int minCount=0)
        {
            string[] rez =  Console.ReadLine().Split(",");
            if (rez.Length < minCount)
            {
                Console.WriteLine($"Count of items cant be less {minCount}");
                return InputList(minCount);
            }
            else return rez;
        }
    }
    public static class Rand
    {
        public static Random rand = new Random();
        public static string RandomString(int lenght = 5)
        {
            char[] chars = new char[lenght];
            for(int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char) rand.Next('a', 'z');
            }
            return new string(chars);
        }
    }