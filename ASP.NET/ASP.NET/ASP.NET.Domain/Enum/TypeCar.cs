using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name ="Легковой автомобиль")]
        PassengerCar=0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хетчбэк")]
        HatchBack = 2,
        [Display(Name = "Минивэен")]
        Minivan = 3,
        [Display(Name = "Спортивная машина")]
        SportsCar = 4,
        [Display(Name = "Внедорожник")]
        Suv = 5
    }
}
