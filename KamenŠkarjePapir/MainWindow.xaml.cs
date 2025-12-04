using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KamenŠkarjePapir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool gameRunning = false;
        private Random rand = new Random();
        int playerWinStevec = 0;
        int CpuWinStevec = 0;
        int izeenacenoStevec = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            gameRunning = true;

            playerWinStevec = 0;
            CpuWinStevec = 0;
            izeenacenoStevec = 0;
            UpdateScoreUI();


            btnKamen.IsEnabled = true;
            btnSkarje.IsEnabled = true;
            btnPapir.IsEnabled = true;

            playerChoice.Text = "";
            cpuChoice.Text = "";
            result.Text = "";
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            gameRunning = false;

            btnKamen.IsEnabled = false;
            btnSkarje.IsEnabled = false;
            btnPapir.IsEnabled = false;

            result.Text = "Igra je ustavljena";
        }

        private void btnKamen_Click(object sender, RoutedEventArgs e)
        {
            if (gameRunning) Play("Kamen");
        }

        private void btnSkarje_Click(object sender, RoutedEventArgs e)
        {
            if (gameRunning) Play("Škarje");
        }

        private void btnPapir_Click(object sender, RoutedEventArgs e)
        {
            if (gameRunning) Play("Papir");
        }

        private void Play(string Player)
        {
            string[] izbire = {"Kamen", "Škarje", "Papir"};
            string cpu;
            int prednost = CpuWinStevec - playerWinStevec;

            if (prednost >= 2)
            {
                switch (Player)
                {
                    case "Kamen":
                        cpu = "Škarje";  
                        break;
                    case "Škarje":
                        cpu = "Papir";    
                        break;
                    case "Papir":
                        cpu = "Kamen";   
                        break;
                    default:
                        cpu = izbire[rand.Next(izbire.Length)];
                        break;
                }
            }
            else 
            {
                cpu = izbire[rand.Next(izbire.Length)];
            }

            playerChoice.Text = "Ti: " + Player;
            cpuChoice.Text = "Računalnik: " + cpu;

            if (Player == cpu)
            {
                result.Text = "Izenačeno";
                izeenacenoStevec++;
            }

            else if ((Player == "Kamen" && cpu == "Škarje") || (Player == "Škarje" && cpu == "Papir") || (Player == "Papir" && cpu == "Kamen"))
            {
                result.Text = "Zmagal si!";
                playerWinStevec++;
            }
            else
            {
                result.Text = "Zgubil si!";
                CpuWinStevec++;
            }

            UpdateScoreUI();
        }

        private void UpdateScoreUI()
        {
            PlayerWins.Text = $"Igralec: {playerWinStevec}";
            CpuWins.Text = $"CPU: {CpuWinStevec}";
            Izeenaceno.Text = $"Izenačeno: {izeenacenoStevec}";
        }
    }
}