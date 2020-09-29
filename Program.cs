using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	partial class Abiturient
	{
		//++// Статическое поле
		public static int amount = 0;

		//++// Поле-константа
		const int code = 74359;

		//++// Конструктор по умолчанию
		public string lname;
		public string name;
		public string patron;
		public string adress;
		public long tel;
		public int[] marks = new int[11];

		//++// Конструктор без параметров
		public Abiturient()
		{
			lname = "Ivanov";
			name = "Ivan";
			patron = "Ivanovich";
			adress = "Minsk";
			tel = 80331234567;
			for (int i = 0; i < 11; i++)
			{
				marks[i] = 7;
			}

			amount++;
		}

		//++// Конструктор с параметрами
		public Abiturient(string _lname, string _name, string _patron, string _adress, long _tel, int[] _marks)
		{
			lname = _lname;
			name = _name;
			patron = _patron;
			adress = _adress;
			tel = _tel;
			for (int i = 0; i < 11; i++)
			{
				marks[i] = _marks[i];
			}

			amount++;
		}

		//++// Закрытый конструктор
		public int X { get; }

		private Abiturient(int a)
		{
			X = a;
		}

		public static Abiturient Contructor(int a)
		{
			return new Abiturient(a);
		}

		//++// Переопределение
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Abiturient m = obj as Abiturient;
			if (m as Abiturient == null)
				return false;
			return m.lname == this.lname && m.name == this.name && m.patron == this.patron;
		}
		public bool Equals(Abiturient obj)
		{
			if (obj == null)
				return false;
			return obj.lname == this.lname && obj.name == this.name && obj.patron == this.patron;
		}

		//++// Только для чтения
		public readonly int smthng = 345;

		public override int GetHashCode()
		{
			int unitCode;
			if (adress == "Minsk")
				unitCode = 1;
			else unitCode = 2;
			return amount + unitCode;
		}
	}

	//++// Class partial
	partial class Abiturient
	{
		//++// Set и get
		public string Adress
		{
			get
			{
				return adress;
			}
			set
			{
				adress = value;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var v = Abiturient.Contructor(2);
			Console.WriteLine(v.X);

			Abiturient abit1 = new Abiturient();
			Abiturient abit2 = abit1;

			int[] marks = new int[11] { 9, 10, 8, 8, 10, 9, 9, 9, 10, 8, 8 };
			Abiturient abit3 = new Abiturient("Voshchuk", "Daniil", "Aleksandrovich", "Kamenets", 80336998835, marks);
			Console.WriteLine(abit3.Adress);
			abit3.Adress = "Brest";
			Console.WriteLine(abit3.Adress);

			Console.WriteLine(abit1.GetHashCode());
			Console.WriteLine(abit2.GetHashCode());
			Console.WriteLine(abit3.GetHashCode());

			Console.WriteLine(abit1.Equals(abit2));
			Console.WriteLine(abit1.Equals(abit3));

			int a = 5;
			Console.WriteLine("Начальное значение переменной a = " + a);
			IncrementRef(a);
			Console.WriteLine("Переменная a после передачи значению равна = " + a);
			IncrementRef(ref a);
			Console.WriteLine("Переменная a после передачи ссылке равна = " + a);

			var regjyu = new { lname = "Tfdsfsd", name = "Fgsdhgfhjs", patron = "Jedjksf", adress = "Swefsvo", tel = 75434579483, marks };
			Console.WriteLine(regjyu.lname);

			Abiturient[] abitArr = new Abiturient[3] { abit1, abit2, abit3 };
			bool check = true;
			for (int i = 0; i < 3; i++)
			{
				lowerThen8Check(abitArr[i], out check);
				if (!check)
					Console.WriteLine(abitArr[i].lname + " have bad marks!");
			}

			int amo = 0;
			for (int i = 0; i < 3; i++)
			{
				amo = 0;
				lowerThen88Check(abitArr[i], out amo);
				if (amo > 88)
					Console.WriteLine(abitArr[i].lname + " is good abiturient!");
			}
		}

		static void lowerThen8Check(Abiturient a, out bool check)
		{
			check = true;
			for (int i = 0; i < 11; i++)
				if (a.marks[i] < 8)
					check = false;
		}

		static void lowerThen88Check(Abiturient a, out int amo)
		{
			amo = 0;
			for (int i = 0; i < 11; i++)
				amo += a.marks[i];
		}

		static void IncrementRef(int x)
		{
			x++;
			Console.WriteLine(x);
		}
		static void IncrementRef(ref int x)
		{
			x++;
			Console.WriteLine(x);
		}
	}
}
