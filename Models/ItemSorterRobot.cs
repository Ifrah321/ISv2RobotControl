using System;
using System.Collections.Generic;
using System.Globalization;

namespace Inventory_system.Models
{
    public class ItemSorterRobot
    {
        private static readonly Dictionary<uint, double[]> SlotPositions = new()
        {
            { 1, new [] { 0.35, -0.25, 0.15 } },
            { 2, new [] { 0.35,  0.00, 0.15 } },
            { 3, new [] { 0.35,  0.25, 0.15 } }
        };

        private readonly double[] boxPos = { 0.15, -0.40, 0.12 };

        public void PickUp(uint location)
        {
            var pos = SlotPositions[location];

            Console.WriteLine($"URScript → movej(p[{pos[0]}, {pos[1]}, {pos[2]}, 0, 0, 0])");
            System.Threading.Thread.Sleep(600);

            Console.WriteLine("Grab close");
            Console.WriteLine($"URScript → movej(p[{boxPos[0]}, {boxPos[1]}, {boxPos[2]}, 0, 0, 0])");
            System.Threading.Thread.Sleep(600);
            Console.WriteLine("Grab open");
        }
    }
}
