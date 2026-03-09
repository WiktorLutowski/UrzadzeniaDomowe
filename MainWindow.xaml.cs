using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private Visibility placeHolderVisibility = default!;
        public Visibility PlaceHolderVisibility { get { return placeHolderVisibility; } set { placeHolderVisibility = value; OnPropertyChanged(); } }

        public MainWindow()
        {
            VacuumeStatus = "wyłączony";
            VacuumeButtonStatus = "Włącz";
            WashingNumberText = "";
            WashingNumber = null;
            PlaceHolderVisibility = Visibility.Visible;

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
        private void Label_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            textBox.Focus();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox)!.Text == string.Empty)
                PlaceHolderVisibility = Visibility.Visible;
            else
                PlaceHolderVisibility = Visibility.Hidden;
        }
    }
}