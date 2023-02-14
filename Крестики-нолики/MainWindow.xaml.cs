using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Крестики_нолики
{
    public partial class MainWindow : Window
    {
        private bool p;
        private List<Button> buttons;
        private int turn = 0;
        private int a;
        public MainWindow()
        {
            p = true;
            if (turn % 2 == 0)
            {

            }
            else if (turn % 2 == 1)
            {
                bot();
            }
            InitializeComponent();
        }
        public void bot()
        {
            buttons = new List<Button>() { but1, but2, but3, but4, but5, but6, but7, but8, but9 };
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsEnabled == false || buttons[i].Content.ToString() != "")
                    buttons.RemoveAt(i);
            }
            Random random = new Random();
            int r = 0;
            if (p == true)
            {
                if (buttons.Count > 1)
                {

                    while (true)
                    {
                        r = random.Next(1, buttons.Count - 1);
                        if (buttons[r].IsEnabled == false)
                        {
                            r = random.Next(1, buttons.Count - 1);
                        }
                        else break;

                    }
                }
                else if (buttons.Count == 1)
                {
                    r = 0;
                }
                else if (buttons.Count < 1)
                {

                }
                buttons[r].Content = "x";
                buttons[r].IsEnabled = false;
                p = false;
                turn++;
            }
            else if (p == false)
            {
                if (buttons.Count > 1)
                {
                    while (true)
                    {
                        r = random.Next(1, buttons.Count - 1);
                        if (buttons[r].IsEnabled == false)
                        {
                            r = random.Next(1, buttons.Count - 1);
                        }
                        else break;

                    }
                }
                else if (buttons.Count == 1)
                {
                    r = 0;
                }
                else if (buttons.Count < 1)
                {

                }
                buttons[r].Content = "o";
                buttons[r].IsEnabled = false;
                p = true;
                turn++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (p == true)
            {
                sender.GetType().GetProperty("Content").SetValue(sender, "x");
                p = false;
            }
            else if (p == false)
            {
                sender.GetType().GetProperty("Content").SetValue(sender, "o");
                p = true;
            }
            sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
            turn++;
            bot();
            win();
        }

        private void win()
        {
            if (but1.Content == but2.Content && but1.Content == but3.Content && but1.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but4.Content == but5.Content && but4.Content == but6.Content && but4.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but7.Content == but8.Content && but7.Content == but9.Content && but7.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but1.Content == but4.Content && but1.Content == but7.Content && but1.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but2.Content == but5.Content && but2.Content == but8.Content && but2.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but3.Content == but6.Content && but3.Content == but9.Content && but3.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but1.Content == but5.Content && but1.Content == but9.Content && but1.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            if (but3.Content == but5.Content && but3.Content == but7.Content && but3.Content.ToString() != "")
            {
                conditions();
                unenable();
            }
            else if (but1.IsEnabled == false && but2.IsEnabled == false && but3.IsEnabled == false && but4.IsEnabled == false && but5.IsEnabled == false && but6.IsEnabled == false && but7.IsEnabled == false && but8.IsEnabled == false && but9.IsEnabled == false)
            {
                MessageBox.Show("Ничья!");
            }
            txt.Text = turn.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            but1.Content = "";
            but2.Content = "";
            but3.Content = "";
            but4.Content = "";
            but5.Content = "";
            but6.Content = "";
            but7.Content = "";
            but8.Content = "";
            but9.Content = "";
            but1.IsEnabled = true;
            but2.IsEnabled = true;
            but3.IsEnabled = true;
            but4.IsEnabled = true;
            but5.IsEnabled = true;
            but6.IsEnabled = true;
            but7.IsEnabled = true;
            but8.IsEnabled = true;
            but9.IsEnabled = true;
            if (p == true)
            {
                p = false;
                turn++;
            }
            else if (p == false)
            {
                p = true;
            }
        }

        public void unenable()
        {
            but1.IsEnabled = false;
            but2.IsEnabled = false;
            but3.IsEnabled = false;
            but4.IsEnabled = false;
            but5.IsEnabled = false;
            but6.IsEnabled = false;
            but7.IsEnabled = false;
            but8.IsEnabled = false;
            but9.IsEnabled = false;
        }
        public void conditions()
        {
            if (a > 0 && turn % 2 == 1)
            {
                MessageBox.Show("вы победили!");
            }
            else if (a > 0 && turn % 2 == 0)
            {
                MessageBox.Show("Вы проиграли(");
            }
        }

    }
}
