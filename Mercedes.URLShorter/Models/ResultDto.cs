namespace Mercedes.URLShorter.Models
{
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }
        public T Response { get; set; }
        public string Error{ get; set; }
    }
}
