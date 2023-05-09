using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] TheArray;
        Graphics g;
        int width = 1000;
        int elArray = 50;
        int delay = 0;
        int maxVal = 500;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            g = panel2.CreateGraphics();
            
            

            int xDraw = width / elArray;
                
            TheArray = new int[elArray];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, width, maxVal);
            Random rand = new Random();
            for (int i = 0; i < elArray; i++)
            {
                TheArray[i] = rand.Next(0, maxVal);
            }
            for (int i = 0; i < elArray; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Wheat), i * xDraw, maxVal - TheArray[i], xDraw-1, maxVal);


            }
        }

        private void BtnBubble_Click(object sender, EventArgs e)
        {
            BubbleSort b = new BubbleSort();
            Thread sort = new Thread(() => b.DoWork(TheArray, g, maxVal, elArray, width, delay));
            //b.DoWork(TheArray, g, maxVal, elArray, width, delay);
            sort.Start();
           
            

        }
      public class BubbleSort
        {
            private bool _sorted = false;
            private int[] theArray;
            private Graphics g;
            private int maxVal;
            private int elArray;
            private int numEntries;
            private int xDraw ;
            private int delay;
            Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Wheat);
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            Brush YellowBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            

            public void DoWork(int[] TheArray_i, Graphics g_i, int maxVal_i,int elArray_i, int numEntries_i, int delay_i)
                {
                
                    theArray = TheArray_i;
                    g = g_i;
                    maxVal = maxVal_i;
                    elArray = elArray_i;
                    numEntries = numEntries_i;
                   xDraw = numEntries / elArray;
                    this.delay = delay_i;
                    while (!_sorted)
                    {
                    int jk = theArray.Count(); 
                        for (int i = 0; i < jk-1; i++)
                        {
                            if (theArray[i] > theArray[i + 1])
                            {
                                Swap(i);
                           // Thread.Sleep(delay);
                            }
                        }
                    jk--;
                        _sorted = isSorted();
                    }
                }

            private void Swap(int i)
            {
                g.FillRectangle(blackBrush, i * xDraw, 0, xDraw - 1, maxVal);
                g.FillRectangle(blackBrush, (i + 1) * xDraw, 0, xDraw - 1, maxVal);
                //  g.FillRectangle(blackBrush, i, 0, 2, maxVal);

                g.FillRectangle(YellowBrush, i * xDraw, maxVal - theArray[i], xDraw - 1, maxVal);
                g.FillRectangle(GreenBrush, (i + 1) * xDraw, maxVal - theArray[i + 1], xDraw - 1, maxVal);
                Thread.Sleep(delay);
              //  int temp = theArray[i];
               // theArray[i] = theArray[i + 1];
               // theArray[i + 1] = temp;

                theArray[i] = theArray[i] + theArray[i + 1];
                theArray[i + 1] = theArray[i] - theArray[i + 1];
                theArray[i] = theArray[i] - theArray[i + 1];

                    

                g.FillRectangle(blackBrush, i * xDraw, 0, xDraw - 1, maxVal);
                g.FillRectangle(blackBrush, (i + 1) * xDraw, 0, xDraw - 1, maxVal);
                //  g.FillRectangle(blackBrush, i, 0, 2, maxVal);
                g.FillRectangle(YellowBrush, i * xDraw, maxVal - theArray[i], xDraw - 1, maxVal);
                g.FillRectangle(GreenBrush, (i + 1) * xDraw, maxVal - theArray[i + 1], xDraw - 1, maxVal);
                Thread.Sleep(delay);

                g.FillRectangle(blackBrush, i* xDraw, 0, xDraw- 1, maxVal);
                    g.FillRectangle(blackBrush, (i + 1)* xDraw, 0, xDraw - 1, maxVal);
                    //g.FillRectangle(blackBrush, i, 0, 2, maxVal);

                    g.FillRectangle(whiteBrush, i * xDraw, maxVal - theArray[i], xDraw - 1, maxVal);
                    g.FillRectangle(whiteBrush, (i + 1) * xDraw, maxVal - theArray[i + 1], xDraw - 1, maxVal);
                }

                private bool isSorted()
                {
                    for (int i = 0; i < theArray.Count() - 1; i++)
                    {
                        if (theArray[i] > theArray[i + 1]) return false;
                    }
               
                    return true;
                }
            }

      

        private void Button3_Click(object sender, EventArgs e)
        {
            elArray = 100;
            button3.BackColor = Color.Red;
            button2.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            elArray = 50;
            button2.BackColor = Color.Red;
            button3.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            elArray = 10;
            button1.BackColor = Color.Red;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            delay = 30;
            button4.BackColor = Color.Red;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            delay = 0;
            button5.BackColor = Color.Red;
            button4.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void Button6_Click(object sender, EventArgs e)
        {
            delay = 500;
            button6.BackColor = Color.Red;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            elArray = 500;
            button7.BackColor = Color.Red ;
            button2.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
        }
    }
    }
