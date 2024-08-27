using System;

public class Class1
{
	public class CinemaRepository 
	{
        //Opretter en ny liste, der indeholder Cinema-objekter 
        public List<Cinema> cinema = new List<Cinema>();
       

        public void SaveSchedule(Schedule schedule)
        {
            schedules.Add(schedule);

            SaveSchedulesToFile();
         
        }

        private void SaveSchedulesToFile()
        
        {
            using (StreamWriter writer = new("MovieDoc.txt"))
            {
                foreach (Cinema cinemas in cinema)
                {
                    writer.WriteLine($"{cinemas.Name},{cinemas.Screen},{cinemas.Schedule}");
                }
            }
        }


    }
	




	
}
