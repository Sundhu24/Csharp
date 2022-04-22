
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {

        static void Main(string[] args)
        {

            Hashtable ht = new Hashtable();

            /*ht.Add(1, "First");
            ht.Add(2, "Second");
            ht.Add(3, "Third");

            foreach(DictionaryEntry vals in ht)
            {
                Console.WriteLine("Key {0} - Value {1}", vals.Key, vals.Value);
            }*/

            Student s1 = new Student(1, "Mariya", 95);
            Student s2 = new Student(2, "John", 75);
            Student s3 = new Student(3, "Peter", 85);
            Student s4 = new Student(4, "Mariya 2", 59);
            Student s5 = new Student(5, "Mariya 3", 90);

            //Console.WriteLine(s4.Id);

            ht.Add(s1.Id, s1);
            ht.Add(s2.Id, s2);
            ht.Add(s3.Id, s3);
            ht.Add(s4.Id, s4);
            ht.Add(s5.Id, s5);

            Student storedRec = (Student)ht[s1.Id];

            Console.WriteLine("{0} - {1} - {2}", storedRec.Id, storedRec.Name,storedRec.Point);

            Console.ReadKey();
        }

        class Student
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public float Point { get; set; }

            public Student(int id, string name, float point)
            {
                this.Id = id;
                this.Name = name;
                this.Point = point;
            }
        }


    }
}
