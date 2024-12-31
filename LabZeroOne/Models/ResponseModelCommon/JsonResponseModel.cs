namespace LabZeroOne.Models.ResponseModelCommon
{
    public class JsonResponseModel<T>
    {
        public string Status{ get; set; }
        public string Message { get; set; }
        public List<T> JsonData { get; set; }
    }
}
