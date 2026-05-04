using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 
namespace zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceJson = File.ReadAllText(args[0]); 
            var sourceData = BuildIdDicionary(sourceJson); 

            string inputJson = File.ReadAllText(args[1]);
            JToken root = JToken.Parse(inputJson); 

            EnrichWithSourceData(root, sourceData); 

            File.WriteAllText(args[2], root.ToString(Formatting.Indented));

            Console.WriteLine("Готово!");
        }

        static Dictionary<string, JObject> BuildIdDicionary(string sourceJson)
        {
            var dict = new Dictionary<string, JObject>();
            JToken source = JToken.Parse(sourceJson); 

            CollectObjectsById(source, dict); 

            return dict;
        }

        static void CollectObjectsById(JToken token, Dictionary<string, JObject> dict) 
        {
            if(token is JObject obj) 
            {
                if(obj.TryGetValue("id", out JToken idToken)) 
                {
                    string id = idToken.ToString(); 

                    var dataWithoutId = new JObject(obj); 
                    dataWithoutId.Remove("id"); 
                    dict[id] = dataWithoutId;
                }

                foreach (var property in obj.Properties()) 
                {
                    CollectObjectsById(property.Value, dict); 
                }
            }

            else if(token is JArray arr) 
            {
                foreach(var item in arr)
                {
                    CollectObjectsById(item, dict); 
                }
            }
        }

        static void EnrichWithSourceData(JToken token, Dictionary<string, JObject> sourceDict) 
        {
            if(token is JObject obj) 
            {
                if(obj.TryGetValue("id", out JToken idToken)) 
                {
                    string id = idToken.ToString();
                    if(sourceDict.TryGetValue(id, out JObject dataToAdd)) 
                    {
                        foreach(var prop in dataToAdd.Properties())
                        {
                            obj[prop.Name] = prop.Value;
                        }
                    }
                }

                foreach(var property in obj.Properties()) 
                {
                    EnrichWithSourceData(property.Value, sourceDict); 
                }
            }
            else if(token is JArray arr) 
            {
                foreach(var item in arr)
                {
                    EnrichWithSourceData(item, sourceDict); 
                }
            }
        }
    }
}
