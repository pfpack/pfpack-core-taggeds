#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static InvalidOperationException CreateNotFirstException()
            =>
            CreateNotCategoryException(CategoryFirst);

        private static InvalidOperationException CreateNotSecondException()
            =>
            CreateNotCategoryException(CategorySecond);

        private static InvalidOperationException CreateNotCategoryException(in string category)
            =>
            new InvalidOperationException($"The tagged union does not represent a {category} instance.");
    }
}
