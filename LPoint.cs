namespace Laba_12
{
    class LPoint
    {
        public int key;
        public string value;
        public LPoint next;

        public LPoint(string s)
        {
            value = s;
            key = GetHashCode();
            next = null;
        }

        public override string ToString()
        {
            return key + " - "+value.ToString();
        }

        public override int GetHashCode()
        {
            var code = 0;
            foreach (var c in value)
            {
                code += (int)c;
            }

            return code;
        }

        //Более практичная функция (минимальное количество коллизий)
        //public override int GetHashCode()
        //{
        //    const int prime = 31;
        //    var hash = 17;
        //    foreach (var c in value)
        //    {
        //        hash = hash * prime + (int)c;
        //    }

        //    return hash;
        //}
    }
}
