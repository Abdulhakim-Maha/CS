using static System.Console;
using static System.Convert;

int a = 10;
double b = a;
WriteLine(b);

double c = 9.8;
int d = (int)c;
WriteLine(d);

double g = 7.5;
int h = ToInt32(g);
WriteLine($"g is {g} and h is {h}");

