using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmBestPractices.Helpers;
using MvvmBestPractices.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MvvmBestPractices.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly IMessenger messenger;
        private readonly RelayCommand opendialogWindowCommand;
        private readonly RelayCommand addNewCommand;
        private ObservableCollection<Player> players;
        private Player selectedPlayer;

        public MainWindowViewModel(IDialogService dialogService, IMessenger messenger)
        {
            this.dialogService = dialogService;
            this.messenger = messenger;
            opendialogWindowCommand = new RelayCommand(OpenDialogWindow);
            addNewCommand = new RelayCommand(AddNewPlayer);
            players = new ObservableCollection<Player>();
            messenger.Register<NotificationMessageResponse<Player>>(this, response => UpdatePlayer(response.Result));
        }

        public ObservableCollection<Player> Players { get => players; set => Set(ref players, value); }

        public Player SelectedPlayer { get => selectedPlayer; set => Set(ref selectedPlayer, value); }

        public RelayCommand OpenDialogWindowCommand
        {
            get
            {
                return opendialogWindowCommand;
            }
        }

        public RelayCommand AddNewPlayerCommand
        {
            get
            {
                return addNewCommand;
            }
        }

        private void OpenDialogWindow()
        {
            if (selectedPlayer == null)
            {
                return;
            }
            messenger.Send<NotificationMessageRequest<Player>>(new NotificationMessageRequest<Player>(selectedPlayer));
            dialogService.ShowDialogWindow();
        }

        private void AddNewPlayer()
        {
            var player = new Player();
            Players.Add(player);

            SelectedPlayer = player;
        }

        private void UpdatePlayer(Player player)
        {
            Debug.WriteLine("Response got");
            SelectedPlayer.Name = player.Name;
            SelectedPlayer.Position = player.Position;
        }
    }
}
