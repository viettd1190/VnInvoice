namespace vnyi.HaLinh.Models
{
    public class MessageResult
    {
        public MessageResult()
        {
            Code = -1;
            Succeeded = false;
            Data = null;
        }

        public int Code { get; set; }

        public bool Succeeded { get; set; }

        public object Data { get; set; }
    }
}
