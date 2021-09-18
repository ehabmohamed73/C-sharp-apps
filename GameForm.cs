using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Tic_Tac_To
{
    class GameForm:Form
    {
        // variples
        bool turn = true;
        int countClick;
        Button[] btnArray = new Button[9];
        Label lblResult;

        //the constructor
        public GameForm()
        {
            this.Size = new Size(300, 400);
            Font = new Font(FontFamily.GenericMonospace,22, FontStyle.Bold);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            lblResult = new Label();
            lblResult.AutoSize = true;
            lblResult.Location = new Point(100,300);
            lblResult.ForeColor = Color.DarkBlue;
            for(int i=0;i<9;i++)
            {
              btnArray[i] = new Button();
                //btnArray[i].Location = new Point(btnArray[i].Width+ 5, btnArray[i].Height +5);
                btnArray[i].Size = new Size(70, 70);
                btnArray[i].Location = new Point(i%3 *70 +20,i/3*70+20);
                btnArray[i].FlatStyle = FlatStyle.Flat;
                btnArray[i].Click += add_text;
            }


            //functions
            // to add x or O
            void add_text(object sender,EventArgs e)
            {
                Button hold = (Button)sender;
                if(turn)
                {
                    hold.Text = "X";

                }
                else
                {
                    hold.Text = "O";
                }
                turn = !turn;
                hold.Enabled = false;
                countClick++;
                checkWinner();
            }

            //check the wineer
            void checkWinner()
            {
                bool winner = false;

                //vertical check
                if ((btnArray[0].Text == btnArray[1].Text) && btnArray[1].Text == btnArray[2].Text && !btnArray[0].Enabled)
                    winner = true;
                else if ((btnArray[3].Text == btnArray[4].Text) && btnArray[4].Text == btnArray[5].Text && !btnArray[3].Enabled)
                    winner = true;
                else if ((btnArray[6].Text == btnArray[7].Text) && btnArray[7].Text == btnArray[8].Text&& !btnArray[6].Enabled)
                    winner = true;

                //horzintal check
                else if ((btnArray[0].Text == btnArray[3].Text) && btnArray[3].Text == btnArray[6].Text&& !btnArray[0].Enabled)
                    winner = true;
                else if ((btnArray[1].Text == btnArray[4].Text) && btnArray[4].Text == btnArray[7].Text&& !btnArray[1].Enabled)
                    winner = true;
                else if ((btnArray[2].Text == btnArray[5].Text) && btnArray[5].Text == btnArray[8].Text&& !btnArray[2].Enabled)
                    winner = true;

                //diagonal check
                else if ((btnArray[0].Text == btnArray[4].Text) && btnArray[4].Text == btnArray[8].Text&& !btnArray[0].Enabled)
                    winner = true;
                else if ((btnArray[2].Text == btnArray[4].Text) && btnArray[4].Text == btnArray[6].Text&& !btnArray[6].Enabled)
                    winner = true;
               if(winner)
                {
                    disableBtn();

                    if (!turn)
                        lblResult.Text = "X Win!";
                    else
                        lblResult.Text = "O Win!";
                }
               else
                {
                    if(countClick==9)
                    {
                        lblResult.Text = "NO Winner";
                    }
                }

             }

            //disable buttons
            void disableBtn()
            {
              for(int i=0;i<9;i++)
                {
                    btnArray[i].Enabled = false;
                }
            }

            //add the controls
            this.Controls.AddRange(btnArray);
            this.Controls.Add(lblResult);
        }
       
    }
}
