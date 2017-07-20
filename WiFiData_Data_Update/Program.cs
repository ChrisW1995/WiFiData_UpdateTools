using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WiFiData_Data_Update.Model;

namespace WiFiData_Data_Update
{
    class Program
    {
        static string location_Name = "";
        enum locationID 
        {
           N = 1,
           成 = 2,
           峰 = 3,
           忠 = 4,
           恩 = 5,
           功 = 6

        }
        static void Main(string[] args)
        {
            bool b = true;
            while (b)
            {
                
                Console.Write("Plz Enter a locationID to update data [ 1:N / 2:成 / 3:峰 / 4:忠 / 5:恩 / else ID to exit...]：");

                locationID location;
                bool result = Enum.TryParse(Console.ReadLine(),out location);
                if (!result)
                {
                    Console.WriteLine("Plz Enter integer value..");
                    continue;
                }
                switch (location)
                {
                    case locationID.N:
                        location_Name = "大恩館";
                        UpdateData(locationID.N.ToString());
                        break;
                    case locationID.峰:
                        location_Name = "曉峰紀念館";
                        UpdateData(locationID.峰.ToString());
                        break;
                    case locationID.忠:
                        location_Name = "大忠館";
                        UpdateData(locationID.忠.ToString());
                        break;
                    case locationID.成:
                        location_Name = "大成館";
                        UpdateData(locationID.成.ToString());
                        break;
                    case locationID.恩:
                        location_Name = "大恩館";
                        UpdateData(locationID.恩.ToString());
                        break;
                    case locationID.功:
                        location_Name = "大功館";
                        UpdateData(locationID.功.ToString());
                        break;
                    default:
                        b = false;
                        break;
                }
                //Console.Write(location);
            }
            
            
            //Console.Write(location);
        }

        public static void UpdateData(string locationStr)
        {
            Console.WriteLine("Progressing...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (SurveyModel _context = new SurveyModel())
            {
                _context.Configuration.AutoDetectChangesEnabled = false;
                var query = (from c in _context.wifi_list
                            where c.location_code.Substring(0, 1) == locationStr
                            select c).ToList();

                for(int i = 0; i < query.Count; i++)
                {
                    int start_position=0, last_position=0;
                    var q = query[i];

                    //---------------------------
                    string floor = "", _roomId = "";
                    string str_locationId = q.location_code.ToString();

                    if (str_locationId.Substring(1, 1) != "B") // normal floor
                    {
                        start_position = str_locationId.IndexOf(locationStr);
                        if (!str_locationId.Contains("F")) //classroom
                        {
                            last_position = str_locationId.IndexOf('-') != -1? str_locationId.IndexOf('-'):str_locationId.Length;
                            floor = last_position - start_position == 4 ?
                                str_locationId.Substring(1, 1) : str_locationId.Substring(1, 2); // sigle num. floor : two num. floor

                            _roomId = floor.Length == 1 ?
                                str_locationId.Substring(1, 3) : str_locationId.Substring(1, 4); //Ex : ID =  200 : 1000


                        }
                        else //aisle
                        {
                            floor = str_locationId.Substring(1,
                               str_locationId.IndexOf('F') - (str_locationId.IndexOf(locationStr) + 1));
                        }
                    }
                    else //if is basement floor
                    {

                        floor = str_locationId.Substring(1, 2);// Ex : B1
                        if (!str_locationId.Contains("F")) //basement classroom
                        {
                            last_position = str_locationId.IndexOf('-') != -1 ? str_locationId.IndexOf('-') : str_locationId.Length;
                            _roomId = str_locationId.Substring(1,
                                last_position - str_locationId.IndexOf('B'));

                        }

                    }
                    q.floor = floor;
                    q.location = location_Name;
                    q.roomId = _roomId;               
                    Console.Write($"{str_locationId} = floor:{floor}\troomId:{_roomId}\tlocation_Name:{location_Name}\n");

                }
                Console.WriteLine("wait a second .. data updating..");
                
                _context.BulkUpdate(query);
                sw.Stop();
                Console.WriteLine($"Update have finished. Plz check your data ( affect {query.Count} records. Consume time：{sw.Elapsed.TotalSeconds} s. )\n-----------------\n");
            }
        }
     
    }
}
