using System;

namespace MyApp
{
    public class Program
    {
        public static int read_int()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void Main(string[] args)
        {
            Obraz o = new Obraz();
            Console.WriteLine("Wybierz opcje");
            int tryb = -1,dx,dy;
            Punkt p1, p2, p3, p4;
            while (tryb != 0)
            {
                Console.WriteLine("0 - Zakoncz program");
                Console.WriteLine("1 - Dodaj trojkat");
                Console.WriteLine("2 - Dodaj czworokat");
                Console.WriteLine("3 - Przesun wszystkie figury");
                Console.WriteLine("4 - Wyswietl obraz");
                tryb = Convert.ToInt32(Console.ReadLine());
                switch (tryb)
                {
                    case 1:
                        Console.WriteLine("Podaj pierwszy punkt");
                        p1 = Punkt.wczytaj();
                        Console.WriteLine("Podaj drugi punkt");
                        p2 = Punkt.wczytaj();
                        Console.WriteLine("Podaj trzeci punkt");
                        p3 = Punkt.wczytaj();
                        o.dodajTrojkat(new Trojkat(p1,p2,p3));
                        break;
                    case 2:
                        Console.WriteLine("Podaj pierwszy punkt");
                        p1 = Punkt.wczytaj();
                        Console.WriteLine("Podaj drugi punkt");
                        p2 = Punkt.wczytaj();
                        Console.WriteLine("Podaj trzeci punkt");
                        p3 = Punkt.wczytaj();
                        Console.WriteLine("Podaj czwarty punkt");
                        p4 = Punkt.wczytaj();
                        o.dodajCzworokat(new Czworokat(p1, p2, p3, p4));
                        break;
                    case 3:
                        Console.WriteLine("Podaj x i y przesuniecia");
                        dx = Program.read_int();
                        dy = Program.read_int();
                        o.przesun(dx, dy);
                        break;
                    case 4:
                        Console.WriteLine(o);
                        break;
                    default:
                        Console.WriteLine("Zakonczono program");
                        break;
                }
            }
            
        }
    }
    public class Punkt
    {
        private int x, y;

        public Punkt(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        public Punkt() : this(0, 0) { }
        public Punkt(Punkt p):this(p.x, p.y) { }
        public void przesun(int dx,int dy)
        {
            x += dx;
            y += dy;
        }
        public override String ToString()
        {
            return "("+x+","+y+")";
        }
        public static Punkt wczytaj()
        {
            return new Punkt(Program.read_int(), Program.read_int());
        }
    }
    public class Linia
    {
        private Punkt p1, p2;
        public Linia(Punkt pkt1, Punkt pkt2)
        {
            p1 = new Punkt(pkt1);
            p2 = new Punkt(pkt2);
        }
        public Linia()
        {
            p1 = new Punkt();
            p2 = new Punkt();
        }
        public Linia(Linia linia):this(linia.p1, linia.p2) { }
        public void przesun(int dx,int dy)
        {
            p1.przesun(dx,dy);
            p2.przesun(dx, dy);
        }
        public override string ToString()
        {
            return "("+p1.ToString()+","+p2.ToString()+")";
        }
    }
    public class Trojkat
    {
        Linia l1, l2, l3;
        public Trojkat()
        {
            l1 = new Linia();
            l2 = new Linia();
            l3 = new Linia();
        }
        public Trojkat(Punkt pkt1,Punkt pkt2,Punkt pkt3)
        {
            l1 = new Linia(pkt1, pkt2);
            l2 = new Linia(pkt2, pkt3);
            l3 = new Linia(pkt3, pkt1);
        }
        public Trojkat(Linia lin1,Linia lin2,Linia lin3)
        {
            l1 = new Linia(lin1);
            l2 = new Linia(lin2);
            l3 = new Linia(lin3);
        }
        public Trojkat(Trojkat trojkat) : this(trojkat.l1, trojkat.l2,trojkat.l3) { }
        public void przesun(int dx,int dy)
        {
            l1.przesun(dx, dy);
            l2.przesun(dx, dy);
            l3.przesun(dx, dy);
        }
        public override string ToString()
        {
            return "(" + l1.ToString() + "," + l2.ToString() + "," + l3.ToString() + ")";
        }
    }
    public class Czworokat
    {
        Linia l1, l2, l3,l4;
        public Czworokat()
        {
            l1 = new Linia();
            l2 = new Linia();
            l3 = new Linia();
            l4 = new Linia();
        }
        public Czworokat(Punkt pkt1, Punkt pkt2, Punkt pkt3, Punkt pkt4)
        {
            l1 = new Linia(pkt1, pkt2);
            l2 = new Linia(pkt2, pkt3);
            l3 = new Linia(pkt3, pkt4);
            l4 = new Linia(pkt4, pkt1);
        }
        public Czworokat(Linia lin1, Linia lin2, Linia lin3, Linia lin4)
        {
            l1 = new Linia(lin1);
            l2 = new Linia(lin2);
            l3 = new Linia(lin3);
            l4 = new Linia(lin4);
        }
        public Czworokat(Czworokat czworokat) : this(czworokat.l1, czworokat.l2, czworokat.l3, czworokat.l4) { }
        public void przesun(int dx, int dy)
        {
            l1.przesun(dx, dy);
            l2.przesun(dx, dy);
            l3.przesun(dx, dy);
            l4.przesun(dx, dy);
        }
        public override string ToString()
        {
            return "(" + l1.ToString() + "," + l2.ToString() + "," + l3.ToString() + "," + l4.ToString() + ")";
        }
    }
    public class Obraz
    {
        private List<Czworokat> czworokaty;
        private List<Trojkat> trojkaty;
        public Obraz()
        {
            czworokaty = new List<Czworokat>();
            trojkaty = new List<Trojkat>();
        }
        public void dodajTrojkat(Trojkat tr)
        {
            trojkaty.Add(tr);
        }
        public void dodajCzworokat(Czworokat cz)
        {
            czworokaty.Add(cz);
        }
        public void przesun(int dx,int dy)
        {

            for(int i = 0; i < czworokaty.Count; i++)
            {
                czworokaty[i].przesun(dx, dy);
            }
            for(int i=0; i < trojkaty.Count; i++)
            {
                trojkaty[i].przesun(dx, dy);
            }

        }
        public override String ToString()
        {
            string cz = "Czworokaty: \n";
            for(int i=0;i< czworokaty.Count; i++)
            {
                string z = czworokaty[i].ToString();
                cz += z+"\n";
            }
            string tr = "Trojkaty: \n";
            for(int j = 0; j < trojkaty.Count; j++)
            {
                string z = trojkaty[j].ToString();
                tr += z+"\n";
            }
            return cz + "\n" + tr;
        }
    }
}
