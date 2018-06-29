// Fig. 9.4: Point.cs
// Point class represents an x-y coordinate pair.
/*Yahia Adrian Brocke
 * 6/18/18
 * CS 298 Advanced OOP*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace ObjectFileParserProject
{
	[Serializable]
	// Point class definition implicitly inherits from Object
	public class Point
	{
		// point coordinate
		private int x, y;

		// default constructor
		public Point()
		{
			// default to 0,0

			this.x = Random.Instance().Next(0, 10);
			this.y = Random.Instance().Next(0, 10);
		}

		// constructor
		public Point(int xValue, int yValue)
		{
			// implicit call to Object constructor occurs here
			X = xValue;
			Y = yValue;
		}

		// property X
		public int X
		{
			get
			{
				return x;
			}

			set
			{
				x = value; // no need for validation
			}

		} // end property X

		// property Y
		public int Y
		{
			get
			{
				return y;
			}

			set
			{
				y = value; // no need for validation
			}

		} // end property Y


		public static List<Point> Parse(int selection)
		{
			//make selection method understand what type of file you specify using regex


			string line;
			List<Point> pointList = new List<Point>();

			//Stream Writer
			if (selection == 1)
			{
				try
				{
					using (TextReader tr = new StreamReader("objects_text.txt"))
					{
						while ((line = tr.ReadLine()) != null)
						{
							//validation
							//if it's Point, make it a point and add to list
							Regex r = new Regex(@"\[([0-9]+),(\s)([0-9]+)\]", RegexOptions.Compiled);//pattern, options
							Match m = r.Match(line);//text

                            //make sure no bs
							if (m.Success)
							{
								//clean up line
								line = line.Trim('[', ']');
								line = line.Replace(" ", "");
                                
								//index of comma
								int commaIndex = line.IndexOf(",");

								//set variables 
								int first = Int32.Parse(line.Substring(0, commaIndex));
								int second = Int32.Parse(line.Substring(commaIndex + 1, line.Length - (commaIndex + 1)));

								//add to list
								pointList.Add(new Point(first, second));
							}
                            else
                            {
                                //Console.WriteLine("isn't in point format");
                            }
								

						}
					}

				}
				catch (FileNotFoundException fnfe)
				{
					Console.WriteLine(fnfe.ToString());
				}
			}

			//Binary writer
			else if (selection == 2)
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream("point.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
				Point point;
                for(int i = 0; i < 4; i++)
				{
					point = (Point)formatter.Deserialize(stream);					
					pointList.Add(point);
					if (point == null)
						break;
				}
				stream.Close();
			}

			//String reader
			else if (selection == 3)
			{
				String testString = "[0, 5]\n[4, 9]\n[3, 9]\n[5, 7]\n[7, 2]\n[2, 6]\n[6, 8]";
				StringReader sr = new StringReader(testString);
				//use newline to make easier
				while ((line = sr.ReadLine()) != null)
				{	
					//validation
					//if it's Point, make it a point and add to list
					Regex r = new Regex(@"\[([0-9]+),(\s)([0-9]+)\]", RegexOptions.Compiled);//pattern, options
					Match m = r.Match(line);//text

					//IsInCorrectFormat(@"\[[0-9],(\s)[0-9]\]", line);
					if (m.Success)
					{
						//clean up line
						line = line.Trim('[', ']');
						line = line.Replace(" ", "");
                        
						//index of comma
						int commaIndex = line.IndexOf(",");
						//int bracketIndex = line.IndexOf("]");

						//set variables 
						int first = Int32.Parse(line.Substring(0, commaIndex));
						int second = Int32.Parse(line.Substring(commaIndex + 1, line.Length - (commaIndex + 1)));
						    
						//add to list
						pointList.Add(new Point(first, second));
					}
                    else
                    {
                        Console.WriteLine("isn't in point format");

                    }
				}

			}
            else { Console.WriteLine("Please Enter a valid selection number"); }
			Console.WriteLine();
			return pointList;
		}



		// return string representation of Point
		public override string ToString()
		{
			return "[" + x + ", " + y + "]";
		}

	}
} // end class Point
	



/*
 **************************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************
*/