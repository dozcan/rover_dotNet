using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    public class Program
    {        
        /*
        * 
        *
        * BU program hiç bir şekilde giriş sayısı, giriş tipi, boyut ve tip kontrolü yapmamakta 
        ve exception handling yapısı içermemektedir, girişlerin ve tiplerin uygun olmasını beklemektedir.
        sadece algoritmaya odaklanılmış ve kod fazlalığından kaçınılmıştır.
        her bir rover bilgisi girdikten ve enter tuşuna basıldıktan sonra girişler bitti ise
        exit yazılarak sonuçlar görülebilmektedir.
        *
        * 
        * 
        */
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int moveOccuredIndex = 0;
            List<string> directions;
            List<string> inputs = new List<string>();

            // console girişleri kontrol edilir
            Helper.enterDataRaw(ref inputs);

             //plato yaratılır
             var plateau = Factory.createPlateau(Helper.CoordinateParser(inputs[0]));
             List<BaseRover> rovers = new List<BaseRover>();

             //işimiz bittiği için plato bilgileri listeden çıkarılır
             inputs.RemoveAt(0);

             for(int i=0;i< inputs.Count;) { 

                 string roverCompass = inputs[i].Substring(4, 1);  // doğrultu bilgisi oluşturulur
                 directions = Helper.DirectionParser(inputs[i+1]); // "L-R bilgileri oluşturulur
                 rovers.Add(Factory.createRover(roverCompass, directions, Helper.CoordinateParser(inputs[i])));
                 inputs.RemoveAt(i);// mevcut ise bir sonraki rover geçiş için mevcut rover listeden silinir
                 inputs.RemoveAt(i);
             };
           

            // rover'ların bulunduğu rovers listesi dolu olduğu sürece kontrol devam eder
            while (Helper.hasMovementExist(ref rovers))
            {
                //ilk hareket sonrası bir sonraki rover hazırlanır
                int nextRoverIndex = Helper.StartNextRoverMovementIndex(rovers.Count,  moveOccuredIndex);
                var nextRover = rovers[nextRoverIndex];
                //bir sonraki rover'a ait yön doğrultu ve koordinat bilgisine geçilir
                nextRover.ManipulateDirectionAndCoordinate(rovers,ref moveOccuredIndex);      
                // bu döngü bütün işlemini tamamlamış rover var ise yürütülür
                if (nextRover.roverMove.Count < 1) {
                    string result = String.Concat(nextRover.x_coordinate, " " + nextRover.y_coordinate, " ", nextRover.defaultDirection);
                    sb.Append(result);
                    Console.WriteLine(sb);
                    sb.Clear();
                }
            }
            Console.ReadLine();
        }

    }
}
