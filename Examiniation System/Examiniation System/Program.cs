using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiniation_System.Questionss;
using Examiniation_System.Exam;
using Examiniation_System;

namespace Examination
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("OOP");
            Question q1 = new ChooseOne("which access modifier allows access of parent attributes in child class", new string[3] { "private", "protected", "public" }, 5, 1);
            Question q2 = new TrueFalse("can a class inherit mupltiple classes in c#", 5, 0);
            Question q3 = new ChooseAll("choose access modifiers in classes", new string[5] { "private", "protected", "public", "internal", "free" }, 4, new int[4] { 0, 1, 2, 3 });
            QuestionList questions = new QuestionList("questions.txt");
            questions.Add(q1);
            questions.Add(q2);
            //questions.Add(q3);

            QuestionList questionsFinal = new QuestionList("questionsFinal.txt");
            questionsFinal.Add(q1);
            questionsFinal.Add(q2);
            questionsFinal.Add(q3);

            Console.WriteLine("Final Exam : 1");
            Console.WriteLine("Practise Exam : 2");
            Console.Write("Please Enter Type of Exam : ");
            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                DateTime date = new DateTime(2022, 5, 27);
                Exam ex1 = new FinalExam(date, subject, questionsFinal);
                ex1.printExam();
                Console.Write("Done Best Wishes");

            }
            else if (type == 2)
            {
                DateTime date = new DateTime(2022, 5, 27);

                Exam ex2 = new PracticeExam(date, subject, questions);
                ex2.printExam();
                Console.Write("Done Best Wishes");
                
            }
            else
            {
                Console.WriteLine("Invalid Type");
            }
            Console.ReadLine();
        }
    }



    







    
}
