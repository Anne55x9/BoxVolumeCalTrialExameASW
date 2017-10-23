using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BoxVolumeCalTrialExameASW
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BoxCalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BoxCalService.svc or BoxCalService.svc.cs at the Solution Explorer and start debugging.
    public class BoxCalService : IBoxCalService
    {
        /// <summary>
        /// Connection string til database.
        /// </summary>
        private const string connectionString =
            "Server=tcp:annesazure.database.windows.net,1433;Initial Catalog=EasjDBasw;Persist Security Info=False;User ID=anne55x9;Password=Easj2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        /// <summary>
        /// Metode GetVolume og GetSide som henholdvis retunere et volumen af en boks. 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public double GetVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        /// <summary>
        /// Metode GetSide som retunere værdien af en manglende side af en boks ud fra 3 kendte parametre volume, side1 og side2. 
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="side1"></param>
        /// <param name="side2"></param>
        /// <returns></returns>

        public double GetSide(double volume, double side1, double side2)
        {
            return volume / (side1 * side2);
           
        }

        /// <summary>
        /// Metode som indsætter værdier i tabellen BoxCalRequest colonner. 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="volume"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void InsertBoxCalRequest(string request, double volume, double length, double width, double height)
        {
            const string insertRequest = "insert into boxcalrequest (request, volume, length, width, height) values (@request, @volume, @length, @width, @height)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertRequest, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@request", request);
                    insertCommand.Parameters.AddWithValue("@volume", volume);
                    insertCommand.Parameters.AddWithValue("@length", length);
                    insertCommand.Parameters.AddWithValue("@width", width);
                    insertCommand.Parameters.AddWithValue("@height", height);

                    insertCommand.ExecuteNonQuery();
               
                }
            }
        }

        /// <summary>
        /// Metode som henter alle udregninger i azure tabel.
        /// </summary>
        /// <returns></returns>
        public IList<BoxCalRequest> GetAllRequest()
        {
            const string selectAllRequests = "select * from boxcalrequest order by request";

            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllRequests, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<BoxCalRequest> requestList = new List<BoxCalRequest>();
                        while (reader.Read())
                        {
                            BoxCalRequest requests = ReadRequest(reader);
                            requestList.Add(requests);
                        }
                        return requestList;
                    }
                }
            }
        }

        private static BoxCalRequest ReadRequest(IDataRecord reader)
        {
            
            string request = reader.GetString(0);
            double volume = reader.GetDouble(1);
            double length = reader.GetDouble(2);
            double width = reader.GetDouble(3);
            double height = reader.GetDouble(4);
            BoxCalRequest req = new BoxCalRequest()
            {
                Request = request,
                Volume = volume,
                Length = length,
                Width = width,
                Height = height,
            };
            return req;
        }

    }
}
