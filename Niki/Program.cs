﻿namespace Computers.UI
{
    using System;

    using Logic.ComputerTypes;
    using Logic.Manufacturers;

    public static class Program
    {
        private const string InvalidCommandMessage = "Invalid command!";
        private const string ExitCommandName = "Exit";
        private const string ChargeCommandName = "Charge";
        private const string ProcessCommandName = "Process";
        private const string PlayCommandName = "Play";

        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            CreateComputers();
            ProcessCommands();
        }

        private static void CreateComputers()
        {
            var manufacturerFactory = new ManufacturerFactory();

            var manufacturerName = Console.ReadLine();
            IComputersFactory computerFactory =
                manufacturerFactory.GetManufacturer(manufacturerName);

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
        }

        private static void ProcessCommands()
        {
            // TODO: Command design pattern
            while (true)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    break;
                }

                if (c.StartsWith(ExitCommandName))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    throw new ArgumentException(InvalidCommandMessage);
                }

                var commandName = cp[0];
                var commandArgument = int.Parse(cp[1]);

                if (commandName == ChargeCommandName)
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommandName)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommandName)
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine(InvalidCommandMessage);
                }
            }
        }
    }
}
