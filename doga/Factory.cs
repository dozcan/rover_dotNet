using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    public class Factory
    {
        public static BaseRover createRover(string defaultDirection, List<string> roverMove, List<int> coordinates)
        {
            return new ConcreteRover(defaultDirection, roverMove, coordinates[0], coordinates[1]);
        }

        public static plateau createPlateau(List<int> coordinates)
        {
            return new plateau(coordinates[0], coordinates[1]);
        }


    }
    }
