using DotNetTrainingChartWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartModel model = new ApexChartPieChartModel();

            model.Series = new int[] { 44, 55, 13, 43, 22 };
            model.Labels = new string[] { "Apple", "Mango", "Orange", "Watermelon", "Banana" };
           
            return View(model);
        }
    }
}
