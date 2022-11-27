namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public bool Equals(TaggedUnion<TFirst, TSecond> other)
    {
        if (tag != other.tag)
        {
            return false;
        }

        if (tag is Tag.First)
        {
            return FirstComparer.Equals(first, other.first);
        }

        if (tag is Tag.Second)
        {
            return SecondComparer.Equals(second, other.second);
        }

        return true;
    }
}
