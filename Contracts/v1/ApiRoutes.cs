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
            public const string Create = Base + "/" + "posts";
            public const string Get = Base + "/" + "posts/{postId}";
        }

        public static class Services
        {
            public const string GetAll = Base + "/" + "services";
            public const string Get = Base + "/" + "services/{serviceId}";
            public const string Create = Base + "/" + "services";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }
    }
}
