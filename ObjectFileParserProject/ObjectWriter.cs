using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
/*Yahia Adrian Brocke
 * 6/18/18
 * CS 298 Advanced OOP*/
namespace ObjectFileParserProject
{
	class Objectwriter
	{
		static void Main(String[] args)
		{

			//StringWriter sw = (StringWriter)sw;

			Die d1 = new Die();
			Point p1 = new Point();
			Die d2 = new Die();
			Point p2 = new Point();
			Die d3 = new Die();
			Point p3 = new Point();
			Die d4 = new Die();
			Point p4 = new Point();



			using (StreamWriter sw = new StreamWriter("objects_text.txt"))
			{
				sw.Write(d1); sw.WriteLine();
				sw.Write(p1); sw.WriteLine();
				sw.Write(d2); sw.WriteLine();
				sw.Write(p2); sw.WriteLine();
				sw.Write(d3); sw.WriteLine();
				sw.Write(p3); sw.WriteLine();
				sw.Write(d4); sw.WriteLine();
				sw.Write(p4); sw.WriteLine();
				
			}
			
			//Writing to binary file
			IFormatter formatter = new BinaryFormatter();
			Stream diceStream = new FileStream("dice.bin", FileMode.Create);
			Stream pointStream = new FileStream("point.bin", FileMode.Create);

			//add Die objects
			formatter.Serialize(diceStream, d1);
			formatter.Serialize(diceStream, d2);
			formatter.Serialize(diceStream, d3);
			formatter.Serialize(diceStream, d4);

			//add point objects
			formatter.Serialize(pointStream, p1);
            formatter.Serialize(pointStream, p2);
            formatter.Serialize(pointStream, p3);
            formatter.Serialize(pointStream, p4);
			diceStream.Close();
			pointStream.Close();
			
		}
	}
}
