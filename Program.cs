using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{


    class Program
    {

        public static void Create(List<Unit> Army1, int armysize, StreamWriter sw) //Метод для создания армий разной размерности и наполняем
        {
            Random a = new Random();
            for (int i = 0; i < armysize; i++)
            {
                switch (a.Next(7))
                {
                    case 0:
                        {
                            Warrior w = new Warrior(" Warrior" + i, 5, 6, 2);
                            Army1.Add(w);
                            Console.WriteLine(w);
                            sw.WriteLine(w);
                            break;
                        }
                    case 1:
                        {
                            Cavalry c = new Cavalry(" Cavalry" + i, 10, 3, 7);
                            Army1.Add(c);
                            Console.WriteLine(c);
                            sw.WriteLine(c);
                            break;
                        }
                    case 2:
                        {
                            Archer arc = new Archer(" Archer" + i, 3, 4, 3);
                            Army1.Add(arc);
                            Console.WriteLine(arc);
                            sw.WriteLine(arc);
                            break;
                        }
                    case 3:
                        {
                            CavalryArcher ca = new CavalryArcher(" CavalryArcher" + i, 7, 2, 10);
                            Army1.Add(ca);
                            Console.WriteLine(ca);
                            sw.WriteLine(ca);
                            break;
                        }
                    case 4:
                        {
                            Healer h = new Healer(" Healer" + i, 3, 5);
                            Army1.Add(h);
                            Console.WriteLine(h);
                            sw.WriteLine(h);
                            break;
                        }
                    case 5:
                        {
                            HealingTower ht = new HealingTower(" HealingTower" + i, 20, 1);
                            Army1.Add(ht);
                            Console.WriteLine(ht);
                            sw.WriteLine(ht);
                            break;
                        }
                    case 6:
                        {
                            AttackingTower at = new AttackingTower(" AttackingTower" + i, 30, 1, 20);
                            Army1.Add(at);
                            Console.WriteLine(at);
                            sw.WriteLine(at);
                            break;
                        }
                }
            }
        }

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("ArmyFile.txt");
            List<Unit> Army1 = new List<Unit>();
            List<Unit> Army2 = new List<Unit>();
            Random a = new Random();
            int army1size = a.Next(1, 6);
            int army2size = a.Next(1, 6);
            Console.WriteLine("Создаем 1 армию:");
            sw.WriteLine("Создаем 1 армию:");
            Create(Army1, army1size, sw);
            Console.WriteLine("Создаем 2 армию:");
            sw.WriteLine("Создаем 2 армию:");
            Create(Army2, army2size, sw);
            List<Unit> kucha1 = new List<Unit>();
            List<Unit> kucha2 = new List<Unit>();
            Console.WriteLine("ДА начнется битва!");
            sw.WriteLine("ДА начнется битва!");

            while ((Army1.Count() != 0) && (Army2.Count() != 0))
            {
                for (int ini = 1; (ini < 7) && (Army1.Count() != 0) && (Army2.Count() != 0); ini++) // отбор воинов с инициативой от 1 до 6
                {

                    for (int i = 0; i < Army1.Count(); i++)
                    {
                        if (Army1[i].initiative == ini) kucha1.Add(Army1[i]);
                    }
                    for (int
                    i = 0; i < Army2.Count(); i++)
                    {
                        if (Army2[i].initiative == ini) kucha2.Add(Army2[i]);
                    }
                    if ((kucha1.Count() != 0) || (kucha2.Count() != 0)) //случайно выбираемый воин бьет случайного противника 
                    {
                        switch (a.Next(1))
                        {
                            case 0:
                                {
                                    int n = a.Next(kucha1.Count());
                                    Console.WriteLine(kucha1[n].ToString() + " выбран для битвы");
                                    sw.WriteLine(kucha1[n].ToString() + " выбран для битвы");
                                    Unit b = Army2[a.Next(Army2.Count())];
                                    if ((kucha1[n] is Healer) || (kucha1[n] is HealingTower)) //если это лекарь или леачащая башная то выбирает случайного война из своей армии для ле
                                    {
                                        if (kucha1[n] is Healer)
                                        {
                                            int d = a.Next(Army1.Count);
                                            if (!(Army1[d] is Tower))
                                            {
                                                if (Army1[d].health < Army1[d].maxhealth)
                                                {
                                                    Army1[d].health = Army1[d].health + 2;
                                                    if (Army1[d].health > Army1[d].maxhealth) Army1[d].health = Army1[d].maxhealth;
                                                    sw.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                                    Console.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                                }
                                            }
                                            kucha1.RemoveAt(n);
                                        }
                                        else
                                        {
                                            for (int i = 1; i < 3; i++)
                                            {
                                                int d = a.Next(Army1.Count);
                                                if (!(Army1[d] is Tower))
                                                {
                                                    if (Army1[d].health < Army1[d].maxhealth)
                                                    {
                                                        Army1[d].health = Army1[d].health + a.Next(15);
                                                        if (Army1[d].health > Army1[d].maxhealth) Army1[d].health = Army1[d].maxhealth;
                                                        sw.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                                        Console.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                                    }
                                                }
                                            }
                                            kucha1.RemoveAt(n);
                                        }
                                    }
                                    else
                                    {

                                        b.health = b.health - kucha1[n].power;
                                        if (b.health < 0)
                                        {
                                            Army2.Remove(b); Console.WriteLine(kucha1[n].ToString() + " убил " + b.ToString() + " из 2 армии");
                                            sw.WriteLine(kucha1[n].ToString() + " убил " + b.ToString() + " из 2 армии");
                                        }
                                        kucha1.RemoveAt(n);
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    int n = a.Next(kucha2.Count());
                                    Console.WriteLine(kucha2[n].ToString() + " выбран для битвы");
                                    sw.WriteLine(kucha2[n].ToString() + " выбран для битвы");
                                    Unit b = Army1[a.Next(Army1.Count())];
                                    //Console.WriteLine("СМОТРИ КОГО ВЫБРАЛИ убивать" + b.ToString());
                                    if ((kucha2[n] is Healer) || (kucha2[n] is HealingTower))
                                    {

                                        if (kucha2[n] is Healer)
                                        {
                                            int d = a.Next(Army2.Count);
                                            //  Console.WriteLine("СМОТРИ КОГО ВЫБРАЛИ ЛЕЧИТЬ" + Army2[d].ToString());
                                            if (!(Army2[d] is Tower))
                                            {
                                                if (Army2[d].health < Army2[d].maxhealth)
                                                {
                                                    Army2[d].health = Army2[d].health + a.Next(2);
                                                    if (Army2[d].health > Army2[d].maxhealth) Army2[d].health = Army2[d].maxhealth;
                                                    sw.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                                    Console.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                                }
                                            }
                                            kucha2.RemoveAt(n);
                                        }
                                        else
                                        {
                                            for (int i = 1; i <= a.Next(1, 3); i++)
                                            {
                                                int d = a.Next(Army2.Count);
                                                //   Console.WriteLine("СМОТРИ КОГО ВЫБРАЛИ ЛЕЧИТЬ" + Army2[d].ToString());
                                                if (!(Army2[d] is Tower))
                                                {
                                                    if (Army2[d].health < Army2[d].maxhealth)
                                                    {
                                                        Army2[d].health = Army1[d].health + a.Next(15);
                                                        if (Army2[d].health > Army2[d].maxhealth) Army2[d].health = Army2[d].maxhealth;
                                                        sw.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                                        Console.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                                    }
                                                }
                                            }
                                            kucha2.RemoveAt(n);
                                        }
                                    }
                                    else
                                    {
                                        b.health = b.health - kucha2[n].power;
                                        if (b.health < 0)
                                        {
                                            Army1.Remove(b); Console.WriteLine(kucha2[n].ToString() + " убил " + b.ToString() + " из 1 армии");
                                            sw.WriteLine(kucha2[n].ToString() + " убил " + b.ToString() + " из 1 армии");
                                        }
                                        kucha2.RemoveAt(n);
                                    }
                                    break;
                                }
                        }
                    }
                   else
                    {
                        if (kucha1.Count() != 0)
                        {
                        int n = a.Next(kucha1.Count());
                        Console.WriteLine(kucha1[n].ToString() + " выбран для битвы");
                        sw.WriteLine(kucha1[n].ToString() + " выбран для битвы");
                        Unit b = Army2[a.Next(Army2.Count())];
                        if ((kucha1[n] is Healer) || (kucha1[n] is HealingTower))
                            {
                            if (kucha1[n] is Healer)
                            {
                                int d = a.Next(Army1.Count);
                                if (!(Army1[d] is Tower))
                                {
                                    if (Army1[d].health < Army1[d].maxhealth)
                                    {
                                        Army1[d].health = Army1[d].health + a.Next(2);
                                        if (Army1[d].health > Army1[d].maxhealth) Army1[d].health = Army1[d].maxhealth;
                                        sw.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                        Console.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                    }
                                }
                                kucha1.RemoveAt(n);
                            }
                            else
                            {
                                for (int i = 1; i <= a.Next(1, 3); i++)
                                {
                                    int d = a.Next(Army1.Count);
                                    if (!(Army1[d] is Tower))
                                    {
                                        if (Army1[d].health < Army1[d].maxhealth)
                                        {
                                            Army1[d].health = Army1[d].health + a.Next(15);
                                            if (Army1[d].health > Army1[d].maxhealth) Army1[d].health = Army1[d].maxhealth;
                                            sw.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                            Console.WriteLine("***" + Army1[d].ToString() + " прохилен до " + Army1[d].health + kucha1[n]);
                                        }
                                    }
                                }
                                kucha1.RemoveAt(n);
                            }
                        }
                            else
                            {
                                b.health = b.health - kucha1[n].power;
                                if (b.health < 0) { Army2.Remove(b); Console.WriteLine(kucha1[n].ToString() + " убил " + b.ToString() + " из 2 армии");
                                sw.WriteLine(kucha1[n].ToString() + " убил " + b.ToString() + " из 2 армии");
                                }
                            kucha1.RemoveAt(n);
                        }
                        }
                        if (kucha2.Count() != 0)
                        {
                            int n = a.Next(kucha2.Count());
                            Console.WriteLine(kucha2[n].ToString() + " выбран для битвы");
                            sw.WriteLine(kucha2[n].ToString() + " выбран для битвы");
                            Unit b = Army1[a.Next(Army1.Count())];
                        if ((kucha2[n] is Healer) || (kucha2[n] is HealingTower))
                                {
                            if (kucha2[n] is Healer)
                            {
                                int d = a.Next(Army2.Count);
                                if (!(Army2[d] is Tower))
                                {
                                    if (Army2[d].health < Army2[d].maxhealth)
                                    {
                                        Army2[d].health = Army2[d].health + a.Next(2);
                                        if (Army2[d].health > Army2[d].maxhealth) Army2[d].health = Army2[d].maxhealth;
                                        sw.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                        Console.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                    }
                                }
                                kucha2.RemoveAt(n);
                            }
                            else
                            {
                                for (int i = 1; i <= a.Next(1, 3); i++)
                                {
                                    int d = a.Next(Army2.Count);
                                    if (!(Army2[d] is Tower))
                                    {
                                        if (Army2[d].health < Army2[d].maxhealth)
                                        {
                                            Army2[d].health = Army1[d].health + a.Next(15);
                                            if (Army2[d].health > Army2[d].maxhealth) Army2[d].health = Army2[d].maxhealth;
                                            sw.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                            Console.WriteLine("***" + Army2[d].ToString() + " прохилен до " + Army2[d].health + kucha2[n]);
                                        }
                                    }
                                }
                                kucha2.RemoveAt(n);
                            }
                        }
                                else
                                {
                                    b.health = b.health - kucha2[n].power;
                                    if (b.health < 0) { Army1.Remove(b); Console.WriteLine(kucha2[n].ToString() + " убил " + b.ToString() + " из 1 армии");
                                    sw.WriteLine(kucha2[n].ToString() + " убил " + b.ToString() + " из 1 армии");
                                        }
                            kucha2.RemoveAt(n);
                        }
                        }
                    }
                    kucha1.Clear();
                    kucha2.Clear();

                }
            }
            if (Army2.Count() == 0)
            {
                Console.WriteLine("Побеждает 1 армия!");
                sw.WriteLine("Побеждает 1 армия!");
            }
            else
            {
                Console.WriteLine("Побеждает 2 армия!");
                sw.WriteLine("Побеждает 2 армия!");
            }
            sw.Close();
            Console.ReadLine();

        }
    }
}
