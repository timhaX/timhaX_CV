using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreasLibrary;

namespace AreasLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArea()
        {
            double[,] sides = new double[3, 2] { { 0.1, 0.2 },
                                                 { 0.3, 0.4 },
                                                 { 0.5, 0.6 } };
            for(int i = 0; i < sides.GetLength(0); i++)
            {
                double result = sides[i, 0] * sides[i, 1];
                double fromLibrary = AreasLibrary.AreasShapes.Area(sides[i, 0], sides[i, 1]);
                Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);            
            }
        }
        [TestMethod]
        public void TestCircle()
        {
            double[] r ={ 0.1, 0.2 ,  0.3, 0.4 };
            for (int i = 0; i < r.Length; i++)
            {
                double result = Math.PI * r[i] * r[i];
                double fromLibrary = AreasLibrary.AreasShapes.AreaCircle(r[i]);
                Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
            }
        }
        [TestMethod]
        public void TestTriangleThreeSides()
        {
            double[,] sides = { { 0.1, 0.2, 0.3 },
                                { 0.4, 0.5, 0.6 },
                                { 0.7, 0.8, 0.9 } };
            for (int i = 0; i < sides.GetLength(0); i++)
            {                
                double p = (sides[i, 0] + sides[i, 1] + sides[i, 2]) / 2;                
                double result = Math.Sqrt(p * (p - sides[i, 0]) * (p - sides[i, 1]) * (p - sides[i, 2]));               
                double fromLibrary = AreasLibrary.AreasShapes.AreaTriangle(sides[i,0], sides[i,1], sides[i,2]);                
                Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result
                    + " sides " + sides[i, 0] + " " + sides[i, 1] + " " + sides[i, 2] + " p " + p);
            }
        }
        [TestMethod]
        public void TestTriangleBaseAndHeight()
        {
            double[,] sides = { { 0.1, 0.2 },
                                { 0.3, 0.4 },
                                { 0.5, 0.6 } };
            for (int i = 0; i < sides.GetLength(0); i++)
            {
                double result = 0.5 * sides[i, 0] * sides[i, 1];
                double fromLibrary = AreasLibrary.AreasShapes.AreaTriangle(sides[i, 0], sides[i, 1]);
                Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
            }
        }
        [TestMethod]
        public void TestIsRightTriangleTrue()
        {
            double[,] sides = { { 5, 4, 3 } };
            for (int i = 0; i < sides.GetLength(0); i++)
            {                
                bool fromLibrary = AreasLibrary.AreasShapes.isRightTriangle(sides[i, 0], sides[i, 1], sides[i, 2]);
                Assert.IsTrue(fromLibrary);
            }
        }
        [TestMethod]
        public void TestIsRightTriangleFalse()
        {
            double[,] sides = { { 8, 4, 3 } };
            for (int i = 0; i < sides.GetLength(0); i++)
            {
                bool fromLibrary = AreasLibrary.AreasShapes.isRightTriangle(sides[i, 0], sides[i, 1], sides[i, 2]);
                Assert.IsFalse(fromLibrary);
            }
        }
    }
}
