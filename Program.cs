using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int OkulNo;
            try
            {
                Console.Write("Okul numaranızın son 4 hanesini giriniz: ");
                OkulNo = Convert.ToInt32(Console.ReadLine());
                if (OkulNo < 1000 || OkulNo > 9999)
                    throw new NumaraException("4 haneden fazla veya az yazdınız! Kör müsün?");

                Ogrenci ogrenci = new Ogrenci(OkulNo);
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı okul numarası girdiniz.");
                Environment.Exit(404);
                //throw; //Açık kalırsa kendini kapatır
            }
            finally
            {

            }
            
            Algoritma algo = new Algoritma();

            try
            {
                Console.Write("Lab notunuzu giriniz: ");
                algo.Lab = Convert.ToInt32(Console.ReadLine());
                Console.Write("Vize notunuzu giriniz: ");
                algo.Vize = Convert.ToInt32(Console.ReadLine());
                Console.Write("Final notunuzu giriniz: ");
                algo.Final = Convert.ToInt32(Console.ReadLine());
                algo.NotuYazdir();
            }
            catch (Exception)
            {

                Console.WriteLine("Sanırım hatalı bir not girdiniz. Bu kabul edilemez! Lütfen daha sonra tekrar deneyin.");
            }
            finally
            {
                Console.WriteLine("Bizi kullandığınız için Teşekkürler.");
            }

            
        }
    }
    class Ogrenci:IOgrenci
    {
        private int okulNo;

        public int OkulNo
        {
            get { return okulNo; }
        }
        public Ogrenci()
        {

        }

        public Ogrenci(int okulNo)
        {
            this.okulNo = okulNo;
        }

        
    }

    class Algoritma:Ogrenci,IHesaplayici
    {
        private int lab;

        public int Lab
        {
            get { return lab; }
            set { if (value < 0 || value > 100) throw new MarkException("Labratuar notu 0'ın altında veya 100'den fazla olamaz"); lab = value; }
        }

        private int vize;

        public int Vize
        {
            get { return vize; }
            set { if (value < 0 || value > 100) throw new MarkException("Vize notu 0'ın altında veya 100'den fazla olamaz"); vize = value; }
        }

        private int final;

        public int Final
        {
            get { return final; }
            set { if (value < 0 || value > 100) throw new MarkException("Final notu 0'ın altında veya 100'den fazla olamaz"); final = value; }
        }

        public Algoritma()
        {

        }

        public Algoritma(int Lab, int Vize, int Final)
        {
            this.Lab = Lab;
            this.Vize = Vize;
            this.Final = Final;
        }

        public double Hesapla()
        {
            double lab = Lab * 40 / 100;
            double vize = Vize * 20 / 100;
            double final = Final * 40 / 100;
            double net = lab + vize + final;
            return net;
        }

        public void NotuYazdir()
        {
            if (Final < 40) Console.WriteLine("Final Notu barajı geçmiyor. Kaldınız!");
                Console.WriteLine(Hesapla());
        }
    }
    interface IOgrenci
    {
        int OkulNo { get; }
    }
    interface IHesaplayici
    {
        int Lab { get; set; }
        int Vize { get; set; }
        int Final { get; set; }

        double Hesapla();
    }

    class MarkException : Exception
    {
        public MarkException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }

    class NumaraException : Exception
    {
        public NumaraException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}

