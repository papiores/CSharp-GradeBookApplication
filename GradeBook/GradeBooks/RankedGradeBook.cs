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
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            base.CalculateStudentStatistics(name);
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
            var grade = 'F';
            var percentile = ((decimal)Students.Select(s => s.AverageGrade >= averageGrade).ToList().Count) / Students.Count;
            grade = percentile <= .8m
                ? 'D'
                : grade;
            grade = percentile <= .6m
                ? 'C'
                : grade;
            grade = percentile <= .4m
                ? 'B'
                : grade;
            grade = percentile <= .2m
                ? 'A'
                : grade;

            return grade;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
