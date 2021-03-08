using MvvmBestPractices.Views;
using System.Windows;

namespace MvvmBestPractices.Helpers
{
    internal class DialogService : IDialogService
    {
        public bool? ShowDialogWindow()
        {
            ModalWindow window = new ModalWindow();
            return window.ShowDialog();
        }

        public MessageBoxResult ShowMessageBox(string message)
        {
            return MessageBox.Show(message);
        }
    }
}
