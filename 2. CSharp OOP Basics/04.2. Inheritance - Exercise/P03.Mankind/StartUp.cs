namespace P03.Mankind
{
    using System;

    class StartUp
    {
        static void Main()
        {
            try
            {
                Student student = CreateStudent();
                Worker worker = CreateWorker();

                PrintOutput(student, worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static Student CreateStudent()
        {
            var studentInfo = Console.ReadLine().Split();

            var firstName = studentInfo[0];
            var lastName = studentInfo[1];
            var facultyNumber = studentInfo[2];

            return new Student(firstName, lastName, facultyNumber);
        }

        private static Worker CreateWorker()
        {
            var workerInfo = Console.ReadLine().Split();

            var firstName = workerInfo[0];
            var lastName = workerInfo[1];
            var salary = decimal.Parse(workerInfo[2]);
            var workingHours = double.Parse(workerInfo[3]);

            return new Worker(firstName, lastName, salary, workingHours);
        }

        private static void PrintOutput(Student student, Worker worker)
        {
            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
    }
}