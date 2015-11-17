namespace _02.Rabbits
{
    using System;
    using System.Linq;

    class RabbitsCount
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] answers = new int[n];

            for (int i = 0; i < answers.Length; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(answers);

            int result = 0;

            for (int i = 0; i < answers.Length; i++)
            {
                if (i + answers[i] < answers.Length)
                {
                    if (answers[i] == answers[i + answers[i]])
                    {
                        i += answers[i];
                        result += answers[i] + 1;
                        continue;
                    }

                    i = Array.LastIndexOf(answers, answers[i]);
                    result += answers[i] + 1;
                    continue;
                }

                i = Array.LastIndexOf(answers, answers[i]);
                result += answers[i] + 1;

                if (answers[i] == answers.Last())
                {
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
