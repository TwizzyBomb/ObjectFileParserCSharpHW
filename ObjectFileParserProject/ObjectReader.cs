using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Yahia Adrian Brocke
 * 6/18/18
 * CS 298 Advanced OOP*/
namespace ObjectFileParserProject
{
	class ObjectReader
	{
        static void Main_(string[] args)
        {
            /* Array lists to hold loaded die and point objects*/
            List<Die> dieList;
            List<Point> pointList;

            //ask user to specify which type of file he/she wants to use
            Console.WriteLine("Which type of stream would you like to use?");
            Console.WriteLine("1.\tStream\n2.\tBinary\n3.\tString\nEnter your choice:");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Console.WriteLine("You chose Stream");
                    break;
                case 2: Console.WriteLine("You chose Binary");
                    break;
                case 3: Console.WriteLine("You chose String");
                    break;
                default: Console.WriteLine("please enter one of the three choices");
                    break;
            }
            Console.WriteLine();
            //dice
            Console.WriteLine("Dice:");
            dieList = Die.Parse(choice);

            // print results
            foreach (Die d in dieList)
                Console.WriteLine("Die :{0}", d);

            //point
            Console.WriteLine("Points:");
            pointList = Point.Parse(1);

            foreach (Point p in pointList)
                Console.WriteLine("Point :{0}", p);
        }
	}
}
