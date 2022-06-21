// See https://aka.ms/new-console-template for more information
using EventLogCollector;
var date =DateTime.Now.Subtract(TimeSpan.FromDays(3));
var dateFormat = date.ToString("yyyy-MM-ddTHH:mm:ss");
var query = $"*[System[(Level>=2 and Level<=3) and TimeCreated/@SystemTime >= '{dateFormat}']]";
if(Collector.Collect("Application", query, "EventLog.evtx"))
{
    Console.WriteLine("Success");
}