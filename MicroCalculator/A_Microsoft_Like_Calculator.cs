/*
 
 author: TLSLT
 Data: 2007.10.21
 Company: ����IT��ҵ���ʽ���Э��  
 
 */
#region using System
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;                                               //ʹ��ջ������ļ�����
using System.Text.RegularExpressions;                                   //�ַ�������Ĳ���,����ĳ�ַ������Ƿ���ĳ�Ӵ�,�������;������ʽ��Ҫʹ��
//using System.Web;
//using System.Web.UI;                                                  //���ý������������ռ�
#endregion

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        public Stack numStack = new Stack();                            //��������ջ
        public Stack operStack = new Stack();                           //��������ջ
        public Stack mStack = new Stack();                              //�����Ĵ���ջ

        bool operFlag = false;                                          //�����������Flag,�����ж��Ƿ��ѵ�������
        bool dotFlag = false;                                           //����С�����Flag,�����ж��Ƿ��ѵ��С����
        bool enterFlag = false;                                         //����=��Enter����Flag


        public frmCalculator()
        {
            InitializeComponent();
  
            operStack.Push("0"); 
            /*
             * �����ڷ����������ջ����
             * �Ҳ�����operate_Click�¼�����ջ
             * ����ÿ�ε�����ŵ�ʱ�򶼼�һ��"0"��ȥ��
             * ���������л��޷���ȡ��������㣬�ڳ�ʼ���ӿڵ�ʱ������Ҳ���"0"����Ӧ�ķ�����������Ϊֻ��+-* /�ġ�
             * ���ڴ˽�"0"�����ջ��,����֮��Ƚ���������ȼ�ʱ�������ȼ���Ϊ���
            */


        }


        #region ��ʼ�����
        private void InitializeComponent()
        {
            this.cancle_all = new System.Windows.Forms.Button();
            this.backspace = new System.Windows.Forms.Button();
            this.cancle_last = new System.Windows.Forms.Button();
            this.�ļ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_c = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_v = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.�鿴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text_display = new System.Windows.Forms.TextBox();
            this.no_0 = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.operate_div = new System.Windows.Forms.Button();
            this.operate_ride = new System.Windows.Forms.Button();
            this.operate_dec = new System.Windows.Forms.Button();
            this.operate_add = new System.Windows.Forms.Button();
            this.flowLayoutPanel_numbers = new System.Windows.Forms.FlowLayoutPanel();
            this.no_7 = new System.Windows.Forms.Button();
            this.no_8 = new System.Windows.Forms.Button();
            this.no_9 = new System.Windows.Forms.Button();
            this.no_4 = new System.Windows.Forms.Button();
            this.no_5 = new System.Windows.Forms.Button();
            this.no_6 = new System.Windows.Forms.Button();
            this.no_1 = new System.Windows.Forms.Button();
            this.no_2 = new System.Windows.Forms.Button();
            this.no_3 = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.sqrt = new System.Windows.Forms.Button();
            this.reciprocal = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Button();
            this.mc = new System.Windows.Forms.Button();
            this.mr = new System.Windows.Forms.Button();
            this.ms = new System.Windows.Forms.Button();
            this.mAdd = new System.Windows.Forms.Button();
            this.label_m = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.flowLayoutPanel_numbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancle_all
            // 
            this.cancle_all.BackColor = System.Drawing.Color.White;
            this.cancle_all.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancle_all.ForeColor = System.Drawing.Color.Red;
            this.cancle_all.Location = new System.Drawing.Point(206, 63);
            this.cancle_all.Name = "cancle_all";
            this.cancle_all.Size = new System.Drawing.Size(67, 32);
            this.cancle_all.TabIndex = 0;
            this.cancle_all.TabStop = false;
            this.cancle_all.Text = "C";
            this.cancle_all.UseVisualStyleBackColor = false;
            this.cancle_all.Click += new System.EventHandler(this.c_Click);
            this.cancle_all.GotFocus += new System.EventHandler(this.button_GotFocus);

            // 
            // backspace
            // 
            this.backspace.BackColor = System.Drawing.Color.White;
            this.backspace.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backspace.ForeColor = System.Drawing.Color.Red;
            this.backspace.Location = new System.Drawing.Point(55, 63);
            this.backspace.Name = "backspace";
            this.backspace.Size = new System.Drawing.Size(73, 32);
            this.backspace.TabIndex = 0;
            this.backspace.TabStop = false;
            this.backspace.Text = "Backspace";
            this.backspace.UseVisualStyleBackColor = false;
            this.backspace.Click += new System.EventHandler(this.backspace_Click);
            this.backspace.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // cancle_last
            // 
            this.cancle_last.BackColor = System.Drawing.Color.White;
            this.cancle_last.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancle_last.ForeColor = System.Drawing.Color.Red;
            this.cancle_last.Location = new System.Drawing.Point(135, 63);
            this.cancle_last.Name = "cancle_last";
            this.cancle_last.Size = new System.Drawing.Size(65, 32);
            this.cancle_last.TabIndex = 0;
            this.cancle_last.TabStop = false;
            this.cancle_last.Text = "CE";
            this.cancle_last.UseVisualStyleBackColor = false;
            this.cancle_last.Click += new System.EventHandler(this.ce_Click);
            this.cancle_last.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // �ļ�ToolStripMenuItem
            // 
            this.�ļ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrl_c,
            this.ctrl_v});
            this.�ļ�ToolStripMenuItem.Name = "�ļ�ToolStripMenuItem";
            this.�ļ�ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.�ļ�ToolStripMenuItem.Text = "�༭(&E)";
            // 
            // ctrl_c
            // 
            this.ctrl_c.Name = "ctrl_c";
            this.ctrl_c.Size = new System.Drawing.Size(154, 22);
            this.ctrl_c.Text = "����(&C) Ctrl+C";
            this.ctrl_c.Click += new System.EventHandler(this.ctrl_c_Click);
            // 
            // ctrl_v
            // 
            this.ctrl_v.Name = "ctrl_v";
            this.ctrl_v.Size = new System.Drawing.Size(154, 22);
            this.ctrl_v.Text = "ճ��(&P) Ctrl+V";
            this.ctrl_v.Click += new System.EventHandler(this.ctrl_v_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�ļ�ToolStripMenuItem,
            this.�鿴ToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.ShowItemToolTips = true;
            this.menu.Size = new System.Drawing.Size(279, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "�ļ�";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // �鿴ToolStripMenuItem
            // 
            this.�鿴ToolStripMenuItem.Name = "�鿴ToolStripMenuItem";
            this.�鿴ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.�鿴ToolStripMenuItem.Text = "�鿴(&V)";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.����ToolStripMenuItem.Text = "����(&H)";
            // 
            // text_display
            // 
            this.text_display.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.text_display.BackColor = System.Drawing.SystemColors.Window;
            this.text_display.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_display.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_display.ForeColor = System.Drawing.Color.Black;
            this.text_display.Location = new System.Drawing.Point(6, 28);
            this.text_display.Name = "text_display";
            this.text_display.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text_display.Size = new System.Drawing.Size(267, 26);
            this.text_display.TabIndex = 0;
            this.text_display.TabStop = false;
            this.text_display.Text = "0.";
            this.text_display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_display.GotFocus += new System.EventHandler(this.text_display_GotFocus);
            // 
            // no_0
            // 
            this.no_0.BackColor = System.Drawing.Color.White;
            this.no_0.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_0.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_0.Location = new System.Drawing.Point(55, 209);
            this.no_0.Name = "no_0";
            this.no_0.Size = new System.Drawing.Size(40, 30);
            this.no_0.TabIndex = 0;
            this.no_0.TabStop = false;
            this.no_0.Tag = "0";
            this.no_0.Text = "0";
            this.no_0.UseVisualStyleBackColor = false;
            this.no_0.Click += new System.EventHandler(this.num_Click);
            this.no_0.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // dot
            // 
            this.dot.BackColor = System.Drawing.Color.White;
            this.dot.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dot.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dot.Location = new System.Drawing.Point(147, 209);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(40, 30);
            this.dot.TabIndex = 0;
            this.dot.TabStop = false;
            this.dot.Tag = "dot";
            this.dot.Text = ".";
            this.dot.UseVisualStyleBackColor = false;
            this.dot.Click += new System.EventHandler(this.dot_Click);
            this.dot.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // equal
            // 
            this.equal.BackColor = System.Drawing.Color.White;
            this.equal.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.equal.ForeColor = System.Drawing.Color.Red;
            this.equal.Location = new System.Drawing.Point(234, 209);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(40, 30);
            this.equal.TabIndex = 0;
            this.equal.TabStop = false;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = false;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            this.equal.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_div
            // 
            this.operate_div.BackColor = System.Drawing.Color.White;
            this.operate_div.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_div.ForeColor = System.Drawing.Color.Red;
            this.operate_div.Location = new System.Drawing.Point(193, 101);
            this.operate_div.Name = "operate_div";
            this.operate_div.Size = new System.Drawing.Size(40, 30);
            this.operate_div.TabIndex = 0;
            this.operate_div.TabStop = false;
            this.operate_div.Tag = "";
            this.operate_div.Text = "/";
            this.operate_div.UseVisualStyleBackColor = false;
            this.operate_div.Click += new System.EventHandler(this.operator_Click);
            this.operate_div.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_ride
            // 
            this.operate_ride.BackColor = System.Drawing.Color.White;
            this.operate_ride.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_ride.ForeColor = System.Drawing.Color.Red;
            this.operate_ride.Location = new System.Drawing.Point(193, 137);
            this.operate_ride.Name = "operate_ride";
            this.operate_ride.Size = new System.Drawing.Size(40, 30);
            this.operate_ride.TabIndex = 0;
            this.operate_ride.TabStop = false;
            this.operate_ride.Tag = "";
            this.operate_ride.Text = "*";
            this.operate_ride.UseVisualStyleBackColor = false;
            this.operate_ride.Click += new System.EventHandler(this.operator_Click);
            this.operate_ride.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_dec
            // 
            this.operate_dec.BackColor = System.Drawing.Color.White;
            this.operate_dec.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_dec.ForeColor = System.Drawing.Color.Red;
            this.operate_dec.Location = new System.Drawing.Point(193, 173);
            this.operate_dec.Name = "operate_dec";
            this.operate_dec.Size = new System.Drawing.Size(40, 30);
            this.operate_dec.TabIndex = 0;
            this.operate_dec.TabStop = false;
            this.operate_dec.Tag = "";
            this.operate_dec.Text = "-";
            this.operate_dec.UseVisualStyleBackColor = false;
            this.operate_dec.Click += new System.EventHandler(this.operator_Click);
            this.operate_dec.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_add
            // 
            this.operate_add.BackColor = System.Drawing.Color.White;
            this.operate_add.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_add.ForeColor = System.Drawing.Color.Red;
            this.operate_add.Location = new System.Drawing.Point(193, 209);
            this.operate_add.Name = "operate_add";
            this.operate_add.Size = new System.Drawing.Size(40, 30);
            this.operate_add.TabIndex = 0;
            this.operate_add.TabStop = false;
            this.operate_add.Tag = "";
            this.operate_add.Text = "+";
            this.operate_add.UseVisualStyleBackColor = false;
            this.operate_add.Click += new System.EventHandler(this.operator_Click);
            this.operate_add.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // flowLayoutPanel_numbers
            // 
            this.flowLayoutPanel_numbers.BackColor = System.Drawing.SystemColors.MenuBar;
            this.flowLayoutPanel_numbers.Controls.Add(this.no_7);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_8);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_9);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_4);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_5);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_6);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_1);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_2);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_3);
            this.flowLayoutPanel_numbers.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flowLayoutPanel_numbers.Location = new System.Drawing.Point(52, 98);
            this.flowLayoutPanel_numbers.Name = "flowLayoutPanel_numbers";
            this.flowLayoutPanel_numbers.Size = new System.Drawing.Size(140, 110);
            this.flowLayoutPanel_numbers.TabIndex = 1;
            // 
            // no_7
            // 
            this.no_7.BackColor = System.Drawing.Color.White;
            this.no_7.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_7.Location = new System.Drawing.Point(3, 3);
            this.no_7.Name = "no_7";
            this.no_7.Size = new System.Drawing.Size(40, 30);
            this.no_7.TabIndex = 0;
            this.no_7.TabStop = false;
            this.no_7.Tag = "7";
            this.no_7.Text = "7";
            this.no_7.UseVisualStyleBackColor = false;
            this.no_7.Click += new System.EventHandler(this.num_Click);
            this.no_7.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_8
            // 
            this.no_8.BackColor = System.Drawing.Color.White;
            this.no_8.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_8.Location = new System.Drawing.Point(49, 3);
            this.no_8.Name = "no_8";
            this.no_8.Size = new System.Drawing.Size(40, 30);
            this.no_8.TabIndex = 0;
            this.no_8.TabStop = false;
            this.no_8.Tag = "8";
            this.no_8.Text = "8";
            this.no_8.UseVisualStyleBackColor = false;
            this.no_8.Click += new System.EventHandler(this.num_Click);
            this.no_8.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_9
            // 
            this.no_9.BackColor = System.Drawing.Color.White;
            this.no_9.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_9.Location = new System.Drawing.Point(95, 3);
            this.no_9.Name = "no_9";
            this.no_9.Size = new System.Drawing.Size(40, 30);
            this.no_9.TabIndex = 0;
            this.no_9.TabStop = false;
            this.no_9.Tag = "9";
            this.no_9.Text = "9";
            this.no_9.UseVisualStyleBackColor = false;
            this.no_9.Click += new System.EventHandler(this.num_Click);
            this.no_9.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_4
            // 
            this.no_4.BackColor = System.Drawing.Color.White;
            this.no_4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_4.Location = new System.Drawing.Point(3, 39);
            this.no_4.Name = "no_4";
            this.no_4.Size = new System.Drawing.Size(40, 30);
            this.no_4.TabIndex = 0;
            this.no_4.TabStop = false;
            this.no_4.Tag = "4";
            this.no_4.Text = "4";
            this.no_4.UseVisualStyleBackColor = false;
            this.no_4.Click += new System.EventHandler(this.num_Click);
            this.no_4.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_5
            // 
            this.no_5.BackColor = System.Drawing.Color.White;
            this.no_5.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_5.Location = new System.Drawing.Point(49, 39);
            this.no_5.Name = "no_5";
            this.no_5.Size = new System.Drawing.Size(40, 30);
            this.no_5.TabIndex = 0;
            this.no_5.TabStop = false;
            this.no_5.Tag = "5";
            this.no_5.Text = "5";
            this.no_5.UseVisualStyleBackColor = false;
            this.no_5.Click += new System.EventHandler(this.num_Click);
            this.no_5.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_6
            // 
            this.no_6.BackColor = System.Drawing.Color.White;
            this.no_6.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_6.Location = new System.Drawing.Point(95, 39);
            this.no_6.Name = "no_6";
            this.no_6.Size = new System.Drawing.Size(40, 30);
            this.no_6.TabIndex = 0;
            this.no_6.TabStop = false;
            this.no_6.Tag = "6";
            this.no_6.Text = "6";
            this.no_6.UseVisualStyleBackColor = false;
            this.no_6.Click += new System.EventHandler(this.num_Click);
            this.no_6.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_1
            // 
            this.no_1.BackColor = System.Drawing.Color.White;
            this.no_1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_1.Location = new System.Drawing.Point(3, 75);
            this.no_1.Name = "no_1";
            this.no_1.Size = new System.Drawing.Size(40, 30);
            this.no_1.TabIndex = 0;
            this.no_1.TabStop = false;
            this.no_1.Tag = "1";
            this.no_1.Text = "1";
            this.no_1.UseVisualStyleBackColor = false;
            this.no_1.Click += new System.EventHandler(this.num_Click);
            this.no_1.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_2
            // 
            this.no_2.BackColor = System.Drawing.Color.White;
            this.no_2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_2.Location = new System.Drawing.Point(49, 75);
            this.no_2.Name = "no_2";
            this.no_2.Size = new System.Drawing.Size(40, 30);
            this.no_2.TabIndex = 0;
            this.no_2.TabStop = false;
            this.no_2.Tag = "2";
            this.no_2.Text = "2";
            this.no_2.UseVisualStyleBackColor = false;
            this.no_2.Click += new System.EventHandler(this.num_Click);
            this.no_2.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_3
            // 
            this.no_3.BackColor = System.Drawing.Color.White;
            this.no_3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_3.Location = new System.Drawing.Point(95, 75);
            this.no_3.Name = "no_3";
            this.no_3.Size = new System.Drawing.Size(40, 30);
            this.no_3.TabIndex = 0;
            this.no_3.TabStop = false;
            this.no_3.Tag = "3";
            this.no_3.Text = "3";
            this.no_3.UseVisualStyleBackColor = false;
            this.no_3.Click += new System.EventHandler(this.num_Click);
            this.no_3.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.White;
            this.minus.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.minus.Location = new System.Drawing.Point(101, 209);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(40, 30);
            this.minus.TabIndex = 0;
            this.minus.TabStop = false;
            this.minus.Text = "+/-";
            this.minus.UseVisualStyleBackColor = false;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            this.minus.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // sqrt
            // 
            this.sqrt.BackColor = System.Drawing.Color.White;
            this.sqrt.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sqrt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.sqrt.Location = new System.Drawing.Point(234, 101);
            this.sqrt.Name = "sqrt";
            this.sqrt.Size = new System.Drawing.Size(40, 30);
            this.sqrt.TabIndex = 0;
            this.sqrt.TabStop = false;
            this.sqrt.Text = "sqrt";
            this.sqrt.UseVisualStyleBackColor = false;
            this.sqrt.Click += new System.EventHandler(this.sqrt_Click);
            this.sqrt.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // reciprocal
            // 
            this.reciprocal.BackColor = System.Drawing.Color.White;
            this.reciprocal.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reciprocal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.reciprocal.Location = new System.Drawing.Point(234, 173);
            this.reciprocal.Name = "reciprocal";
            this.reciprocal.Size = new System.Drawing.Size(40, 30);
            this.reciprocal.TabIndex = 0;
            this.reciprocal.TabStop = false;
            this.reciprocal.Text = "1/x";
            this.reciprocal.UseVisualStyleBackColor = false;
            this.reciprocal.Click += new System.EventHandler(this.reciprocal_Click);
            this.reciprocal.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // percent
            // 
            this.percent.BackColor = System.Drawing.Color.White;
            this.percent.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.percent.Location = new System.Drawing.Point(234, 137);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(40, 30);
            this.percent.TabIndex = 0;
            this.percent.TabStop = false;
            this.percent.Text = "%";
            this.percent.UseVisualStyleBackColor = false;
            this.percent.Click += new System.EventHandler(this.percent_Click);
            this.percent.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mc
            // 
            this.mc.BackColor = System.Drawing.Color.White;
            this.mc.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mc.ForeColor = System.Drawing.Color.Red;
            this.mc.Location = new System.Drawing.Point(6, 101);
            this.mc.Name = "mc";
            this.mc.Size = new System.Drawing.Size(40, 30);
            this.mc.TabIndex = 0;
            this.mc.TabStop = false;
            this.mc.Text = "MC";
            this.mc.UseVisualStyleBackColor = false;
            this.mc.Click += new System.EventHandler(this.mc_Click);
            this.mc.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mr
            // 
            this.mr.BackColor = System.Drawing.Color.White;
            this.mr.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mr.ForeColor = System.Drawing.Color.Red;
            this.mr.Location = new System.Drawing.Point(6, 137);
            this.mr.Name = "mr";
            this.mr.Size = new System.Drawing.Size(40, 30);
            this.mr.TabIndex = 0;
            this.mr.TabStop = false;
            this.mr.Text = "MR";
            this.mr.UseVisualStyleBackColor = false;
            this.mr.Click += new System.EventHandler(this.mr_Click);
            this.mr.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // ms
            // 
            this.ms.BackColor = System.Drawing.Color.White;
            this.ms.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ms.ForeColor = System.Drawing.Color.Red;
            this.ms.Location = new System.Drawing.Point(6, 173);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(40, 30);
            this.ms.TabIndex = 0;
            this.ms.TabStop = false;
            this.ms.Text = "MS";
            this.ms.UseVisualStyleBackColor = false;
            this.ms.Click += new System.EventHandler(this.ms_Click);
            this.ms.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mAdd
            // 
            this.mAdd.BackColor = System.Drawing.Color.White;
            this.mAdd.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mAdd.ForeColor = System.Drawing.Color.Red;
            this.mAdd.Location = new System.Drawing.Point(6, 209);
            this.mAdd.Name = "mAdd";
            this.mAdd.Size = new System.Drawing.Size(40, 30);
            this.mAdd.TabIndex = 0;
            this.mAdd.TabStop = false;
            this.mAdd.Text = "M+";
            this.mAdd.UseVisualStyleBackColor = false;
            this.mAdd.Click += new System.EventHandler(this.mAdd_Click);
            this.mAdd.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // label_m
            // 
            this.label_m.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label_m.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_m.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_m.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_m.Location = new System.Drawing.Point(6, 63);
            this.label_m.Name = "label_m";
            this.label_m.Size = new System.Drawing.Size(40, 32);
            this.label_m.TabIndex = 1;
            this.label_m.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCalculator
            // 
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(279, 244);
            this.Controls.Add(this.label_m);
            this.Controls.Add(this.mAdd);
            this.Controls.Add(this.ms);
            this.Controls.Add(this.mr);
            this.Controls.Add(this.cancle_all);
            this.Controls.Add(this.mc);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.reciprocal);
            this.Controls.Add(this.sqrt);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.text_display);
            this.Controls.Add(this.flowLayoutPanel_numbers);
            this.Controls.Add(this.backspace);
            this.Controls.Add(this.cancle_last);
            this.Controls.Add(this.operate_add);
            this.Controls.Add(this.operate_dec);
            this.Controls.Add(this.operate_ride);
            this.Controls.Add(this.operate_div);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.dot);
            this.Controls.Add(this.no_0);
            this.Controls.Add(this.menu);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "frmCalculator";
            this.Text = "C#������";
            
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.KeyPreview = true;
            /*
             * ����������֮��Ż�ʹ���̺�ʹ�� 
             * this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
             * ��仰���������壨���������пؼ�����KeyUp�¼���ί�и�keyUp()��������
             * 
             * ��仰����˼�ǰ�KeyUp�¼�����һ��ί�У�KeyEventHandler����ִ�У����ί�а�KeyUp�¼���������ʵ������һ��ָ��keyUp()����������
             * 
             * �����ί��ֻ�������ί�У������������ǿ����Լ�����ί����ʹ�á�
             * 
             * ��KeyPreview�������뽹���йصġ�
             * 
             */



            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.flowLayoutPanel_numbers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        #region widget_loseFocus
        private void text_display_GotFocus(object sender, EventArgs e)                      
        {   /*
             * �ı���ġ���ȡ���㡱�¼�����ʱִ�еķ�����ÿ�λ�ý���ʱ���ͻ�ִ�д˷�����ʹ֮����ʧȥ���㡣
             * 
             * ��ĳ�ؼ���Enable���Ա�ΪFalse��ʱ�����Ľ��㽫ת�Ƶ�TabIndex����ֵ������1�Ŀؼ��ϡ�
             * ��ʱ������ж���ؼ���TabIndex����ֵͬʱ������1���������ť���û�����ʱ��ᷢ�����ˡ���һ����
             * ���ڱ������У���label_m�ؼ���TabIndex��Ϊ1��������ȫ����Ϊ0��������еĿؼ��ڲ�����ʱ���㶼��ת�Ƶ�label_m�ϣ�
             * ��Ϊlabel_mû��Click��KeyUp�¼������Բ������
             * ������ʵ����ȫ���޽���Ĺ��ܡ�
             * 
             */
            text_display.Enabled = false;                                                   //��ʹ�ı��򲻿��ã���ʱ����ת�Ƶ�TabIndex���ı�������һ���ؼ���
            text_display.Enabled = true;                                                    //��ʹ�ı�����ã���ʱ���㲻�᷵�ء�
        }

        private void button_GotFocus(object sender, EventArgs e)                            //���еİ�ť�ؼ����ô˷���ʧȥ����
        {
            Button btnTmp = (Button)sender;
            btnTmp.Enabled = false;
            btnTmp.Enabled = true;
        }

        #endregion Ends_widget_loseFocus






        #region num_Click
        private void num_Click(object sender, EventArgs e)              //���ֵ�Click�¼���object��ΪButton����ʾ��ǰ����İ�ť
        {
            Button num = (Button)sender;                                // object ���������κ����͵ı��� ,���ڵ�object sender ��һ����ť,���Խ���ת��Ϊ��ť����

            if (operFlag)                                               //���ѵ���������
            {
                if (!dotFlag)                                           //���ѵ���������,��û���С����,�������������0�����ı����Ϊ"0."�������ı���Ϊ���������,�����������Ϊδ���״̬
                {
                    if (num.Text.Equals("0"))
                    {
                        text_display.Text = "0";
                        operFlag = false;
                        dotFlag = false;                                 //�˾���п��ޣ���Ϊ���ڵ�״̬�ǡ�0.�����ٵ��С�����ʱ�򣬾ͻᰴ���ı����ǡ�0.����������У��಻�����С����

                    }
                    else
                    {
                        text_display.Text = num.Text.ToString();        //�˾�����ı�����Ϊ����������Ϊ0�����������
                        operFlag = false;
                        dotFlag = false;

                    }
                }
                else                                                    //���������С���㶼�ѵ��,��ֱ���ں�����ӵ��������,�����������ȺŸ�Ϊδ���״̬
                {
                    text_display.Text = text_display.Text + num.Text.ToString();
                    operFlag = false;

                }
            }
            else                                                                                            //��δ��������
            {
                if (!dotFlag && (text_display.Text.Equals("0.") || text_display.Text.Equals("0")))          //��δ��������,��δ���С����,���ı�����Ϊ"0."��"0"
                {
                    text_display.Text = num.Text.ToString();

                }
                else 
                {
                    text_display.Text = text_display.Text + num.Text.ToString();                            //�������һ��ֱ����ӡ�

                }

            }
            enterFlag = false;                                          //��Enter��true֮������ִ����ʲô��������������ΪFalse


            label_m.Focus();                                            //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }

        #endregion Ends_num_Click

        #region dot_Click
        private void dot_Click(object sender, EventArgs e)
        {
            if (!dotFlag)                                                   //û����������
            {
                if (operFlag)                                               //�������������,�ͽ��ı���Ϊ"0.",����С������Ϊ�ѵ��
                {
                    text_display.Text = "0.";
                    dotFlag = true;
                }
                else if (text_display.Text.Equals("0."))                    //���û�е�������,�е�ǰ�ı���"0.",�㱣����״����С������Ϊ�ѵ��
                {
                    dotFlag = true;
                }
                else if (text_display.Text.Equals("0") || text_display.Text.Equals(""))  
                {
                    text_display.Text = "0.";
                    dotFlag = true;
                }
                else                                                        //�������ֱ����Ӳ���С������Ϊ�ѵ��
                {
                    text_display.Text = text_display.Text + ".";
                    dotFlag = true;
                }
            }
            else                                                            //����ѵ����ʲôҲ����
            {

            }
            enterFlag = false;


            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion



        #region operator_Click
        private void operator_Click(object sender, EventArgs e)         //�������Click�¼�
        {
            Button oper = (Button)sender;

            if (enterFlag)                                              //���Enter�Ѿ�������ٵ���������ʱ���ִ�м��������г�ʼ״̬ʱ�ĵ�һ�����ͷ�����ջ��������ʱ����վӦ��Ϊ"0"������ջΪ�գ�
            {
                numStack.Push(text_display.Text.ToString());
                operStack.Push(oper.Text.ToString());
                operFlag = true;
                dotFlag = false;                                        //���п��ޡ���Ϊ����Ⱥ�֮���ѽ����ΪFalse
            
            }

            if (operFlag)                                               //����������ʱ�������״̬Ϊ�ѵ������ȡ����ǰ����ջջ��Ԫ�أ��ѵ�ǰ������������ջ
            {
                operStack.Pop();
                operStack.Push(oper.Text);
            }
            else
            {
                if (operStack.Count == 1 || priorityCompare(oper.Text.ToString(), operStack.Peek().ToString()))
                {   
                    /*
                     * ������ջΪ��ʼ��״̬��ֻ��һ��"0"ʱ��
                     * ��ջ����������ȼ� > ջ�������ȼ�ʱ
                     * ��"0"�����ȼ�Ϊ��ͣ���-1����
                     * �ı�������������ջ�����������ջ��
                     * ����������Ϊ�ѵ��״̬,��С������Ϊδ���״̬
                    */
                    numStack.Push(text_display.Text);
                    operStack.Push(oper.Text);
                    operFlag = true;
                    dotFlag = false;
                }
                else                                                    //��ջ����������ȼ� <= ջ����������ȼ�ʱ
                {
                    object result = new object();
                    numStack.Push(text_display.Text);                   //�Ƚ�����������ջ      
               
                    string num1 = numStack.Peek().ToString();           //ȡ������ջ��Ԫ��
                    string num2;
                    string operTmp = operStack.Peek().ToString();       //ȡ�÷���ջ��Ԫ��

                    if (num1.Equals("0.") && operTmp.Equals("/"))       
                    {
                        /*
                         * �ж��Ƿ�Ϊ����Ϊ�����������ǣ�����ʾ������ʾ������ɾ������ջ�����㣬
                         * ���������Ⱥ���Ϊ���״̬����С������Ϊδ���״̬���ȴ��������룬
                         * ��ǰ���������������κδ���
                        */
                        text_display.Text = "��������Ϊ0��";
                        numStack.Pop();
                        operFlag = true;
                        dotFlag = false;
                    }
                    else
                    {
                        while (!priorityCompare(oper.Text.ToString(), operStack.Peek().ToString()))     //ÿ��ջ����������ȼ� <= ջ����������ȼ�ʱ,��ִ��while�������䣬ֱ��ջ����������ȼ� > ջ����������ȼ�ʱ�ż���ִ��while��������
                        {
                            num1 = numStack.Pop().ToString();
                            num2 = numStack.Pop().ToString();
                            operTmp = operStack.Pop().ToString();
                            OperateFactory operFac = new OperateFactory();                              //�����������󣬲��������CreateOperate()����������ȡ�õ����������ѡ������һ�ַ�����ʵ����operInterface�ӿ�
                            OperateInterface operInterface = operFac.CreateOperate(operTmp);
                            result = operInterface.Operate(num1, num2);                                 //��ʵ�����õĽӿڵ���ʵ�������ķ�����Operate()����������
                            numStack.Push(result.ToString());                                           //�����������ջ��������һ��ѭ��������                         
                            text_display.Text = numStack.Peek().ToString();                             //��һ�佫ÿ�������õ��м�����ʾ���ı����ϣ�ʹ��Peek()�����ı�վ��Ԫ�ء��ٴ��������ֵ�ʱ����Զ���գ���Ӱ����һ��������
                        }
                        operStack.Push(oper.Text);                                                      //��ʱջ����������ȼ� > ջ����������ȼ����ʽ���������������ջ
                        operFlag = true;                                                                //�������Ϊ�����С������Ϊδ���
                        dotFlag = false;
                    }
                }

            }
            enterFlag = false; 


            label_m.Focus();                                                                            //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_operator_Click
        
        #region equal_Click
        private void equal_Click(object sender, EventArgs e)
        {   
            numStack.Push(text_display.Text);                                                           //�Ƚ��ı�����������վ       
            object result = new object();
            string num1 = numStack.Peek().ToString();
            string num2;
            string operTmp = operStack.Peek().ToString();


            if(num1.Equals("0.") && operTmp.Equals("/"))
            {
                text_display.Text = "��������Ϊ0��";
                operFlag = true;
                dotFlag = false;

            }           
             
            else
            {             
                while ( operStack.Count > 1)                                                            //������ջ��Ԫ�� > 1 ʱ��ִ�����㲢�����������ջ
                {
                    num1 = numStack.Pop().ToString();
                    num2 = numStack.Pop().ToString();
                    operTmp = operStack.Pop().ToString();
                    OperateFactory operFac = new OperateFactory();
                    OperateInterface operInterface = operFac.CreateOperate(operTmp);
                    result = operInterface.Operate( num1, num2);
                    numStack.Push(result.ToString());
                }
                text_display.Text = numStack.Pop().ToString();                                          //��ʾ���
                numStack.Clear();                                                                       //�������ջ
                operStack.Clear();                                                                  
                operStack.Push("0");
                operFlag = true;                                                                        //ֻ��true���ڰ��Ⱥ�������֮���������ֲŻᰴ�������Ϊtrue���������ı������������������������һ�εĽ��֮��������������
                dotFlag = false;                                                                        //С������Ϊδ���

            }
            enterFlag = true;
            
            
            label_m.Focus();                                                                            //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion



        #region c_Click
        private void c_Click(object sender, EventArgs e)                    //�����ж���Ϊ��ʼ��״̬
        {
            text_display.Text = "0.";
            numStack.Clear();
            operStack.Clear();
            operStack.Push("0");
            operFlag = false;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion

        #region ce_Click
        private void ce_Click(object sender, EventArgs e)                   //�����û��������Ĵ������֣����ȴ�����������
        {
            if (operFlag)
            {
                text_display.Text = "������ִ�У�����ȡ�������������㡣";
            }
            else
            {
                text_display.Text = "0.";
                operFlag = true;
                dotFlag = false;
                enterFlag = false;
            }
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }        
        #endregion

        #region backspace_Click
        private void backspace_Click(object sender, EventArgs e)
        {
            if (operFlag) 
            {
            }
            else if (text_display.Text.Length > 0 )
            {
                text_display.Text = text_display.Text.Substring(0, text_display.Text.Length - 1);

                if (text_display.Text.Equals("0") || text_display.Text.Equals("0.") || text_display.Text.Equals(""))
                {
                    text_display.Text = "0.";                               //��ʱ���൱��ִ��һ����CE�Ĺ���
                    operFlag = true;
                    dotFlag = false;
                }

            }

            int dotNum = text_display.Text.IndexOf(".");                  //�������ͱ��������㵱ǰ�ı���"."�ĸ���,��Ϊ-1��Ϊ������
            if (dotNum == -1 && !text_display.Text.Equals("0."))
            {
                dotFlag = false;                                          //��������С�����ˣ��ѱ�ɾ���������dotFlag��Ϊfalse���ȴ��û����롣
            }
            else                                                          //������С���㣬����Ϊtrue��
            {
                dotFlag = true;
            }

            enterFlag = false;
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion



        #region Priority

        private int getPriority(string oper)                                                        //ȡ�����ȼ��ķ���
        {   
            if(oper.Equals("+"))                                                                    // * /���ȼ�Ϊ1,+-Ϊ0 ,����ջ��Ĭ�ϵ�"0"�����ȼ���-1
            {
                return 0;
            }
            else if (oper.Equals("-"))
        	{
                return 0;
        	}
            else if(oper.Equals("*"))
        	{
                return 1;
        	}
            else if(oper.Equals("/"))
        	{
                return 1;
        	}
            else if (oper.Equals("0"))
            {
                return -1;
            }
            return 0;
        }

        private bool priorityCompare(string oper1, string oper2)                                    //�Ƚ����ȼ��ķ���
        {
            int pri1 = getPriority(oper1);                                                          //ȡ��ջ����������ȼ�
            int pri2 = getPriority(oper2);                                                          //ȡ��ջ����������ȼ�
  
            if(pri1 > pri2)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
        #endregion



        #region minus_Click
        private void minus_Click(object sender, EventArgs e)
        {
            int minusNum = text_display.Text.IndexOf("-");                  //�������ͱ��������㵱ǰ�ı���-�ĸ���,��Ϊ-1��Ϊ������
            if (minusNum == -1 && !text_display.Text.Equals("0."))
            {
                text_display.Text = "-" + text_display.Text;
            }
            else 
            {
                text_display.Text = text_display.Text.Replace("-","");      //��ĳ�ַ������ҳ���һ���������ַ������õڶ����������ַ��滻
            }
            /*
             * �˴��Ͳ���Ҫ�����κ�Flag��״̬��
             * ��Ϊֻ�ǵ�ͬ�ڸı�һ���ı��������ֵ��������൱������һ������
             * �������ֵ��֮����Ѿ���Ը�Flag������ȷ�Ĳ�����
             */

            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�
        }
        #endregion

        #region recip_Click
        private void reciprocal_Click(object sender, EventArgs e)
        {
            object result = new object();
            Button recip = (Button)sender;
            string Num = text_display.Text.ToString();

            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");                     //һ��������ʽ����֤�����Ϊ���֣�

            if (reg.IsMatch(text_display.Text.ToString()))                  //��ƥ�����������ʽ
            {
                if ((text_display.Text.Equals("0.") || text_display.Text.Equals("0")))
                {
                    text_display.Text = "��������Ϊ�㡣";
                    operFlag = true;
                    dotFlag = false;
                }
                else
                {
                    OperateFactory operFac = new OperateFactory();
                    OperateInterface operInterface = operFac.CreateOperate(recip.Name.ToString());
                    result = operInterface.Operate(text_display.Text.ToString(), "1");
                    text_display.Text = result.ToString();
                    operFlag = true;
                    dotFlag = false;
                }
            }

            else 
            {
                text_display.Text = "���������֡�";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;



            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_recip_Click

        #region sqrt_Click
        private void sqrt_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");

            if (reg.IsMatch(text_display.Text.ToString()))
            {
                if (double.Parse(text_display.Text) >= 0)
                {
                    text_display.Text = Math.Sqrt(double.Parse(text_display.Text.ToString())).ToString();
                    operFlag = true;
                    dotFlag = false;
                }
                else
                {
                    text_display.Text = "�������ܿ��������������롣";
                    operFlag = true;
                    dotFlag = false;
                }
            }
            else
            {
                text_display.Text = "���������֡�";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;


            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_sqrt_Click

        #region percent_Click
        private void percent_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString())) 
            {
                double Num = double.Parse(text_display.Text.ToString()) / 100;
                text_display.Text = Num.ToString();
                operFlag = true;
                dotFlag = false;
            }
            else
            {
                text_display.Text = "���������֡�";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;


            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_percent_Click

        #region m

        #region mADD_Click
        private void mAdd_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString()))
            {
                if (mStack.Count == 0)
                {
                    mStack.Push(text_display.Text.ToString());
                    label_m.Text = "M";
                }
                else if (mStack.Count > 0)
                {
                    decimal num1 = decimal.Parse(text_display.Text.ToString());
                    decimal num2 = decimal.Parse(mStack.Pop().ToString());
                    decimal numTmp = num1 + num2;
                    mStack.Push(numTmp.ToString());
                    label_m.Text = "M";
                }
            }
            else
            {
                text_display.Text = "���������֡�";
            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_mAdd_Click

        #region ms_Click
        private void ms_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString()))
            {
                mStack.Clear();
                mStack.Push(text_display.Text.ToString());
                label_m.Text = "M";
            }
            else
            {
                text_display.Text = "���������֡�";
            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_ms_Click

        #region mr_Click
        private void mr_Click(object sender, EventArgs e)
        {
            if (mStack.Count > 0)                                           //���Ĵ���ջ��Ϊ��ʱ
            {
                text_display.Text = mStack.Pop().ToString();
                label_m.Text = "";
            }
            else
            {
                text_display.Text = "�Ĵ���Ϊ��";
                label_m.Text = "";

            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;

            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_mr_Click
        
        #region mc_Click
        private void mc_Click(object sender, EventArgs e)
        {
            mStack.Clear();
            label_m.Text = "";
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //���̰���֮�󽹵�������ĸ���_GotFocus()�������ƣ������֮��Ľ��������������ƣ�ͬ��ʹ����ת�Ƶ�label_m�ϡ�

        }
        #endregion Ends_mc_Click

        #endregion Ends_m


        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        #region keyUp
        private void keyUp(object sender, KeyEventArgs e)   
        {   /* 
             * ����KeyUp�¼���Ӧ�ķ������ڴ���������е�KeyUp��ѡ�д�keyUp���������ʵ���ڰ�ţ̌��ʱ��KeyUp��ִ�д˷���
             */

            if (e.KeyCode == Keys.Escape)           //����KeyEventArg�Ķ��������е��෽��
            {
                c_Click(cancle_all,e);
        
            }
            else if (e.KeyCode == Keys.Back)
            {
                backspace_Click(backspace,e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                equal_Click(equal,e);
            }

            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                operator_Click(operate_add, e);
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                operator_Click(operate_dec, e);
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                operator_Click(operate_ride, e);
            }
            else if (e.KeyCode == Keys.Divide)
            {
                operator_Click(operate_div, e);
            }
            else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {
                num_Click(no_0, e);

            }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {
                /* �������ĳ���ؼ��������䱾���KeyUp�¼�֮��
                 * �������keyUp()���������ж����ĸ�����
                 * ����Ǵ���̻�����С���̵�1ʱ�������num_Click()������
                 * ������no_1��e��
                 * �������no_1ָ���ǰ�ťno_1��e��KeyUp�¼�
                 * no_1�ǰ�ť��������ʽ��ȷ����e��KeyUp�¼���Ҳ���¼���һ�֡�KeyEventHandler��ȻҲ��EventHandler��һ���֡�
                 * ���Ե�����֮num_Click()��һ�а���no_1��ť�¼��Ĳ���ִ��
                 * ����no_1��ť����һ��
                 * this.no_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_Click);    
                 * ���Բ�д
                 */
                num_Click(no_1, e);

            }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {
                num_Click(no_2, e);

            }
            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {
                num_Click(no_3, e);

            }
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {
                num_Click(no_4, e);

            }
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {
                num_Click(no_5, e);

            }
            else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {
                num_Click(no_6, e);

            }
            else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {
                num_Click(no_7, e);

            }
            else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {
                num_Click(no_8, e);

            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                num_Click(no_9, e);

            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.OemPeriod || e.KeyValue == 110 || e.KeyValue == 46)              //С�����ϵ�С�����KeyValue��110�����������46
            {
                dot_Click(dot,e);
            }
        }
        #endregion Ends_keyUp


        #region Copy_Paste
        private void ctrl_c_Click(object sender, EventArgs e)
        {
            
            Clipboard.SetDataObject(text_display.Text);
            enterFlag = false;
        }

        private void ctrl_v_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            IDataObject iData = Clipboard.GetDataObject();
            /*
             * ����һ��IDataObject������Ӽ�����ȡ�ص�����.
             * ȡ�ؼ���������.Determines(ȷ��)�Ƿ������ʹ�õ����ݸ�ʽ.
             */
            if (iData.GetDataPresent(DataFormats.Text)||iData.GetDataPresent(DataFormats.OemText))
            {
                text_display.Text = (String)iData.GetData(DataFormats.Text); 
                if (!reg.IsMatch(text_display.Text.ToString()))
                {
                    text_display.Text = "����Ĳ�������";
                    //MessageBox.Show("����Ĳ�������", "������");
                    operFlag = true;
                    dotFlag = false;

                }
                else
                {

                }
                enterFlag = false;
            }
        }
        #endregion


    }
    
}


