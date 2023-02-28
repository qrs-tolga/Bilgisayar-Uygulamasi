using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Bilgisayar
    {

        bool pcDurum = false;


        public void pcAc()
        {
            Console.Clear();
            if (pcDurum == false) { Console.WriteLine("Bilgisayar Açılıyor ..."); Thread.Sleep(1000); Console.Clear(); Console.WriteLine("Bilgisayar Açıldı !"); pcDurum = true;  }
            else { Console.WriteLine("Bilgisayar Zaten Açık !"); }
        }

        public void pcKapat()
        {
            Console.Clear();
            if (pcDurum == true) { Console.WriteLine("Bilgisayar Kapanıyor ...");Thread.Sleep(1000); Console.Clear(); Console.WriteLine("Bilgisayar Kapandı !");pcDurum = false; }
            else { Console.WriteLine("Bilgisayar Zaten Kapalı !"); }
        }

        public void oyunlar()
        {
            if(pcDurum == true)
            {
                Console.Clear();
                Console.Write("-----------------------------------------------\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|             1 - Taş Kağıt Makas             |\n" +
                                "|            2 - Sayı Tahmin Oyunu            |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "-----------------------------------------------\n" +
                                "Seçiniz : ");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        Console.Clear();
                        tasKagitMakas();
                        break;
                    case 2:
                        Console.Clear();
                        sayiTahmin();
                        break;
                    case 3:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("İlk Önce Bilgisayarı Açmalısınız !");
            }
        }

        public void sayiTahmin()
        {
            Console.Clear();
            Random rnd = new Random();
            int[] rastgeleSayilar = new int[5];
            int enBuyukPuan = 0;
            int enBuyukPuan_index = 0;
            for (int i = 0; i < rastgeleSayilar.Length; i++)
            {
                rastgeleSayilar[i] = rnd.Next(1, 5);
            }
            int tahminSayi;
            Console.Write("-------Sayı Tahmin-------\n\n"+
                          "Oyuncu Sayısını Giriniz : ");
            int oyuncuSayisi = Convert.ToInt32(Console.ReadLine());
            int[] puan = new int[oyuncuSayisi];
            byte oyuncu = 0;

            Console.Clear();

            for (int i = 0; i < rastgeleSayilar.Length; i++)
            {
                while (true)
                {
                    Console.WriteLine($"-------Sayı Tahmin-------\n");
                    Console.Write($"{oyuncu + 1}.Oyuncu Tahminizi Giriniz : ");

                    tahminSayi = Convert.ToInt32(Console.ReadLine());

                    if (rastgeleSayilar[i] == tahminSayi)
                    {
                        Console.WriteLine("Doğru Tahmin Ettiniz");
                        puan[oyuncu] += 10;
                    }
                    else
                    {
                        if (rastgeleSayilar[i] > tahminSayi)
                        {
                            puan[oyuncu] += 10 - (rastgeleSayilar[i] - tahminSayi);
                        }

                        else
                        {
                            puan[oyuncu] += 10 - (tahminSayi - rastgeleSayilar[i]);
                        }

                        Console.WriteLine("Yanlış Tahmin Ettiniz");
                    }

                    Console.Clear();

                    if (oyuncu == (oyuncuSayisi - 1))
                    {
                        Console.WriteLine($"-------Sayı Tahmin-------\n");
                        for (int s = 0; s < oyuncuSayisi; s++)
                        {
                            Console.WriteLine($"{s + 1}. Oyuncunun Puanı : {puan[s]}");

                        }
                        Console.Write("Devam Etmek İçin Herhangi Bir Tuşa Basınız ...");
                        Console.ReadKey();
                        Console.Clear();
                        oyuncu = 0;
                        break;
                    }
                    else
                    {
                        oyuncu++;
                    }
                }

            }
            for (int i = 0; i < oyuncuSayisi; i++)
            {

                if (puan[i] > enBuyukPuan)
                {
                    enBuyukPuan = puan[i];
                    enBuyukPuan_index = i;
                }
            }
            for (int s = 0; s < oyuncuSayisi; s++)
            {
                Console.WriteLine($"{s + 1}. Oyuncunun Puanı : {puan[s]}");

            }
            Console.Write($"Kazanan Oyuncu {enBuyukPuan_index + 1}. Oyuncu Tebrikler !!");
            Console.ReadKey();
        }

        public void tasKagitMakas()
        {
            Random rnd = new Random();
            Console.Clear();
            Console.Write("------Taş Kağıt Makas------\n" +
                          "1 - Bilgisayara Karşı\n" +
                          "2 - İki Kişilik\n" +
                          "Seçiniz : ");
            int menuSecim = Convert.ToInt32(Console.ReadLine());

            switch(menuSecim)
            {
                case 1:
                    Console.Clear();
                    Console.Write("------Taş Kağıt Makas------\n" +
                                    "1 - Taş\n" +
                                    "2 - Kağıt\n" +
                                    "3 - Makas\n" +
                                    "Seçiniz : ");
                    int oyuncuSecimPC = Convert.ToInt32(Console.ReadLine());
                    int pcSecim = rnd.Next(1, 3);

                    if (pcSecim == oyuncuSecimPC) { Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                     "Berabere !"); }

                    else if (pcSecim == 1 && oyuncuSecimPC == 2) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Oyuncu Kazandı !");}

                    else if (pcSecim == 1 && oyuncuSecimPC == 3) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Bilgisayar Kazandı !");}

                    else if (pcSecim == 2 && oyuncuSecimPC == 1) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Bilgisayar Kazandı !");}

                    else if (pcSecim == 2 && oyuncuSecimPC == 3) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Oyuncu Kazandı !");}

                    else if (pcSecim == 3 && oyuncuSecimPC == 1) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Bilgisayar Kazandı !");}

                    else if (pcSecim == 3 && oyuncuSecimPC == 2) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                   "Oyuncu Kazandı !");}
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("------Taş Kağıt Makas------\n" +
                                    "---------1. Oyuncu---------\n" +
                                    "1 - Taş\n" +
                                    "2 - Kağıt\n" +
                                    "3 - Makas\n" +
                                    "Seçiniz : ");
                    int oyuncuSecim = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.Write("------Taş Kağıt Makas------\n" +
                                    "---------2. Oyuncu---------\n" +
                                    "1 - Taş\n" +
                                    "2 - Kağıt\n" +
                                    "3 - Makas\n" +
                                    "Seçiniz : ");
                    int oyuncu2Secim = Convert.ToInt32(Console.ReadLine());

                    if (oyuncu2Secim == oyuncuSecim) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                     "Berabere !");}

                    else if (oyuncu2Secim == 1 && oyuncuSecim == 2) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                        "1. Oyuncu Kazandı !");}

                    else if (oyuncu2Secim == 1 && oyuncuSecim == 3){Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                       "2. Oyuncu Kazandı !");}

                    else if (oyuncu2Secim == 2 && oyuncuSecim == 1) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                        "2. Oyuncu Kazandı !");}

                    else if (oyuncu2Secim == 2 && oyuncuSecim == 3) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                        "1. Oyuncu Kazandı !");}

                    else if (oyuncu2Secim == 3 && oyuncuSecim == 1) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                        "1. Oyuncu Kazandı !");}

                    else if (oyuncu2Secim == 3 && oyuncuSecim == 2) {Console.Clear(); Console.WriteLine("------Taş Kağıt Makas------\n" +
                                                                                                        "2. Oyuncu Kazandı !");}
                    break;
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bilgisayar pc = new Bilgisayar();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("-----------------------------------------------\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|              1 - Bilgsayarı Aç              |\n" +
                                "|            2 - Bilgisayarı Kapat            |\n" +
                                "|                 3 - Oyunlar                 |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "|                                             |\n" +
                                "-----------------------------------------------\n" +
                                "Seçiniz : ");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        Console.Clear();
                        pc.pcAc();
                        break;
                    case 2:
                        Console.Clear();
                        pc.pcKapat();
                        break;
                    case 3:
                        Console.Clear();
                        pc.oyunlar();
                        break;
                }

                Console.WriteLine("Devam Etmek İçin Herhangi Bir Tuşa Basınız...");
                Console.ReadKey();

                
            }
        }
    }
}
