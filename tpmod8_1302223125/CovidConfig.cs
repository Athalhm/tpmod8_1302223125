using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmod8_1302223125
{
    public class covidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }
    public class MainCovidConfig
    {
        public covidConfig dataConfig;

        private string filePath = "D:\\codingan\\tpmod8_1302223125\\covid_config.json";

        public void ReadJSON()
        {
            string configJsonData = File.ReadAllText(filePath);
            this.dataConfig = JsonSerializer.Deserialize<covidConfig>(configJsonData);
        }

        public void WriteJSON()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(dataConfig, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void setDefault()
        {
            dataConfig = new covidConfig();
            dataConfig.satuan_suhu = "celcius";
            dataConfig.batas_hari_demam = 14;
            dataConfig.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            dataConfig.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        }

        public void ubahSatuan()
        {
            if (this.dataConfig.satuan_suhu == "celcius")
            {
                this.dataConfig.satuan_suhu = "fahrenheit";
            }
            else
            {
                this.dataConfig.satuan_suhu = "celcius";
            }

            WriteJSON();
        }

        public MainCovidConfig()
        {
            try
            {
                ReadJSON();
            }
            catch
            {
                setDefault();
                WriteJSON();
            }
        }
    }
}