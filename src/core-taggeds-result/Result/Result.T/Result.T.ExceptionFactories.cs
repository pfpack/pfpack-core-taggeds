namespace System;

partial struct Result<TSuccess, TFailure>
{
    private static InvalidOperationException CreateNotSuccessException()
        =>
        CreateNotCategoryException("Success");

    private static InvalidOperationException CreateNotFailureException()
        =>
        CreateNotCategoryException("Failure");

    private static InvalidOperationException CreateNotCategoryException(string category)
        =>
        new($"The result does not represent a {category} instance.");
}
