using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;
using Assignment1.DataAccess;
using System.Data;

namespace Assignment1.Business
{
    public class BusGameDetails
    {
        public static List<GameDetails> GetGameDetails()
        {
            GameDetails IndivDemo = new GameDetails();
            var GameDetailsList = new List<GameDetails>();
            DataSet dsGetGameDetailsReport = new DataSet();

            dsGetGameDetailsReport = DAGetGameDetails.DAGetGameDetailsWithConfig();

            //Transfer Dataset details to List Object
            if (dsGetGameDetailsReport.Tables.Count > 0)
            {
                GameDetailsList = dsGetGameDetailsReport.Tables[0].AsEnumerable().Select(m => new GameDetails
                {
                    //Left side is Model Object - Right Side is Database columns
                    Id = Convert.ToString(m["Id"]),
                    Name = Convert.ToString(m["Name"]),
                    Platforms = Convert.ToString(m["Platforms"]),
                    Description = Convert.ToString(m["Description"])
                }).ToList();
            }

            return GameDetailsList;

        }

    }
}
