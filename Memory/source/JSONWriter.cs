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

        public void CreateFile(string filePath) {
            /*
             * This is the method that creates a JSON file.
             * Arguments: file name
             * Return value: Non existing
             */
            if (!File.Exists(filePath)) {
                File.Create(filePath);
            } else {
                Console.WriteLine("File already exists! No file was created...");
            }
        }

        private bool exists(string filePath) {
            /*
             * This method is for checking if save file already exists
             * Arguments: filePath
             * Return value: bool
             */
            if (File.Exists(filePath)) { return true; }
            return false;
        }

        private JObject ToJSON(string key, dynamic value) {
            /*
             * This is a method for string to json conversion
             * Arguments: Key & Value
             * Return value: JObject
             */
            string jsonObject = @"{'" + key + "': '" + value + "'}";
            return JObject.Parse(jsonObject);
        }

        private JObject parseJSON(string filePath) {
            /*
             * This method parses the already made JSON inside the savefile
             * Arguments: filePath
             * Return value: JObject
             */
            string content = "";
            using (StreamReader ouputFile = new StreamReader(filePath)) {
                content = ouputFile.ReadToEnd();
            }
            return JObject.Parse(content);
        }

        public void WriteTo(string filePath, string key, string stringValue = null, JObject objectValue = null) {
            /*
             * This is the method that writes to a JSON file
             * Arguments: Key & Value
             * Return value: Non existing
             */
            dynamic value = null;
            if (stringValue == null && objectValue == null) { return; }
            else if (stringValue != null) { value = stringValue; }
            else if (objectValue != null) { value = objectValue as JToken; }
            JObject newObject = this.ToJSON(key, value);
            if (this.exists(filePath)) {
                // Parse the already made file
                JObject read = this.parseJSON(filePath);
                read.Add(key, value);
                newObject = read;
            }
            using (StreamWriter outputFile = new StreamWriter(filePath)) {
                outputFile.WriteLine(newObject);
            }
        }
    }
}
