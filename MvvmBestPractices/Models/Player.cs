using GalaSoft.MvvmLight;

namespace MvvmBestPractices.Models
{
    public class Player : ObservableObject
    {
        string name;
        string position;

        public string Name { get => name; set => Set(ref name, value); }
        public string Position { get => position; set => Set(ref position, value); }
    }
}
