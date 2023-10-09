using System.Text;

namespace Lab2
{
	public partial class MyMatrix
	{
		private double[,] _matrix;

		public int Height => _matrix.GetLength(0);

		public int Width => _matrix.GetLength(1);

		public double this[int row, int column]
		{
			get
			{
				if (AreInvalidInputIndexes(row, column))
				{
					throw new ArgumentOutOfRangeException();
				}

				return _matrix[row, column];
			}
			set
			{
				if (AreInvalidInputIndexes(row, column))
				{
					throw new ArgumentOutOfRangeException();
				}

				_matrix[row, column] = value;
			}
		}

		public double[,] Matrix
		{
			get { return _matrix; }
		}

		public MyMatrix(int rows, int columns)
		{
			if (rows < 0 || columns < 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			_matrix = new double[rows, columns];
		}

		public MyMatrix(MyMatrix other)
		{
			_matrix = other.Matrix;
		}

		public MyMatrix(double[,] other)
		{
			_matrix = other;
		}

		public MyMatrix(double[][] other)
		{
			if (other == null || other.Length == 0 || other[0] == null || other[0].Length == 0)
			{
				throw new ArgumentException("Invalid input array.");
			}

			int numRows = other.Length;
			int numCols = other[0].Length;

			for (int i = 1; i < numRows; i++)
			{
				if (other[i].Length != numCols)
				{
					throw new ArgumentException("Input array should have consistent row lengths.");
				}
			}

			_matrix = new double[numRows, numCols];

			for (int i = 0; i < numRows; i++)
			{
				for (int j = 0; j < numCols; j++)
				{
					_matrix[i, j] = other[i][j];
				}
			}
		}

		public MyMatrix(string[]? rows)
		{
			if (rows == null || rows.Length == 0)
			{
				throw new ArgumentException("Input rows cannot be empty or null.");
			}

			int numRows = rows.Length;
			int numCols = rows[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
			_matrix = new double[numRows, numCols];

			for (int i = 0; i < numRows; i++)
			{
				string[] rowValues = rows[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

				if (rowValues.Length != numCols)
				{
					throw new ArgumentException("All rows must have the same number of columns.");
				}

				for (int j = 0; j < numCols; j++)
				{
					if (!double.TryParse(rowValues[j], out _matrix[i, j]))
					{
						throw new ArgumentException("Invalid numeric value in the input.");
					}
				}
			}
		}

		public double getElement(int row, int column)
		{
			if (AreInvalidInputIndexes(row, column))
			{
				throw new ArgumentOutOfRangeException();
			}

			return _matrix[row, column];
		}

		public void setElement(int row, int column, double value)
		{
			if (AreInvalidInputIndexes(row, column))
			{
				throw new ArgumentOutOfRangeException();
			}

			_matrix[row, column] = value;
		}

		public override string ToString()
		{
			StringBuilder result = new();

			for (int i = 0; i < _matrix.GetLength(0); i++)
			{
				for (int j = 0; j < _matrix.GetLength(1); j++)
				{
					result.Append($"{_matrix[i, j]}\t");
				}

				result.Append('\n');
			}

			return result.ToString();
		}

		private bool AreInvalidInputIndexes(int row, int column)
		{
			return Height < row || Width < column || row < 0 || column < 0;
		}
	}
}
