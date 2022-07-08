using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracjaOptima
{

    class LoadSettings
    {
        public static string Firma { get; set; }
        public static string Operator { get; set; }
        public static string sql_serwer { get; set; }
        public static string sql_baza { get; set; }
        public static string sql_user { get; set; }
        public static string sql_password { get; set; }
        public static string ConnString { get; set; }
        public static string Sciezka { get; set; }

        public static void Load()
        {
            Firma = ConfigurationManager.AppSettings["Firma"].ToString();
            Operator = ConfigurationManager.AppSettings["Operator"].ToString();
            sql_serwer = ConfigurationManager.AppSettings["sql_serwer"].ToString();
            sql_baza = ConfigurationManager.AppSettings["sql_baza"].ToString();
            sql_user = ConfigurationManager.AppSettings["sql_user"].ToString();
            sql_password = ConfigurationManager.AppSettings["sql_password"].ToString();
           // Sciezka = ConfigurationManager.AppSettings["sciezka"].ToString();

            ConnString = $@"Data Source={sql_serwer};Initial Catalog={sql_baza};User ID={sql_user};Password={sql_password};";
        }

    }
}