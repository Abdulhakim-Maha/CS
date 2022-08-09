public class Program{
	public static void Main(){
		string[] names;
		names = new string[4];
		names[0] = "Kate";
		names[1] = "Jack";
		names[2] = "Rebecca";
		names[3] = "Tom";

		for (int i = 0; i< names.Length; i++){
			Console.WriteLine(names[i]);
		}
	}
}
