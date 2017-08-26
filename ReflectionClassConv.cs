using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ReflectionClassConverter
{
    class ReflectionClassConv
    {
        static Target ConvertClass(Source sourceInstance)
        {
            Target targetInstance = new Target();

            var SourceFields = typeof(Source).GetProperties(); 
            var TargetFields = typeof(Target).GetProperties();

            try
            {
                foreach (var sourceItem in SourceFields)
                {
                    foreach (var targetItem in TargetFields)
                    {
                        if(sourceItem.Name == targetItem.Name)
                        {
                            targetItem.SetValue(targetInstance, sourceItem.GetValue(sourceInstance));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return targetInstance;
        }

        static void Main(string[] args)
        {
            Source sourceInstance = new Source() { MyProperty = 1, MyProperty2 = 2, MyProperty3 = 3};
            Target TargetResult = ConvertClass(sourceInstance);

            Console.WriteLine(TargetResult.MyProperty);
            Console.WriteLine(TargetResult.MyProperty2);
            Console.WriteLine(TargetResult.MyProperty3);

            Console.ReadKey();

        }
    }


    class Source
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }

    class Target
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }
}
