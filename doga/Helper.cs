using System;
using System.Collections.Generic;
using System.Linq;

namespace doga
{
    public class Helper
    {
        //helper işlemi sağlar
        public static List<string> DirectionParser (string roverMove)
        {
            List<string> directions = new List<string>();
            char[] charArr = roverMove.ToCharArray();
            foreach (char ch in charArr)
            {
                directions.Add(ch.ToString());
            }
            return directions;
        }

        //helper işlemi sağlar
        public static List<int> CoordinateParser(string plateuCoordinate)
        {
            plateuCoordinate = plateuCoordinate.Replace(" ", string.Empty);
            List<int> coordinates = new List<int>();
            coordinates.Add(Convert.ToInt16(plateuCoordinate.Substring(0, 1)));
            coordinates.Add(Convert.ToInt16(plateuCoordinate.Substring(1, 1)));
            return coordinates;
        }

        /*
        her rover tek bir "M" işlemi yapabildiği için 
        "M" sonrası, bir sonraki rover'ın yürütülmesini sağlana metod
         */ 
        public static int StartNextRoverMovementIndex(int roverLength,  int moveOccuredIndex)
        {
            if (moveOccuredIndex >= roverLength)
                return 0;
            else
                return moveOccuredIndex;
        }

        /*
        rover'lar rovers listesine eklendikten sonra her rover'a ait yön listesi kontrol edilir.
        mevcut varsa program devam eder.
        */
        public static bool hasMovementExist(ref List<BaseRover> rovers)
        {
            rovers = rovers.FindAll(s => s.roverMove.Count > 0);
            if (rovers.Count > 0)
                return true;
            else
                return false;
        }
        public static void enterDataRaw(ref List<string> inputs)
        {
            var info = Console.ReadKey();
            Console.WriteLine("VERİLERİ GİRİNİZ SONUCU GÖRMEK İÇİN exit yazınız");
            while (true)
            {

                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }
                else
                {
                    inputs.Add(line);
                }
            }
        }

    }
}
