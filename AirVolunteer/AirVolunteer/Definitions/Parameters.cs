using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirVolunteer.Definitions
{
    public static class Parameters
    {
        public static String BaseUrl = "https://airvolunteer-drb3l7wtqa-rj.a.run.app";

        private static String _pilotIDFilePath = Path.Combine(FileSystem.CacheDirectory, "cpf");
        private static String _pilotID;

        public static String PilotID
        {
            get
            {
                if (String.IsNullOrEmpty(_pilotID))
                {
                    try
                    {
                        string data = File.ReadAllText(_pilotIDFilePath);
                        _pilotID = data;
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                }
                return _pilotID;
            }
            set
            {
                if (_pilotID != value)
                {
                    File.WriteAllTextAsync(_pilotIDFilePath, value);
                }
                _pilotID = value;
            }
        }

        public static readonly Color SplashBackgroundColor = Color.FromHex("#01304E"); // Change "#FF0000" to your desired color code

    }
}
