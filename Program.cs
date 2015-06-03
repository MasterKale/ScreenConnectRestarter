using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace ScreenConnect_Restarter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of all services on the machine
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            // We'll use this later to display an error message if no ScreenConnect Client service was found
            Boolean foundService = false;

            foreach (ServiceController service in scServices)
            {
                if (service.ServiceName.Contains("ScreenConnect Client"))
                {
                    foundService = true;
                    
                    String serviceName = service.DisplayName;

                    Console.WriteLine("Found Service: " + serviceName);

                    try
                    {
                        if (service.Status == ServiceControllerStatus.Running)
                        {
                            Console.WriteLine("Stopping Service");
                            service.Stop();
                            Console.WriteLine("Waiting for Service to enter Stopped state");
                            service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                        }

                        Console.WriteLine("Restarting Service");
                        service.Start();
                        Console.WriteLine("Waiting for Service to enter Running state");
                        service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        Console.WriteLine(serviceName + " has successfully restarted");
                    }
                    else
                    {
                        Console.WriteLine(serviceName + " was unable to restart");
                        Console.WriteLine("Please restart your computer if you encounter further errors");
                    }
                }
            }

            if (!foundService)
            {
                Console.WriteLine("Unable to find any ScreenConnect Client services. Is one installed?");
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
