using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.RightsManagement;

namespace Memory {
    class JSONParser {

        JObject content;

        public JSONParser(string filePath) {
            // Constructor
            this.content = this.parse(filePath);
            Console.WriteLine(this.getTokens("powerups")[0]);
        }

        private JObject parse(string filePath) {
            string content = "";
            using (StreamReader reader = new StreamReader(filePath)) {
                content = reader.ReadToEnd();
            }
            return JObject.Parse(content);
        }

        public List<JToken> getTokens(string key) {
            List<JToken> tokens = new List<JToken> { };
            foreach (var x in this.content) { 
                if (x.Key == key) { 
                    foreach (var values in x.Value) {
                        foreach (var user in values) { tokens.Add(user); }
                    }
                }
            }
            return tokens;
        }
    }
}