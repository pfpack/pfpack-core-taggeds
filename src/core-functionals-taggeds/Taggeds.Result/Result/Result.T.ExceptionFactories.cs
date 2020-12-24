#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static InvalidOperationException CreateNotSuccessException()
            =>
            CreateNotCategoryException(CategorySuccess);

        private static InvalidOperationException CreateNotFailureException()
            =>
            CreateNotCategoryException(CategoryFailure);

        private static InvalidOperationException CreateNotCategoryException(string category)
            =>
            new($"The result does not represent a {category} instance.");
    }
}
