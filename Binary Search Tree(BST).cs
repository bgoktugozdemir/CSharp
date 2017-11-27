using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTDugum yenis = new BSTDugum(8);
            yenis.Ekle(4);
            yenis.Ekle(3);
            yenis.Ekle(6);
            yenis.Ekle(13);
            yenis.Ekle(11);
            yenis.Ekle(18);
            yenis.Ekle(1);
            yenis.Ekle(3);
            yenis.Ekle(5);
            yenis.Ekle(7);
            yenis.Ekle(16);
            yenis.Ekle(21);
            yenis.Ekle(12);
            yenis.Ekle(9);
            Console.WriteLine(yenis.MinDeger());
            yenis.Cikar(11);
            yenis.Ara(11);


            /*
            BSTDugum yeni = new BSTDugum(11);
            yeni.Ekle(5);
            yeni.Ekle(15);
            yeni.Ekle(3);
            yeni.Ekle(8);
            yeni.Ekle(12);
            yeni.Ekle(17);
            yeni.Ekle(16);
            yeni.Ara(17);
            yeni.Cikar(17);
            Console.WriteLine(yeni.MinDeger());
            */
        }
    }

    class BSTDugum
    {
        public int Veri;

        BSTDugum pSol, pSag;

        public BSTDugum(int Veri)
        {
            pSol = pSag = null;
            this.Veri = Veri;   //KÖK
        }

        public void Ekle(int item)
        {
            if (item < Veri)
            {
                if (pSol != null)
                {
                    pSol.Ekle(item);
                    return;
                }
                BSTDugum pYeni = new BSTDugum(item);
                pSol = pYeni;
            }
            else if (item > Veri)
            {
                if (pSag != null)
                {
                    pSag.Ekle(item);
                    return;
                }
                BSTDugum pYeni = new BSTDugum(item);
                pSag = pYeni;
            }
        }

        public void Cikar(int item, BSTDugum ebeveyn = null)
        {
            if (item < Veri)
            {
                if (pSol != null)
                    pSol.Cikar(item, this);
                return;
            }
            else if (item > Veri)
            {
                if (pSag != null)
                    pSag.Cikar(item, this);
                return;
            }
            if (pSag == null && pSol == null)
            {
                if (ebeveyn.pSol == this)
                    ebeveyn.pSol = null;
                else
                    ebeveyn.pSag = null;
            }

            else if (pSag != null && pSol != null)
            {
                Veri = pSag.MinDeger();
                pSag.Cikar(Veri, this);
                return;
            }
            else if (pSag != null)
            {
                if (ebeveyn.pSol == this)
                    ebeveyn.pSol = pSag;
                else
                    ebeveyn.pSag = pSag;
            }
            else if (pSol != null)
            {
                if (ebeveyn.pSol == this)
                    ebeveyn.pSol = pSol;
                else
                    ebeveyn.pSag = pSol;
            }
        }

        public BSTDugum Ara(int item)
        {
            if (item < Veri)
            {
                if (pSol != null)
                    return pSol.Ara(item);
                else
                    return null;
            }
            else if (item > Veri)
            {
                if (pSag != null)
                    return pSag.Ara(item);
                else
                    return null;
            }
            return this;
        }

        public int MinDeger()
        {
            if (pSol != null)
            {
                return pSol.MinDeger();
            }
            return Veri;
        }
    }
}
