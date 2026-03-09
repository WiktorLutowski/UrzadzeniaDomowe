using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace UrzadzeniaDomowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string vacuumeStatus = default!;
        public string VacuumeStatus { get { return vacuumeStatus; } set { vacuumeStatus = value; OnPropertyChanged(); } }

        private string vacuumeButtonStatus = default!;
        public string VacuumeButtonStatus { get { return vacuumeButtonStatus; } set { vacuumeButtonStatus = value; OnPropertyChanged(); } }

        private string washingNumberText = default!;
        public string WashingNumberText { get { return washingNumberText; } set { washingNumberText = value; OnPropertyChanged(); } }

        private int? washingNumber = default!;
        public int? WashingNumber { get { return washingNumber; } set { washingNumber = value; OnPropertyChanged(); } }

        public MainWindow()
        {
            VacuumeStatus = "wyłączony";
            VacuumeButtonStatus = "Włącz";
            WashingNumberText = "";
            WashingNumber = null;

            InitializeComponent();

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void VacuumeOnButton_Click(object sender, RoutedEventArgs e)
        {
            if (VacuumeButtonStatus == "Włącz")
            {
                VacuumeStatus = "włączony";
                VacuumeButtonStatus = "Wyłącz";
            }
            else
            {
                VacuumeStatus = "wyłączony";
                VacuumeButtonStatus = "Włącz";
            }
        }

        private void WashingMachineConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(WashingNumberText, out int number) || number < 1 || number > 12)
                return;

            WashingNumber = number;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }

    }
}