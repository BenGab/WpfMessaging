using GalaSoft.MvvmLight;

namespace MvvmBestPractices.Models
{
    public class NotificationMessageRequest<T> where T : ObservableObject
    {
        public NotificationMessageRequest(T model)
        {
            Model = model;
        }

        public T Model { get; }
    }
}
