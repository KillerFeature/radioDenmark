using System;
using System.Xml;

namespace podcast
{

    class podcast
    {

        public string getLatestPodcast(string url)
        {

            //This loads the Podcast
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            //This builds a list of the Item nodes
            XmlNodeList items = doc.SelectNodes("//item");

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].SelectSingleNode("title").InnerText);
                Console.WriteLine(items[i].SelectSingleNode("enclosure").Attributes["url"].Value);

            }
            return items[0].SelectSingleNode("enclosure").Attributes["url"].Value;

        }

    }

}