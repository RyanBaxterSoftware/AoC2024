
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please choose which day you would like to run?");

var dayEntered = Console.ReadLine();
while(dayEntered != "Exit") {
    switch(dayEntered) {
    case "1":
        Day1.TotalRun();
        break;
    case "2":
        Day2.TotalRun();
        break;
    default:
        Console.WriteLine("I didn't find that day. Here is Hello World instead.");
        BasicCode.runHelloWorld();
        break;
    }

    Console.WriteLine("That was fun! Want to run another? Enter the day or 'Exit'");
    dayEntered = Console.ReadLine();
}
