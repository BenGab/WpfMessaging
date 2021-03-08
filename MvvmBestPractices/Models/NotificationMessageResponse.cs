using GalaSoft.MvvmLight;

namespace MvvmBestPractices.Models
{
    public class NotificationMessageResponse<T> where T : ObservableObject
    {
        public T Result { get; }

        public NotificationMessageResponse(T model)
        {
            Result = model;
        }
    }
}
