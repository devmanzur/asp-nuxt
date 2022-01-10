namespace SimpleCart.Core.Dtos;

public class Segment
{
    private readonly int _size;
    private readonly int _index;
    private const int DefaultPageSize = 50;
    private const int MaxPageSize = 100;

    public Segment(int? size = DefaultPageSize, int? index = 1)
    {
        Size = size ?? 0;
        Index = index ?? 0;
    }

    private static int GetValidOrDefaultIndex(int index)
    {
        return index < 1 ? 1 : index;
    }

    private static int GetValidOrDefaultSize(int size)
    {
        return size < 10 ? DefaultPageSize : (size > MaxPageSize ? MaxPageSize : size);
    }

    public int Index
    {
        get => this._index;

        init => _index = value < 1 ? 1 : value;
    }

    public int Size
    {
        get => this._size;

        init => _size = value < 10 ? DefaultPageSize : value > MaxPageSize ? MaxPageSize : value;
    }

    public int Skip => (Index - 1) * Size;
}