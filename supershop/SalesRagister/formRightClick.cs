using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


public class formRightClick : Form
{
	public string strClick = "";
	LabelItem[] lbtnArray = new LabelItem[0];
	public bool bolPlaceUnderMouse = true;
	public string strParent = "";
	static formRightClick[] frmRightStack = new formRightClick[0];
	string strSubMenuArrow = "►";

	formRightClick frmMyOffspring;
	public bool bolMouseHasEntered = false;
	public Form frmMain;
	public bool bolPasteToClipBoard = false;
	public formRightClick(params string[] strButtons)
	{
		FormBorderStyle = FormBorderStyle.None;
		lbtnArray = new LabelItem[strButtons.Length];
		int intWidthButtons = 0;
		int intHeight = 14;
		ShowInTaskbar = false;
		BackColor = Color.White;
		for (int intButtonCounter = 0; intButtonCounter < strButtons.Length; intButtonCounter++)
		{
			LabelItem lbtn = new LabelItem();
			lbtn.BackgroundDull = BackColor;
			lbtn.BackgroundHighlight = Color.Gray;
			if (strButtons[intButtonCounter].Contains("(") && strButtons[intButtonCounter].Contains(")"))
			{ // sub-menu
				int intSubMenu_Start = strButtons[intButtonCounter].IndexOf("(");
				int intSubMenu_End = strButtons[intButtonCounter].LastIndexOf(")");
				string strSubMenu = strButtons[intButtonCounter].Substring(intSubMenu_Start, intSubMenu_End - intSubMenu_Start + 1);
				strButtons[intButtonCounter] = strButtons[intButtonCounter].Replace(strSubMenu, "") + strSubMenuArrow;
				strSubMenu = strSubMenu.Substring(1, strSubMenu.Length - 2);
				lbtn.strSubMenu = strSubMenu;
				lbtn.MouseEnter += new EventHandler(lbtn_MouseEnter);
			}
			lbtn.Text = strButtons[intButtonCounter];
			lbtn.ClickTogglesFlag = false;
			lbtn.Left = 5;
			lbtn.Top = 5 + intHeight * intButtonCounter;
			lbtn.AutoSize = true;
			if (lbtn.Width > intWidthButtons)
				intWidthButtons = lbtn.Width;
			Controls.Add(lbtn);
			lbtn.Height = 12;
			lbtn.Click += new EventHandler(lbtn_Click);
			lbtn.MouseLeave += new EventHandler(lbtn_MouseLeave);

			lbtnArray[intButtonCounter] = lbtn;
		}

		for (int intButtonCounter = 0; intButtonCounter < strButtons.Length; intButtonCounter++)
		{
			lbtnArray[intButtonCounter].AutoSize = false;
			lbtnArray[intButtonCounter].Width = intWidthButtons;
			lbtnArray[intButtonCounter].Height = intHeight;
		}

		Array.Resize<formRightClick>(ref frmRightStack, frmRightStack.Length + 1);
		frmRightStack[frmRightStack.Length - 1] = this;

		Height = lbtnArray[lbtnArray.Length - 1].Top + lbtnArray[lbtnArray.Length - 1].Height + 5;
		Width = intWidthButtons - 50;
		VisibleChanged += new EventHandler(formRightClick_VisibleChanged);
		Disposed += new EventHandler(formRightClick_Disposed);
		MouseMove += new MouseEventHandler(formRightClick_MouseMove);
		MouseLeave += new EventHandler(formRightClick_MouseLeave);
		TopMost = true;
	}

	void formRightClick_MouseLeave(object sender, EventArgs e)
	{
		if (!bolMouseHasEntered)
			return;
		bool bolDispose = true;
		int intMouseOver = -1;

		for (int intStackCounter = frmRightStack.Length - 1; intStackCounter >= 0; intStackCounter--)
		{
			if (MousePosition.X >= frmRightStack[intStackCounter].Left
				&& MousePosition.X <= frmRightStack[intStackCounter].Right
				&& MousePosition.Y >= frmRightStack[intStackCounter].Top
				&& MousePosition.Y <= frmRightStack[intStackCounter].Bottom)
			{
				bolDispose = false;
				intMouseOver = intStackCounter;
				break;
			}
		}

		for (int intKillCounter = frmRightStack.Length - 1; intKillCounter > intMouseOver; intKillCounter--)
		{
			if (frmRightStack[intKillCounter].bolMouseHasEntered)
			{
				frmRightStack[intKillCounter].Hide();
				frmRightStack[intKillCounter].Dispose();
			}
		}

		if (bolDispose)
		{
			Dispose();
		}
		else
			BringToFront();
	}

	void formRightClick_Disposed(object sender, EventArgs e)
	{
		for (int intStackCounter = frmRightStack.Length - 1; intStackCounter >= 0; intStackCounter--)
		{
			if (frmRightStack[intStackCounter] == this)
			{
				frmRightStack[intStackCounter] = frmRightStack[frmRightStack.Length - 1];
				Array.Resize<formRightClick>(ref frmRightStack, frmRightStack.Length - 1);
				frmMain.BringToFront();
				return;
			}
		}
	}

	void lbtn_MouseEnter(object sender, EventArgs e)
	{
		LabelItem lbtn = (LabelItem)sender;
		if (lbtn.frmSubMenu != null)
			return;
		if (frmMyOffspring != null && frmMyOffspring != lbtn.frmSubMenu)
		{
			frmMyOffspring.Dispose();
		}
		lbtn.set();
		// sub-menued item
		string[] strArray = new string[0];
		if (lbtn.strSubMenu.Length == 0)
			return;

		string strLbtnSubMenu = lbtn.strSubMenu;

		while (strLbtnSubMenu.Length > 0)
		{
			string strNextItem = getNextSubMenu(strLbtnSubMenu);
			strLbtnSubMenu = strLbtnSubMenu.Length > strNextItem.Length ? strLbtnSubMenu.Substring(strNextItem.Length + 1) : "";
			Array.Resize<string>(ref strArray, strArray.Length + 1);
			strArray[strArray.Length - 1] = strNextItem;
		}

		frmMyOffspring
			= lbtn.frmSubMenu
			= new formRightClick(strArray);
		frmMyOffspring.bolPasteToClipBoard = bolPasteToClipBoard;
		lbtn.frmSubMenu.bolPlaceUnderMouse = false;

		lbtn.frmSubMenu.Owner = this;
		lbtn.frmSubMenu.frmMain = frmMain;
		lbtn.frmSubMenu.strParent = strParent + lbtn.Text.Replace(strSubMenuArrow, "").Trim() + "+";
		lbtn.frmSubMenu.Show();

		strClick = strParent + frmMyOffspring.strClick;
		if (frmMyOffspring.strClick.Length > 0)
			Dispose();
	}

	string getNextSubMenu(string strSubMenu)
	{
		int intCountOpenBrackets = 0;

		for (int intCharCounter = 0; intCharCounter < strSubMenu.Length; intCharCounter++)
		{
			char chrThis = strSubMenu[intCharCounter];
			if (chrThis == ')')
				intCountOpenBrackets --;
			if (chrThis == '(')
				intCountOpenBrackets++;
			if (chrThis == '+' && intCountOpenBrackets == 0)
				return strSubMenu.Substring(0, intCharCounter);
		}
		return strSubMenu;
	}

	void lbtn_MouseLeave(object sender, EventArgs e)
	{
		LabelItem lbtn = (LabelItem)sender;
		if (MousePosition.Y <= Top + lbtn.Top || MousePosition.Y >= Top + lbtn.Bottom)
		{ //  kill submenu
			if (lbtn.frmSubMenu != null)
			{
				lbtn.frmSubMenu.Hide();
				lbtn.frmSubMenu.Dispose();
				lbtn.frmSubMenu = null;
			}
			lbtn.reset();
		}
	}

	void formRightClick_MouseMove(object sender, MouseEventArgs e)
	{
		bolMouseHasEntered = true;
	}




	void lbtn_Click(object sender, EventArgs e)
	{
		LabelButton lbtn = (LabelButton)sender;
		if (lbtn.Tag == null)
		{
			strClick = strParent + lbtn.Text;

			for (int intStackCounter = 0; intStackCounter < frmRightStack.Length; intStackCounter++)
			{
				if (frmRightStack[intStackCounter] != this)
				{
					frmRightStack[intStackCounter].strClick = strClick;
					frmRightStack[intStackCounter].Hide();
					frmRightStack[intStackCounter].Dispose();
				}
			}
			if (strClick.EndsWith(strSubMenuArrow))
				strClick = strClick.Substring(0, strClick.Length - 1);
			frmRightStack = new formRightClick[0];
			if (bolPasteToClipBoard)
				Clipboard.SetText(strClick.ToUpper());
			Hide();
			Dispose();
		}
	}

	void formRightClick_VisibleChanged(object sender, EventArgs e)
	{
		if (bolPlaceUnderMouse)
		{
			Left = MousePosition.X - 10;
		}
		else
		{
			formRightClick frmParent = (formRightClick)((formRightClick)sender).Owner;
			if (frmParent.Left + frmParent.Width + Width < Screen.PrimaryScreen.WorkingArea.Width)
			{ // place on right of parent form - mouse height
				Left = frmParent.Left + frmParent.Width - 3;
			}
			else
			{ // place on left of parent form - mouse height
				Left = frmParent.Left - Width + 3;
			}
		}
		Top = MousePosition.Y - 10;
		if (Top + Height > Screen.PrimaryScreen.WorkingArea.Height)
			Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
	}

	class LabelItem : LabelButton
	{
		public string strSubMenu;
		public formRightClick frmSubMenu;
	}
}


	
	public class LabelButton : Label
	{
		Color clrBackground;
		Color clrBackgroundDull = Color.FromArgb(255, 100, 100, 100);
		Color clrBackgroundHighlight = Color.Yellow;

		public Color BackgroundDull
		{
			get { return clrBackgroundDull; }
			set
			{
				clrBackgroundDull = value;
			}
		}

		public Color BackgroundHighlight
		{
			get { return clrBackgroundHighlight; }
			set
			{
				clrBackgroundHighlight = value;
			}
		}

		bool flag;
		public bool Flag
		{
			get { return flag; }
			set
			{
				flag = value;
				LabelButton_MouseLeave((object)this, new EventArgs());
			}
		}

		bool highlightWhenFlagSet = true;
		public bool HighLightWhenFlagSet
		{
			get { return highlightWhenFlagSet; }
			set { highlightWhenFlagSet = value; }
		}

		bool _bolClickTogglesFlag = true;
		public bool ClickTogglesFlag
		{
			get { return _bolClickTogglesFlag; }
			set { _bolClickTogglesFlag = value; }
		}
		
		public LabelButton()
		{
			MouseEnter += new EventHandler(LabelButton_MouseEnter);
			MouseLeave += new EventHandler(LabelButton_MouseLeave);
			MouseClick += new MouseEventHandler(LabelButton_MouseClick);
			AutoSize = true;
			VisibleChanged += new EventHandler(LabelButton_VisibleChanged);
		}

		void LabelButton_VisibleChanged(object sender, EventArgs e)
		{
			reset();
		}

		public void toggle()
		{
			LabelButton_MouseClick((object)this, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0));
			LabelButton_MouseLeave((object)this, new EventArgs());
		}

		public void set()
		{
			flag = true;
			setBackGroundColor();
			LabelButton_MouseLeave((object)this, new EventArgs());
		}

		public void reset()
		{
			flag = false;
			setBackGroundColor();
			LabelButton_MouseLeave((object)this, new EventArgs());
		}

		void LabelButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (ClickTogglesFlag)
				flag = !flag;
			setBackGroundColor();
		}

		void setBackGroundColor()
		{
			clrBackground = (flag && highlightWhenFlagSet ? clrBackgroundHighlight  : clrBackgroundDull);
		}

		void LabelButton_MouseLeave(object sender, EventArgs e)
		{
			BackColor = clrBackground;
			ForeColor = Color.FromArgb(255,
									   (BackColor.R + 125) % 256,
									   (BackColor.G + 125) % 256,
									   (BackColor.B + 125) % 256);
		}

		void LabelButton_MouseEnter(object sender, EventArgs e)
		{
			ForeColor = clrBackground;
			BackColor = Color.FromArgb(255,
									   (ForeColor.R + 125) % 256,
									   (ForeColor.G + 125) % 256,
									   (ForeColor.B + 125) % 256);
		}
	}

	