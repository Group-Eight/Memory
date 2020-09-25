using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Memory {
    class JSONParser {

        JObject content;

        public JSONParser(string filePath) {
            // Constructor
            this.content = this.parse(filePath);
        }

        private JObject parse(string filePath) {
            return;
        }

        public List<string> getUsers() {
            return;
        }
    }
}