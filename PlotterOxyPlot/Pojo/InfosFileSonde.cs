using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterOxyPlot.Pojo
{
    class InfosFileSonde
    {
        private List<Sonde> datas { get; set; }
        private string name { get; set; }

        public InfosFileSonde(List<Sonde> datas, string name)
        {
            this.datas = datas;
            this.name = name;
        }

        
    }
}
