using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Media.Converters;

namespace Memory {
    class JSONParser {

        JObject content;

        /*
         * < Usage >
         * JSONParser parser = new JSONParser(filePath);
         * parser.getTokens(key);
         * parser.getGrid();
         * 
         * IMPORTANT - getTokens is not meant for the grid! getGrid is used to parse the grid.
         * ALSO IMPORTANT - For every single file there needs to be an instance
         */
        public JSONParser(string filePath) {
            // Constructor
            this.content = this.parse(filePath);
        }

        /*
         * This method reads the given file.
         * Arguments: filePath
         * Return value: JObject
         */
        private JObject parse(string filePath) {
            string content = "";
            using (StreamReader reader = new StreamReader(filePath)) {
                content = reader.ReadToEnd();
            }
            return JObject.Parse(content);
        }

        /*
         * This method reads and returns the value of the tokens.
         * Arguments: key
         * Return value: List
         */
        public List<JToken> getTokens(string key) {
            List<JToken> tokens = new List<JToken> { };
            foreach (var x in this.content) { 
                if (x.Key == key) {
                    if (x.Value.GetType() == typeof(JValue)) { tokens.Add(x.Value); }
                    foreach (var values in x.Value) {
                        foreach (var user in values) { tokens.Add(user); }
                    }
                }
            }
            return tokens;
        }

        /*
         * This method returns the grid with cell and card.
         * Arguments: None
         * Return value: Dictionary
         */
        public Dictionary<JToken, JToken> getGrid() {
            Dictionary<JToken, JToken> grid = new Dictionary<JToken, JToken> { };
            foreach (var x in this.content) {
                if (x.Key == "grid") {
                    foreach (var child in x.Value.Children()) {
                        Regex valuePair = new Regex(@"[a-z]+\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        MatchCollection collection = valuePair.Matches(child.ToString());
                        List<string> keyValue = new List<string> { };
                        foreach (Match match in collection) {
                            GroupCollection col = match.Groups;
                            keyValue.Add(col[0].ToString());
                        }
                        grid.Add(keyValue[0], keyValue[1]);
                    }
                }
            }
            return grid;
        }
    }
}
