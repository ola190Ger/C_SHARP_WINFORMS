using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Group> groupList = new List<Group>()
            {
                new Group(){id=1, number=101},
                new Group(){id=2, number=102},
                new Group(){id=3, number=201},
                new Group(){id=4, number=202},
            };
            IList<Specializations> specList = new List<Specializations>()
            {
                new Specializations(){ facultyNumber=554214, special="Web Dev"},
                new Specializations(){ facultyNumber=554214, special="QA"},
                new Specializations(){ facultyNumber=653215, special="Web Dev"},
                new Specializations(){ facultyNumber=156212, special="PHP Dev"},
                new Specializations(){ facultyNumber=324413, special="PHP Dev"},
                new Specializations(){ facultyNumber=324413, special="Web Dev"},
                new Specializations(){ facultyNumber=134014, special="JS Dev"},
                new Specializations(){ facultyNumber=134014, special="QA/QC"},

            };

            IList<Student> studentList = new List<Student>()
            {
                new Student(){id=1, firstName="Sara", lastName="Gibson", age=24, mail="sm@gmail.com", phone="02435521", groupId=1, mark=new List<int>(){6,6,6,5 }, facultyNumber=554214 },
                new Student(){id=2, firstName="Andrew", lastName="Gibson", age=21, mail="ag@gmail.com", phone="0895223344", groupId=2, mark=new List<int>(){3,4,5,6 }, facultyNumber=653215 },
                new Student(){id=3, firstName="Craig", lastName="Ellis",age=19, mail="cel2@mail.com", phone="+3592667710", groupId=1, mark=new List<int>(){4,2,3,4 }, facultyNumber=156212},
                new Student(){id=4, firstName="Steve", lastName="Cole",age=35, mail="sscole@gl.om", phone="3242133312", groupId=2, mark=new List<int>(){5,6,5,5 }, facultyNumber=324413},
                new Student(){id=5, firstName="Andrew", lastName="Ellis",age=15, mail="sm@gm.co", phone="+001234532", groupId=3, mark=new List<int>(){5,3,4,2 }, facultyNumber=134014}
            };

            // 1 Print all students from group number 2. Use LINQ. Order the students by FirstName.

            var res1 = studentList.Join(groupList,

                student => student.groupId,
                group => group.id,
                (student, group) => new
                {
                    StudentFirstName = student.firstName,
                    StudentLastName = student.lastName,
                    group = group.number
                }).Where(s => s.group == 102).OrderBy(s => s.StudentFirstName);

            foreach (var item in res1)
            {
                Console.WriteLine(item.StudentFirstName + " " + item.StudentLastName + " " + item.group);
            }

            // 2 Using the same input as above print all students whose first name is before their last name lexicographically. Use LINQ. Print
            //them in order of appearance
            // what is lexicographically?
            Console.WriteLine("=== part 2 ===");
            var res2 = studentList.Where(s => 0 > string.Compare(s.firstName, s.lastName));
            foreach (var it in res2)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}  age {it.age} ");
            }

            //Write a LINQ function that finds the first name and last name of all students 
            //with age between 18 and 24. The query should
            //return the first name, last name and age.Print them in order of appearance.
            Console.WriteLine("=== part 3 ===");

            var res3 = studentList.Join(groupList,
                student => student.groupId,
                group => group.id,
            (student, group) => new
            {
                StudentFirstName = student.firstName,
                StudentLastName = student.lastName,
                age = student.age,
                group = group.number
            }).Where(s => s.age >= 18 && s.age <= 24);

            foreach (var it in res3)
            {
                    Console.WriteLine($"{it.StudentFirstName} {it.StudentLastName}  age {it.age} group {it.group}");
            }

            Console.WriteLine("=== part 3 (Max/Min) ===");
            foreach (var it in res3)
            {
                if (it.age == res3.Min(s => s.age) || it.age == res3.Max(s => s.age))
                    Console.WriteLine($"{it.StudentFirstName} {it.StudentLastName}  age {it.age} group {it.group}");

            }


            //Using the lambda expressions with LINQ syntax sort the students first by last name 
            //in ascending order and then by first
            //namein descending order.
            Console.WriteLine("=== part 4 ===");

            var res4= studentList.OrderBy(s => s.lastName).ThenByDescending(s => s.firstName);
            foreach (var it in res4)
            {
                    Console.WriteLine($"{it.firstName} {it.lastName}  age {it.age}");
            }

            //Print all students that have email @gmail.com in the order of appearance. Use LINQ.

            Console.WriteLine("=== part 5 ===");

            var res5 = studentList.Where(s=>s.mail.EndsWith("@gmail.com"));
            foreach (var it in res5)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}  age {it.age} mail {it.mail}");
            }

            //Print all students with phones starting with Sofia’s phone prefix(starting with 02 / +3592).Use LINQ.
            Console.WriteLine("=== part 6 ===");

            var res6 = studentList.Where(s => s.phone.StartsWith("02")|| s.phone.StartsWith("+3592"));
            foreach (var it in res6)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}  age {it.age} phone {it.phone}");
            }
            //Print all students that have at least one mark Excellent (6). Use LINQ.
            Console.WriteLine("=== part 7 ===");
            var res7 = studentList.Where(s => s.mark.Contains(6));
            foreach (var it in res7)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}");
            }
            //Write a similar program to the previous one to extract the students 
            //with at least 2 marks under or equal to "3". Use LINQ.
            Console.WriteLine("=== part 8 ===");
            var res8 = studentList.Where(s => s.mark.Count(m => m <= 3) >= 2);
            foreach (var it in res8)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}");
            }
            //Using LINQ, extract and print the Marks of the students that enrolled in 2014 or 2015 
            //(the students from 2014 have 14 as
            //their 5 - th and 6 - th digit in the FacultyNumber, those from 2015 have 15).
            Console.WriteLine("=== part 9 ===");
            var res9 = studentList.Where(s => s.facultyNumber.ToString().EndsWith("14") || s.facultyNumber.ToString().EndsWith("15"));
            foreach (var it in res9)
            {
                Console.Write($"{it.facultyNumber}      ");
                foreach (int i in it.mark)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
            //Create a class Person. It should consists of properties : name and group (String, Integer). 
            //Write a program that extracts all
            //persons(students), grouped by GroupName and then prints them on the console. 
            //Print all group names along with the
            //students in each group. Use the group by query in LINQ.You will be given an input on the console.
            Console.WriteLine("=== part 10 ===");
            var res10 = studentList.GroupBy(s => s.groupId);
            foreach(var it in res10)
            {
                Console.WriteLine($"        GroupID: {it.Key}");
                foreach(Student std in it)
                {
                    Console.WriteLine($"{std.firstName} {std.lastName}");

                }
            }


            Console.WriteLine("=== part 11 ===");

                        var res11 = studentList.Join(specList,

                student => student.facultyNumber,
                spec => spec.facultyNumber,
                (student, specialization) => new
                {
                    FirstName = student.firstName,
                    LastName = student.lastName,
                    faculty= specialization.facultyNumber,
                    trade=specialization.special
                }).OrderBy(s => s.FirstName);

            foreach (var it in res11)
            {
                Console.WriteLine($"{it.FirstName} {it.LastName}    {it.faculty}    {it.trade}");

            }




            Console.ReadKey();
        }
    }
}
