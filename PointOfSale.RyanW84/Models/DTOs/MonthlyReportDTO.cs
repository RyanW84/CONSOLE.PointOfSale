using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.EntityFramework.RyanW84.Models.DTOs;

internal class MonthlyReportDTO
    {
    public string Month {  get; set; }
    public decimal TotalPrice   {  get; set; }
    public int TotalQuantity { get; set; }
    }

