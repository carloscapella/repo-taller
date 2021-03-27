namespace Api_NetCore_Example.Models.Validations
{
    public class Validation
    {
        public Validation()
        {
            Name = "";
            Message = "";
        }

        public string Name { get; set; }
        public string Message { get; set; }
    }
}
