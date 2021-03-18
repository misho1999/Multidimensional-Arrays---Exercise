using CommandPattern.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
