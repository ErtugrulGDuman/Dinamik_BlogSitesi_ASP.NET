using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AltTab.Models
{
	public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			var Category = new List<Category>()
			{
				new Category() {CategoryName = "C#"},
				new Category() {CategoryName = "PYTHON"},
				new Category() {CategoryName = "JAVA"}

			};
			foreach (var item in Category)
			{
				context.Categories.Add(item);
			}
			context.SaveChanges();

			var Makale = new List<Makale>()
			{
				new Makale() {Title="C# Dilindeki Temel Veri Türleri", Description="int: Tam sayıları temsil eder. Örneğin: int age = 25;\r\nfloat: Ondalıklı sayıları (tek hassasiyetli kayan nokta) temsil eder. Örneğin: float pi = 3.14f;\r\ndouble: Çift hassasiyetli kayan nokta sayıları temsil eder. Örneğin: double pi = 3.14159;\r\ndecimal: Hassas ondalık sayıları temsil eder. Örneğin: decimal amount = 123.45m;\r\nchar: Tek bir karakteri temsil eder. Örneğin: char grade = 'A';\r\nstring: Metin veya karakter dizilerini temsil eder. Örneğin: string name = \"John\";\r\nbool: Mantıksal değerleri temsil eder, yani true veya false. Örneğin: bool isTrue = true;\r\nbyte: 8-bit (1 byte) tamsayıları temsil eder. Örneğin: byte data = 255;\r\nshort: Kısa tam sayıları temsil eder (genellikle 16 bit). Örneğin: short temperature = -10;\r\nlong: Uzun tam sayıları temsil eder (genellikle 64 bit). Örneğin: long population = 8000000L;\r\nBu veri tipleri, C# programlamada farklı türdeki verileri depolamak ve işlemek için kullanılır.", Image="A1.png", ReleaseDate=Convert.ToDateTime("2023-10-08"), Views=0, Confirm=true, CategoryId=1, UseName="GokayDuman"},
				new Makale() {Title="PYTHON Dilindeki Temel Veri Türleri", Description="int: Tam sayıları temsil eder. Örneğin: age = 25\r\n\r\nfloat: Ondalıklı sayıları (tek veya çift hassasiyetli kayan nokta) temsil eder. Örneğin: pi = 3.14\r\n\r\nstr: Metin veya karakter dizilerini temsil eder. Örneğin: name = \"John\"\r\n\r\nbool: Mantıksal değerleri temsil eder, yani True veya False. Örneğin: is_true = True\r\n\r\nlist: Birden fazla öğeyi depolamak için kullanılan bir veri yapısıdır. Örneğin: numbers = [1, 2, 3, 4]\r\n\r\ntuple: Listenin değiştirilemez bir versiyonudur. Öğeleri değiştirilemez. Örneğin: coordinates = (x, y)\r\n\r\ndict: Sözlükleri temsil eder, anahtar-değer çiftleri şeklinde veri depolar. Örneğin: person = {\"name\": \"Alice\", \"age\": 30}\r\n\r\nset: Benzersiz öğelerin koleksiyonunu temsil eder. Örneğin: unique_numbers = {1, 2, 3, 4}\r\n\r\nNoneType: Bir değer atanmamış veya yok olarak temsil edilir. Örneğin: result = None\r\n\r\nPython, dinamik bir tipleme sistemine sahip olduğu için değişken türlerini belirlemek için veri tiplerini açıkça belirtmeniz gerekmez. Bu temel veri tipleri, Python'da veri depolama, işleme ve manipülasyon için temel araçlarınızı oluşturur. Ayrıca, daha karmaşık veri yapıları ve sınıflar da oluşturabilirsiniz.\r\n\r\n\r\n\r\n\r\n\r\n", Image="A2.png", ReleaseDate=Convert.ToDateTime("2023-12-25"), Views=0, Confirm=true, CategoryId=2, UseName="ErtugrulDuman"},
				new Makale() {Title="JAVA Dilindeki Temel Veri Türleri", Description="İlkel (Primitive) Veri Tipleri:\r\n\r\nint: Tam sayıları temsil eder. Örneğin: int age = 25;\r\n\r\nfloat: Tek hassasiyetli kayan nokta ondalık sayıları temsil eder. Örneğin: float pi = 3.14f;\r\n\r\ndouble: Çift hassasiyetli kayan nokta ondalık sayıları temsil eder. Örneğin: double pi = 3.14159;\r\n\r\nchar: Tek bir karakteri temsil eder. Örneğin: char grade = 'A';\r\n\r\nboolean: Mantıksal değerleri temsil eder, yani true veya false. Örneğin: boolean isTrue = true;\r\n\r\nbyte: 8-bit (1 byte) tamsayıları temsil eder. Örneğin: byte data = 127;\r\n\r\nshort: 16-bit tamsayıları temsil eder. Örneğin: short temperature = -10;\r\n\r\nlong: 64-bit tamsayıları temsil eder. Örneğin: long population = 8000000L;\r\n\r\nİlkel (Primitive) Veri Türleri: Bunlar, ilkel veri türlerinin değerini tutmadığını ifade eder. Örneğin: Integer number = 42;\r\n\r\nReferans (Reference) Veri Tipleri:\r\n\r\nString: Metin veya karakter dizilerini temsil eder. Örneğin: String name = \"John\";\r\n\r\nArray: Dizi veri yapısını temsil eder. Örneğin: int[] numbers = {1, 2, 3, 4};\r\n\r\nClass: Sınıf türlerini temsil eder. Örneğin: Person person = new Person();\r\n\r\nInterface: Arayüz türlerini temsil eder. Örneğin: Runnable task = new MyRunnable();\r\n\r\nEnum: Sabit değerlerin koleksiyonunu temsil eder. Örneğin: enum Day { MONDAY, TUESDAY, WEDNESDAY, ... };\r\n\r\nJava'da temel veri tipleri ve referans veri tipleri, veri manipülasyonu ve nesne yönelimli programlama (OOP) için temel taşları oluşturur.", Image=".net.png", ReleaseDate=Convert.ToDateTime("2023-11-20"), Views=0, Confirm=true, CategoryId=3, UseName="SanemDuman"}
			};
			foreach (var item in Makale)
			{
				context.Makales.Add(item);
			}
			context.SaveChanges();
			base.Seed(context);
		}
	}
}