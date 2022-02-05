using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Plotter_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.run();
        }

       
    }

    public class Controller // controls all the processes done between the four modular classes, taking in inputs and processing them to control outputs accordingly.
    {
        UserInterface userinterface = new UserInterface();
        Calculation calculation = new Calculation();
        Representation representation = new Representation();
        FileManager filemanager = new FileManager();
        private int currentuserinput = 0;
        private string currentfilename = "";
        private List<Point> pointslist = new List<Point>();
        private string graphshape = "";
        private string equation = "";
        //private Bitmap image = new Bitmap();
        public void run() //runs the controller
        {
            userinterface.displaymenu();
            currentuserinput = userinterface.Getuserinput();
            switch(currentuserinput)
            {
                case 1:
                    currentfilename = userinterface.GetFileName();
                    pointslist = filemanager.GetPoints(currentfilename);
                    graphshape = userinterface.GetShape();
                    equation = calculation.GetEquation(pointslist,graphshape);
                    representation.CreateImage(equation, pointslist);
                    userinterface.SaveFile();
                    filemanager.SaveImgFile();
                    break;
                case 5:
                    break;
            }
            
            
        }

        
    }

    public class UserInterface
    {
       private int userinput = 0;

        public void displaymenu() // displays the menu and options to the user.
        {
            Console.Clear();
            Console.WriteLine("   _____ _____            _____  _    _   _____  _      ____ _______ _______ ______ _____ ");
            Console.WriteLine("  / ____|  __ \\     /\\   |  __ \\| |  | | |  __ \\| |    / __ \\__   __|__   __|  ____|  __ \\ ");
            Console.WriteLine(" | |  __| |__) |   /  \\  | |__) | |__| | | |__) | |   | |  | | | |     | |  | |__  | |__) |");
            Console.WriteLine(" | | |_ |  _  /   / /\\ \\ |  ___/|  __  | |  ___/| |   | |  | | | |     | |  |  __| |  _  / ");
            Console.WriteLine(" | |__| | | \\ \\  / ____ \\| |    | |  | | | |    | |___| |__| | | |     | |  | |____| | \\ \\");
            Console.WriteLine("  \\_____|_|  \\_\\/_/    \\_\\_|    |_|  |_| |_|    |______\\____/  |_|     |_|  |______|_|  \\_\\");
            Console.WriteLine();
            Console.WriteLine("MENU:");
            Console.WriteLine();
            Console.WriteLine("1  Create a graph");
            Console.WriteLine("2  View saved graphs");
            Console.WriteLine("3  Create a textfile");
            Console.WriteLine("4  View saved textfiles");
            Console.WriteLine("5  Exit");
        } 
        public int Getuserinput()
        {
            bool valid = false;
            while (valid == false)
            {
                userinput = int.Parse(Console.ReadLine());
                if(userinput == 1 || userinput == 2 || userinput == 3 || userinput == 4 || userinput == 5) // all valid inputs.
                {
                    valid = true;
                }
                else // error handling
                {
                    Console.WriteLine("Enter a valid option (1-5)");
                }

            }
            return userinput;
        } // returns userinput from menu choices to the controller.

        public string GetFileName() // returns file name to the controller.
        {
            Console.Clear();
            Console.WriteLine("Enter the textfile containing the data set you wish to use:");
            return Console.ReadLine();
        }
        public string GetShape() //returns shape of graph to the controller.
        {
            Console.WriteLine("Enter the expected shape of graph:");
            return Console.ReadLine();
        }
        public string SaveFile()
        {
            Console.WriteLine("Save file as...");
            return Console.ReadLine();
        } // returns file name to the controller for saving any file.
    }

    public class Calculation
    {
        public string GetEquation(List<Point> points,string graphshape)
        {
            string equation = "";
            return equation;
        }
    }

    public class Representation
    {
        public void CreateImage(string equation, List<Point> points)
        {

        }
    }

    public class FileManager
    {
        
        public List<Point> GetPoints(string textfile) // returns a list of points read from the specified textfile.
        {
            List<Point> points = new List<Point>();
            return points; 
        } 
        public void SaveImgFile() //saves an image file to the image folder
        {

        }
    }

    public class Point
    {

    }
}
