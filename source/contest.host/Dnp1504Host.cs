using System;
using System.IO;
using contestrunner.contract.host;
using contest.submission.contract;
using System.Diagnostics;

namespace contest.host
{

    public class Dnp1504Host : IHost
    {

        private decimal secretfigure = 100000001m;
        private decimal estimatedfigure = 0m;
        private int numberofsteps = 100;
        private int usedNumberofSteps = 0;

        public void Prüfen(object beitrag, string wettbewerbspfad, string beitragsverzeichnis)
        {
            var sut = (IDnp1504Solution)beitrag;
            Stopwatch sw = new Stopwatch();

            var anfang = new Prüfungsanfang { Wettbewerb = Path.GetFileName(wettbewerbspfad), Beitrag = Path.GetFileName(beitragsverzeichnis) };
            Anfang(anfang);

            sut.SendResult += x =>
            {
                estimatedfigure = x;
            };

            sw.Start();
            sut.Process(Rating.Start);

            for (usedNumberofSteps = 1; usedNumberofSteps < numberofsteps; usedNumberofSteps++)
            {
                var rating = this.CheckValue(estimatedfigure);
               // Console.WriteLine(usedNumberofSteps+" : "+estimatedfigure);

                if (rating == Rating.Exactly)
                {
                    Status(new Prüfungsstatus() { Statusmeldung = "**** Hurra: Zahl gefunden ***** " });
                    break;
                }

                sut.Process(rating);
            }
            sw.Stop();

            Status(new Prüfungsstatus() { Statusmeldung = "Gemerkte Zahl: " + secretfigure });
            Status(new Prüfungsstatus() { Statusmeldung = "Geratene Zahl: " + estimatedfigure });

            Status(new Prüfungsstatus() { Statusmeldung = "Differenz:     " + Math.Abs(secretfigure - estimatedfigure) });
            Status(new Prüfungsstatus() { Statusmeldung = "Mit Anzahl Schritte: " + usedNumberofSteps });

            Ende(new Prüfungsende() { Dauer = sw.Elapsed });
        }

        public event Action<Prüfungsanfang> Anfang;
        public event Action<Prüfungsstatus> Status;
        public event Action<Prüfungsende> Ende;
        public event Action<Prüfungsfehler> Fehler;


        public Rating CheckValue(decimal estimatedfigure)
        {
            if (estimatedfigure == secretfigure) return Rating.Exactly;
            if (estimatedfigure > secretfigure) return Rating.ToHigh;
            else return Rating.ToLow;
        }
    }
}
