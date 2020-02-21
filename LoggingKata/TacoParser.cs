namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            if(line == null)
            {
                logger.LogError("Null Data Exception");
                return null;
            }

            var cells = line.Split(',');
            if(cells == null)
            {
                logger.LogError("Null Data Exception");
                return null;
            }
            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3 || cells.Length > 3)
            {
                logger.LogError("Invalid data format");
                return null; 
            }

            var tryLat = double.TryParse(cells[0], out double latitude);
            var tryLong = double.TryParse(cells[1], out double longitude);
            var name = cells[2];

            if(tryLat == false || tryLong == false)
            {
                return null;
            }
            
            var location = new TacoBell();
            location.Name = name;
            location.Location = new Point { Latitude = latitude, Longitude = longitude };

            return location;
        }
    }
}