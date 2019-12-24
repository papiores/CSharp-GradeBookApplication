using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override double GetGPA(char letterGrade, StudentType studentType)
        {
            return base.GetGPA(letterGrade, studentType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Invalid student count for letter grade.");
            }
            var aboveAverage = Students.Where(s => s.AverageGrade >= averageGrade).ToList();
            var percentile = aboveAverage.Count / (decimal)Students.Count;
            if(percentile <= .2m)
            {
                return 'A';
            }
            else if ( percentile <= .4m)
            {
                return 'B';
            }
            else if ( percentile <= .6m)
            {
                return 'C';
            }
            else if ( percentile <= .8m)
            {
                return 'D';
            }

            return 'F';
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
