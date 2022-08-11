using static System.Console;

public class Program{
	public static void Main(string[] args){
		// object o = 3;
		// int j = 4;
		// if (o is int i){ // check whether if o is integer. if is assign them to variable i.
		// 	WriteLine($"{i} x {j} = {i*j}");
		// }
		// else{
		// 	WriteLine("cannot multiply");
		// }

		// foreach
		string[] names = {"austiniqer", "hakim", "kenobi"};
		foreach (string name in names)
		{
			WriteLine($"{name} has {name.Length} characters");		
		}
	}
}

