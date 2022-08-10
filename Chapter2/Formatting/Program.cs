int numberOfApples = 12;
decimal pricePerApple = 0.35M;
System.Console.WriteLine(
	format: "{0} apples costs {1:C}",
	arg0 :numberOfApples,
	arg1 :pricePerApple *numberOfApples
);

string formatted  = string.Format(
	format: "{0} apples costs {1:C}",
	arg0: numberOfApples,
	arg1: pricePerApple * numberOfApples
);

System.Console.WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples}");
