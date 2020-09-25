using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Memory {
    class JSONParser {

        JObject content;

        public JSONParser(string filePath) {
            // Constructor
            this.content = this.parse(filePath);
            Console.WriteLine(this.content);
        }

        private JObject parse(string filePath) {
            string content = "";
            using (StreamReader reader = new StreamReader(filePath)) {
                content = reader.ReadToEnd();
            }
            return JObject.Parse(content);
        }

        public List<string> getUsers() {
            List<string> users = new List<string> { };
            return users;
        }
    }
}