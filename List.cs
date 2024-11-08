using System.Collections;
using laba_10;

namespace Laba_12;

public class List<T> : IEnumerable<T> where T : Transport
{
    public Point<T> beg;
    private Point<T> end;
    public int position = -1;

    public int Count
    {
        get
        {
            if (beg == null)
            {
                return 0;
            }

            int count = 0;
            Point<T> current = beg;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
    }

    public void AddFirst(T data)
    {
        Point<T> newPoint = new Point<T>(data);
        if (beg != null)
        {
            newPoint.next = beg;
            beg.pred = newPoint;
        }
        else
        {
            end = newPoint;
        }
        beg = newPoint;
    }

    public void AddLast(T data)
    {
        Point<T> newPoint = new Point<T>(data);

        if (end != null)
        {
            newPoint.pred = end;
            end.next = newPoint;
        }
        else
        {
            beg = newPoint;
        }
        end = newPoint;
    }

    public void RemoveAt(int index)
    {
        if (index >= 0 && index < Count)
        {
            Point<T> current = beg;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.next;
            }

            if (current != null)
            {
                if (current == beg)
                {
                    beg = current.next;
                    if (beg != null)
                    {
                        beg.pred = null;
                    }
                    else
                    {
                        end = null;
                    }
                }
                else if (current == end)
                {
                    end = current.pred;
                    if (end != null)
                    {
                        end.next = null;
                    }
                    else
                    {
                        beg = null;
                    }
                }
                else
                {
                    current.pred.next = current.next;
                    current.next.pred = current.pred;
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }
    }


    public void PrintList()
    {
        Point<T> newPoint = beg;
        while (newPoint != null)
        {
            Console.Write(newPoint.data + " ");
            newPoint = newPoint.next;
            Console.WriteLine();
        }
        Console.WriteLine("\n----------------\n");
    }

    public void AddEllementList(int nom, T newCar)
    {
        if (beg == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (nom > Count || nom <= 0)
        {
            Console.WriteLine("Неверный номер элемента");
            return;
        }

        if (nom == 1)
        {
            AddFirst(newCar);
            return;
        }

        if (nom == Count + 1)
        {
            AddLast(newCar);
            return;
        }

        Point<T> p = beg;
        for (int i = 1; i < nom - 1 && p != null; i++)
        {
            p = p.next;
        }

        if (p == null)
        {
            Console.WriteLine("Неверный номер элемента");
            return;
        }

        Point<T> newPoint = new Point<T>(newCar);
        newPoint.next = p.next;
        newPoint.pred = p;
        p.next.pred = newPoint;
        p.next = newPoint;
    }


    public void RemoveFirst()
    {
        if (beg == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        beg = beg.next;
        if (beg != null)
        {
            beg.pred = null;
        }
        else
        {
            end = null;
        }
    }

    public void RemoveLast()
    {
        if (beg == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        end = end.pred;
        if (end != null)
        {
            end.next = null;
        }
        else
        {
            beg = null;
        }
    }

    public void Clear()
    {
        beg = null;
        end = null;
        if (beg == null)
        {
            Console.WriteLine("Список пуст");
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Point<T> current = beg;
        while (current != null)
        {
            yield return current.data;
            current = current.next; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }
        Point<T> current = beg;
        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }
        return current.data;
    }

}