using System;

public class Class1
{
	public class Playtime() 
	{
	 public datetime PlayTimeStart { get; set; }
	 public datetime PlayTimeEnd { get; set; }
	 public datetime PlayTimeDate { get; set; }
	 public string Movie { get; set; }
	 public int Screen { get; set; }

		public Playtime(datetime PlayTimeStart, datetime PlayTimeEnd, datetime PlayTimeDate, string Movie, int Screen) 
		{
		 PlayTimeStart = playTimeStart;
		 PlayTimeEnd = playTimeEnd;
		 PlayTimeDate = playTimeDate;
		 Movie = movie;
		 Screen = screen;
		
		}

	}
}
