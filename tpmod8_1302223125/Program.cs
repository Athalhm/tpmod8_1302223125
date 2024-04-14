using tpmod8_1302223125;

internal class Program
{
    private static void Main(string[] args)
    {
        MainCovidConfig appConfig = new MainCovidConfig();

        appConfig.ubahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {appConfig.dataConfig.satuan_suhu} : ");
        double suhuBadan = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
        int hariTerakhirDemam = int.Parse(Console.ReadLine());

        bool BatasDemamTerima = hariTerakhirDemam < appConfig.dataConfig.batas_hari_demam;
        bool suhuCelciusTerima = (appConfig.dataConfig.satuan_suhu == "celcius") && (suhuBadan >= 36.5 && suhuBadan <= 37.5);
        bool suhuFahrenheitTerima = (appConfig.dataConfig.satuan_suhu == "fahrenheit") && (suhuBadan >= 97.7 && suhuBadan <= 99.5);

        if (
            BatasDemamTerima && (suhuCelciusTerima || suhuFahrenheitTerima)
        )
        {
            Console.WriteLine(appConfig.dataConfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(appConfig.dataConfig.pesan_ditolak);
        }
    }
}