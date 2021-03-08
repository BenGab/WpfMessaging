using System.Windows;

namespace MvvmBestPractices.Helpers
{
    public interface IDialogService
    {
        bool? ShowDialogWindow();

        MessageBoxResult ShowMessageBox(string message);
    }
}
