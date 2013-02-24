using System;

namespace BDDfySamples.CustomFramework
{
    public class Assert
    {
        static public void AreEqual(int expected, int actual)
        {
            if (expected != actual)
            {
                var message = string.Format("{0} is not equal to {1}", actual, expected);
                throw new AssertionException(message);
            }
        }

        static public void AreEqual(bool expected, bool actual)
        {
            if (expected != actual)
            {
                var message = string.Format("{0} is not equal to {1}", actual, expected);
                throw new AssertionException(message);
            }
        }

        static public void AreEqual(Enum expected, Enum actual)
        {
            if (expected.ToString() != actual.ToString())
            {
                var message = string.Format("{0} is not equal to {1}", actual, expected);
                throw new AssertionException(message);
            }
        }

        static public void IsFalse(bool condition)
        {
            if (condition)
            {
                var message = "Expected false but value was true";
                throw new AssertionException(message);
            }
        }
    }

    public class AssertionException : Exception
    {
        public AssertionException(string message) : base(message) { }
    }
}