using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Data;
using Newtonsoft.Json;
using Transportation_v2._0.DataPerson;

namespace Transportation_v2._0.IO_service
{
    class IO
    {
        private readonly string PATH;
        public IO(string path)
        {
            PATH = path;
        }
        public BindingList<PersonTransportation> LoadingData()
        {
            var fileExist = File.Exists(PATH);
            if(!fileExist)
            {
                File.Create(PATH).Dispose();
                return new BindingList<PersonTransportation>();
            }
            using (var read = File.OpenText(PATH))
            {
                var file = read.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<PersonTransportation>>(file);
            }
        }
        public void SaveDate(object sender)
        {
            using(StreamWriter writer=File.CreateText(PATH))
            {
                string otput = JsonConvert.SerializeObject(sender);
                writer.Write(otput);
            }
        }
            

    }
}
