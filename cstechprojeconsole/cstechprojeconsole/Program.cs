using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstechprojeconsole
{
    class Program
    {
        static IEnumerable<string> rakamlar(int basamak) // foreach döngüsü arka planda bir iterator yapısını kullanmaktadır. foreach döngüsü verilen koleksiyon veya dizi içerisindeki elemanları iterator sayesinde tek tek elemanları elde etmeye çalıştım.
        {                                                //foreach döngüsü, yapısı gereği IEnumerable, IEnumerator, IEnumerable<T> veya IEnumerator<T> arayüzlerinden türemiş elemanlar üzerinde çalıştığını çalıştığını öğrendim ve bunu kullandım.
            if (basamak > 0) // basamak sıfırdan büyüksegir.
            {
                foreach (string rakam in rakamlar(basamak - 1)) // basamak değerini 1 azaltarak doldur.
                    foreach (char rkm in "123456789") // 1-9 a kadar olan sayıları char olarak al
                        if (!rakam.Contains(rkm))// rkm değeri eğer rakam değerinin içinde içermiyorsa gir.
                            yield return rakam + rkm; // rakam değeri rkm değerine ekle. 
            }   // yield iteratör classlarında içerir. kaldığı yerden return etmesi sağlanır.
            else
                yield return "";
        }

        static IEnumerable<T> Shuffle<T>(IEnumerable<T> liste)
        {
            Random random = new Random();//random oluşturdum.
            List<T> liste2 = liste.ToList();// olan listeyi liste2 ye kopyaladım.
            while (liste2.Count > 0)// liste nin uzunluğu 0 a eit olana kadar dögüye girdi.
            {
                int tekrarlayan = random.Next(liste2.Count);//tekrarlayan değişkeni lidte2 countu kadar random değişken aldı.
                yield return liste2[tekrarlayan]; // yield kullanarak kaldığı yerden yani tekrarlayan sayıyı atadım.
                liste2.RemoveAt(tekrarlayan); // tekrarlayan sayı olursa 4 rakamın içinden at .
            }
        }

        public static bool dogruyanlıs(out int dogru, out int yanlıs) // kullanıcıdan alınan  doğru yanlış ipucu olarak alan method
        {
            string[] girdi = Console.ReadLine().Split(',').ToArray(); // kullanıcdan alınan girdiyi split ediyoruz.
            dogru = yanlıs = 0;
            if (girdi.Length < 2) // kullanıcıdan alınan ipucu parametresi ikiden küçükse false döndür.
                return false;
            else
                return int.TryParse(girdi[0], out dogru) && int.TryParse(girdi[1], out yanlıs); // girdiyi parse ederek ayırıyoruz.
        }
        public static int[] randomsayiuretme()//bilgisayar sayıyı ürettiği method 
        {
            Random random = new Random(); // random class random sayı üretmek için 
            int[] dortbasamak = new int[] { 10, 10, 10, 10 };// dörtbasamaklı sayı üretmek için 10lar ise 0-9 rakamları temsil ediyor.
            for (int i = 0; i < dortbasamak.Length; i++)//index 0 den lengthe kadar sayı ürettirdik.
            {
                int temp = random.Next(1, 9);//rakam 1-9 a rastgele gelsin.
                while (temp == dortbasamak[0] || temp == dortbasamak[1] || temp == dortbasamak[2] || temp == dortbasamak[3])
                {
                    temp = random.Next(1, 9);// eğer birisine eşitse random rakam tekrardan ürettim.
                }
                dortbasamak[i] = temp;// dortbasamak arrayın içine koy.
                                      //Console.WriteLine(dortbasamak[i]);
            }
            return dortbasamak;//dortbasamak arrayıne geri dön.

        }

        public static int[] tuttugunsayi// kullanıcıdan alınan method
        {
            get
            {

                Console.WriteLine("Lütfen Tahminizi Giriniz : ");
                string tahmin = Console.ReadLine();// string ifade olarak kullanıcı kendi tahmin ettği sayıyı(rakamları farklı) giriyor.
                if (tahmin.Length != 4 || tahmin.Replace("\\D", "").Length != 4)// uzunluk 4'e eşit değilse tekraradan girdir. 
                {
                    Console.WriteLine("Geçersiz sayı.Sadece 0 - 9 rakamları arasından 4 basamaklı sayı girmelisin.");
                    return tuttugunsayi;
                }
                int[] tahminsayi = new int[4];//tahminsayi arrayi 4 sizeli açtık.
                for (int i = 0; i < 4; i++)
                {
                    tahminsayi[i] = int.Parse(tahmin[i].ToString());// tahmin arrayini stringten integera parse ederek dönüştürdük.
                    if (tahminsayi[0] == 0)//baş taraf sıfır olamayacağından tekrara girmesi için attık.
                    {
                        Console.WriteLine("Lütfen 4 basamaklı sayı girin.");
                        return tuttugunsayi;// methoda geri dönsün.
                    }
                }
                return tahminsayi;// methoda geri dönsün.
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Şimdi senle aklından sayı tut oyunu oynayalım.\n Ben sayı tutacağım sen tahmin etmeye çalışacaksın. \n Sen sayı tutup ben tahmin etmeye çalışacağım.");//konsolda ilk olarak yazdırıyoruz.
            Console.WriteLine(" ");
            Console.WriteLine("Şimdi bilgisayar olarak rakamları tekrarlamayan bir tane 4 basamaklı sayı tuttum. \n" + " Sende bu sayıyı 5 aşamada bu sayıyı tahmin etmeye çalış. \n"); //konsolda ilk ekrana yazdırıyoruz.
            Console.WriteLine("_______________________________________________________\n");

            /*
            List<int> ilist= Shuffle(rakamlar(4)).ToList().ConvertAll<int>(Convert.ToInt32);
            int[] randomsayi = ilist.ToArray();
            int[] randomsayi2 = new int[4];                            ******* burda stringi integera eşitlemeye çalıştım ve 3 index fazla 000 basıyor ve çözemedim. farklı methodlardan kullanıcı ve bilgisayar tahmin ve kullanıcı ve bilgisayar tuttuğu sayıyı farklı yaptım.***********
            bool a = false;
            for (int i = 0; i < randomsayi.Length; i++)
            {
                if (randomsayi2.Length == 4)
                {
                    a = true;
                    randomsayi2[i] = randomsayi[i];
                    Console.Write(randomsayi2[i]);
                }
                break;
            }*/
            int[] randomsayi = randomsayiuretme(); // randomsayi methodunda rakamları farklı 4 basamaklı sayı ürettirdim ve randomsayi arrayına kopyalattım. Randomsayi bir copy arrayidir. 
            int denemesayisi = 5; // Programı 5 aşamadan oluşturdum ve 5 olarak tanımladım. 
            int dogru = 0; // doğru sayısını 0 olarak yani boş olarak tanımladım.
            int yanlıs = 0; // yanlış sayısını 0 olarak yani boş olarak tanımladım.
            

            while (denemesayisi > 0 && dogru != 4) // denemesayisi sıfırdan büyük ve doğru rakam sayısı 4'e eşit değilse while döngüsü çalışsın.
            {
                int[] tahminsayi = tuttugunsayi; // kullanıcının tuttuğu rakamları farklı 4 basamaklı sayıyı tahminsayiya kopyaladım.
                dogru = 0;// doğru sayısını sıfırdan başlattım.
                yanlıs = 0;// yanlış sayısını sıfırdan başlattım.

                for (int i = 0; i < tahminsayi.Length; i++) //tahminsayi arrayinin uzunluğu kadar dönsün.
                {
                    if (tahminsayi[i] == randomsayi[i])// tahminsayi ve randomsayi arraylerindeki indexin içindeki sayi eşitse doğruyu bir artır.örnek binler basamağı binler basağındaki sayıya eşitse bir artır.
                    {
                        dogru++;
                    }
                    else if (tahminsayi[i] == randomsayi[0] || tahminsayi[i] == randomsayi[1] || tahminsayi[i] == randomsayi[2] || tahminsayi[i] == randomsayi[3])// tahminsayi arrayındaki bir tane indexdeki eleman eşitse yanlış basamakta olduğu için artır. örnek birler basmağı ile yüzler basasmağına eşitse yanlışı bir artır.
                    {
                        yanlıs++;
                    }

                }
                if (dogru == 4)// tahminsayi ve randomsayidaki arraylarının(indexdeki elemanlar eşitse bir artır.
                {
                    Console.Write("Tebrikler! Tahmininiz doğru! Tuttuğum Sayı: ");
                    for (int i = 0; i < tahminsayi.Length; i++)//tahminsayi uzunluğunda for döngüsü dönsün.Rakamları bastır.
                    {
                        Console.Write(tahminsayi[i]);
                    }
                }
                else
                {
                    denemesayisi--;// aşamayı azaltıyorum.
                    if (denemesayisi > 1)// denemesayısi 1 den büyükse console yazdır.
                    {
                        Console.WriteLine("Doğru pozisyonda " + "+" + dogru + " doğru rakamı, yanlış pozisyonda " + "-" + yanlıs + " doğru rakamı tahmin etmişsin. \n " + denemesayisi + " aşamanız kaldı.");
                    }
                    else if (denemesayisi == 1) // denemesayisi 1 e eşitse console yazdır.
                    {
                        Console.WriteLine("Doğru pozisyonda " + "+" + dogru + " doğru rakamı, yanlış pozisyonda " + "-" + yanlıs + " doğru rakamı tahmin etmişsin. \n Son aşamadasınız!. İyi şanslar =)");
                    }
                    else
                    {
                        Console.WriteLine("Maalesef, 5 aşamada sayıyı tahmin edemedin.");
                        Console.Write("Tuttuğum sayı: ");
                        for (int i = 0; i < randomsayi.Length; i++) // 5 aşamadan sonra eğer tahmin sayimiz tutmuyorsa console yazdır.
                        {
                            Console.Write(randomsayi[i]);
                        }
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Şimdi sen bir tekrarlamayan 4 rakamlı bir sayı tut ve ben tahmin etmeye çalışıyım.");
            Console.WriteLine("_______________________________________________________\n");
            Console.WriteLine(" ");
            List<string> dortrakam = Shuffle(rakamlar(4)).ToList(); //iteratör rakamlar methodundan aldığım shuffle methoduna atadım ve shuffle methodunu karıştırmak için yazdım.
            int tdogru = 0, tyanlıs = 0;//tahminin doğru yanlısı alsın diye tanımladım.
            while (dortrakam.Count > 1)
            {
                string tahmin = dortrakam[0];// bilgisayar tahminini atadım.
                Console.Write("Bilgisayar olarak benim tahminim {0}. Kaç tanesi doğru pozisyonda veya yanlış pozisyonda : ", tahmin);// tahmini yazdırmak için {0} parametresini alsın diye.
                dogru = 0;//dogru sıfırladım kullanıcı tahminden dolayı
                yanlıs = 0;//yanlıs sıfırladım kullanıcı tahminden dolayı
                if (!dogruyanlıs(out dogru, out yanlıs))// kullanıcı yanlış parametre girerse diye
                    Console.WriteLine("Dediğini anlamadım. Bir daha dene.");
                else
                    for (int bilcvp = dortrakam.Count - 1; bilcvp >= 0; bilcvp--)// dortrakamın countun bir eksiğinden başlayarak index sıfıra gidiyor.Çünkü her basamağına baktırmak için
                    {
                        tdogru = 0;//0 dan başlatarak
                        tyanlıs = 0;// 0 dan başlatarak
                        for (int i = 0; i < 4; i++)// dortrakamın son indexi almadan git. 
                            if (dortrakam[bilcvp][i] == tahmin[i])// dortrakam arrayı bilgisayarın tuttuğu sayı ile kullanıcının doğru pozisyon ipucu eşitse doğruyu artır.
                                tdogru++;
                            else if (dortrakam[bilcvp].Contains(tahmin[i]))// dortrakam arrayı bilgisayarın tuttuğu sayı ile kullanıcının yanlış pozisyon ipucu eşitse yanlışı artır.
                                tyanlıs++;
                        if ((tdogru != dogru) || (tyanlıs != yanlıs)) // tdoğru doğruya eşit değilse yada tyanlıs yanlısa eşit değilse bilcvpı at. yani index değiştir.
                            dortrakam.RemoveAt(bilcvp);
                    }
            }

            if (dortrakam.Count == 1)// count bire eşitse tuttuğun sayıyı bastır.
                Console.WriteLine("Evet buldum. Senin tuttuğun sayı {0}!", dortrakam[0]);
            else
                Console.WriteLine("Bulamadım");

            Console.ReadKey();
        }
    }
}
