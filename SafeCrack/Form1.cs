namespace SafeCrack
{
    public partial class SafeCracker : Form
    {
        Random random = new Random();
        List<Label> lblResults = new List<Label>();
        List<PictureBox> picResults = new List<PictureBox>();
        int answer1 = 0; //first answer
        int answer2 = 0; //second answer
        int answer3 = 0; //third answer
        int numGuess = 0; //number of guesses by the player
        int intGuess = 0;//stores the player's guess
        public SafeCracker()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            answer1 = random.Next(0, 10);
            answer2 = random.Next(0, 10);
            answer3 = random.Next(0, 10);
            txtGuess1.Enabled = true;
            txtGuess2.Enabled = false;
            txtGuess3.Enabled = false;
            btnStart.Text = "Reset";
        }

        private void ResetGame()
        {
            txtGuess1.Enabled = false;
            txtGuess2.Enabled = false;
            txtGuess3.Enabled = false;
            txtGuess1.Text = string.Empty;
            txtGuess2.Text = string.Empty;
            txtGuess3.Text = string.Empty;
            lblAnswer.Text= string.Empty;
            btnStart.Text = "Start Cracking!";
            lblEndMessage.Text = string.Empty;
            openLock1.Image = Properties.Resources.lockedLock;
            openLock2.Image= Properties.Resources.lockedLock;
            openLock3.Image= Properties.Resources.lockedLock;
            numGuess = 0;
            foreach(PictureBox pictureBox in picResults)
            {
                pictureBox.Image = null;
            }
            foreach(Label label in lblResults)
            {
                label.Text = string.Empty;
            }
        }

        private void InitializeGame()
        {
            lblResults.Add(label1);
            lblResults.Add(label2);
            lblResults.Add(label3);

            picResults.Add(pic1);
            picResults.Add(pic2);
            picResults.Add(pic3);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGame();
            ResetGame();
        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start Cracking!")
            {
                StartGame();
            }
            else
            {
                ResetGame();
            }
        }

        private void GameWon()
        {
            txtGuess1.Enabled=false;
            txtGuess2.Enabled=false;
            txtGuess3.Enabled=false;
            lblEndMessage.Text = "You cracked the safe and stole everything insides. Kind of messed up cuz it was money for orphans!";
            lblEndMessage.Visible=true;
        }

        private void GameLost()
        {
            txtGuess1.Enabled=false;
            txtGuess2.Enabled=false;
            txtGuess3.Enabled=false;
            lblEndMessage.Text = "Yeah. The cops got to you before you could open the safe. You have life in prison";
            lblEndMessage.Visible=true;
        }

        private void txtGuess1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if Enter Key
            {
               
                if (!int.TryParse(txtGuess1.Text, out intGuess))
                {
                    MessageBox.Show("You did not enter a number");
                    return;
                }
                if (intGuess == answer1 + 1 || intGuess == answer1 - 1)
                {
                    lblResults[numGuess].Text = intGuess + ": You're close! You hear a  click";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.click;
                }
                else if (intGuess < answer1)
                {
                    lblResults[numGuess].Text = intGuess +": Is not even cloes. Too low";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if (intGuess > answer1)
                {
                    lblResults[numGuess].Text = intGuess+": Shooting the stars there. Too High";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if(intGuess == answer1)
                {

                    lblResults[numGuess].Text = intGuess+": Your inner lockpicking lawyer says that pin 1 is set";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.open_lock_1f513;
                    txtGuess1.Enabled = false;
                    txtGuess2.Enabled = true;

                    label1.Text = string.Empty; label2.Text = string.Empty; label3.Text = string.Empty;
                    pic1.Image = null; pic2.Image = null; pic3.Image = null;
                    openLock1.Image = Properties.Resources.open_lock_1f513;

                }
                numGuess++;
                if(numGuess <= 3 && intGuess == answer1) 
                {
                    System.Diagnostics.Debug.WriteLine("inside and if loop");
                    numGuess = 0;
                    return;
                }
                else if(numGuess == 3)
                {
                    GameLost();
                    return;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = answer1 + " " + answer2 + " " + answer3;
        }

        private void txtGuess2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if Enter Key
            {
                if (!int.TryParse(txtGuess2.Text, out intGuess))
                {
                    MessageBox.Show("You did not enter a number");
                    return;
                }
                if (intGuess == answer2 + 1 || intGuess == answer2 - 1)
                {
                    lblResults[numGuess].Text = intGuess + ": You're close! You hear a  click";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.click;
                }
                else if (intGuess < answer2)
                {
                    lblResults[numGuess].Text = intGuess + ": Is not even cloes. Too low";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if (intGuess > answer2)
                {
                    lblResults[numGuess].Text = intGuess + ": Shooting the stars there. Too High";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if (intGuess == answer2)
                {

                    lblResults[numGuess].Text = intGuess + ": Your inner lockpicking lawyer says that pin 1 is set";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.open_lock_1f513;
                    txtGuess2.Enabled = false;
                    txtGuess3.Enabled = true;

                    label1.Text = string.Empty; label2.Text = string.Empty; label3.Text = string.Empty;
                    pic1.Image = null; pic2.Image = null; pic3.Image = null;
                    openLock2.Image = Properties.Resources.open_lock_1f513;

                }
                numGuess++;
                if (numGuess <= 3 && intGuess == answer2)
                {
                    System.Diagnostics.Debug.WriteLine("inside and if loop");
                    numGuess = 0;
                    return;
                }
                else if (numGuess == 3)
                {
                    GameLost();
                    return;
                }
            }
        }

        private void txtGuess3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if Enter Key
            {
                if (!int.TryParse(txtGuess3.Text, out intGuess))
                {
                    MessageBox.Show("You did not enter a number");
                    return;
                }
                if (intGuess == answer3 + 1 || intGuess == answer3 - 1)
                {
                    lblResults[numGuess].Text = intGuess + ": You're close! You hear a  click";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.click;
                }
                else if (intGuess < answer3)
                {
                    lblResults[numGuess].Text = intGuess + ": Is not even cloes. Too low";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if (intGuess > answer3)
                {
                    lblResults[numGuess].Text = intGuess + ": Shooting the stars there. Too High";
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.straightFace;
                }
                else if (intGuess == answer3)
                {

                    lblResults[numGuess].Text = intGuess + ": Your inner lockpicking lawyer says that pin 1 is set";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.open_lock_1f513;
                    txtGuess2.Enabled = false;
                    txtGuess3.Enabled = true;

                    label1.Text = string.Empty; label2.Text = string.Empty; label3.Text = string.Empty;
                    pic1.Image = null; pic2.Image = null; pic3.Image = null;
                    openLock3.Image = Properties.Resources.open_lock_1f513;
                    GameWon();
                    return;

                }
                numGuess++;
                if (numGuess <= 3 && intGuess == answer3)
                {
                    GameWon();
                    return;
                }
                else if (numGuess == 3)
                {
                    GameLost();
                    return;
                }
            }
        }

        private void txtGuess3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //control characters are non-printing charcters like the Enter key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //cancel the key press
            }
        }

        private void txtGuess2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //control characters are non-printing charcters like the Enter key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //cancel the key press
            }
        }

        private void txtGuess1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //control characters are non-printing charcters like the Enter key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //cancel the key press
            }
        }
    }
}