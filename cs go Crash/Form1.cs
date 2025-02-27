using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_go_Crash
{
	public partial class Form1 : Form
	{
		Random rand = new Random();

		bool Crashing = false;
		int coins = 100;
		double multiplier = 1.00;
		int bet = 0;

		public Form1()
		{
			InitializeComponent();
			button2.Text = "start";
			update();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			multiplier += multiplier / 1000;
			int lucky = rand.Next(1, (int)(multiplier + 1000));
			if (lucky <= multiplier)
			{
				Crash();
			}
			update();
		}

		private void Crash()
		{
			timer1.Enabled = false;
			label1.ForeColor = Color.Red;
			bet = 0;
			button2.Text = "start";
			label4.Visible = true;
			label4.Text = "Crashed!";
			Crashing = false;
			update();
		}

		private void update()
		{
			label1.Text = $"x{Math.Round(multiplier, 2)}";
			label2.Text = $"Coin(s): {coins}";
			label3.Text = $"{bet} * {Math.Round(multiplier, 2)} = {Math.Round(bet * multiplier)}";
		}

		private void start()
		{
			label4.Visible = false;
			label1.ForeColor = Color.SpringGreen;
			multiplier = 1;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (bet > 0)
			{
				if (!Crashing)
				{
					start();
					button2.Text = "stop";
					Crashing = true;
					timer1.Enabled = true;
				}

				else
				{
					timer1.Enabled = false;
					button2.Text = "start";
					coins += (int)(Math.Round(bet * multiplier));
					multiplier = 1;
					bet = 0;
					update();
					Crashing = false;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (coins >= int.Parse(numericUpDown1.Text))
				{
					start();
					coins -= int.Parse(numericUpDown1.Text);
					bet += int.Parse(numericUpDown1.Text);
					update();
				}
			}
			catch
			{

			}
		}

		private void numericUpDown1_Click(object sender, EventArgs e)
		{
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			update();
			numericUpDown1.Value = coins;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			update();
			numericUpDown1.Value = (int)Math.Round((double)coins / 2);
		}
	}
}