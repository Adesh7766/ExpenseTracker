namespace Entity.Common
{
    public class ResponseData
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResponseData<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public T RespData { get; set; }
    }
}
