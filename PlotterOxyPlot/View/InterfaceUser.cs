using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterOxyPlot.View
{
    class InterfaceUser
    {
        public static PlotModel Sonde { get; set; }

        public InterfaceUser() { Sonde = new PlotModel(); }
    }
}
