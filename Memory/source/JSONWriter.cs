using Memory;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Memory {
    class JSONWriter {

        public JSONWriter() {
            // Constructor
        }

        public void CreateFile(string fileName) {
            /*
             * This is the method that creates a JSON file.
             * Arguments: file name
             * Return value: Non existing
             */
            if (!File.Exists(fileName)) {
                File.Create(fileName);
            } else {
                Console.WriteLine("File already exists! No file was created...");
            }
        }

        private JObject ToJSON(string key, string value) {
            /*
             * This is a method for string to json conversion
             * Arguments: Key & Value
             * Return value: string
             */
            string jsonObject = @"{'{0}': '{1}'}";
            JObject obj = JObject.Parse(jsonObject);
            return obj;
        }

        public void WriteTo(string filePath, string key, string value) {
            /*
             * This is the method that writes to a JSON file
             * Arguments: Key & Value
             * Return value: Non existing
             */
            using (StreamWriter outputFile = new StreamWriter(filePath)) {
                outputFile.WriteLine(this.ToJSON(key, value));
            }
        }
    }
}
