using System;
using System.Collections.Generic;

namespace P02.MinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources =
                new Dictionary<string, int>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                //Skips the else and the nesting
                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }
                resources[resource] += quantity;
                //if (!resource.Contains(resource))
                //{
                //    resources[resource] = quantity;
                //}
                //else
                //{
                //    resources[resource] += quantity;
                //}
            }

            foreach (var rqp in resources)
            {
                Console.WriteLine($"{rqp.Key} -> {rqp.Value}");
            }
        }
    }
}
