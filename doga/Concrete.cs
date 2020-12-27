using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    public class plateau
    {
        private int x_coordinate;
        private int y_coordinate;
        public plateau(int _x_coordinate, int _y_coordinate)
        {
            x_coordinate = _x_coordinate;
            y_coordinate = _y_coordinate;
        }
    }
    public class ConcreteRover : BaseRover
    {
        public ConcreteRover(string _defaultDirection,List<string>_roverMove, int _x_coordinate, int _y_coordinate)
        {
            name = _defaultDirection;
            defaultDirection = _defaultDirection;
            roverMove = _roverMove;
            x_coordinate = _x_coordinate;
            y_coordinate = _y_coordinate;
        }

        //rover nesnesine ait anlık "M" sonrası koordinat hesaplanır
        public override void ManipulateNextCoordinate()
        {
            switch (this.defaultDirection)
            {
                case "N": this.y_coordinate = this.y_coordinate + 1; break;
                case "S": this.y_coordinate = this.y_coordinate - 1; break;
                case "W": this.x_coordinate = this.x_coordinate - 1; break;
                case "E": this.x_coordinate = this.x_coordinate + 1; break;
                default: break;
            }
        }

        /*
        N:kuzey, E:doğu, S:güney, W:batı
        rover'a ait anlık yön durumuna göre(L-R?)
        bir sonraki doğrultu bulunur.    
        */
        public override void FindDirection(int roverDirectionStatus)
        {
            string[] DIRECTION = { "N", "E", "S", "W" };
            int ilkDurumIndex = Array.IndexOf(DIRECTION,this.defaultDirection);
            if (this.roverMove[roverDirectionStatus] == "R")
            {
                if (ilkDurumIndex + 1 == DIRECTION.Length)
                    this.defaultDirection = DIRECTION[0];
                else
                    this.defaultDirection = DIRECTION[ilkDurumIndex + 1];
            }
            else if (this.roverMove[roverDirectionStatus] == "L")
            {
                if (ilkDurumIndex - 1 < 0)
                    this.defaultDirection = DIRECTION[DIRECTION.Length - 1];
                else
                    this.defaultDirection = DIRECTION[ilkDurumIndex - 1];
            }
        }
        /*
        rover'a ait anlık doğrultuyu bulan FindDirection ve koordinatı hesaplayan 
        ManipulateNextCoordinate metodunu çağıran bu metod asıl görevi her "M" sonrası bir sonraki
        rover'ın hareketini sağlamaktır.
        genel olarak olarak kullanılan RemoveAt metodları listeyi shift yapmaktadır ki
        iterasyon rahat yapılsın ve gözlenebilsin.
        */
        public override void ManipulateDirectionAndCoordinate(List<BaseRover> rovers, ref int moveOccuredIndex)
        {
            bool moveOccured = false;
            for (int i = 0; i < this.roverMove.Count;)
            {
                this.FindDirection(i);
                if (this.roverMove[i] == "M")
                {
                    this.ManipulateNextCoordinate();
                    moveOccured = true;
                    moveOccuredIndex = rovers.FindIndex(rover => rover == this) + 1;
                }

                this.roverMove.RemoveAt(0);
                if (moveOccured) break;
            }
        }
    }

   
}
