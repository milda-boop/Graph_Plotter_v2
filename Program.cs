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

        public void run() //runs the controller
        {
            userinterface.displaymenu();
            currentuserinput = userinterface.Getuserinput();
            switch(currentuserinput)
            {
                case 1: //case for creating a graph
                    string currentfilename = userinterface.GetFileName(); //gets file name for dataset from user interface.
                    List<Point> pointslist = filemanager.GetPoints(currentfilename); //gets the file manager to return a list of points from the file.
                    string graphshape = userinterface.GetShape(); // gets the shape of the graph from the user interface.
                    string equation = calculation.GetEquation(pointslist,graphshape); // passes in the shape of graph and list of points into calculation in return for the equation of best-fit.
                    Bitmap image = representation.CreateImage(equation, pointslist); //  passes in the equation and list of points into representation in return for a bitmap image of the final graph.
                    filemanager.SaveImgFile(userinterface.SaveFile(),image); // Gets the user requested file name from user interface and passes this into the file manager along with the bitmap image to save the file.
                    run(); // back to menu (recursive subroutine with a base case of user input = 5)
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
        private List<string> imagefiles = new List<string>();
        private List<string> textfiles = new List<string>();
        public List<Point> GetPoints(string textfile) // returns a list of points read from the specified textfile.
        {
            List<Point> points = new List<Point>();
            return points; 
        } 
       
        public void SaveImgFile(string filename, Bitmap b) //writes the dataset to a new textfile, and adds it to the list of all created files.
        {
            imagefiles.Add(filename);
        }
        public void SaveTxtFile(string filename, List<string> dataset)
        {
            textfiles.Add(filename);
        }
        public List<string> GetImgFiles() //returns list of image files
        {
            return imagefiles;
        }
        public List<string> GetTxtFiles() //returns list of text files
        {
            return textfiles;
        }
    }

    public class Point
    {
        private double x;
        private double y;

        public Point(string point) // constructor used for when instantiating point objects from a text file.
        {
            string[] splitpoint = point.Split(','); // splits a point into x and y values.
            this.x = double.Parse(splitpoint[0]) * Math.Pow(10, -12); // numbers are temporarily minimised to avoid rounding errors during calculations.
            this.y = double.Parse(splitpoint[1]) * Math.Pow(10, -12);
        }
        public Point(double x, double y) // different constructor used for when instantiating point objects for the line of best fit.
        {
            this.x = x;
            this.y = y;
        }
        public double GetX() 
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }
    }
}
