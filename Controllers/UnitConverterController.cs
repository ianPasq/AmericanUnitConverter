using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AmuricaUnity.Models;

public class UnitConverterController : Controller
{
    private List<UnitCategory> _unitCategories;
    private List<ObjectCategory> _objectCategories;

    public UnitConverterController()
    {
        _unitCategories = new List<UnitCategory>
        {
            new UnitCategory
            {
                Name = "Length",
                Identifier = "lA",
                Units = new List<Unit>
                {
                    // Metric units
                    new Unit(0, "Meter", "iv", "iv"),          
                    new Unit(1, "Kilometer", "iv*1000", "iv/1000"),
                    new Unit(2, "Centimeter", "iv*0.01", "iv/0.01"),
                    new Unit(3, "Millimeter", "iv*0.001", "iv/0.001"),
                    new Unit(4, "Micrometer", "iv*0.000001", "iv/0.000001"),
                    new Unit(5, "Nanometer", "iv*0.000000001", "iv/0.000000001"),
                    // Imperial units
                    new Unit(6, "Mile", "iv*1609.34", "iv/1609.34"),
                    new Unit(7, "Yard", "iv*0.9144", "iv/0.9144"),
                    new Unit(8, "Foot", "iv*0.3048", "iv/0.3048"),
                    new Unit(9, "Inch", "iv*0.0254", "iv/0.0254"),
                    new Unit(10, "Light Year", "iv*9460730472580800", "iv/9460730472580800")
                },

            },

            new UnitCategory
            {
                Name = "Weight",
                Identifier = "weight",
                Units = new List<Unit>
                {
                    new Unit(0, "Kilogram", "iv", "iv"),
                    new Unit(1, "Gram", "iv*0.001", "iv/0.001"),
                    new Unit(2, "Milligram", "iv*0.000001", "iv/0.000001"),
                    new Unit(3, "Metric Ton", "iv*1000", "iv/1000"),
                    new Unit(4, "Pound", "iv*0.453592", "iv/0.453592"),
                    new Unit(5, "Ounce", "iv*0.0283495", "iv/0.0283495"),
                    new Unit(6, "Stone", "iv*6.35029", "iv/6.35029"),
                    new Unit(7, "Carat", "iv*0.0002", "iv/0.0002")
                },
                
            },


        };

        _objectCategories = new List<ObjectCategory>
        {
            new ObjectCategory
            {
                Name = "Length",
                Units = new List<ObjectUnit>
                {
                    new ObjectUnit { Name = "Meters", Multiplier = 1, Divisor = 1 },
                    new ObjectUnit { Name = "Inches", Multiplier = 0.0254, Divisor = 39.3701 },
                    new ObjectUnit { Name = "Centimeters", Multiplier = 0.01, Divisor = 100 }
                },
                Objects = new List<ObjectItem>
                {
                    new ObjectItem { Name = "Banana", BaseValue = 0.17 }, 

                    new ObjectItem { Name = "Soda Can", BaseValue = 0.12 } 
                }
            },
            new ObjectCategory
            {
                Name = "Weight",
                Units = new List<ObjectUnit>
                {
                    new ObjectUnit { Name = "Kilograms", Multiplier = 1, Divisor = 1 },
                    new ObjectUnit { Name = "Grams", Multiplier = 0.001, Divisor = 1000 },
                    new ObjectUnit { Name = "Pounds", Multiplier = 0.453592, Divisor = 2.20462 }
                },
                Objects = new List<ObjectItem>
                {
                    new ObjectItem { Name = "Banana", BaseValue = 0.101 } 
                }
            }
        };
    }

   public IActionResult Converter()
    {
        ViewBag.ObjectCategories = _objectCategories;
        return View(_unitCategories); 
    }

    [HttpPost]
    public JsonResult ConvertUnit(int categoryIndex, int fromUnitIndex, int toUnitIndex, double value)
    {
        var category = _unitCategories[categoryIndex];
        var fromUnit = category.Units[fromUnitIndex];
        var toUnit = category.Units[toUnitIndex];
        
        var baseValue = value * fromUnit.Multiplier;
        var result = baseValue * toUnit.Divisor; 
        
        return Json(new { result });
    }
    [HttpPost]
    public JsonResult ConvertObject(int objectCategoryIndex, int objectIndex, int unitIndex, double quantity)
    {
        try
        {
            var category = _objectCategories[objectCategoryIndex];
            var obj = category.Objects[objectIndex];
            var unit = category.Units[unitIndex];
            var result = (quantity * obj.BaseValue) * unit.Divisor;
            
            return Json(new { result });
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }
    }
}