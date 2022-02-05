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

    public class Controller
    {
        UserInterface userinterface = new UserInterface();
        Calculation calculation = new Calculation();
        Representation representation = new Representation();
        
        public void run()
        {

        }
    }

    public class UserInterface
    {

    }

    public class Calculation
    {

    }

    public class Representation
    {

    }
}
