using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Drawing.Imaging;

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
        private bool exit = false;

        public void run() //runs the controller
        {
            userinterface.displaymenu();
            currentuserinput = userinterface.Getuserinput();
            while (!exit)
            {
                switch (currentuserinput)
                {
                    case 1: //case for creating a graph
                        string currentfilename = userinterface.GetFileName();                   // gets file name for dataset from user interface.
                        List<Point> pointslist = filemanager.GetPoints(currentfilename);        // gets the file manager to return a list of points from the file.
                        string graphshape = userinterface.GetShape();                           // gets the shape of the graph from the user interface.
                        string equation = calculation.GetEquation(pointslist, graphshape);      // passes in the shape of graph and list of points into calculation in return for the equation of best-fit.
                        Bitmap image = representation.CreateImage(equation, pointslist);        // passes in the equation and list of points into representation in return for a bitmap image of the final graph.
                        filemanager.SaveImgFile(userinterface.SaveFile(), image);               // Gets the user requested file name from user interface and passes this into the file manager along with the bitmap image to save the file.
                        break;
                    case 2: //case for viewing graphs
                        userinterface.DisplayFiles(filemanager.GetImgFiles());
                        break;
                    case 3: //case for viewing data sets
                        userinterface.DisplayFiles(filemanager.GetTxtFiles());
                        break;
                    case 4: //case for creating a data set
                        List<string> dataset = userinterface.GetDataset();
                        filemanager.SaveTxtFile(userinterface.SaveFile(),dataset);
                        break;
                    case 5: //case for when user decided to exit - bool value is set to true and controller escapes the while loop.
                        exit = true;
                        break;
                }

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
        public string GetShape()    //returns shape of graph to the controller.
        {
            Console.WriteLine("Enter the expected shape of graph:");
            return Console.ReadLine();
        }
        public string SaveFile()
        {
            Console.WriteLine("Save file as...");
            return Console.ReadLine();
        } // returns file name to the controller for saving any file.
        public void DisplayFiles(List<string> files) //displays the list of files (txt/img).
        {
            foreach(string f in files)
            {
                Console.WriteLine(f);
            }
        }
        public List<string> GetDataset() // gets user to enter in the points for a new dataset and returns the list of points as strings to the controller.
        {
            List<string> dataset = new List<string>();
            bool over = false;   
            Console.WriteLine("Enter points one at a time, with the x and y values separated by a single comma:");
            while(!over) // will keep asking for points until user selects to save.
            {
                Console.WriteLine("Enter next point or s to save the dataset:");
                if(Console.ReadLine()!="s")
                {
                    dataset.Add(Console.ReadLine());
                }
                else
                {
                    over = true;
                }
            }
            return dataset;
        }
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
        public Bitmap CreateImage(string equation, List<Point> points) //returns a bitmap image of the graph.
        {
            Bitmap b = new Bitmap(600, 600);
            using (b)
            {
               using(Graphics g = Graphics.FromImage(b))
               {

               }
            }
            return b;
        }
        public void ScalePoints()
        {

        }
        public void CalculateBfPoints()
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
