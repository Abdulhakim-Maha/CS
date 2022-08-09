public class Program{
	public static void Main(){
		// unsigned interger maens positive whole number
		// including 0 
		// uint naturalNumber = 23;

		// integer means negative or positive whole number
		// including 0
		
		// int integerNumber = -23;

		// float means single-precision floating point
		// F suffix makes it a float literal
		// float realNumber = 2.3F;

		// double means double-precision floating point
		// double anotherRealNumber = 2.3; // double literal


		// Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}");

		//object
		object anotherName = "Hakim";
		int length = ((string)anotherName).Length;
		Console.WriteLine($"the length is {length}");

		//dynamic
		dynamic anotherName2 = "Hameedah";
		int length2 = anotherName2.Length;
		Console.WriteLine($"the length is {length2}");

		//int 
		int population = 66_000_000;
		int anotherPopulation = 66000000;
		Console.WriteLine($"{population} {anotherPopulation}");
	}
}