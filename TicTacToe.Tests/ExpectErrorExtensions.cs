using System;
using System.Reflection;

public static class Expect {
    public static void ExpectError(this Object testClass, Action action) {
        try {
            action();
        }
        catch (Exception e) {
            var errorField = testClass.GetType().GetField(
                "error",
                BindingFlags.NonPublic | BindingFlags.Instance
            );
            errorField!.SetValue(testClass, e);

            return;
        }

        throw new ExpectedExceptionException();
    }
}

public class ExpectedExceptionException : Exception {}