using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swf_editor {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
        }

        private int GetCurrentFrameNumber() {
            return int.Parse(MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text);
        }

        private void FrameDecrease_Click(object sender, EventArgs e) {
            if (GetCurrentFrameNumber() > 0) MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text = (GetCurrentFrameNumber() - 1).ToString();
        }

        private void FrameIncrease_Click(object sender, EventArgs e) {
            MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text = (GetCurrentFrameNumber() + 1).ToString();
        }

        private void FrameDisplay_TextChanged(object sender, EventArgs e) {
            string NString = "";
            for (int i = 0; i < MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text.Length; i++) {
                if (MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text[i] >= '0') {
                    if (MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text[i] <= '9') {
                        NString += MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text[i];
                    }
                }
            }
            if (NString == "") NString = "0";
            MainWindow.ActiveForm.Controls.Find("FrameDisplay", true)[0].Text = NString;
        }
    }
}
