namespace Lab2
{
	public class MyTime
	{
		private int _hour, _minute, _second;

		public int Hour => _hour;
		public int Minute => _minute;
		public int Second => _second;

		public MyTime(int hour, int minute, int second)
		{
			if (hour > 23 || minute > 59 || second > 59 ||
				hour < 0 || minute < 0 || second < 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			_hour = hour;
			_minute = minute;
			_second = second;
		}

		public override string ToString()
		{
			return $"{Hour}:{Minute:D2}:{Second:D2}";
		}

		public int SecondsSinceMidnight()
		{
			return Hour * 3600 + Minute * 60 + Second;
		}

		public void AddSeconds(int s)
		{
			if (s < 0)
			{
				throw new ArgumentOutOfRangeException("s", "Number of seconds cannot be negative.");
			}

			int totalSeconds = SecondsSinceMidnight() + s;
			_hour = totalSeconds / 3600 % 24;
			_minute = (totalSeconds % 3600) / 60;
			_second = totalSeconds % 60;
		}

		public void AddOneSecond()
		{
			AddSeconds(1);
		}

		public void AddOneMinute()
		{
			AddSeconds(60);
		}

		public void AddOneHour()
		{
			AddSeconds(3600);
		}

		public int Difference(MyTime mt)
		{
			if (mt is null)
			{
				throw new ArgumentNullException();
			}

			return Math.Abs(SecondsSinceMidnight() - mt.SecondsSinceMidnight());
		}

		public string WhatLesson()
		{
			int totalMinutes = Hour * 60 + Minute;

			if (totalMinutes < 8 * 60)
			{
				return "пари ще не почалися";
			}
			else if (totalMinutes < 9 * 60 + 20)
			{
				return "1-а пара";
			}
			else if (totalMinutes < 9 * 60 + 40)
			{
				return "перерва між 1-ю та 2-ю парами";
			}
			else if (totalMinutes < 11 * 60)
			{
				return "2-а пара";
			}
			else if (totalMinutes < 11 * 60 + 20)
			{
				return "перерва між 2-ю та 3-ю парами";
			}
			else if (totalMinutes < 12 * 60 + 40)
			{
				return "3-я пара";
			}
			else if (totalMinutes < 13 * 60)
			{
				return "перерва між 3-ю та 4-ю парами";
			}
			else if (totalMinutes < 14 * 60 + 20)
			{
				return "4-а пара";
			}
			else if (totalMinutes < 14 * 60 + 40)
			{
				return "перерва між 4-ю та 5-ю парами";
			}
			else if (totalMinutes < 16 * 60)
			{
				return "5-а пара";
			}
			else if (totalMinutes < 16 * 60 + 20)
			{
				return "перерва між 5-ю та 6-ю парами";
			}
			else if (totalMinutes < 17 * 60 + 20)
			{
				return "б-а пара";
			}
			else
			{
				return "пари вже скінчилися";
			}
		}
	}
}
