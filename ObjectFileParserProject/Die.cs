using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
/*Yahia Adrian Brocke
 * 6/18/18
 * CS 298 Advanced OOP*/
namespace ObjectFileParserProject
{
	[Serializable]
	public class Die 
	{
		private int numberOfEyes;
		private Random randomNumberSupplier; 
		private const int maxNumberOfEyes = 6;

		public Die()
		{
			randomNumberSupplier = Random.Instance();
			numberOfEyes = NewTossHowManyEyes();
		}

		public Die(int eyesNum)
		{
			numberOfEyes = eyesNum;
		}

		public void Toss()
		{
			numberOfEyes = NewTossHowManyEyes();
		}

		private int NewTossHowManyEyes ()
		{
			return randomNumberSupplier.Next(1,maxNumberOfEyes + 1);
		}

		public int NumberOfEyes() 
		{
			return numberOfEyes;
		}

		public static List<Die> Parse(int selection)
		{
			string line;
			List<Die> diceList = new List<Die>();

			//streamReader
			if (selection == 1)
			{
				try
				{
					using (TextReader tr = new StreamReader("objects_text.txt"))
					{
						while ((line = tr.ReadLine()) != null)
						{
							//validation							
							//if it's die, make it a die and add to 						
							Regex r = new Regex(@"\[[0-9]\]", RegexOptions.Compiled);//pattern, options
							Match m = r.Match(line);//text
							if (m.Success)
							{
								//strip out the die number
								line = line.Trim('[', ']');
								int num = Int32.Parse(line);

								//add to list 
								diceList.Add(new Die(num));
							}
                            else
                            {
                                //Console.WriteLine("isn't in die format");

                            }
						}
					}
				}
				catch (FileNotFoundException fnfe)
				{
					Console.WriteLine(fnfe.ToString());
				}
				finally
				{
					//close file
				}
			}
			

			//binary reader
			else if(selection == 2)
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream("dice.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
				
				Die die;
				//while((die = (Die)formatter.Deserialize(stream)) != null)didn't work
				for(int i = 0; i < 4; i++)
				{
					die = (Die)formatter.Deserialize(stream);
					diceList.Add(die);
					if (die == null)
						break;
				}//add this to point, also if you have time, maybe catch
				//System.Runtime.Serialization.SerializationException
				//to break the loop
				
				stream.Close();
			}

			//string reader
			else if(selection == 3)
			{
				String testString = "[5]\n[9]\n[3]\n[7]\n[2]\n[4]\n[6]";
				StringReader sr = new StringReader(testString);
				//use newline to make easier
				while ((line = sr.ReadLine()) != null)
				{
					//validation
					//if it's Point, make it a point and add to list
					Regex r = new Regex(@"\[[0-9]\]", RegexOptions.Compiled);//pattern, options
					Match m = r.Match(line);//text

					if (m.Success)
					{
						//clean up line
						line = line.Trim('[', ']');
						int num = Int32.Parse(line);

						//add to list 
						diceList.Add(new Die(num));
					}
                    else
                    {
                        //Console.WriteLine("isn't in dice format");
                    }
						
					//trim and regex for values we need

					//create object

					//add to list


			    }
            }else { Console.WriteLine("Please Enter a valid selection number"); }

			//return
			return diceList;
		}

		public override String ToString()
		{
			return String.Format("[{0}]", numberOfEyes);
		}
	}
}