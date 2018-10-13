using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    class CommandProcessor
    {
        private List<Command> _cmdPsr = new List<Command>();

        public CommandProcessor()
        {
            LookCommand LookCommand = new LookCommand(new string[] { "look" } );
            MoveCommand MoveCommand = new MoveCommand(new string[] { "move" } );

            _cmdPsr.Add(LookCommand);
            _cmdPsr.Add(MoveCommand);
        }

        public void Proccess(string cmd, Player p)
        {
            string[] commands = cmd.Split(' ');

            switch (commands[0].ToLower())
            {
                case "move":
                    foreach (Command c in _cmdPsr)
                    {
                        if (c.CmdType.ToLower() == "move")
                        {
                            Console.WriteLine(c.Execute(p, commands));
                        }
                    }
                    break;
                case "look":
                    foreach (Command c in _cmdPsr)
                    {
                        if (c.CmdType.ToLower() == "look")
                        {
                            Console.WriteLine(c.Execute(p, commands));
                            
                        }
                    }
                break;
                default:
                    Console.WriteLine("Command Not Recognised");
                break;
            }
        }

        public List<Command> CommandProccessor
        {
            get
            {
                return _cmdPsr;
            }
        }
    }
}
