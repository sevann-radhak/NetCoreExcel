using Microsoft.AspNetCore.Mvc;
using NetCoreExcel.Models;
using NetCoreExcel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreExcel.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarService _carService;
        private readonly CarGroupService _carGroupService;

        public HomeController(
            CarService carService,
            CarGroupService carGroupService)
        {
            _carService = carService;
            _carGroupService = carGroupService;
        }

        public IActionResult Index()
        {
            List<CarGroup> carGroups = _carGroupService.GetCarCategories().ToList();
            List<CarRequest> carRequest = _carService.GetCarRequest().ToList();
            List<CarGroup> carGroupResponse = new List<CarGroup>();
            List<CarResponse> carResponse = new List<CarResponse>();

            carRequest.Select(cr =>
            {
                CarGroup carGroup = carGroups.Where(cg => cg.CGroup == cr.Amis).FirstOrDefault(); ;
                if (carGroup == null)
                {
                    int newCarGroupId = carGroups.Max(x => Convert.ToInt32(x.GroupId) + 1);
                    carGroup = new CarGroup
                    {
                        GroupId = newCarGroupId.ToString(),
                        CGroup = cr.Amis,
                        NGroup = cr.Tipo,
                        NMarc = cr.Marca
                    };
                    carGroups.Add(carGroup);
                    carGroupResponse.Add(carGroup);
                }

                CarResponse carResp = new CarResponse
                {
                    Anioe = cr.Modelo,
                    Codia = cr.Amis,
                    Model = cr.Descripcion,
                    Marca = cr.Marca,
                    NGrup = cr.Tipo,

                    CGrup = carGroup.GroupId,
                    Creas = "0",
                    IDSX = "0",
                    NMarca = "0",
                    NMode = "0",
                    Pre01 = "0",
                    Pre02 = "0",
                    Pre03 = "0",
                    Pre04 = "0",
                    Pre05 = "0",
                    Pre06 = "0",
                    Pre07 = "0",
                    Pre08 = "0",
                    Pre09 = "0",
                    Pre10 = "0",
                    Pre11 = "0",
                    Pre12 = "0",
                    Pre13 = "0",
                    Pre14 = "0",
                    Pre15 = "0",
                    Pre16 = "0",
                    Pre17 = "0",
                    Pre18 = "0",
                    Pre19 = "0",
                    Pre20 = "0"
                };
                carResponse.Add(carResp);
                return true;
            }).ToList();

            //return CarGroupCSV(carGroupResponse);
            return CarCSV(carResponse);
        }


        public IActionResult CarCSV(List<CarResponse> cars)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[NMARCA],[MARCA],[NMODE],[MODEL],[CODIA],[NGRUP],[CGRUP],[CREAS],[ANIOE],[PRE01],[PRE02],[PRE03],[PRE04],[PRE05],[PRE06],[PRE07],[PRE08],[PRE09],[PRE10],[PRE11],[PRE12],[PRE13],[PRE14],[PRE15],[PRE16],[PRE17],[PRE18],[PRE19],[PRE20],[IDSX]");
            foreach (CarResponse car in cars)
            {
                builder.AppendLine($"{car.NMarca},{car.Marca},{car.NMode},{car.Model},{car.Codia},{car.NGrup},{car.CGrup},{car.Creas},{car.Anioe},{car.Pre01},{car.Pre02},{car.Pre03},{car.Pre04},{car.Pre05},{car.Pre06},{car.Pre07},{car.Pre08},{car.Pre09},{car.Pre10},{car.Pre11},{car.Pre12},{car.Pre13},{car.Pre14},{car.Pre15},{car.Pre16},{car.Pre17},{car.Pre18},{car.Pre19},{car.Pre20},{car.IDSX}");
            }
            FileContentResult a = File(
                Encoding.UTF8
                .GetBytes(builder.ToString()), "text/csv", "AUTOS.csv");

            return File(
                Encoding.UTF8
                .GetBytes(builder.ToString()), "text/csv", "AUTOS.csv");
        }

        public IActionResult CarGroupCSV(List<CarGroup> carGroups)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[GroupID],[NMARC],[CGROUP],[NGROUP]");
            foreach (CarGroup carGroup in carGroups)
            {
                builder.AppendLine($"{carGroup.GroupId},{carGroup.NMarc},{carGroup.CGroup},{carGroup.NGroup}");
            }

            return File(
                Encoding.UTF8
                .GetBytes(builder.ToString()), "text/csv", "AUTOS_GROUP.csv");
        }
    }
}
