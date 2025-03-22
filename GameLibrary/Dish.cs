using GameLibrary;
using InputLibrary;


public class Dish : IInit
{
    private static int COUNT = 0;
    public static int Count()
    {
        return COUNT;
    }
    public Dish(double prot, double fat, double carb)
    {
        Proteins = prot;
        Fats = fat;
        Carbohydrates = carb;
        COUNT++;
    }

    public Dish() : this(0, 0, 0)
    {

    }

    private double proteins;
    public double Proteins
    {
        get
        {
            return proteins;
        }
        set
        {
            if (value < 0) throw new Exception("try set negative proteins");
            proteins = value;
        }
    }
    private double fats;
    public double Fats
    {
        get
        {
            return fats;
        }
        set
        {
            if (value < 0) throw new Exception("try set negative fats");
            fats = value;
        }
    }
    private double carbohydrates;
    public double Carbohydrates
    {
        get
        {
            return carbohydrates;
        }
        set
        {
            if (value < 0) throw new Exception("try set negative carbohydrates");
            carbohydrates = value;
        }
    }
    public double Coloric()
    {
        return 4 * Proteins + 9 * Fats + 4 * Carbohydrates;
    }
    public void Display()
    {
        Console.WriteLine(this);
    }
    public static double Coloric(Dish dish)
    {
        return dish.Coloric();
    }
    public static Dish operator ++(Dish dish)
    {
        return new Dish(dish.Proteins + 1, dish.Fats + 1, dish.Carbohydrates + 1);
    }
    public static double operator ~(Dish dish)
    {
        return dish.Coloric() / 2000 * 100;
    }
    public static explicit operator bool(Dish dish)
    {
        return (dish.Proteins == dish.Fats) && (dish.Proteins * 4 == dish.Carbohydrates * 3);
    }
    public static implicit operator string(Dish dish){
        return $"Белков – {dish.Proteins} г., жиров – {dish.Fats} г., углеводов – {dish.Carbohydrates} г.";
    }
    public override string ToString()
    {
        return $"Dish{{{(string)this}}}";
    }
    public static double operator *(Dish dish, double mass){
        return dish.Coloric()*mass/100;
    }
    public static double operator *(double mass, Dish dish){
        return dish*mass;
    }
    public static bool operator <(Dish a, Dish b){
        return a.Coloric()<b.Coloric();
    }
    public static bool operator >(Dish a, Dish b){
        return a.Coloric()>b.Coloric();
    }
    public override bool Equals(object? obj){
        if (obj is Dish dish){
            return dish.Carbohydrates==Carbohydrates && dish.Fats==Fats && dish.Proteins==Proteins;
        }
        else return false;
    }

    public void Init()
    {
        Console.WriteLine("Input parameters of dish:");
        Console.WriteLine("Input carbohydrites::");
        Carbohydrates = ConsoleInput.NAT0.get();
        
    }

    public void RandomInit()
    {
        throw new NotImplementedException();
    }


    ~Dish()
    {
        Console.WriteLine("delete");
        COUNT--;
    }
}