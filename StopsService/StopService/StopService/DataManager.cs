using StopService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopService
{
    public class DataManager
    {
        public static IEnumerable<StopRoutes> GetData(int stopName)
        {

            //Mock up the route and stop data
            List<StopRoutes> routesByStop = new List<StopRoutes>();
            List<DateTime> Route1 = new List<DateTime>();
            List<DateTime> Route2 = new List<DateTime>();
            List<DateTime> Route3 = new List<DateTime>();
            DateTime Route1loop = new DateTime(0);
            DateTime Route1loopStop = new DateTime(0);
            DateTime Route2loop = new DateTime(0);
            DateTime Route2loopStop = new DateTime(0);
            DateTime Route3loop = new DateTime(0);
            DateTime Route3loopStop = new DateTime(0);

            //Mock up data for 3 routes 2 minutes apart 
            Route1loop = Route1loop.Add(new TimeSpan(12, 00, 0)); //start at 12:00 PM
            Route1loopStop = Route1loopStop.Add(new TimeSpan(12, 00, 0)); //start at 12:00 PM
            Route2loop = Route2loop.Add(new TimeSpan(12, 02, 0)); //start at 12:02 PM
            Route2loopStop = Route2loopStop.Add(new TimeSpan(12, 02, 0)); //start at 12:00 PM
            Route3loop = Route3loop.Add(new TimeSpan(12, 04, 0)); //start at 12:04 PM
            Route3loopStop = Route3loopStop.Add(new TimeSpan(12, 04, 0)); //start at 12:04 PM
                                                                          //for (int x = 1; x <= 10; x++)
                                                                          //{
            for (int i = 0; i < 96; i++)
            {


                for (int stops = 1; stops < 11; stops++)
                {
                    //print it as 1:30 PM
                    Route1loopStop = Route1loopStop.Add(new TimeSpan(0, 2, 0));      //add 30 minutes
                    StopRoutes sr = new StopRoutes();
                    sr.StopName = stops;
                    sr.route = 1;
                    sr.StopTimeDT = Route1loopStop;
                    sr.StopTime = Route1loopStop.ToShortTimeString();
                    routesByStop.Add(sr);
                }
                Route1loopStop = Route1loop.Add(new TimeSpan(0, 15, 0));
                Route1loop = Route1loopStop;

            }

            for (int i = 0; i < 96; i++)
            {

                for (int stops = 1; stops < 11; stops++)
                {
                    //print it as 1:30 PM
                    Route2loopStop = Route2loopStop.Add(new TimeSpan(0, 2, 0));      //add 30 minutes
                    StopRoutes sr = new StopRoutes();
                    sr.StopName = stops;
                    sr.route = 2;
                    // var stopTime = Route1loop.Add(new TimeSpan(0, 2, 0));
                    sr.StopTimeDT = Route2loopStop;
                    sr.StopTime = Route2loopStop.ToShortTimeString();
                    routesByStop.Add(sr);
                }
                Route2loopStop = Route2loop.Add(new TimeSpan(0, 15, 0));
                Route2loop = Route2loopStop;
            }

            for (int i = 0; i < 96; i++)
            {


                for (int stops = 1; stops < 11; stops++)
                {
                    //print it as 1:30 PM
                    Route3loopStop = Route3loopStop.Add(new TimeSpan(0, 2, 0));      //add 30 minutes
                    StopRoutes sr = new StopRoutes();
                    sr.StopName = stops;
                    sr.route = 3;
                    sr.StopTimeDT = Route3loopStop;
                    sr.StopTime = Route3loopStop.ToShortTimeString();
                    routesByStop.Add(sr);
                }
                Route3loopStop = Route3loop.Add(new TimeSpan(0, 15, 0));
                Route3loop = Route3loopStop;
            }
            DateTime CurrentTime = System.DateTime.Now;
            //CurrentTime = CurrentTime.ToString("HH:mm"); 
            IEnumerable<StopRoutes> routes = (from StopRoutes in routesByStop
                          orderby StopRoutes.StopTimeDT.TimeOfDay ascending
                          where StopRoutes.StopName == stopName && StopRoutes.StopTimeDT.TimeOfDay > CurrentTime.TimeOfDay && StopRoutes.route==1
                          select new StopRoutes { StopName = StopRoutes.StopName,StopTimeDT=StopRoutes.StopTimeDT, StopTime = StopRoutes.StopTime , route=StopRoutes.route}).Take(2);
            IEnumerable<StopRoutes> routes2 = (from StopRoutes in routesByStop
                          orderby StopRoutes.StopTimeDT.TimeOfDay ascending
                          where StopRoutes.StopName == stopName && StopRoutes.StopTimeDT.TimeOfDay > CurrentTime.TimeOfDay && StopRoutes.route == 2
                          select new StopRoutes { StopName = StopRoutes.StopName, StopTimeDT = StopRoutes.StopTimeDT, StopTime = StopRoutes.StopTime, route = StopRoutes.route }).Take(2);
            IEnumerable<StopRoutes> routes3 = (from StopRoutes in routesByStop
                          orderby StopRoutes.StopTimeDT.TimeOfDay ascending
                          where StopRoutes.StopName == stopName && StopRoutes.StopTimeDT.TimeOfDay > CurrentTime.TimeOfDay && StopRoutes.route == 3
                          select new StopRoutes { StopName = StopRoutes.StopName, StopTimeDT = StopRoutes.StopTimeDT, StopTime = StopRoutes.StopTime, route = StopRoutes.route }).Take(2);

           //.List<IEnumerable<StopRoutes>> routesBack = new List<IEnumerable<StopRoutes>>();
            //routesBack.Add(routes);
            //routesBack.Add(routes2);
            //routesBack.Add(routes3);
            var totalroutes = routes.Concat(routes2);
            var final = totalroutes.Concat(routes3);
            IEnumerable<StopRoutes> query = final.OrderBy(final => final.StopTime);
            return query;
        }
    
}
}
