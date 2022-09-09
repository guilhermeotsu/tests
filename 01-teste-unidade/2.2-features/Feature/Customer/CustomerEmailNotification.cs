namespace Feature.Customer
{
    public class CustomerEmailNotification
    {
        public string From { get; }
        public string To { get; }
        public string Message { get; }
        public string Subject { get; }

        public CustomerEmailNotification(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
