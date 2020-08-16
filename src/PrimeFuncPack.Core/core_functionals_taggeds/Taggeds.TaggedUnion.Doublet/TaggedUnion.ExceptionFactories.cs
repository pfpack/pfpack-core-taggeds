#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static InvalidOperationException CreateNotTheFirstException()
            =>
            CreateNotACategoryException(CategoryFirst);

        private static InvalidOperationException CreateNotTheSecondException()
            =>
            CreateNotACategoryException(CategorySecond);

        private static InvalidOperationException CreateNotACategoryException(in string category)
            =>
            new InvalidOperationException($"The tagged union does not represent {category} instance.");
    }
}
