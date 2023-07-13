using System;
using System.Collections.Generic;

namespace RegisterApp
{
    class Program
    {
        static EndpointRepository repository = new EndpointRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "6")
            {
                switch (userOption)
                {
                    case "1":
                        InsertEndpoint();
                        break;
                    case "2":
                        UpdateEndpoint();
                        break;
                    case "3":
                        DeleteEndpoint();
                        break;
                    case "4":
                        ListEndpoints();
                        break;
                    case "5":
                        FindEndpoint();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.ReadLine();
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like today?");

            Console.WriteLine("1 - Insert a new endpoint");
            Console.WriteLine("2 - Edit an existing endpoint");
            Console.WriteLine("3 - Delete an existing endpoint");
            Console.WriteLine("4 - List all endpoints");
            Console.WriteLine("5 - Find an endpoint by endpoint serial number");
            Console.WriteLine("6 - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
        private static void InsertEndpoint()
        {
            Console.WriteLine("Insert a new endpoint: \r\n");

            Console.Write("Inform the serial number: ");
            int serialNumber = int.Parse(Console.ReadLine());

            var lista = repository.List();

            if (lista.Count != 0)
            {
                for (var i = 0; i < lista.Count; i++)
                {
                    if (lista[i].SerialNumber == serialNumber)
                    {
                        throw new ArgumentException("This serial number is already in use!");
                    }
                }
            }

            foreach (int i in Enum.GetValues(typeof(SwitchState)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(SwitchState), i));
            }

            Console.Write("Inform the Switch State: ");
            int switchState = int.Parse(Console.ReadLine());

            
            Console.Write("Inform the Meter Model Id: ");
            int meterModelId = int.Parse(Console.ReadLine());

            Console.Write("Inform the Meter Number: ");
            int meterNumber = int.Parse(Console.ReadLine());

            Console.Write("Inform the Meter Firmware Version: ");
            string meterFirmwareVersion = Console.ReadLine();


            Endpoint newEndpoint = new Endpoint(serialNumber: serialNumber,
                                        meterModelId: (MeterModelId)meterModelId,
                                        meterNumber: meterNumber,
                                        meterFirmwareVersion: meterFirmwareVersion,
                                        switchState: (SwitchState)switchState);

            repository.Insert(newEndpoint);
        }
        private static void UpdateEndpoint()
        {
            Console.Write("\r\nInform the serial number of the endpoint you want to update: \r\n");
            int endpointSerialNumber = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(SwitchState)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(SwitchState), i));
            }

            Console.Write("Inform the new Switch State: ");
            int switchState = int.Parse(Console.ReadLine());
            var st = (SwitchState)switchState;

            repository.Update(endpointSerialNumber, st);
        }
        private static void DeleteEndpoint()
        {
            Console.Write("\r\nInforme the endpoint serial number that you want to delete: \r\n");
            int endpointSerialNumber = int.Parse(Console.ReadLine());

            repository.Exclude(endpointSerialNumber);
        }
        private static void ListEndpoints()
        {
            
           Console.WriteLine("Endpoints: \r\n");

            var list = repository.List();
            int i = 0;
            if (list.Count == 0)
            {
                Console.WriteLine("There's no endpoints registered yet!\r\n");
                return;
            }
            foreach(var endpoint in list)
            { 
                var excluded =  endpoint.returnExcluded();

                if (!excluded)
                {
                    Console.WriteLine(
                    $"#Endpoint {i+1}:\r\n Serial Number: {endpoint.returnSerialNumber()} \r\n Meter Model Id:  {endpoint.returnMeterModelId()} \r\n Meter Number:  {endpoint.returnMeterNumber()} \r\n Meter Firmware Version:  {endpoint.returnMeterFirmwareVersion()} \r\n Switch State:  {endpoint.returnSwitchState()}");

                    i++;
                }

            }
        }

        private static void FindEndpoint()
        {
            Console.Write("Inform the endpoint's serial number that you want to visualize: ");
            int serialNumber = int.Parse(Console.ReadLine());

            var list = repository.List();
            Endpoint obj = null;
            if (list.Count != 0)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].SerialNumber == serialNumber)
                    {
                        obj = list[i];
                    }
                }
            }

            Console.WriteLine($"#Endpoint Details: Serial Number: {obj.returnSerialNumber()} - Meter Model Id:  {obj.returnMeterModelId()} - Meter Number:  {obj.returnMeterNumber()} - Meter Firmware Version:  {obj.returnMeterFirmwareVersion()} - Switch State:  {obj.returnSwitchState()}");
        }

    }
}
