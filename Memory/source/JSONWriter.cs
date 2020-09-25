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

        private bool exists(string filePath) {
            if (File.Exists(filePath)) { return true; }
            return false;
        }

        private JObject ToJSON(string key, string value) {
            /*
             * This is a method for string to json conversion
             * Arguments: Key & Value
             * Return value: string
             */
            string jsonObject = @"{'" + key + "': '" + value + "'}";
            return JObject.Parse(jsonObject);
        }

        private JObject parseJSON(string filePath) {
            string content = "";
            using (StreamReader ouputFile = new StreamReader(filePath)) {
                content = ouputFile.ReadToEnd();
            }
            return JObject.Parse(content);
        }

        public void WriteTo(string filePath, string key, string value) {
            /*
             * This is the method that writes to a JSON file
             * Arguments: Key & Value
             * Return value: Non existing
             */
            JObject read;
            JObject newObject = this.ToJSON(key, value);
            //Console.WriteLine(this.exists(filePath));
            //if (this.exists(filePath)) {
            //    // Parse the already made file
            //    read = this.parseJSON(filePath);
            //    read.Add(key, value);
            //    newObject = read;
            //}
            using (StreamWriter outputFile = new StreamWriter(filePath)) {
                outputFile.WriteLine(newObject);
            }
        }
    }
}
