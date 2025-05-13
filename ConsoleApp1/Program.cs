namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Islemler islemler = new Islemler(new ogrenci());
            islemler.KayitYap();

            islemler = new Islemler(new personel());
        }
    }
    class personel:IKayit
    {
        public void kaydet()
        {
            Console.WriteLine("personel kaydedildi");
        }
    }
    class ogrenci:IKayit
    {
        public void kaydet()
        {
            Console.WriteLine("öğrenci kaydedildi");
        }
    }
    class Islemler
    {
        IKayit _kayit;

        public Islemler(IKayit kayit)
        {
            _kayit = kayit;

        }
        public void KayitYap()
        {
            _kayit.kaydet();
        }
    }

    interface IKayit
    {
        void kaydet();
    }
}
