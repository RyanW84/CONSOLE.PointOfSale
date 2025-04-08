using System.Globalization;

using PointOfSale.EntityFramework.RyanW84.Controllers;
using PointOfSale.EntityFramework.RyanW84.Models.DTOs;

namespace PointOfSale.EntityFramework.RyanW84.Services;

internal class ReportService
    {
    internal static void CreateMonthlyReport()
        {
        var orders = OrderController.GetOrders();

        var report = orders.GroupBy(x => new //Linq creates anonymous object
            {
            x.CreatedDate.Month
            })
            .Select(grp => new MonthlyReportDTO
                {
                //Igrouping links elements by Key
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Month),
                TotalPrice = grp.Sum(grp => grp.TotalPrice),
                TotalQuantity = grp.Sum(x => x.OrderProducts.Sum(x => x.Quantity))
                }).ToList();

        UserInterface.ShowReportByMonth(report);
        }
    }

