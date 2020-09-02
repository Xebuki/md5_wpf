using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace md5_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                String source = this.code.Text;
                String hash = GetMd5Hash(md5Hash, source);
                enCode.Text = hash;
                if (VerifyMd5Hash(md5Hash, source, hash)){
                    this.check.Text = "Potwierdzenie: POTWIERDZONO";
                }
                {

                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Zmiana danych wprowadzonych na tablice byte i obliczenie haszu.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Tworzenie nowego Strinbuilder, ktorego zadaniem jest zgromadzenie bitow i stowrzenie z nich string
            StringBuilder sBuilder = new StringBuilder();

            // Petla przez kazdy bit danych hasz
            // oraz format kazdego z nich na hex string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Zwracanie hex string
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Haszowanie danych wejsciowych
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Tworzenie stringComprarer do porownania haszy
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
