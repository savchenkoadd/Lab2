using Lab2;

namespace Tests
{
	public class MyTimeTest
	{
		[Fact]
		public void MyTime_IncorrectConstructorValues()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				MyTime myTime = new MyTime(-1, 21, 555);
			});
		}

		[Fact]
		public void MyTime_ToString()
		{
			MyTime myTime = new MyTime(9, 21, 23);

			string expected = "9:21:23";

			string actual = myTime.ToString();

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_SecondsSinceMidnight()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			var expected = 203;

			var actual = myTime.SecondsSinceMidnight();

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_AddNegativeSeconds()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				myTime.AddSeconds(-1);
			});
		}

		[Fact]
		public void MyTime_AddSeconds()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			myTime.AddSeconds(60);

			var actual = new int[] { myTime.Hour, myTime.Minute, myTime.Second };

			var expected = new int[] { 0, 4, 23 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_AddOneSecond()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			myTime.AddOneSecond();

			var actual = new int[] { myTime.Hour, myTime.Minute, myTime.Second };

			var expected = new int[] { 0, 3, 24 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_AddOneMinute()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			myTime.AddOneMinute();

			var actual = new int[] { myTime.Hour, myTime.Minute, myTime.Second };

			var expected = new int[] { 0, 4, 23 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_AddOneHour()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			myTime.AddOneHour();

			var actual = new int[] { myTime.Hour, myTime.Minute, myTime.Second };

			var expected = new int[] { 1, 3, 23 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_DifferenceNullValue()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			Assert.Throws<ArgumentNullException>(() =>
			{
				myTime.Difference(null);
			});
		}

		[Fact]
		public void MyTime_DifferenceWithSmallerInputValue()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			int expected = 180;
			int actual = myTime.Difference(new MyTime(0, 0, 23));

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_DifferenceWithBiggerInputValue()
		{
			MyTime myTime = new MyTime(0, 3, 23);

			int expected = 60;
			int actual = myTime.Difference(new MyTime(0, 4, 23));

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MyTime_WhatLesson()
		{
			List<string> expected = new List<string>()
			{
				"пари ще не почалися",
				"1-а пара",
				"перерва між 1-ю та 2-ю парами",
				"2-а пара",
				"перерва між 2-ю та 3-ю парами",
				"3-я пара",
				"перерва між 3-ю та 4-ю парами",
				"4-а пара",
				"перерва між 4-ю та 5-ю парами",
				"5-а пара",
				"перерва між 5-ю та 6-ю парами",
				"б-а пара",
				"пари вже скінчилися"
			};
			List<string> actual = new List<string>();

			List<MyTime> times = new List<MyTime>()
			{
				new MyTime(7, 30, 0),
				new MyTime(8, 20, 0),
				new MyTime(9, 35, 0),
				new MyTime(9, 50, 0),
				new MyTime(11, 10, 0),
				new MyTime(11, 40, 0),
				new MyTime(12, 45, 0),
				new MyTime(13, 10, 0),
				new MyTime(14, 30, 0),
				new MyTime(14, 50, 0),
				new MyTime(16, 13, 0),
				new MyTime(17, 0, 0),
				new MyTime(17, 21, 0),
			};

			foreach (var item in times)
			{
				actual.Add(item.WhatLesson());
			}

			Assert.Equal(expected, actual);
		}
	}
}
