namespace Laba_12
{
    class HTable
    {
        private readonly LPoint[] table;
        private readonly int Size;
        private int count = 0; 

        public HTable(int size = 10)
        {
            Size = size;
            table = new LPoint[size];
        }

        public bool Add(string s)
        {
            LPoint point = new LPoint(s);
            int index = Math.Abs(point.GetHashCode()) % Size;
            if (table[index] == null)
            {
                table[index] = point;
                return true;
            }
            LPoint cur = table[index];
            if (string.Compare(cur.ToString(), point.ToString()) == 0)
            {
                return false;
                while (cur.next != null)
                {
                    if (string.Compare(cur.next.ToString(), point.ToString()) == 0)
                    {
                        return false;
                    }

                    cur = cur.next;
                }

                cur.next = point;
            }

            return true;
        }
        
        
        public void Print()
        {
            if (table == null)
            {
                Console.WriteLine("Таблица пустая!");
                return;
            }

            for (int i = 0; i < Size; i++)
            {
                if (table[i] == null)
                {
                    Console.WriteLine(i+") ");
                }
                else
                {
                    Console.Write(i+") ");
                    LPoint p = table[i];
                    while (p != null)
                    {
                        Console.Write(p.ToString()+", ");
                        p = p.next;
                    }

                    Console.WriteLine();
                }
            }
        }

        public bool FindPoint(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            LPoint Ip = new LPoint(str);
            var code = Math.Abs(Ip.GetHashCode()) % Size;
            if (String.Compare(str, Ip.ToString()) == 0)
            {
                return true;
            }

            Ip = table[code];

            while (Ip != null)
            {
                if (string.Compare(Ip.value, str) == 0)
                {
                    return true;
                }

                Ip = Ip.next;
            }

            return false;
        }

        public string DelPoint(string str)
        {

            LPoint Ip = new LPoint(str);
            var code = Math.Abs(Ip.GetHashCode()) % Size;
            Ip = table[code];

            if (table[code] == null)
            {
                return null;
            }

            if (table[code] != null && String.Compare(table[code].value, str) == 0)
            {
                Ip = table[code];
                table[code] = table[code].next;
                return Ip.value;
            }

            while (Ip.next != null && (string.Compare(Ip.next.value, str) != 0))
            {
                Ip = Ip.next;
            }

            if (Ip.next != null)
            {
                str = Ip.next.value;
                Ip.next = Ip.next.next;
                return str;
            }

            return null;
        }

        public bool IsFull()
        {
            int occupied = 0;
            for (int i = 0; i < Size; i++)
            {
                if (table[i] != null)
                {
                    occupied++;
                }
            }
            return occupied >= Size;
        }

    }
}
