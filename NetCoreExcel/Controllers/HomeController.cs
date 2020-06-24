using Microsoft.AspNetCore.Mvc;
using NetCoreExcel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreExcel.Controllers
{
    public class HomeController : Controller
    {
        private List<Car> GetCars()
        {

            ICollection<Car> cars = new List<Car>()
            {
                new Car
                {
                    Anioe = "2005",
                    Codia = "G0010001",
                    CGrup = "979",
                    Marca = "ACURA",
                    Model = "ACURA TL 3.2 L 270 H.P. V6 IMP AUT 04 ABS CA CE PIEL CD CQ CB 05",
                    NGrup = "ACURA TL",
                    NMarca = "ACURA"
                },
                new Car
                {
                    Anioe = "2006",
                    Codia = "G0010001",
                    CGrup = "979",
                    Marca = "ACURA",
                    Model = "ACURA TL 3.2 L 270 H.P. V6 IMP AUT 04 ABS CA CE PIEL CD CQ CB 05",
                    NGrup = "ACURA TL",
                    NMarca = "ACURA"
                },
                new Car
                {
                    Anioe = "2007",
                    Codia = "G0010001",
                    CGrup = "979",
                    Marca = "ACURA",
                    Model = "ACURA TL 3.2 L 270 H.P. V6 IMP AUT 04 ABS CA CE PIEL CD CQ CB 05",
                    NGrup = "ACURA TL",
                    NMarca = "ACURA"
                }
            };

            return cars.Select(c =>
            {
                c.Creas = "0";
                c.NMarca = "0";
                c.NMode = "0";
                c.Pre01 = "0";
                c.Pre02 = "0";
                c.Pre03 = "0";
                c.Pre04 = "0";
                c.Pre05 = "0";
                c.Pre06 = "0";
                c.Pre07 = "0";
                c.Pre08 = "0";
                c.Pre09 = "0";
                c.Pre10 = "0";
                c.Pre11 = "0";
                c.Pre12 = "0";
                c.Pre13 = "0";
                c.Pre14 = "0";
                c.Pre15 = "0";
                c.Pre16 = "0";
                c.Pre17 = "0";
                c.Pre18 = "0";
                c.Pre19 = "0";
                c.Pre20 = "0";
                c.IDSX = "0";
                return c;
            }).ToList();
        }

        public IActionResult Index()
        {
            return CSV();
        }

        
        public IActionResult CSV()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[NMARCA],[MARCA],[NMODE],[MODEL],[CODIA],[NGRUP],[CGRUP],[CREAS],[ANIOE],[PRE01],[PRE02],[PRE03],[PRE04],[PRE05],[PRE06],[PRE07],[PRE08],[PRE09],[PRE10],[PRE11],[PRE12],[PRE13],[PRE14],[PRE15],[PRE16],[PRE17],[PRE18],[PRE19],[PRE20],[IDSX]");
            foreach (Car car in GetCars())
            {
                builder.AppendLine($"{car.NMarca},{car.Marca},{car.NMode},{car.Model},{car.Codia},{car.NGrup},{car.CGrup},{car.Creas},{car.Anioe},{car.Pre01},{car.Pre02},{car.Pre03},{car.Pre04},{car.Pre05},{car.Pre06},{car.Pre07},{car.Pre08},{car.Pre09},{car.Pre10},{car.Pre11},{car.Pre12},{car.Pre13},{car.Pre14},{car.Pre15},{car.Pre16},{car.Pre17},{car.Pre18},{car.Pre19},{car.Pre20},{car.IDSX}");
            }

            return File(
                Encoding.UTF8
                .GetBytes(builder.ToString()), "text/csv", "AUTOS.csv");
        }
    }
}
