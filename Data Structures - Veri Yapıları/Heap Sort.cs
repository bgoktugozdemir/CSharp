using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
/*
                    23
            3               8
        7       11      20      2
    5
*/
            Heap D = new Heap();

            int[] a = { 23, 3, 8, 7, 11, 20, 2, 5 };

            D.HeapOlustur(a, 8);
            int s = 1;
            while (D.ES > 0)
            {
                int temp = D.Getir();
                Console.Write(temp + " ");
                s++;
                if(s == 1 || s == 2 || s == 4 || s == 8 || s == 16)
                    Console.WriteLine();
            }
        }
    }

    class Heap
    {
        public int ES { get; private set; }
        int[] Veri;
        int MAX;

        public Heap(int MAX = 10)
        {
            ES = 0;
            this.MAX = MAX;
            Veri = new int [MAX];
        }

        //Yardımcı Metotlar
        int SolCocukGetir(int i) {
            return (2 * i) + 1;
        }
        int SagCocukGetir(int i)
        {
            return (2 * i) + 2;
        }
        int EbeveynGetir(int i)
        {
            return (i - 1) / 2;
        }

        public int Getir()
        {
            if (ES == 0)
                return 0;

            int e = Veri[0];
            Veri[0] = Veri[ES - 1];
            ES--;
            HeapifyDown(0);
            return e;
        }

        public bool Ekle(int e)
        {
            if (ES >= MAX)
                return false;

            ES++;
            Veri[ES - 1] = e;
            HeapifyUp(ES - 1);
            return true;

        }

        void HeapifyDown(int i)
        {
            int Sol = SolCocukGetir(i);
            int Sag = SagCocukGetir(i);
            int min;

            if (Sag >= ES)
            {
                if (Sol >= ES)
                    return;
                else
                    min = Sol;
            }
            else
            {
                if (Veri[Sol] < Veri[Sag])
                    min = Sol;
                else
                    min = Sag;
            }

            if (Veri[min] < Veri[i])
            {
                int swap = Veri[i];
                Veri[i] = Veri[min];
                Veri[min] = swap;
                HeapifyDown(min);
            }
        }

        void HeapifyUp(int i)
        {
            if (i == 0)
                return;

            int eb = EbeveynGetir(i);

            if (Veri[i] < Veri[eb])
            {
                int swap = Veri[i];
                Veri[i] = Veri[eb];
                Veri[eb] = swap;
                HeapifyUp(eb);
            }
        }

        public bool HeapOlustur(int[] a, int es)
        {
            if (es > MAX)
                return false;
            this.ES = es;

            for (int i = 0; i < es; i++)
                Veri[i] = a[i];

            int k = (es - 1) / 2;

            for (int i = k; i >= 0; i--)
                HeapifyDown(i);
            return true;
        }
    }
}
