using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ModernFlatUI
{
    public partial class MainForm : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderOfBtn;

        // 생성자
        public MainForm()
        {
            InitializeComponent();
            leftBorderOfBtn = new Panel();
            leftBorderOfBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderOfBtn);
        }


        // Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(249,118,176);
            public static Color color3 = Color.FromArgb(253,138,114);
            public static Color color4 = Color.FromArgb(95,77,221);
            public static Color color5 = Color.FromArgb(249,88,155);
            public static Color color6 = Color.FromArgb(24,161,251);
        }


        // Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                // Deactivate Previous Button
                DisableButton(); 

                //Button
                // 뒷 배경색을 아주 약간 더 밝게 변경하고,
                // 앞 버튼 색을 매개변수에서 저장한 후,
                // 글자는 가운데 정렬, 아이콘은 오른쪽 정렬
                // 글자는 이미지 앞쪽에 배치

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Left border button
                // 왼쪽 막대(버튼이 아니라 패널)
                // 왼쪽 끝인 X: 0과 현재 버튼의 Y 위치에 막대를 표시
                // 색은 전달한 색과 같게
                leftBorderOfBtn.BackColor = color;
                leftBorderOfBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderOfBtn.Visible = true;
                leftBorderOfBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if(currentBtn != null)
            {
                // 기존의 버튼을 초기 설정 값으로 돌려 놓음.
                // 새로운 버튼을 눌렀으므로, currentBtn은 이전 버튼의 참조가 저장되어 있음.
                // 배경색을 31,30,68로 설정하고, 
                // 글자색(아이콘 색)을 Gainsboro색으로 설정,(원래 기본 색)
                // 글자 정렬은 MiddleLeft로 같고,
                // IconColor도 기본 색으로 돌림.
                // 이미지를 텍스트보다 앞쪽에 배치
                // 이미지의 정렬은 왼쪽으로.
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void btnMarketing_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }
    }
}
