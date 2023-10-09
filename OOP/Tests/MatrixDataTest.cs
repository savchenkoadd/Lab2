using Lab2;

namespace Tests
{
	public class MatrixDataTest
	{
		[Fact]
		public void MyMatrix_ProperIndexGetting()
		{
			//Arrange
			MyMatrix myMatrix = new MyMatrix(new double[,]
			{
				{ 1, 2, 3, 4 },
				{ 5, 6, 7, 8 },
				{ 9, 10, 11, 12 },
			});
			double expected = 8;

			//Act
			double actual = myMatrix[1, 3];

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyMatrix_NegativeIndexInIndexator()
		{
			MyMatrix myMatrix = new MyMatrix(new double[,]
			{
				{ 1, 2, 3, 4 },
				{ 5, 6, 7, 8 },
				{ 9, 10, 11, 12 },
			});

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				var a = myMatrix[-1, 1];
			});
		}

		[Fact]
		public void MyMatrix_ProperIndexesConstructor()
		{
			MyMatrix myMatrix = new MyMatrix(1, 3);

			var actual = new int[] { myMatrix.Height, myMatrix.Width };
			var expected = new int[] { 1, 3 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyMatrix_NegativeIndexesConstructor()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				MyMatrix myMatrix = new MyMatrix(-1, 3);
			});
		}

		[Fact]
		public void MyMatrix_OtherMatrixConstructor()
		{
			MyMatrix myMatrix1 = new MyMatrix(1, 2);

			MyMatrix myMatrix2 = new MyMatrix(myMatrix1);

			Assert.Equal(myMatrix1.Matrix, myMatrix2.Matrix);
		}

		[Fact]
		public void MyMatrix_Default2DArrayConstructor()
		{
			double[,] values =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			MyMatrix myMatrix2 = new MyMatrix(values);

			Assert.Equal(values, myMatrix2.Matrix);
		}

		[Fact]
		public void MyMatrix_Jagged2DArrayConstructor()
		{
			double[][] values =
			{
				new double[] { 1, 2, 3 },
				new double[] { 4, 5, 6 }
			};

			MyMatrix myMatrix2 = new MyMatrix(values);

			Assert.Equal(new double[,]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			}, myMatrix2.Matrix);
		}

		[Fact]
		public void MyMatrix_NullStringArrayConstructor()
		{
			string[]? values = null;

			Assert.Throws<ArgumentException>(() =>
			{
				MyMatrix myMatrix = new MyMatrix(values);
			});
		}

		[Fact]
		public void MyMatrix_EmptyStringArrayConstructor()
		{
			string[]? values = new string[0];

			Assert.Throws<ArgumentException>(() =>
			{
				MyMatrix myMatrix = new MyMatrix(values);
			});
		}

		[Fact]
		public void MyMatrix_DifferentRowsStringArrayConstructor()
		{
			string[]? values =
			{
				"1 2 3",
				"1 2"
			};

			Assert.Throws<ArgumentException>(() =>
			{
				MyMatrix myMatrix = new MyMatrix(values);
			});
		}

		[Fact]
		public void MyMatrix_InvalidValueStringArrayConstructor()
		{
			string[]? values =
			{
				"1 2 3",
				"1 b"
			};

			Assert.Throws<ArgumentException>(() =>
			{
				MyMatrix myMatrix = new MyMatrix(values);
			});
		}

		[Fact]
		public void MyMatrix_ProperStringArrayConstructor()
		{
			string[]? values =
			{
				"1 2 3",
				"1 3 4"
			};

			MyMatrix myMatrix = new MyMatrix(values);

			Assert.Equal(myMatrix.Matrix, new double[,]
			{
				{ 1, 2, 3 },
				{ 1, 3, 4 }
			});
		}

		[Fact]
		public void MyMatrix_GetElementWithNegativeIndexes()
		{
			double[,] values =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			MyMatrix myMatrix = new MyMatrix(values);

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				myMatrix.getElement(-1, 1);
			});
		}

		[Fact]
		public void MyMatrix_GetElementWithProperIndexes()
		{
			double[,] values =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			MyMatrix myMatrix = new MyMatrix(values);

			Assert.Equal(6, myMatrix.getElement(1, 2));
		}

		[Fact]
		public void MyMatrix_SetElementWithNegativeIndexes()
		{
			double[,] values =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			MyMatrix myMatrix = new MyMatrix(values);

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				myMatrix.setElement(-1, 1, 13);
			});
		}

		[Fact]
		public void MyMatrix_ProperToString()
		{
			double[,] values =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			MyMatrix myMatrix = new MyMatrix(values);

			string expected = "1\t2\t3\t\n4\t5\t6\t\n";

			Assert.Equal(expected, myMatrix.ToString());
		}
	}
}