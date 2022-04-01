using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // DllImport를 위해 추가
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ModernFlatUI.Forms;

namespace ModernFlatUI
{
    public partial class MainForm : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderOfBtn;
        private Form currentChildForm;

        // 생성자
        public MainForm()
        {
            InitializeComponent();
            leftBorderOfBtn = new Panel();
            leftBorderOfBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderOfBtn);
            // 폼
//            this.Text = string.Empty;
//            this.ControlBox = false;    // 상단 표시줄 옆 메뉴 삭제
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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
                //Icon Current Child Form
                // 현재 집 모양 아이콘
                // 현재 선택한 아이콘과 색을 표시
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                // lblTitleChildForm.Text = currentBtn.Text; // childForm.Text와 같을 것 같기도 하지만, 일단 주석 처리
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

        // 기존 자식 폼 닫고, 모덜리스로 판넬에 붙이고 엶. (.Add로 컨트롤에 붙였는데, Remove안 해주고 .Close()만 해줘도 되는 건가?)
        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                //open only form
                currentChildForm.Close(); // 기존의 자식 폼은 닫음
            }
            currentChildForm = childForm;   // 매개변수로부터 전역 변수에 저장
            // 폼을 panelDesktop에 붙이기 전에 설정.
            childForm.TopLevel = false; // 최상의 창으로 표시하지 않음.
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            // 판넬에 폼을 붙이고, 가장 앞으로 보이게 하고, Show() 모달리스 방식으로 엶.
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormDashboard()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormOrders()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormProducts()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormCustomers()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        private void btnMarketing_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormMarketing()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormSetting()); // 기존ChildForm을 닫고, 판넬에 새 ChildForm을 붙임.
        }

        // 
        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            // 반영했던 아이콘 모양과 색을 원래대로 설정
            DisableButton();
            leftBorderOfBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        // 폼 드래그 이동 위해 Import
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); // 리턴형 bool로 하면, 성공시 bool값 리턴. GetLastError를 호출해서 실패 이유 확인도 가능.
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] // 가져오는 메서드 하나하나에 대해서, 적어주는 듯하다.
        // wParam에 사용할 수 있는 값들
        // #define SC_SZLEFT (0xF001)
        // #define SC_SZRIGHT (0xF002)
        // #define SC_SZTOP (0xF003)
        // #define SC_SZTOPLEFT (0xF004)
        // #define SC_SZTOPRIGHT (0xF005)
        // #define SC_SZBOTTOM (0xF006)
        // #define SC_SZBOTTOMLEFT (0xF007)
        // #define SC_SZBOTTOMRIGHT (0xF008)
        // #define SC_DRAGMOVE (0xF012)
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // 폼 드래그 이동
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // 화면 영역 밖에서 WM_MOUSEMOVE가 더 이상 받아지지 않음. <-> HWND SetCapture(HWND hWnd);이전 SetCapture했던 HWND반환. 없으면 NULL
            ReleaseCapture(); 
            // 0x112는 WM_SYSCOMMAND, 0xf012는 SC_DRAGMOVE
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Application.Exit(); // 모든 메시지 루프를 종료하고, 모든 창을 닫아 폼의 정리코드(Form.OnClose등)을 실행할 수 있는 가능성을 제공
            // Environment.Exit(0); // 프로세스를 죽임. 리소스(데이터베이스 연결 등)가 제대로 해제되지 않고, 파일이 플러쉬되지 않을 수 있음. 저장되지 않은 변경사항이 있을 경우, 사용자에게 묻는 메시지 등이 표시되지 않음.
            // this.Close(); // 폼을 닫음. 다른 폼이 열려 있는 경우, 프로그램이 종료되지 않음.
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) // 윈도우 상태가 노멀이면 최대화로 설정
                WindowState = FormWindowState.Maximized;
            else                                       // 최소화된 상태나 최대화된 상태면, 노멀 상태로 설정.
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            // 윈도우 상태를 최소화 상태로 함.(이미 최소화 되어 있으면 최소화 버튼이 보이지 않으므로, 구현하지 않음)
            WindowState = FormWindowState.Minimized;
        }
    }
}
