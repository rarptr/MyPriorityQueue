using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace EntryPoint
{
    internal class CommandHandler
    {
        private IOutput _writer;
        PriorityQueue<User> us;
        Kit kit;
        public CommandHandler(IOutput writer)
        {
            _writer = writer;
            us = new PriorityQueue<User>(new ConsoleWriter());
            kit = new Kit();
        }

        public void CheckOut(string command, string parameter = "")
        {
            switch (command)
            {
                case Commands.Add:
                    var newUser = User.GetRndUser(kit);
                    us.Add(newUser);
                    _writer.Write("Added: " + newUser);
                    break;

                case Commands.Extract:
                    var user = us.Extract();
                    _writer.Write("Retrieved: " + user);
                    break;

                case Commands.DisplayAll:
                    us.DisplayAll();
                    break;

                case Commands.AllCommands:
                    var type = typeof(Commands);
                    var allConstants = type.GetFields();
                    foreach(var field in allConstants)
                    {
                        _writer.Write(field.GetValue(type).ToString());
                    }
                    
                    break;

                default:
                    _writer.Write("Command not found.");
                    return;
            }
        }
    }
}
