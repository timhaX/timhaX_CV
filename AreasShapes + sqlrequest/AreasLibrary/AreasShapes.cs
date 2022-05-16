using System;


namespace AreasLibrary
{
    public class AreasShapes
    {
        //Площадь квадратов, прямоугольников и параллелограммов
        public static double Area(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Sides should be > 0");
            }
            return width * height;
        }
        //Площадь кругов
        public static double AreaCircle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius should be > 0");
            }
            return Math.PI * Math.Pow(radius, 2);
        }
        //Площадь треугольников
        public static double AreaTriangle(double sideOne, double sideTwo, double sideThree)
        {
            if (sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
            {
                throw new ArgumentException("Sides should be > 0");
            }
            double p = (sideOne + sideTwo + sideThree) / 2;
            if(p < sideOne || p < sideTwo || p < sideThree)
            {
                throw new ArgumentException("p should be >= any side of triangles");
            }
            return Math.Pow((p * (p - sideOne) * (p - sideTwo) * (p - sideThree)),0.5);
        }
        public static double AreaTriangle(double b, double height)
        {
            if (b <= 0 || height <= 0)
            {
                throw new ArgumentException("Base and height should be > 0");
            }

            return 0.5 * b * height;
        }
        //Проверка прямоугольного треугольника
        public static bool isRightTriangle(double sideOne, double sideTwo, double sideThree)
        {
            if (sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
            {
                throw new ArgumentException("Sides should be > 0");
            }
            double maxSide = Math.Max(Math.Max(sideOne, sideTwo), sideThree);
            return (maxSide * maxSide) == (maxSide == sideOne ? sideTwo * sideTwo + sideThree * sideThree :
                                            maxSide == sideTwo ? sideOne * sideOne + sideThree * sideThree :
                                            sideOne * sideOne + sideTwo * sideTwo);
        }
    }
}
