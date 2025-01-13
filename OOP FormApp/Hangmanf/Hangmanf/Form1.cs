using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangmanf
{
    public partial class Form1 : Form
    {
        #region Veriables
        // Şehir isimlerinin yer aldığı kelime listesi
        List<string> words = new List<string>
        {
            "adana", "adıyaman", "afyonkarahisar", "aksaray", "amasya", "ankara", "antalya", "ardahan", "artvin", "aydın", "ağrı", "balıkesir", "bartın", "batman",
        "bayburt", "bilecik", "bingöl", "bitlis", "bolu", "burdur", "bursa", "denizli", "diyarbakır", "düzce", "edirne", "elazığ", "erzincan", "erzurum", "eskişehir",
        "gaziantep", "giresun", "gümüşhane", "hakkâri", "hatay", "isparta", "ığdır", "kahramanmaraş", "karabük", "karaman", "kars", "kastamonu", "kayseri", "kilis",
        "kocaeli", "konya", "kütahya", "kırklareli", "kırıkkale", "kırşehir", "malatya", "manisa", "mardin", "mersin", "muğla", "muş", "nevşehir", "niğde", "ordu",
        "osmaniye", "rize", "sakarya", "samsun", "siirt", "sinop", "sivas", "tekirdağ", "tokat", "trabzon", "tunceli", "uşak", "van", "yalova", "yozgat", "zonguldak",
        "çanakkale", "çankırı", "çorum", "istanbul", "izmir", "şanlıurfa", "şırnak"
        };

        // Yanlış tahmin sayısını tutacak değişken
        int incorrectGuess;

        // Rastgele kelime seçmek için kullanılacak Random sınıfı
        Random random;

        // Seçilen kelime
        string selectedWord;

        // Tahmin edilen kelimeyi ekranda göstermek için '_' sembolleriyle dizilen harfler
        char[] displayWord;
        #endregion

        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlatma
        }

        // Form yüklendiğinde yapılacak işlemler
        private void Form1_Load(object sender, EventArgs e)
        {
            incorrectGuess = 0; // Yanlış tahmin sayısı sıfırlanıyor
            random = new Random(); // Yeni bir rastgele sayı üretici nesnesi oluşturuluyor
            selectedWord = words[random.Next(words.Count)]; // Rastgele bir kelime seçiliyor
            displayWord = new string('_', selectedWord.Length).ToCharArray(); // Seçilen kelimenin uzunluğuna göre '_' ile dizi oluşturuluyor
            string formattedDisplayWord = string.Join(" ", displayWord); // Ekranda kelimeyi aralıklı göstermek için dizi düzenleniyor
            lblWordDisplay.Text = formattedDisplayWord; // Label üzerinde tahmin edilecek kelime görüntüleniyor
        }

        // Tahmin butonuna basıldığında çalışacak metod
        private void btnGuess_Click(object sender, EventArgs e)
        {
            char guess = tbGuess.Text.ToLower()[0]; // Girilen harf alınıyor ve küçük harfe dönüştürülüyor
            bool corrrectGuess = false; // Doğru tahmin olup olmadığını kontrol eden değişken
            for (int i = 0; i < selectedWord.Length; i++)
            {
                // Eğer tahmin edilen harf kelimenin içinde varsa ilgili yere harf yazılıyor
                if (selectedWord[i] == guess)
                {
                    displayWord[i] = guess;
                    corrrectGuess = true; // Doğru tahmin yapılmış demek
                }
            }

            lblWordDisplay.Text = string.Join(" ", displayWord); // Güncel kelime durumu ekrana basılıyor
            if (!corrrectGuess) // Eğer doğru tahmin edilmediyse
            {
                UpdateHangmanImage(); // Asılan adamın bir kısmı çiziliyor
            }

            if (!lblWordDisplay.Text.Contains('_')) // Eğer tahmin edilen kelimede '_' kalmadıysa
            {
                MessageBox.Show("Congratulations! Your guess is right."); // Tebrik mesajı gösteriliyor
                Application.Restart(); // Oyun yeniden başlatılıyor
            }

        }

        // Yanlış tahmin sayısına göre adam asmaca resmini güncelleyen metod
        private void UpdateHangmanImage()
        {
            incorrectGuess++; // Yanlış tahmin sayısı artırılıyor
            switch (incorrectGuess)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Hangman_1; // İlk yanlışta asma direği çiziliyor
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Hangman_2; // İkinci yanlışta kafa ekleniyor
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.Hangman_3; // Üçüncü yanlışta beden ve ayaklar ekleniyor
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.Hangman_4; // Dördüncü yanlışta eller ekleniyor ve oyun bitiyor
                    MessageBox.Show("You lost! The word was " + selectedWord); // Oyuncuya kaybettiği ve kelimenin ne olduğu söyleniyor
                    Application.Restart(); // Oyun yeniden başlatılıyor
                    break;
            }
        }
    }
}
