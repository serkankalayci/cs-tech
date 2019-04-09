using System;

public class proje
{


    public static void Main(string[] args)
    {
        Console.WriteLine("Bilgisayar olarak rakamları tekrarlamayan bir tane 4 basamaklı sayı tuttum. \n" + " Sende sayı tut ve 5 aşamada bu sayıyı tahmin etmeye çalış. \n");//consolda ilk ekrana yazdırıyoruz.
        Console.WriteLine("_______________________________________________________\n");
        int[] randomsayi = randomsayiuretme(); // randomsayi methodunda rakamları farklı 4 basamaklı sayı ürettirdim ve randomsayi arrayına kopyalattım. Randomsayi bir copy arrayidir. 
        int denemesayisi = 5; // Programı 5 aşamadan oluşturdum ve 5 olarak tanımladım. 
        int dogru = 0; // doğru sayısını 0 olarak yani boş olarak tanımladım.
        int yanlıs = 0; // yanlış sayısını 0 olarak yani boş olarak tanımladım.
        
        while (denemesayisi > 0 && dogru!= 4) // denemesayisi sıfırdan büyük ve doğru rakam sayısı 4'e eşit değilse while döngüsü çalışsın.
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
                    Console.WriteLine("Doğru pozisyonda "+"+"+ dogru +" doğru rakamı, yanlış pozisyonda "+ "-" + yanlıs +" doğru rakamı tahmin etmişsin. \n "+ denemesayisi +" aşamanız kaldı.");
                }
                else if (denemesayisi == 1) // denemesayisi 1 e eşitse console yazdır.
                {
                    Console.WriteLine("Doğru pozisyonda "+ "+" + dogru +" doğru rakamı, yanlış pozisyonda "+ "-" + yanlıs +" doğru rakamı tahmin etmişsin. \n Son aşamadasınız!. İyi şanslar =)");
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
          Console.ReadKey();//Konsol kapanmasın diye 
    }
    public static int[] randomsayiuretme()//bilgisayar sayıyı ürettiği method 
    {
        Random random = new Random(); // random class random sayı üretmek için 
        int[] dortbasamak = new int[] { 10, 10, 10, 10 };// dörtbasamaklı sayı üretmek için 10lar ise 0-9 rakamları temsil ediyor.
        for (int i = 0; i < dortbasamak.Length; i++)//index 0 den lengthe kadar sayı ürettirdik.
        {
            int temp = random.Next(0,9);//rakam 0-9 a rastgele gelsin.
            while (temp == dortbasamak[0] || temp == dortbasamak[1] || temp == dortbasamak[2] || temp == dortbasamak[3])
            {
                temp = random.Next(0,9);// eğer birisine eşitse random rakam tekrardan üretsin.
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

    
    
}

