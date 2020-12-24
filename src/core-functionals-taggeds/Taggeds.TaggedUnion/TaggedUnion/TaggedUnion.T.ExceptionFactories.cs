#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static InvalidOperationException CreateNotFirstException()
            =>
            CreateNotCategoryException("First");

        private static InvalidOperationException CreateNotSecondException()
            =>
            CreateNotCategoryException("Second");

        private static InvalidOperationException CreateNotCategoryException(string category)
            =>
            new($"The tagged union does not represent a {category} instance.");
    }
}
