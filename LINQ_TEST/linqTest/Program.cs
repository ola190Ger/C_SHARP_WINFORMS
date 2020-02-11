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
                new Group(){id=5, number=301},
                new Group(){id=6, number=302}
            };

            IList<Student> studentList = new List<Student>()
            {
                new Student(){id=1, firstName="Sara", lastName="Gibson", age=24, mail="sm@gmail.com", phone="02435521", groupId=1},
                new Student(){id=2, firstName="Andrew", lastName="Gibson", age=21, mail="ag@gmail.com", phone="0895223344", groupId=2},
                new Student(){id=3, firstName="Craig", lastName="Ellis",age=19, mail="cel2@mail.com", phone="+3592667710", groupId=1},
                new Student(){id=4, firstName="Steve", lastName="Cole",age=35, mail="sscole@gl.om", phone="3242133312", groupId=2},
                new Student(){id=5, firstName="Andrew", lastName="Ellis",age=15, mail="sm@gm.co", phone="+001234532", groupId=2}
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
            foreach (var it in res5)
            {
                Console.WriteLine($"{it.firstName} {it.lastName}  age {it.age} phone {it.phone}");
            }





            Console.ReadKey();
        }
    }
}
