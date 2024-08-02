using NetArchTest.Rules;
using Shouldly;

namespace MemeGame.ArchitectureTests.Extensions
{
    public static class ShouldExtensions
    {
        public static void ShoudBeMeet(this ConditionList conditionList)
        {
            conditionList
                .GetResult()
                .ShoudBeSuccessful();
        }

        public static void ShoudBeSuccessful(this TestResult testResult)
        {
            testResult.IsSuccessful.ShouldBeTrue(GetFailingTypesMessage(testResult));
        }

        private static string GetFailingTypesMessage(TestResult result)
        {
            var failingTypeNames = result.FailingTypeNames != null ? string.Join(", ", result.FailingTypeNames) : string.Empty;
            var message = $"Failing types: [{failingTypeNames}]";

            return message;
        }
    }
}
