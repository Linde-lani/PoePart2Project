using System.Collections.Generic;
using System.IO;
using System;

namespace PoePart1
{
    public class Check_writeFile
    {

        public Check_writeFile()
        { //going to create this class to have method
            //only
            //three method 
            /*
             * 1: checking file and create
             * 2: getting what is stored in the txt file
             * 3: adding or writting into the txt file
             * */
            Check_writeFile check_exist = new Check_writeFile();

            //Now use the object name check_exist
            //To get the method on the check_writeFile class

            //First class method to be called is check_file
            check_exist.check_file();

            //Second one is getting the stored values in file
            List<string> memory = check_exist.return_memory();

            //now list all the memory values
            foreach (string checks in memory)
            {
                Console.WriteLine(checks);
            }//end of foreach

            //Now lets prompt the user and save what they
            //enter
            Console.WriteLine("Enter your name and favourite cyber-security topic");
            string asking = Console.ReadLine();

            //now store into the List and save to the file
            memory.Add(asking);

            //now also store into the file
            check_exist.save_memory(memory);
        }
         //Since AppDomain as global gives an error of static
         //Lets do a return method for it to return the path
    private string path_return()
        {
            //App Domain get full path
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;
            //then replace the bin/Debug/
            //so its bin\\Debug\\ inside the "" no space
            string new_path = fullpath.Replace("bin\\Debug\\", "");
            //now combine the path of new_path and the txt file
            string path = Path.Combine(new_path, "memory.txt");

            return path;
        }//end of return path method

        //Now lets do the three methods

        //Method to check the txt file and create if not found
        public void check_file()
        {
            //get the path
            string path = path_return();
            //Now check if the path exists or not
            //then if not found then create the txt file
            if (!File.Exists(path))
            {
                //this by !
                //it means if not, the path of the file is
                //not found the create or do something
                File.CreateText(path);
            }
            else
            {
                //then if the file is found 
                Console.WriteLine("File is found...");
            }

        }//end of method check_file

        //Now for the get what is in the file method
        public List<string> return_memory()
        {
            //Now get the path of the file
            string path = path_return();

            return new List<string>(File.ReadAllLines(path));
            //by this you return all in the txt file

        }//end of return memory method

        //method to write to the file
        public void save_memory(List<string> save_new)
        {
            //get the path
            string path = path_return();

            //then for the parameter pass a List
            //then lets write into the txt file
            File.WriteAllLines(path, save_new);
            //if you pass a variable it give you an error
            //you can test using variable
        }//end of save memory method

        
        }//end of class
}//end of namespace

    

