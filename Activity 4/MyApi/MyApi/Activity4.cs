using System;

namespace MyNamespace
{
    interface ParentsGetterSetters
    {
       //String property
       string pName { get; set; }

       //Int property
       int pAge { get; set; }

       //Bool Property
       bool pChildren { get; set; }

       // Indexer
       String this[int index] { get; set; }

       //Instance
       void getParentInfo();
    }
    class Parents:ParentsGetterSetters
    {
        private string name;
        private int age;
        private bool children;

        //Array for indexer
        private String[] childrenName = new String[100];

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
        public String this[int i]
        {
            get { return childrenName[i]; }
            set { childrenName[i] = value; }
        }

        public void getParentInfo()
        {
            var allChildrenName="";
            if (pChildren)
            {
                foreach (var child in this.childrenName)
                {
                    if(child != null)
                        allChildrenName+=child + ", ";
                }
            }
            Console.WriteLine("Name: " + this.pName + " Age: " + this.pAge + " Has Children: " + pChildren + " Children Names: "+ allChildrenName);
        }
        class Program
        {
            static void Main(string[] args)
            {
                //Using Class in Main
                var allParents = new Parents();
                allParents.pName = "Karen";
                allParents.pAge = 41;
                allParents.pChildren = true;
                allParents[0] = "Chad";
                allParents[1] = "Stacy";
                allParents[2] = "Caren";
                allParents[3] = "Greg";
                allParents.getParentInfo();
            }
        }
    }
}