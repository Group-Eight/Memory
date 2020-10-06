using Memory;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Memory {
    class JSONWriter {

        /*
         * < Usage >
         * JSONWriter writer = new JSONWriter();
         * writer.CreateFile(filePath);
         * writer.WriteTo(filePath, stringValue: string, objectValue: obj);
         * 
         * The argument types can be found below.
         */
        public JSONWriter("/bin/Debug") {
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
            }
            return;
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
            string newObject = @"{'" + key + "': '" + value + "'}";
            return JObject.Parse(newObject);
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
