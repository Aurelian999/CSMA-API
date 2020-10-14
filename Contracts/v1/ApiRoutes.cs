namespace CSMA_API.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class EmployeeWorkingHours
        {
            public const string GetAll = Base + "/" + "employeeworkinghours";
            public const string Get = Base + "/" + "employeeworkinghours/{employeeId}";
            public const string Create = Base + "/" + "employeeworkinghours";

        }

        public static class Posts
        {
            public const string GetAll = Base + "/" + "posts";
        }
    }
}
