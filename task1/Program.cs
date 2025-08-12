
// Task 1
Console.WriteLine("Enter number of small carpets");
int smallCarpets = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter number of large carpets");
int largeCarpets = Convert.ToInt32(Console.ReadLine());

int totalPrice = (smallCarpets * 25) + (largeCarpets * 35);

Console.WriteLine($"Toatal estimate: {totalPrice * 1.06}");
Console.WriteLine("This estimate is valid for 30 days");




// Search Task Example from slides
/*

int X = 10;
int Y = 20;
Console.WriteLine($"Equation: {X} + {Y} = {X + Y:C}");
*/



// Search Task Example from me
/*
double completionRate = 0.875;
Console.WriteLine($"Completion: {completionRate:P}");
*/