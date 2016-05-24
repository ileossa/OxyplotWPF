using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using PlotterOxyPlot.Pojo;
using System.ComponentModel;

namespace PlotterOxyPlot
{
    public class FileBusiness
    {

        public FileBusiness()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\ileossa\Desktop\SmartHome\ecole\capteurs.xtim");
            

            //XmlNodeList nodes = doc.DocumentElement.GetElementsByTagName("capteur");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("descendant::capteurs");

            Console.Write(nodes);
            List<OptionsData> listeCapteurs = new List<OptionsData>();
            List<InfosFileSonde> listInfosFileSonde = new List<InfosFileSonde>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                OptionsData optionData = new OptionsData();

                optionData.capteurType = node.Attributes["type"].InnerText;
                optionData.id = node.SelectSingleNode("id").InnerText;
                optionData.description = node.SelectSingleNode("description").InnerText;
                optionData.grandeurUnite = node.SelectSingleNode("grandeur").Attributes["unite"].InnerText;
                optionData.grandeurNom = node.SelectSingleNode("grandeur").Attributes["nom"].InnerText;
                optionData.grandeurAbreviation = node.SelectSingleNode("grandeur").Attributes["abreviation"].InnerText;
                optionData.box = node.SelectSingleNode("box").InnerText;
                optionData.lieu = node.SelectSingleNode("lieu").InnerText;

                listeCapteurs.Add(optionData);

            }

               
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ileossa\Desktop\SmartHome\ecole\netatmo");
                FileInfo[] filesDataSonde = dir.GetFiles();
                int i = 0;

               
                foreach (FileInfo fichier in filesDataSonde)
                {
                    StreamReader reader = fichier.OpenText();
                    string line;
                    Sonde sonde = new Sonde();
                    List<Sonde> datas = new List<Sonde>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] brut = line.Split('"');
                        sonde.date = Convert.ToDateTime(brut[1]);
                        string[] infos = brut[2].Split(' ');
                        sonde.sonde = infos[1];
                        sonde.value = Single.Parse(infos[2]);

                    datas.Add(sonde);
                    }
                    listInfosFileSonde.Add(new InfosFileSonde(datas, fichier.Name));
                    ++i;
                }
              
            System.Console.WriteLine("Total files: " + i);
        }
    }
}