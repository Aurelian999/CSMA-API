namespace CSMA_API.Application.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public int StatusCode { get; set; }

        internal Result(bool succeeded, IEnumerable<string> errors, int statusCode = 200)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            StatusCode = statusCode;
        }


        public static Result Success()
        {
            return new Result(true, new string[] { });
        }

        public static Result Failure(IEnumerable<string> errors, int statusCode)
        {
            return new Result(false, errors, statusCode);
        }
    }
}
