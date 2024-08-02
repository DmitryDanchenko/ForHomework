using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork3
{
    internal class F
    {
        public int MyInt;
        public string MyString;
        public static F Get => new F { MyInt = 1, MyString = "Foo" };

        public string ToCsv(object o)
        {
            return string.Join("\n", o.GetType().GetFields().Select(x => x.Name + "," + x.GetValue(o)));
        }

        public void WriteInFile(string str)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "serializationData";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.Write(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public F ReadFile()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "serializationData";
            var deserializedClass = new F();

            using (StreamReader sr = new StreamReader(path))
            {
                string[] array = new string[2];
                string line;
                line = sr.ReadLine();
                array = line.Split(',');
                var propertyInfo = deserializedClass.GetType().GetField(array[0]);
                propertyInfo.SetValue(deserializedClass, Int32.Parse(array[1]));
                line = sr.ReadLine();
                array = line.Split(',');
                var propertyInfo1 = deserializedClass.GetType().GetField(array[0]);
                propertyInfo1.SetValue(deserializedClass, (array[1]).ToString());
            }

            return deserializedClass;
        }

        public override string ToString()
        {
            return ("MyInt=" + MyInt.ToString() + "\tMySting=" + MyString);
        }
    }
}

