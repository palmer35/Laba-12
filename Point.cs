using laba_10;

namespace Laba_12
{
    public class Point<T> where T : Transport
    {
    public T data;
    public Point<T> next;
    public Point<T> pred;

    public Point()
    {
        data = default(T);
        next = null;
        pred = null;
    }

    public Point(T data)
    {
        this.data = data;
        next = null;
        pred = null;
    }

    public override string ToString()
    {
        return data.ToString();
    }
    }
}
