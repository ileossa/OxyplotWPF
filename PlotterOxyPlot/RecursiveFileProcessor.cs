using System.IO;

namespace PlotterOxyPlot
{

    class RecursiveFileProcessor
    {
        public string[] filePaths { get; set; }

        public RecursiveFileProcessor()
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            filePaths = Directory.GetFiles(@""+ appPath + "", "*.dt", SearchOption.AllDirectories);
         
        }
    }
}
