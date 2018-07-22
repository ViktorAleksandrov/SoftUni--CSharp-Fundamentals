namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;

    public class PrintOrderedStudentsCommand : Command
    {
        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string orderType = this.Data[2].ToLower();
            string orderCommand = this.Data[3].ToLower();
            string orderQuantity = this.Data[4].ToLower();

            TryParseParametersForOrderAndTake(orderCommand, orderQuantity, courseName, orderType);
        }

        private void TryParseParametersForOrderAndTake(
            string orderCommand, string orderQuantity, string courseName, string orderType)
        {
            if (orderCommand == "take")
            {
                if (orderQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, orderType);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(orderQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, orderType, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}