using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                MessageBox.Show("File with name already exists!");
            }
        }

        public void WriteTo() {
            /*
             * This is the method that writes to a JSON file
             * Arguments: Key & Value
             * Return value: Non existing
             */
        }
    }
}
