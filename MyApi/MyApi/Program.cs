using System;

namespace MyNamespace
{
    interface ParentsGetterSetters
    {
       string pName { get; set; }
       int pAge { get; set; }
       bool pChildren { get; set; }
    }
    class Parents:ParentsGetterSetters
    {
        private string name;
        private int age;
        private bool children;

        public string pName
        {
            get { return name; }
            set { name = value; }
        }
        public int pAge
        {
            get { return age; }
            set { age = value; }
        }
        public bool pChildren
        {
            get { return children; }
            set { children = value; }
        }

        class ParentsAssociation<T>
        {
            private T[] arr = new T[100];

            public T this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var allParents = new ParentsAssociation<Parents>();
                Parents p1 = new Parents();
                p1.pName = "Karen";
                p1.pAge = 41;
                p1.pChildren = true;
                allParents[0] = p1;
                Console.WriteLine(allParents[0].pName);
            }
        }
    }
}

