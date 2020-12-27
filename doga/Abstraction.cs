using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    public abstract class BaseRover
    {
        public string name;
        public  string defaultDirection ;
        public  List<string> roverMove;
        public int x_coordinate;
        public int y_coordinate;

        public abstract void FindDirection(int roverDirectionStatus);
        public abstract void ManipulateNextCoordinate();
        public abstract void ManipulateDirectionAndCoordinate(List<BaseRover> rovers, ref int moveOccuredIndex);

    }
}
