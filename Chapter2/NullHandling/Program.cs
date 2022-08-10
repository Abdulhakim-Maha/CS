int thisCannotBeNull = 5;
// thisCannotBeNull = null; // compile error!

int? thisCanbeNull = null;
System.Console.WriteLine(thisCanbeNull);
System.Console.WriteLine(thisCanbeNull.GetValueOrDefault());

thisCanbeNull = 7;
System.Console.WriteLine(thisCanbeNull.GetValueOrDefault());