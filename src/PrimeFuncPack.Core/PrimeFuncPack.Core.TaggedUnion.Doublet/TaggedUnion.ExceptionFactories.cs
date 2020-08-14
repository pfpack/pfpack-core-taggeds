#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static InvalidOperationException CreateExpectedValidInvariantException()
            =>
            new InvalidOperationException("The tagged union is expected to have the valid invariant.");

        private static InvalidOperationException CreateNotInitializedException()
            =>
            new InvalidOperationException("The tagged union is not initialized.");

        private static InvalidOperationException CreateNotFirstException()
            =>
            CreateNotACategoryException(CategoryFirst);

        private static InvalidOperationException CreateNotSecondException()
            =>
            CreateNotACategoryException(CategorySecond);

        private static InvalidOperationException CreateNotACategoryException(in string category)
            =>
            new InvalidOperationException($"The tagged union does not represent {category} instance.");
    }
}
