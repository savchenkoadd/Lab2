namespace Lab2
{
	public partial class MyMatrix
	{
		public static MyMatrix operator +(MyMatrix left, MyMatrix right)
		{
			if (left == null || right == null)
			{
				throw new ArgumentNullException("Matrix operands cannot be null.");
			}

			if (left.Height != right.Height || left.Width != right.Width)
			{
				throw new InvalidOperationException("Matrix dimensions must match for addition.");
			}

			int rows = left.Height;
			int columns = left.Width;
			MyMatrix result = new MyMatrix(rows, columns);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					result[i, j] = left[i, j] + right[i, j];
				}
			}

			return result;
		}

		public static MyMatrix operator *(MyMatrix left, MyMatrix right)
		{
			if (left == null || right == null)
			{
				throw new ArgumentNullException("Matrix operands cannot be null.");
			}

			if (left.Width != right.Height)
			{
				throw new InvalidOperationException("The number of columns in the left matrix must be equal to the number of rows in the right matrix for multiplication.");
			}

			int rows = left.Height;
			int columns = right.Width;
			int commonDimension = left.Width;
			MyMatrix result = new MyMatrix(rows, columns);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					double sum = 0;
					for (int k = 0; k < commonDimension; k++)
					{
						sum += left[i, k] * right[k, j];
					}
					result[i, j] = sum;
				}
			}

			return result;
		}

		public MyMatrix GetTransponedCopy()
		{
			double[,] transposedArray = GetTransposedArray();
			return new MyMatrix(transposedArray);
		}

		public void TransponeMe()
		{
			double[,] transposedArray = GetTransposedArray();
			_matrix = transposedArray;
		}

		private double[,] GetTransposedArray()
		{
			int rows = Height;
			int columns = Width;
			double[,] transposedArray = new double[columns, rows];

			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					transposedArray[i, j] = this[j, i];
				}
			}

			return transposedArray;
		}
	}
}
