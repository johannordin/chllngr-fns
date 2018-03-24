namespace chllngr.Functions
{
    public class GreetingService
    {
        public ResponseModel Greet(string name)
        {
            return new ResponseModel { Greeting = $"Hello, {name}" };
        }
    }
}
