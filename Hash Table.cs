using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        public const int MAX = 10;
        
        static void Main(string[] args)
        {
            HashTable h = new HashTable();
            h.Ekle(2);
            h.Ekle(12);
            h.Ekle(22);
            h.Ekle(32);
            h.Ekle(42);
            h.Ekle(52);
            h.Ekle(62);
            h.Ekle(72);
            h.Ekle(82);
            h.Ekle(92);
            h.Ekle(102);
            h.Ekle(112);
            h.Ekle(44);
            h.Cikar(112);
            h.Cikar(42);
            var v = h.Getir(12);
            var v2 = h.Getir(42);
            Console.WriteLine(v);
            Console.WriteLine(v2);
            h.Ekle(36);

            HashTable2 h2 = new HashTable2();
            h2.Ekler(33);
            h2.Ekler(43);
            h2.Ekler(23);
            h2.Ekler(53);
            h2.Ekler(63);
            h2.Ekler(73);
            h2.Ekler(83);
            h2.Cikarir(83);
            h2.Ekler(3);
            //Console.WriteLine(h.Getir(24));
        }
    }
    
    class Node
    {
        public int Anahtar;
        public int Durum = 0;

        public Node(int Anahtar)
        {
            this.Anahtar = Anahtar;
            Durum = 0;
        }

        public Node()
        {
            Durum = 0;
        }

        public override string ToString()
        {
            return Anahtar.ToString();
        }
    }

    class Dugum
    {
        public int Anahtar;
        public Dugum pSonraki;

        public Dugum(int Anahtar)
        {
            this.Anahtar = Anahtar;
            pSonraki = null;
        }

        public override string ToString()
        {
            return Anahtar.ToString();
        }
    }

    class HashTable
    {
        public const int MAX = 10;
        public Dugum[] Veri = new Dugum[MAX];

        public HashTable()
        {
            for (int i = 0; i < MAX; i++)
                Veri[i] = null;
            
        }

        public void Ekle(int Anahtar)
        {
            Dugum pYeni = new Dugum(Anahtar);
            int mod = Anahtar % MAX;

            if (Veri[mod] == null)
            {
                Veri[mod] = pYeni;
                return;
            }

            Dugum pTemp = Veri[mod];

            while (pTemp.pSonraki != null)
                pTemp = pTemp.pSonraki;

            pTemp.pSonraki = pYeni;
        }

        public Dugum Getir(int Anahtar)
        {
            int mod = Anahtar % MAX;
            Dugum pTemp = Veri[mod];

            while (pTemp != null)
            {
                if (pTemp.Anahtar == Anahtar)
                    return pTemp;

                pTemp = pTemp.pSonraki;
            }
            return null;
        }

        public bool Cikar(int Anahtar)
        {
            int mod = Anahtar % MAX;
            Dugum pTemp = Veri[mod];

            if (Veri[mod] == null)
                return false;

            if (Veri[mod].pSonraki == null)
            {
                if (Veri[mod].Anahtar == Anahtar)
                {
                    Veri[mod] = null;
                    return true;
                }
                return false;
            }

            if (Veri[mod].Anahtar == Anahtar)
            {
                Veri[mod] = Veri[mod].pSonraki;
                return true;
            }

            while (pTemp.pSonraki != null)
            {
                if(pTemp.pSonraki.Anahtar == Anahtar)
                {
                    pTemp.pSonraki = pTemp.pSonraki.pSonraki;
                    return true;
                }
                pTemp = pTemp.pSonraki;
            }
            return false;
        }
    }

    class HashTable2
    {
        public const int MAX = 10;
        public Node[] Veri = new Node[MAX];

        public HashTable2()
        {

            for (int i = 0; i < MAX; i++)
            {
                Node Data = new Node();
                Veri[i] = Data;
            }
        }

        public bool Ekler(int Anahtar)
        {
            int mod = Anahtar % MAX;
            int i = mod;

            while (Veri[i].Durum == 1) //Boş satır bulana kadar geziniyor
            {
                if (i == MAX - 1)
                    i = 0;
                else
                    i++;

                if (i == mod)
                    return false;
            }

            Veri[i].Anahtar = Anahtar;
            Veri[i].Durum = 1;

            return true;
        }

        public bool Cikarir(int Anahtar)
        {
            int mod = Anahtar % MAX;
            int i = mod;

            while (Veri[i].Durum != 0)
            {
                if (Veri[i].Anahtar == Anahtar)
                {
                    if (Veri[i].Durum == 1)
                    {
                        Veri[i].Durum = 2;
                        return true;
                    }
                }

                if (i == MAX - 1)
                    i = 0;
                else
                    i++;

                if (i == mod)
                    return false;
            }
            return false;
        }
    }
}
