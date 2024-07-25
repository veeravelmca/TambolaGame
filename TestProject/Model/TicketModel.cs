using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public class TicketModel
    {
        public int[,] Numbers { get; set; } = new int[3, 5];
        public bool[,] Crossed { get; set; } = new bool[3, 5];
    }
}

