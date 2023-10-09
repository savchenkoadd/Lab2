using Lab2;

namespace Tests
{
	public class MatrixOperationsTest
	{
		[Fact]
		public void MyMatrix_OperatorValuesAreNull()
		{
			MyMatrix myMatrix1 = null!;

			MyMatrix myMatrix2 = null!;

			Assert.Throws<ArgumentNullException>(() =>
			{
				var a = myMatrix1 + myMatrix2;
			});
		}

		[Fact]
		public void MyMatrix_OperatorValuesAreDifferent()
		{
			MyMatrix myMatrix1 = new MyMatrix(1, 3);

			MyMatrix myMatrix2 = new MyMatrix(2, 5)!;

			Assert.Throws<InvalidOperationException>(() =>
			{
				var a = myMatrix1 + myMatrix2;
			});
		}

		[Fact]
		public void MyMatrix_RightOperatorValues()
		{
			double[,] array1 =
			{
				{ 1, 2, 3 },
				{ 1, 3, 3 },
			};

			double[,] array2 =
			{
				{ 12, 2, 5 },
				{ 1, 3, 3 },
			};

			MyMatrix myMatrix1 = new MyMatrix(array1);
			MyMatrix myMatrix2 = new MyMatrix(array2);

			double[,] expected =
			{
				{ 13, 4, 8 },
				{ 2, 6, 6 },
			};

			var actual = (myMatrix1 + myMatrix2).Matrix;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyMatrix_TransponedCopy()
		{
			double[,] array1 =
			{
				{ 1, 2, 3 },
				{ 1, 3, 3 },
			};
			double[,] expected =
			{
				{ 1, 1 },
				{ 2, 3 },
				{ 3, 3 }
			};

			MyMatrix myMatrix1 = new MyMatrix(array1);

			var actual = (myMatrix1.GetTransponedCopy()).Matrix;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyMatrix_Transponed()
		{
			double[,] array1 =
			{
				{ 1, 2, 3 },
				{ 1, 3, 3 },
			};

			MyMatrix myMatrix1 = new MyMatrix(array1);

			myMatrix1.TransponeMe();

			var actual = myMatrix1.Matrix;

			double[,] expected =
			{
				{ 1, 1 },
				{ 2, 3 },
				{ 3, 3 }
			};

			Assert.Equal(expected, actual);
		}
	}
}
