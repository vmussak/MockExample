namespace MockExample.Core.Notification
{
    public enum Status
    {
        Ok,
        NoContent,
        Error
    }

    public class Notification
    {
        private Notification(Status status)
        {
            Status = status;
            Content = null;
        }

        private Notification(Status status, object content)
        {
            Status = status;
            Content = content;
        }

        public static Notification Response(Status status)
        {
            return new Notification(status);
        }

        public static Notification Response<T>(Status status, T content)
        {
            return new Notification(status, content);
        }

        public Status Status { get; }
        public object Content { get; }
    }
}