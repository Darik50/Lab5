using System;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var AirBug = new Air();
            AirBug.Add(new Animals { Name = "Pushok", Cage = true });
            AirBug.Add(new Sub { Type = "Skiing", Size = 10 });
            Console.WriteLine("ReportA");
            AirBug.Accept(new ReportA());
            Console.WriteLine("ReportB");
            AirBug.Accept(new ReportB());

            Console.ReadKey();
        }
    }
    /// <summary>
    /// Интерфейс для составления отчетов.
    /// </summary>
    interface Visit
    {
        void VisitAnimal(Animals anim);
        void VisitSubj(Sub subj);
    }

    /// <summary>
    /// Класс для составления отчета A
    /// </summary>
    class ReportA : Visit
    {
        public void VisitAnimal(Animals anim)
        {
            string rep = "Name: " + anim.Name + ". The presence of a cell: ";
            if (anim.Cage)
            {
                rep = rep + "Yes";
            }
            else
            {
                rep = rep + "No";
            }
            Console.WriteLine(rep);
        }

        public void VisitSubj(Sub subj)
        {
            string rep = "Type: " + subj.Type + ". Size: " + subj.Size + ".";
            Console.WriteLine(rep);
        }
    }

    /// <summary>
    /// Класс для составления отчета B
    /// </summary>
    class ReportB : Visit
    {
        public void VisitAnimal(Animals anim)
        {
            string rep = "Name: " + anim.Name + ".";
            if (anim.Cage)
            {
                rep = rep + "The animal is admitted.";
            }
            else
            {
                rep = rep + "The animal is not allowed.";
            }
            Console.WriteLine(rep);
        }

        public void VisitSubj(Sub subj)
        {
            string rep = "Type: " + subj.Type + ".";
            if (subj.Size > 10)
            {
                rep = rep + " Not allowed.";
            }
            else
            {
                rep = rep + " Allowed.";
            }
            Console.WriteLine(rep);
        }
    }

    /// <summary>
    /// Класс о всех поклажах.
    /// </summary>
    class Air
    {
        List<Lug> Lugges = new List<Lug>();
        public void Add(Lug obg)
        {
            Lugges.Add(obg);
        }
        public void Accept(Visit visitor)
        {
            foreach (Lug obg in Lugges)
                obg.Accept(visitor);
        }
    }

    /// <summary>
    /// Интерфейс поклажи.
    /// </summary>
    interface Lug
    {
        void Accept(Visit visitor);
    }
    /// <summary>
    /// Класс животных.
    /// </summary> 
    class Animals : Lug
    {
        public string Name { get; set; }
        public bool Cage { get; set; }

        public void Accept(Visit visitor)
        {
            visitor.VisitAnimal(this);
        }
    }
    /// <summary>
    /// Класс предметов.
    /// </summary> 
    class Sub : Lug
    {
        public string Type { get; set; }
        public int Size { get; set; }

        public void Accept(Visit visitor)
        {
            visitor.VisitSubj(this);
        }
    }
}
