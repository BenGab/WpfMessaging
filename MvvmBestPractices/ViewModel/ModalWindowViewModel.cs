using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmBestPractices.Models;
using System.Diagnostics;

namespace MvvmBestPractices.ViewModel
{
    public class ModalWindowViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;
        private RelayCommand saveCommand;
        private Player player;

        public Player Player { get => player; set => Set(ref player, value); }

        public ModalWindowViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            saveCommand = new RelayCommand(SavePlayer);
            messenger.Register<NotificationMessageRequest<Player>>(this, message =>
                {
                    Debug.WriteLine("Message request received");
                    Player = message.Model;
                }
            );
        }

        public RelayCommand SavePlayerCommand
        {
            get
            {
                return saveCommand;
            }
        }

        private void SavePlayer()
        {
            if (player == null)
                return;

            messenger.Send(new NotificationMessageResponse<Player>(player));
        }
    }
}
