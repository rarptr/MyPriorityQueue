using EntryPoint;

var ch = new CommandHandler(new ConsoleWriter());
var input = "";
do
{
    input = Console.ReadLine();
    //var commandArray = input.Split(' ');

    ch.CheckOut(input);
}
while (input != Commands.Exit);
