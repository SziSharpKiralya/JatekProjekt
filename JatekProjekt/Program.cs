namespace JatekProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Az adatok behívásra kerülnek
            var dbKezelo = new AdatbazisKezelo();
            var karakterek = dbKezelo.AdatokBetoltese();
            foreach (var item in karakterek)
            {
                Console.WriteLine(item);
            }
        }
    }
}
