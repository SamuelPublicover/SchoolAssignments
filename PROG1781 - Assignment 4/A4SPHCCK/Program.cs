/* Program ID: A4SPHCCK
 * 
 * Purpose: To exemplify knowledge of arrays
 * 
 * Revision History
 *  Created 2020-11-11 by Sam P, Hulya C, Connie K
 */




using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4SPHCCK
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Variables
            string[] shirtSizes = new string[4] { "1", "2", "3", "4" };
            string[] brandSPHCCK = new string[3];
            string[] tShirtCompleted = new string[12] {"NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE"};
            int menuOption = 0;
            bool keepGoing = true;
            bool itemDelete = true;
            bool loopOption = true;
            string userSelection = "";
            string brand = "";
            int optionThreeInt = 0;
            string inputBrandString = "";
            string inputSizeString = "";
            string tshirtString = "";
            string deleteEntry = "";
            string userChoice = "";
            int tshirtNumber = 0;
            int i = 0;
            int a = 0;
            bool tShirtFoundBool = true;
            bool tShirtSavedBool = true;
            bool exitProgram = false;
            bool tShirtExistsBool = false;
            bool done = false;


            //Get store name and three brands
            //Use a 'for' loop
            Console.WriteLine("Please enter the three brands your store carries:");
            Console.Write("Brand 1:");
            brandSPHCCK[0] = Console.ReadLine().ToUpper();
            Console.Write("Brand 2:");
            brandSPHCCK[1] = Console.ReadLine().ToUpper();
            Console.Write("Brand 3:");
            brandSPHCCK[2] = Console.ReadLine().ToUpper();

            do //Display Menu
            {
                Console.WriteLine("Please choose from the following: ");
                Console.WriteLine("1. Add new T-Shirt details (Brand Name & Size)");
                Console.WriteLine("2. Edit existing T-Shirt details (Brand Name & Size)");
                Console.WriteLine("3. Display all T-Shirts in store (display the Brand Name & Size");
                Console.WriteLine("4. Delete T-Shirt Info");
                Console.WriteLine("5. Exit the program ");
                menuOption = int.Parse(Console.ReadLine());


                //Menu option 1 Selected
                if (menuOption == 1)
                {
                    do //while user doesn't enter "DONE"
                    {
                        //reset variables 
                        tShirtFoundBool = true;
                        tShirtSavedBool = true;
                        tShirtExistsBool = false;
                        done = false;

                        //Create a New T-Shirt (Input brand name and size)
                        //Loop Option 1 until performed correctly (a new T-Shirt is added if able)

                        //Enter the T-Shirt's Brand
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Which brand is this new T-Shirt:");
                            Console.WriteLine("- " + brandSPHCCK[0]);
                            Console.WriteLine("- " + brandSPHCCK[1]);
                            Console.WriteLine("- " + brandSPHCCK[2]);
                            inputBrandString = Console.ReadLine().ToUpper();


                            if (inputBrandString == brandSPHCCK[0] || inputBrandString == brandSPHCCK[1] || inputBrandString == brandSPHCCK[2])
                            {
                                keepGoing = false;
                            }
                            else if (inputBrandString == "DONE")
                            {
                                done = true;
                            }
                            else
                            {
                                keepGoing = true;
                                Console.WriteLine("Brand does not exist, please enter one of the provided brands.");
                            }
                        } while (keepGoing);

                        //Get Size

                        if (!done)
                        {
                            do  //Loop until proper size is entered 
                            {
                                Console.WriteLine("What is the size of the shirt? (Enter a digit from 1-4)");
                                Console.WriteLine(shirtSizes[0] + ": Small");
                                Console.WriteLine(shirtSizes[1] + ": Medium");
                                Console.WriteLine(shirtSizes[2] + ": Large");
                                Console.WriteLine(shirtSizes[3] + ": X-Large");
                                inputSizeString = Console.ReadLine();
                                if (inputSizeString == "1" || inputSizeString == "2" || inputSizeString == "3" || inputSizeString == "4")
                                {
                                    keepGoing = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a numeric value from 1-4");
                                    keepGoing = true;
                                }

                            } while (keepGoing);

                            //conjugate brand and size, with "-" in between
                            tshirtString = inputBrandString + "-" + inputSizeString;

                            i = 0;

                            tShirtExistsBool = false;

                            //Sift through completed/stored T-Shirt's array to see if entered T-Shirt already exists
                            do
                            {
                                if (tShirtCompleted[i] == tshirtString)
                                {

                                    tShirtExistsBool = true;
                                    Console.WriteLine("T-Shirt has already been stored in spot #" + (i + 1));
                                }

                                i++;

                            } while (i < 12 && !(tShirtExistsBool));


                            i = 0;
                            tShirtSavedBool = false;
                            //Sift through T-Shirts to find an empty spot IF the T-Shirt doesn't already exist
                            if (!tShirtExistsBool)
                            {
                                do
                                {
                                    if (tShirtCompleted[i] == "NONE")
                                    {
                                        tShirtCompleted[i] = tshirtString;
                                        tShirtSavedBool = true;
                                        Console.WriteLine("T-Shirt: " + tshirtString + ", has been saved in spot #" + (i + 1));
                                    }
                                    i++;

                                } while (i < 12 && !(tShirtSavedBool));
                            }
                            else
                            //Tell user to go back to menu and delete a shirt if desired
                            {
                                Console.WriteLine("Please enter a t-shirt that doesn't already exist, or delete the previously saved shirt.");
                            }

                            //If the do loop has gone thorugh 12 iterations and did not find an empty T-Shirt value, inventory is full.
                            if (!tShirtExistsBool && !tShirtSavedBool)
                            {
                                Console.WriteLine("Inventory Full, Please delete a saved shirt before creating a new entry.");
                            }
                        }
                    } while (!done);
                }



                else if (menuOption == 2)
                {
                    //Edit existing details of a saved shirt; loop until executed properly
                    do
                    {
                        //Specify which shirt you'd like the find
                        do
                        {
                            //Enter the T-Shirt's Brand; loop until entered correctly
                            Console.WriteLine();
                            Console.WriteLine("Which brand is this new T-Shirt:");
                            Console.WriteLine("- " + brandSPHCCK[0]);
                            Console.WriteLine("- " + brandSPHCCK[1]);
                            Console.WriteLine("- " + brandSPHCCK[2]);
                            inputBrandString = Console.ReadLine().ToUpper();
                            if (inputBrandString == brandSPHCCK[0] || inputBrandString == brandSPHCCK[1] || inputBrandString == brandSPHCCK[2])
                            {
                                keepGoing = false;
                            }
                            else
                            {
                                keepGoing = true;
                                Console.WriteLine("Brand does not exist, please enter one of the provided brands.");

                            }
                        } while (keepGoing);

                        //Loop until proper size is entered correctly
                        do
                        {
                            Console.WriteLine("What is the size of the shirt? (Enter a digit from 1-4)");
                            Console.WriteLine(shirtSizes[0] + ": Small");
                            Console.WriteLine(shirtSizes[1] + ": Medium");
                            Console.WriteLine(shirtSizes[2] + ": Large");
                            Console.WriteLine(shirtSizes[3] + ": X-Large");
                            inputSizeString = Console.ReadLine();
                            if (inputSizeString == "1" || inputSizeString == "2" || inputSizeString == "3" || inputSizeString == "4")
                            {
                                keepGoing = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a numeric value from 1-4");
                                keepGoing = true;
                            }

                        } while (keepGoing);


                        tshirtString = inputBrandString + "-" + inputSizeString;
                        tShirtExistsBool = false;
                        i = 0;

                        //Sift through completed/stored T-Shirt's array to see if entered T-Shirt already exists
                        do
                        {
                            if (tShirtCompleted[i] == tshirtString)
                            {

                                tShirtExistsBool = true;

                            }

                            i++;

                        } while (i < 12 && !(tShirtExistsBool));

                        //If the T-Shirt exists, ask user what they'd like to replace it with
                        if (tShirtExistsBool)
                        {
                            Console.WriteLine("T-Shirt Information Found in spot #" + (i));
                            //Ask for what to edit
                            //This should be the correct tShirt
                            Console.WriteLine(tShirtCompleted[(i - 1)]);
                            Console.WriteLine("What brand would you like this T-Shirt to be changed to?");
                            Console.WriteLine("- " + brandSPHCCK[0]);
                            Console.WriteLine("- " + brandSPHCCK[1]);
                            Console.WriteLine("- " + brandSPHCCK[2]);
                            inputBrandString = Console.ReadLine().ToUpper();
                            Console.WriteLine("What size would you like this T-shirt to be changed to?");
                            Console.WriteLine(shirtSizes[0] + ": Small");
                            Console.WriteLine(shirtSizes[1] + ": Medium");
                            Console.WriteLine(shirtSizes[2] + ": Large");
                            Console.WriteLine(shirtSizes[3] + ": X-Large");
                            inputSizeString = Console.ReadLine();
                            tShirtCompleted[(i - 1)] = inputBrandString + "-" + inputSizeString;
                            Console.WriteLine("T-Shirt Saved as:" + tShirtCompleted[(i - 1)] + ", in spot #" + (i));
                            loopOption = false;
                        }
                        //If T-Shirt isn't found, tell user to create one back at the menu
                        else
                        {
                            Console.WriteLine("T-Shirt Record Not Found, no T-shirt's with those specifications currently exist within the system.");
                            loopOption = false;
                        }
                    } while (loopOption);
                }



                //Menu Option #3: Display all completed/saved T-Shirts in the system
                else if (menuOption == 3)

                {
                    do
                    {
                        for (int b = 0; b < tShirtCompleted.Length; b++)
                        {
                            Console.WriteLine("Shirt #" + (b + 1) + tShirtCompleted[b]);
                        }
                        //Display all t-shirts in store
                        Console.WriteLine("If You Like To Go To The Main Menu, Please Press Enter:  ");

                        string userEntry1 = Console.ReadLine();

                        if (userEntry1 == "")

                        {
                            break;
                        }
                        else
                        {
                            keepGoing = false;

                        }

                    } while (keepGoing == true);

                }


                //Menu Option #4: Delete a stored t-shirt
                else if (menuOption == 4)
                {
                    do
                    {
                        //Display all stored shirts
                        Console.WriteLine("current shirts in inventory: ");
                        
                        for (int c = 0; c < tShirtCompleted.Length; c++)
                        {
                            Console.WriteLine("Shirt number {0}: {1}", (c + 1), tShirtCompleted[c]);

                        }
                        do
                        {
                            Console.Write("enter the t-shirt you want to delete: ");
                            tshirtNumber = Convert.ToInt32(Console.ReadLine());
                            if (tshirtNumber == 1 || tshirtNumber == 2 || tshirtNumber == 3 || tshirtNumber == 4)
                            {
                                keepGoing = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a numeric value from 1-4");
                                keepGoing = false;
                            }
                        } while (!keepGoing);
                        tShirtCompleted[(tshirtNumber - 1)] = ("NONE");

                        do //loop until entered properly
                        {
                            Console.WriteLine("Are you sure you want to delete this entry? Please type YES or NO");
                            userChoice = Console.ReadLine().ToUpper();
                            if (userChoice == "YES")
                            {

                                Console.WriteLine("Here is your updated list: ");
                                for (int c = 0; c < tShirtCompleted.Length; c++)
                                {
                                    Console.WriteLine("Shirt number: {0}: {1}", (c + 1), tShirtCompleted[c]);

                                }
                                itemDelete = true;
                            }
                            else if (userChoice == "NO")
                            {
                                itemDelete = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter either 'yes' or 'no' with no spaces.");
                                keepGoing = false;
                            }
                        } while (!keepGoing);

                    } while (!itemDelete);
                }

                else if (menuOption == 5)
                {
                    //Exit Program
                    exitProgram = true;

                }

                else
                {
                    Console.WriteLine("Please Enter a numeric number between 1 and 5");
                    exitProgram = false;
                }
                
            } while (!exitProgram);
            Console.ReadLine();
        }
    }
}
