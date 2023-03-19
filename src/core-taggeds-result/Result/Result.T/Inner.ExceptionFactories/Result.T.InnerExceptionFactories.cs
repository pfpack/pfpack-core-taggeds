namespace System;

partial struct Result<TSuccess, TFailure>
{
    private static InvalidOperationException InnerCreateExpectedSuccessException()
        =>
        new(InnerCreateExpectedTagMessage("Success"));

    private static InvalidOperationException InnerCreateExpectedFailureException()
        =>
        new(InnerCreateExpectedTagMessage("Failure"));

    private static string InnerCreateExpectedTagMessage(string tag)
        =>
        $"The result is expected to represent the {tag} case.";
}
