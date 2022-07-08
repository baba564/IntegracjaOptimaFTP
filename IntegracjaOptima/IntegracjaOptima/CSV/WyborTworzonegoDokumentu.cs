using IntegracjaOptima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntegracjaOptima.CSV
{
    public class WyborTworzonegoDokumentu
    {
        private static Model _model { get; set; }
        private static int _gidnumer { get; set; }
        private ModelSciezki sciezki = new ModelSciezki();

        public WyborTworzonegoDokumentu(Model wchodzi, int gidnumer)
        {
            _model = wchodzi;
            _gidnumer = gidnumer;   
        }
        public  WyborTworzonegoDokumentu()
        {

        }

        public ModelSciezki WybórDokumentu(string rodzajDokumentu)
        {
            switch (rodzajDokumentu)
            {
                case "RCP":
                    MessageBox.Show("RCP");
                    RCP rcp = new RCP(_model, _gidnumer);
                    sciezki = rcp.CreateRCP();
                    break;
                case "SHP":
                    MessageBox.Show("SHP");
                    SHP shp = new SHP(_model, _gidnumer);
                    sciezki = shp.CreateSHP();
                    break;
                case "STK":
                    MessageBox.Show("SHP");
                    STK stk = new STK();
                    sciezki = stk.CreateSTK();
                    break;
                default:
                    MessageBox.Show("Brak takiego typu dokumentu.");
                    break;
                 

            }
            return null;
        }
    }
}
