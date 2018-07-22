﻿namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}