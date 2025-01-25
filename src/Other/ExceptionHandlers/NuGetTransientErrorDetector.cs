public static class NuGetTransientErrorDetector
{
    private static readonly List<string> _errorSubstrings = new List<string>()
    {
        "A connection attempt failed because the connected party did not properly respond after a period of time",
        "Response status code does not indicate success: 5",   // match any 5xx error
        "Response status code does not indicate success: 429", // 429 Too Many Requests
        "An error occurred while sending the request"
    };

    public static bool IsTransientError(string errorMessage)
    {
        return errorMessage.Contains("NuGet.targets") && _errorSubstrings.Any(errorMessage.Contains);
    }
}

public class ErrorDetectorTester
{
    [Fact]
    public void IsTransientErrorTest()
    {
        Assert.False(NuGetTransientErrorDetector.IsTransientError("Response status code does not"));
        Assert.True(
            NuGetTransientErrorDetector.IsTransientError(
                "NuGet.targets Response status code does not indicate success: 429"));
    }
}