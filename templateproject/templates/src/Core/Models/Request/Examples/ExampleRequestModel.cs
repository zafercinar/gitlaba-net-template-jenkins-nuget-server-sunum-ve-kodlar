namespace ZACx.Templates.WebApiProject.Core.Models.Request.Examples
{
    public class ExampleRequestModel
    {
        public string Code { get; set; }

        public ExampleRequestModel(string code)
        {
            if (!string.IsNullOrEmpty(code))
                throw new Exception("Code bilgisi boş olamaz");

            Code = code;
        }
    }
}
