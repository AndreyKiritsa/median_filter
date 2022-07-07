using System.Linq;
using System;
namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double SortValue(double[] mediadValue, int countRow, int countCol)
        {
			double res = 0.0;
			Array.Sort(mediadValue);
			if ((countRow*countCol)%2 == 0)
            {
				int index = (countRow*countCol)/2;
				res = (mediadValue[index-1]+mediadValue[index])/2;
            }
			else
            {
				int index = (countRow*countCol)/2;
				res = mediadValue[index];
            }
			return res;
        }
		public static double Median(int Row, int Col, int countRow, int countCol, double[,] original)
        {
			double[] mediadValue = new double[countRow*countCol];
			int count = 0;
			var res = 0.0;
			if(Row == original.GetLength(0)-1 && Row != 0)
				Row--;
			if (Col == original.GetLength(1)-1 && Col != 0)
				Col--;
			for (int i = 0; i < countRow; i++)
            {
				for (int j = 0; j < countCol; j++)
                {
					mediadValue[count] = original[Row, Col];
					count++;
					Col++;
                }
				Row++;
				Col=Col-countCol;
            }
			res = SortValue(mediadValue, countRow, countCol);
			return res;
        }
		public static (int,int) Index(double[,] original)
        {
			var indR = 2;
			var indC = 2;
			if (original.GetLength(0) < 2)
            {
				indR = 1;
            }
			if(original.GetLength(1) < 2)
            {
				indC = 1;
            }
			return (indR, indC);
        }
		public static double Value(int i, int j, double[,] original)
        {
			int indR = 0;
			int indC = 0;
			(indR, indC) = Index(original);
            double res = 0.0;
			if  (j == 0 || j == original.GetLength(1)-1)
            { 
				if ((j - 1) < 0)
                { 
					res = Median(i, j, indR, indC, original);
				}
				else
                { 
					res = Median(i, j-1, indR, indC, original);
				}
			}
			else
            {
				res = Median(i, j-1, indR, 3, original);
            }
			return res;
        }
		public static double GoToFunction(int lenRow, int lenCol,
			int indC, int i, int j, double[,] original)
        {
			double res = 0.0;
			if(i==0 || i == lenRow-1)
            {
				res = Value(i, j, original);
            }
			else if (j==0 || j == lenCol-1)
            {
						
				res = Median(i-1, j, 3, indC, original);
            }
			else
            {
				res = Median(i-1, j-1, 3, 3, original);
            }
			return res;
        }
		public static double[,] MedianFilter(double[,] original)
		{
			double[,] result = new double[original.GetLength(0), original.GetLength(1)];
			int lenRow = original.GetLength(0);
			int lenCol = original.GetLength(1);
			double res = 0.0;
			var indC = 2;
			if (original.GetLength(1) < 2)
            {
				indC = 1;
            }
			for (int i =0; i < lenRow; i++)
            {
				for (int j =0; j < lenCol; j++)
                {
					res = GoToFunction(lenRow, lenCol, indC, i, j, original);
					result[i,j] = res;

                }
            }				
			return result;
		}
	}
}
