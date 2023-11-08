using System;
using System.Collections.Generic;
using System.Text;
using HitachiQA.Helpers;
using HitachiQA.Driver;
using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework.Constraints;
using NUnitAssert = NUnit.Framework.Assert;
using static IdentityModel.ClaimComparer;

namespace HitachiQA
{
    class Assert
    {
        public static bool Contains(List<string> list, string expectedItem, bool optional = false)
        {
            var listAsString = new StringBuilder();
            listAsString.Append("[\n");
            foreach (var item in list)
            {
                listAsString.Append(item).Append(", \n");
            }
            listAsString.Append("]");

            var successMessage = $"List [{listAsString}] contains [{expectedItem}]";
            return WrapAssert(NUnitAssert.Contains, expectedItem, list, optional, successMessage);
        }
        public static bool TextContains(string text, string expected, bool optional = false)
        {
            var successMessage = $"text: {text} contains value: {expected}";
            return WrapAssert(StringAssert.Contains, NormalizeDashes(expected), NormalizeDashes(text), optional, successMessage);
        }
        private static string NormalizeDashes(string str)
        {
            return Regex.Replace(str, "-|–|—", "-");
        }
        public static bool TextIsMatch(string regex, string text, bool optional = false)
        {
            var successMessage = $"text: {text} matches pattern: {regex}";
            return WrapAssert(StringAssert.IsMatch, regex, text, optional, successMessage);
        }
        public static bool AreEqual(object actual, object expected, bool optional = false)
        {
            var successMessage = $"Object {actual} equals {expected}";
            return WrapAssert(NUnitAssert.AreEqual, expected, actual, optional, successMessage);
        }
        public static bool AreNotEqual(object actual, object expected, bool optional = false)
        {
            var successMessage = $"Object {actual} does not equal {expected}";
            return WrapAssert(NUnitAssert.AreNotEqual, expected, actual, optional, successMessage);
        }

        /// <summary>
        /// checks whether the given condition was false,<br></br>
        /// </summary>
        /// <returns> will return true if the condition was true</returns>
        public static bool IsTrue(bool condition, bool optional = false, string failureMessage = null)
        {
            var successMessage = $"Condition {condition}";
            return WrapAssert(NUnitAssert.IsTrue, condition, optional, successMessage, failureMessage);
        }

        /// <summary>
        /// checks whether the given condition was false,<br></br>
        /// </summary>
        /// <returns> will return true if the condition equals false or null</returns>
        public static bool IsFalse(bool? condition, bool optional = false)
        {
            var successMessage = $"Condition {condition}";
            return WrapAssert(NUnitAssert.IsFalse, condition, optional, successMessage);
        }

        public static bool IsNull(object theObject, bool optional = false)
        {
            var successMessage = $"Object is null";
            return WrapAssert(NUnitAssert.IsNull, theObject, optional, successMessage);
        }
        public static bool IsNotNull(object theObject, bool optional = false)
        {
            var successMessage = "Object is not null";
            return WrapAssert(NUnitAssert.IsNotNull, theObject, optional, successMessage);
        }

        public static bool CurrentURLEquals(string URL, bool optional=false)
        {
            ActualValueDelegate<string> actualValueDelegate = () => UserActions.GetCurrentURL();
            var delayedConstraint = Is.EqualTo(URL).After(10).Seconds.PollEvery(50).MilliSeconds;
            var successMessage = $"URL {URL} is the current URL";
            return WrapAssert(NUnitAssert.That, actualValueDelegate, delayedConstraint, optional, successMessage);
        }
        
        private static void Success(string message)
        {
            Log.Info("Success - Assert: " + message);
        }
        private static bool WrapAssert<T1>(Action<T1> assert, T1 arg, bool optional = false, string successMessage = "assert passed", string failureMessage = null)
        {
            using var context = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
            try
            {
                assert(arg);
                Success(successMessage);
            }
            catch (Exception ex)
            {
                HandleFailure(failureMessage, ex, optional);
                return false;
            }
            return true;
        }
        private static bool WrapAssert<T1, T2>(Action<T1, T2> assert, T1 arg1, T2 arg2, bool optional = false, string successMessage = "assert passed", string failureMessage = null)
        {
            using var context = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
            try
            {
                assert(arg1, arg2);
                Success(successMessage);
            }
            catch (Exception ex)
            {
                HandleFailure(failureMessage, ex, optional);
                return false;
            }
            return true;
        }

        private static void HandleFailure(string failureMessage, Exception ex, bool optional)
        {
            if (failureMessage != null)
            {
                Functions.HandleFailure(failureMessage, ex, optional);
            }
            else
            {
                Functions.HandleFailure(ex, optional);
            }
        }
    }
}
