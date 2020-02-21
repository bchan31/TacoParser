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
            //logger.LogInfo("Begin parsing");

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
                // Log that and return null
                logger.LogError("Invalid data format");
                // Do not fail if one record parsing fails, return null
                return null; 
            }

            // grab the latitude from your array at index 0
            var tryLat = double.TryParse(cells[0], out double latitude);
            // grab the longitude from your array at index 1
            var tryLong = double.TryParse(cells[1], out double longitude);
            // grab the name from your array at index 2
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