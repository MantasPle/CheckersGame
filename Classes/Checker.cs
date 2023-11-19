using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Classes
{
    public class Checker
    {
        public Panel Panel { get; set; }

        public Checker(Panel panel)
        {
            Panel = panel;
        }

    }
}
