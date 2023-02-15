using System;
using System.Reflection;

namespace ImplementInterfaceExplicitly
{
    internal class Program
    {
        static void Main()
        {
            HeavyTank tank = new HeavyTank();
            //===========华丽的分割线=================
            Type t = tank.GetType();
            object? o = Activator.CreateInstance(t);
            MethodInfo? f1 = t.GetMethod("Fire");
            MethodInfo? f2 = t.GetMethod("Run");
            MethodInfo? f3 = t.GetMethod("GetRealRange");
            f1?.Invoke(o,null);
            f2?.Invoke(o,null);
            object?[]? p = { "Well" };
            object? realRange=f3?.Invoke(o,p);
            Console.WriteLine(realRange);

        } 
    }
   class HeavyTank 
    {
        static private double _range=800;
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }
        public void Run() 
        {
            Console.WriteLine("The tank is running!");
        }
        public double? GetRealRange(string weatherCondition) 
        {
            if (string.IsNullOrEmpty(weatherCondition))
            {
                throw new Exception("Error!");
            }
            switch (weatherCondition)
            {
                case "Good":
                    return _range;
                    //没有break;都return了还break啥
                case "Well":
                    return _range * 0.8;
                case "Bad":
                    return _range * 0.5;
                default:
                    Console.WriteLine("Please input correctly!!!!");
                    return null;
            }
        }
    }
}