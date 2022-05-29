using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Examiniation_System.Questionss;
using Examiniation_System.Exam;


namespace Examiniation_System.Questionss
{
     class QuestionList : List<Question>
    {
        string fileName;

        public string FileName { get => fileName; set => fileName = value; }

        public QuestionList(string fileName) : base()
        {
            this.fileName = fileName;
        }

        public new void Add(Question question)
        {
            base.Add(question);
            StreamWriter file = new StreamWriter(FileName, append: true);
            file.WriteLine(question.ToString());
            file.Close();
        }
    }


    abstract class Question
    {
        string header;
        string body;
        int mark;

        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }
        public int Mark { get => mark; set => mark = value; }

        public Question(string body, int mark)
        {
            this.body = body;
            this.mark = mark;
        }

        public abstract void printQuestion();
        public abstract void takeAnswer();
        public abstract int markQuestion();
        public abstract void showCorrectAnswer();

        public void printChoice(int number, string choice)
        {
            Console.WriteLine(number + "." + choice);
        }

        public abstract override string ToString();

        public abstract string choicesToString();
    }

    class ChooseOne : Question
    {
        string[] choices;
        int correctAnswerIndex;
        int studentanswerIndex = -1;

        public string[] Choices { get => choices; set => choices = value; }
        public int CorrectAnswerIndex { get => correctAnswerIndex; set => correctAnswerIndex = value; }
        public int StudentanswerIndex { get => studentanswerIndex; set => studentanswerIndex = value; }

        public ChooseOne(string body, string[] choices, int mark, int correctAnswerIndex) : base(body, mark)
        {
            Header = "Choose One:";
            this.choices = choices;
            this.correctAnswerIndex = correctAnswerIndex;
        }

        public override void printQuestion()
        {
            Console.WriteLine(Body + "\t" + "Marks:" + Mark + "\n" + Header);
            for (int i = 0; i < choices.Length; i++)
            {
                printChoice(i, choices[i]);
            }
        }
        public override string choicesToString()
        {
            string choicesString = "";
            for (int i = 0; i < Choices.Length; i++)
            {
                choicesString += "\n" + i + "." + Choices[i];
            }
            return choicesString;
        }

        public override string ToString()
        {
            return Body + "\t" + "Marks: " + Mark + "\n" + Header + choicesToString() + "\n";
        }

        public override int markQuestion()
        {
            if (correctAnswerIndex == studentanswerIndex)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }

        public override void takeAnswer()
        {
            Console.Write("Answer Index: ");
            int ans = int.Parse(Console.ReadLine());
            StudentanswerIndex = ans;
        }

        public override void showCorrectAnswer()
        {
            Console.WriteLine("Correct Answer Index: " + correctAnswerIndex);
        }
    }

    class TrueFalse : Question
    {
        string[] choices = new string[2];
        int correctAnswerIndex;
        int studentanswerIndex = -1;

        public string[] Choices { get => choices; set => choices = value; }
        public int CorrectAnswerIndex { get => correctAnswerIndex; set => correctAnswerIndex = value; }
        public int StudentanswerIndex { get => studentanswerIndex; set => studentanswerIndex = value; }

        public TrueFalse(string body, int mark, int correctAnswerIndex) : base(body, mark)
        {
            Header = "Choose True or False:";
            choices[0] = "true";
            choices[1] = "false";
            this.correctAnswerIndex = correctAnswerIndex;
        }

        public override void printQuestion()
        {
            Console.WriteLine(Body + "\t" + "Marks:" + Mark + "\n" + Header);
            for (int i = 0; i < choices.Length; i++)
            {
                printChoice(i, choices[i]);
            }
        }

        public override string choicesToString()
        {
            string choicesString = "";
            for (int i = 0; i < Choices.Length; i++)
            {
                choicesString += "\n" + i + "." + Choices[i];
            }
            return choicesString;
        }

        public override string ToString()
        {
            return Body + "\t" + "Marks: " + Mark + "\n" + Header + choicesToString() + "\n";
        }

        public override int markQuestion()
        {
            if (correctAnswerIndex == studentanswerIndex)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }

        public override void takeAnswer()
        {
            Console.Write("Answer Index: ");
            int ans = int.Parse(Console.ReadLine());
            StudentanswerIndex = ans;
        }
        public override void showCorrectAnswer()
        {
            Console.WriteLine("Correct Answer Index: " + correctAnswerIndex);
        }
    }

    class ChooseAll : Question
    {
        string[] choices = new string[2];
        int[] correctAnswerIndex;
        int[] studentanswerIndex;

        public string[] Choices { get => choices; set => choices = value; }
        public int[] CorrectAnswerIndex { get => correctAnswerIndex; set => correctAnswerIndex = value; }
        public int[] StudentanswerIndex { get => studentanswerIndex; set => studentanswerIndex = value; }

        public ChooseAll(string body, string[] choices, int mark, int[] correctAnswerIndex) : base(body, mark)
        {
            Header = "Choose all the correct answers:";
            this.choices = choices;
            this.correctAnswerIndex = correctAnswerIndex;
        }

        public override void printQuestion()
        {
            Console.WriteLine(Body + "\t" + "Marks:" + Mark + "\n" + Header);
            for (int i = 0; i < choices.Length; i++)
            {
                printChoice(i, choices[i]);
            }
        }

        public override string choicesToString()
        {
            string choicesString = "";
            for (int i = 0; i < Choices.Length; i++)
            {
                choicesString += "\n" + i + "." + Choices[i];
            }
            return choicesString;
        }

        public override string ToString()
        {
            return Body + "\t" + "Marks: " + Mark + "\n" + Header + choicesToString() + "\n";
        }

        public override int markQuestion()
        {
            bool isCorrect = true;
            int wrongCount = 0;
            Array.Sort(correctAnswerIndex);
            Array.Sort(studentanswerIndex);
            for (int i = 0; i < correctAnswerIndex.Length; i++)
            {
                if (correctAnswerIndex[i] != studentanswerIndex[i])
                {
                    isCorrect = false;
                    wrongCount++;
                }
            }

            if (isCorrect)
            {
                return Mark;
            }
            else
            {
                int finalMark = Mark - wrongCount;
                finalMark = finalMark < 0 ? 0 : finalMark;
                return finalMark;
            }
        }

        public override void takeAnswer()
        {
            Console.Write("Answer Index: ");
            int[] ans = new int[correctAnswerIndex.Length];
            for (int i = 0; i < ans.Length; i++)
            {
                Console.WriteLine("enter answer index");
                ans[i] = int.Parse(Console.ReadLine());
            }
            StudentanswerIndex = ans;
        }

        public override void showCorrectAnswer()
        {
            Console.Write("Correct Answer Index: ");
            for (int i = 0; i < correctAnswerIndex.Length; i++)
            {
                Console.Write(correctAnswerIndex[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
