using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rps_deneme_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.KeyPreview = true; // Klavyeden veri alabilmek için
            InitializeComponent();
        }
        string playerselect, computerselect;
        int playerpoint, computerpoint, rastgele;
        Random randomlyy = new Random();

        private void pictureBoxrock_Click(object sender, EventArgs e)
        {
            // resimleri ekle ve neyi eklediğini yaz
            pictureBoxplayer.ImageLocation = "Resimler/rock.png";
            playerselect = "rock";
            Test();
        }
        private void pictureBoxpaper_Click(object sender, EventArgs e)
        {
            pictureBoxplayer.ImageLocation = "Resimler/paper.png";
            playerselect = "paper";
            Test();
        }
        private void pictureBoxscissors_Click(object sender, EventArgs e)
        {
            pictureBoxplayer.ImageLocation = "Resimler/scissors.png";
            playerselect = "scissors";
            Test();
        }

        private void Computer_attack()
        { // random sayı belirle ve random sayıda olan eşyayı yaz
            rastgele = randomlyy.Next(1, 4);
            
            if (rastgele == 1)
            {   
                pictureBoxcomputer.ImageLocation = "Resimler/rock.png";
                computerselect = "rock";
            }
            else if (rastgele == 2)
            {
                pictureBoxcomputer.ImageLocation = "Resimler/paper.png";
                computerselect = "paper";
            }
            else if (rastgele == 3)
            {
                pictureBoxcomputer.ImageLocation = "Resimler/scissors.png";
                computerselect = "scissors";
            }

        }
        
       
        private void timer1_Tick_1(object sender, EventArgs e)
        { 
            Random r = new Random();
           
        }

        private void Test()
        {
            try
            {
                if (computerpoint == 0 && playerpoint == 0)
                {  // oyun başladığında kazanan yazısının gözükmesini istemiyoruz.
                    label7.Visible = false;
                    label8.Visible = false;
                    bttnstart.Visible = true;
                    button4.Visible = false;
                    lblplayerpoint.Text = "0";
                    lblcomputerpoint.Text = "0";
                }
                // oyuncu seçimini yapmadan oyun başlama hatasının önüne geç.
                if (playerselect == null)
                {
                    MessageBox.Show("Lutfen hamlenizi seçiniz", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Computer_attack();
                }
                summerypoint();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        private void bttnstart_Click(object sender, EventArgs e)
        {
            //Test();
        }

        private void summerypoint()
        { // toplam puanları hangi koşula göre hesaplanacağını yaz.
            if (playerselect == "rock" && computerselect == "paper")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "rock" && computerselect == "scissors")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            else if (playerselect == "paper" && computerselect == "rock")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            else if (playerselect == "paper" && computerselect == "scissors")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "scissors" && computerselect == "rock")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "scissors" && computerselect == "paper")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            if (computerpoint == 5 || playerpoint == 5)
            { // 5'e ilk ulaşan kazanır :)
                label7.Visible = true;
                label8.Visible = true;
                bttnstart.Visible = false;
                button4.Visible = true;
                if (computerpoint > playerpoint)
                {  // bilgisayar kazanırsa onun adını oyuncu kazanırsa onun adını yazdırıyoruz.
                   // ve oyun bittiği için puan değerlerini sıfırlıyoruz. 
                    label8.Text = "Computer";
                    playerpoint = 0;
                    computerpoint = 0;
                    playerselect = null;
                    computerselect = null;
                    bttnstart.Visible = false;
                    button4.Visible = true;
                }
                else if (computerpoint < playerpoint)
                {
                    label8.Text = "Player";
                    playerpoint = 0;
                    computerpoint = 0;
                    playerselect = null;
                    computerselect = null;
                }
            }
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        { // sayıları 5'e resimleri sıfırladık ve puanları sıfırladık
            pictureBoxplayer.ImageLocation = null;
            pictureBoxcomputer.ImageLocation = null;
            bttnstart.Visible = true;
            button4.Visible = false;
            lblplayerpoint.Text = "0";
            lblcomputerpoint.Text = "0";
            label7.Visible = false;
            label8.Visible=false;
        }

        // buradan sonrası multiplayer kısmı

        int user1point, user2point;
        public void multiplayer(int player1, int player2)
        {
            string[] rps = { "rock", "paper", "scissors" };
            if (user1point<5 && user2point<5)
            {  // puanlar 5'ten küçükse arttırsın dedik  ve 5'E EŞİT OLDUĞUNDA sayıyı büyütmeye devam ettik
               // ve bttnnwegame de user1point ve user2point'i sıfıra eşitledik
                if (player1 == 0 && player2 == 1 || player1 == 1 && player2 == 2 || player1 == 2 && player2 == 0)
                { // player2 kazanır
                    user2point++;
                    lbluser2point.Text = user2point.ToString();
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
                else if (player1 == 2 && player2 == 1 || player1 == 0 && player2 == 2 || player1 == 1 && player2 == 0)
                { // player1 kazanır
                    user1point++;
                    lbluser1point.Text = user1point.ToString();
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
                else if (player1 == 0 && player2 == 0 || player1 == 1 && player2 ==1 || player1 == 2 && player2 == 2)
                { // berabere kalındı
                    user1point += 0;
                    user2point += 0;
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
            }
            if (user1point == 5 || user2point == 5)
            {   
                user1point += 1; 
                user2point += 1;
                bttnnewgame.Visible = true;
                if (user1point > user2point)
                {
                    label12.Visible = true;
                    label11.Visible = true;
                    label11.Text = "user1";                    
                }
                if (user1point < user2point)
                {
                    label12.Visible = true;
                    label11.Visible = true;
                    label11.Text = "user2";
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        { // oyun arkası  ses eklemek için
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { // space'in hatasını durdurmak için kullandık. 
            if (e.KeyCode==Keys.Space)
            {
                MessageBox.Show("hatalı tuşlama");
            }
        }
        // Burada -1 değerinin verilme sebebi kullanıcılardan ikisi de seçim yapmadan sonucu göstermemek
       public int player_1 = -1, player_2 = -1;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {   // asd ve 123 tuşarını taş-kağıt-makasa atadık.
            if (panel3.Visible == true)
            { // panel3 aktif ise puanları saydırdık ve panel3 açılmadan sayma hatasının önüne geçtik
                if (e.KeyChar.ToString() == "a")
                {  // resimleri iki tarafta seçmeden göstermemek için viisble=false yaptık
                   // daha sonra multiplayer  if-else kısmında puandan(userpoint++) sonra visible=true yaptık.     
                    player_1 = 0;
                    pictureBoxuser1.ImageLocation = "Resimler/rock.png";
                    pictureBoxuser1.Visible = false;
                }
                else if (e.KeyChar.ToString() == "s")
                {
                    player_1 = 1;
                    pictureBoxuser1.ImageLocation = "Resimler/paper.png";
                    pictureBoxuser1.Visible = false;
                }
                else if (e.KeyChar.ToString() == "d")
                {
                    player_1 = 2;
                    pictureBoxuser1.ImageLocation = "Resimler/scissors.png";
                    pictureBoxuser1.Visible = false;
                }
                 if (e.KeyChar.ToString() == "1")
                 {
                    player_2 = 0;
                    pictureBoxuser2.ImageLocation = "Resimler/rock.png";
                    pictureBoxuser2.Visible = false;
                 }
                else if (e.KeyChar.ToString() == "2")
                {
                    player_2 = 1;
                    pictureBoxuser2.ImageLocation = "Resimler/paper.png";
                    pictureBoxuser2.Visible = false;
                }
                else if (e.KeyChar.ToString() == "3")
                {
                    player_2 = 2;
                    pictureBoxuser2.ImageLocation = "Resimler/scissors.png";
                    pictureBoxuser2.Visible = false;
                }
                if (player_1 != -1 && player_2 != -1)
                {
                  multiplayer(player_1, player_2);
                  player_1 = -1;
                  player_2 = -1;
                }
            }
        }
        private void bttnnewgame_Click(object sender, EventArgs e)
        {
            user1point = 0;
            user2point = 0;
            lbluser1point.Text = "0";
            lbluser2point.Text = "0";
            label11.Visible = false;
            label12.Visible = false;
            bttnnewgame.Visible = false;
            pictureBoxuser1.ImageLocation = null;
            pictureBoxuser2.ImageLocation = null;
        }
    }
}






// alttaki ilk hali.try-catch,breakpoint yok,thread yok.
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rps_deneme_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.KeyPreview = true; // Klavyeden veri alabilmek için
            InitializeComponent();
        }
        string playerselect, computerselect;
        int playerpoint, computerpoint, rastgele;
        Random randomlyy = new Random();

        private void pictureBoxrock_Click(object sender, EventArgs e)
        {
            // resimleri ekle ve neyi eklediğini rame yaz
            pictureBoxplayer.ImageLocation = "Resimler/rock.png";
            playerselect = "rock";
        }
        private void pictureBoxpaper_Click(object sender, EventArgs e)
        {
            pictureBoxplayer.ImageLocation = "Resimler/paper.png";
            playerselect = "paper";
        }
        private void pictureBoxscissors_Click(object sender, EventArgs e)
        {
            pictureBoxplayer.ImageLocation = "Resimler/scissors.png";
            playerselect = "scissors";
        }

        private void Computer_attack()
        { // random sayı belirle ve random sayıda olan eşyayı rame yaz
            rastgele = randomlyy.Next(1, 4);
            if (rastgele == 1)
            {
                pictureBoxcomputer.ImageLocation = "Resimler/rock.png";
                computerselect = "rock";
            }
            else if (rastgele == 2)
            {
                pictureBoxcomputer.ImageLocation = "Resimler/paper.png";
                computerselect = "paper";
            }
            else if (rastgele == 3)
            {
                pictureBoxcomputer.ImageLocation = "Resimler/scissors.png";
                computerselect = "scissors";
            }

        }
        private void bttnstart_Click(object sender, EventArgs e)
        {
            if (computerpoint == 0 && playerpoint == 0)
            {  // kazanan yazısının gözükmesini istemiyoruz.
                label7.Visible = false; // lbl1=lbl7 ve lbl2=lbl8    
                label8.Visible = false;
                bttnstart.Visible =true;
                button4.Visible = false;
                lblplayerpoint.Text = "0";
                lblcomputerpoint.Text = "0";
            }
            // oyuncu seçimini yapmadan oyun başlama hatasının önüne geç.
            if (playerselect == null)
            {
                MessageBox.Show("Lutfen hamlenizi seçiniz", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Computer_attack();
            }
            summerypoint();
        }

        private void summerypoint()
        { // toplam puanları hangi koşula göre hesaplanacağını yaz.
            if (playerselect == "rock" && computerselect == "paper")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "rock" && computerselect == "scissors")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            else if (playerselect == "paper" && computerselect == "rock")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            else if (playerselect == "paper" && computerselect == "scissors")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "scissors" && computerselect == "rock")
            {
                computerpoint++;
                lblcomputerpoint.Text = computerpoint.ToString();
            }
            else if (playerselect == "scissors" && computerselect == "paper")
            {
                playerpoint++;
                lblplayerpoint.Text = playerpoint.ToString();
            }
            if (computerpoint == 5 || playerpoint == 5)
            { // 5'e ilk ulaşan kazanır :)
                label7.Visible = true;
                label8.Visible = true;
                bttnstart.Visible = false;
                button4.Visible = true;
                if (computerpoint > playerpoint)
                {  // bilgisayar kazanırsa onun adını oyuncu kazanırsa onun adını yazdırıyoruz.
                   // ve oyun bittiği için puan değerlerini sıfırlıyoruz. 
                    label8.Text = "Computer";
                    playerpoint = 0;
                    computerpoint = 0;
                
                    //pictureBoxplayer.ImageLocation = null;
                    // pictureBoxcomputer.ImageLocation = null;
                    playerselect = null;
                    computerselect = null;
                    bttnstart.Visible = false;
                    button4.Visible = true;
                   
                }
                else if (computerpoint < playerpoint)
                {
                    label8.Text = "Player";
                    playerpoint = 0;
                    computerpoint = 0;
                    //pictureBoxplayer.ImageLocation = null;
                    //pictureBoxcomputer.ImageLocation = null;
                    playerselect = null;
                    computerselect = null;
                }
            }
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            lbluser1point.Text = "0";
            lbluser2point.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        { // sayıları 5'e ulaşınca butonu ekle buna basılınca sıfırlasın resimleri
            pictureBoxplayer.ImageLocation = null;
            pictureBoxcomputer.ImageLocation = null;
            bttnstart.Visible = true;
            button4.Visible = false;
            lblplayerpoint.Text = "0";
            lblcomputerpoint.Text = "0";
            label7.Visible = false;
            label8.Visible=false;
        }

        // BURANIN AŞAĞISI 3.PANEL //////////////

        int user1point, user2point;

        public void multiplayer(int player1, int player2)
        {
            string[] rps = { "rock", "paper", "scissors" };
            if (user1point<5 && user2point<5)
            {  // puanlar 5'ten küçükse arttırsın dedik  ve 5'E EŞİT OLDUĞUNDA sayıyı büyütmeye devam ettik
               // ve bttnnwegame de user1point ve user2point'i sıfıra eşitledik
                if (player1 == 0 && player2 == 1 || player1 == 1 && player2 == 2 || player1 == 2 && player2 == 0)
                { // player2 kazanır
                    user2point++;
                    lbluser2point.Text = user2point.ToString();
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
                else if (player1 == 2 && player2 == 1 || player1 == 0 && player2 == 2 || player1 == 1 && player2 == 0)
                { // player1 kazanır
                    user1point++;
                    lbluser1point.Text = user1point.ToString();
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
                else if (player1 == 0 && player2 == 0 || player1 == 1 && player2 ==1 || player1 == 2 && player2 == 2)
                { // berabere kalındı
                    user1point += 0;
                    user2point += 0;
                    pictureBoxuser1.Visible = true;
                    pictureBoxuser2.Visible = true;
                }
            }

            if (user1point == 5 || user2point == 5)
            {   
                user1point += 1; 
                user2point += 1;
                bttnnewgame.Visible = true;
                if (user1point > user2point)
                {
                    label12.Visible = true;
                    label11.Visible = true;
                    label11.Text = "user1";
                   // user1point += 1; //=0;
                   //user2point += 1; //=0;
                    
                }
                if (user1point < user2point)
                {
                    label12.Visible = true;
                    label11.Visible = true;
                    label11.Text = "user2";
                    //user1point += 1; //=0;
                    //user2point += 1; //=0;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { // oyun arkası  ses eklemek için
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { // space in hatasını durdurmak için ve asd 123 girdileri dudurmak için  
            if (e.KeyCode==Keys.Space)
            {
                MessageBox.Show("hatalı tuşlama");
            }
        }
        // Burada -1 değerinin verilme sebebi kullanıcılardan ikisi de seçim yapmadan sonucu göstermemek
       public int player_1 = -1, player_2 = -1;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {   // tuşları ata.asd 123
            if (panel3.Visible == true)
            { // panel3 aktif ise puanları saydırdık ve panel3 açılmadan sayma hatasının önüne geçtik
                if (e.KeyChar.ToString() == "a")
                {  // resimleri iki tarafta seçemden göztermemk için viisble=false yaptık
                   // daha sonra multiplayer  if-else kısmında puandan sonra visible=true yaptık.     
                    player_1 = 0;
                    pictureBoxuser1.ImageLocation = "Resimler/rock.png";
                    pictureBoxuser1.Visible = false;
                }
                else if (e.KeyChar.ToString() == "s")
                {
                    player_1 = 1;
                    pictureBoxuser1.ImageLocation = "Resimler/paper.png";
                    pictureBoxuser1.Visible = false;
                }
                else if (e.KeyChar.ToString() == "d")
                {
                    player_1 = 2;
                    pictureBoxuser1.ImageLocation = "Resimler/scissors.png";
                    pictureBoxuser1.Visible = false;
                }
                 if (e.KeyChar.ToString() == "1")
                {
                    player_2 = 0;
                    pictureBoxuser2.ImageLocation = "Resimler/rock.png";
                    pictureBoxuser2.Visible = false;
                }
                else if (e.KeyChar.ToString() == "2")
                {
                    player_2 = 1;
                    pictureBoxuser2.ImageLocation = "Resimler/paper.png";
                    pictureBoxuser2.Visible = false;
                }
                else if (e.KeyChar.ToString() == "3")
                {
                    player_2 = 2;
                    pictureBoxuser2.ImageLocation = "Resimler/scissors.png";
                    pictureBoxuser2.Visible = false;
                }
                    if (player_1 != -1 && player_2 != -1)
                {
                    multiplayer(player_1, player_2);
                    player_1 = -1;
                    player_2 = -1;
                }
            }

        }

        private void bttnnewgame_Click(object sender, EventArgs e)
        {
            user1point = 0;
            user2point = 0;
            lbluser1point.Text = "0";
            lbluser2point.Text = "0";
            label11.Visible = false;
            label12.Visible = false;
            bttnnewgame.Visible = false;
            pictureBoxuser1.ImageLocation = null;
            pictureBoxuser2.ImageLocation = null;

        }
    
    }
}

*/

