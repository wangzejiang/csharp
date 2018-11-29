#include "MyFunc.h"
#include <windows.h>
#include <commctrl.h>
#include <stdio.h>
#include <iostream>
#include <string>

MyFunc::MyFunc() {

}
MyFunc::~MyFunc() {

}

HWND s1()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TEdit = FindWindowEx(TPanel, 0, TEXT("TEdit"), NULL);
	TEdit = FindWindowEx(TPanel, TEdit, TEXT("TEdit"), NULL);
	if(TEdit==0)MessageBox(0, LPCTSTR("s1"), LPCTSTR("myMbox"), MB_OK);
	return TEdit;
}

HWND s11()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TComboBox = FindWindowEx(TPanel, 0, TEXT("TComboBox"), NULL);
	TComboBox = FindWindowEx(TPanel, TComboBox, TEXT("TComboBox"), NULL);
	HWND Edit = FindWindowEx(TComboBox, 0, TEXT("Edit"), NULL);
	if (Edit == 0)MessageBox(0, LPCTSTR("s11"), LPCTSTR("myMbox"), MB_OK);
	return Edit;
}

HWND s12()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TComboBox = FindWindowEx(TPanel, 0, TEXT("TComboBox"), NULL);
	HWND Edit = FindWindowEx(TComboBox, 0, TEXT("Edit"), NULL);
	if (Edit == 0)MessageBox(0, LPCTSTR("s12"), LPCTSTR("myMbox"), MB_OK);
	return Edit;
}

HWND s13()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TEdit = FindWindowEx(TPanel, 0, TEXT("TEdit"), NULL);
	if (TEdit == 0)MessageBox(0, LPCTSTR("s13"), LPCTSTR("myMbox"), MB_OK);
	return TEdit;
}

HWND s2()
{
	HWND mhwnd = FindWindow(NULL, TEXT("选择订单"));
	HWND TPageControl = FindWindowEx(mhwnd, 0, TEXT("TPageControl"), NULL);
	HWND TTabSheet = FindWindowEx(TPageControl, 0, TEXT("TTabSheet"), TEXT("销售单"));
	HWND TPanel = FindWindowEx(TTabSheet, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TTabSheet, TPanel, TEXT("TPanel"), NULL);
	HWND TEdit = FindWindowEx(TPanel, 0, TEXT("TEdit"), NULL);
	if (TEdit == 0)MessageBox(0, LPCTSTR("s2"), LPCTSTR("myMbox"), MB_OK);
	return TEdit;
}


HWND s3()
{
	HWND mhwnd = FindWindow(NULL, TEXT("选择订单"));
	HWND TPageControl = FindWindowEx(mhwnd, 0, TEXT("TPageControl"), NULL);
	HWND TTabSheet = FindWindowEx(TPageControl, 0, TEXT("TTabSheet"), TEXT("销售单"));
	HWND TListView = FindWindowEx(TTabSheet, 0, TEXT("TListView"), NULL);
	if (TListView == 0)MessageBox(0, LPCTSTR("s3"), LPCTSTR("myMbox"), MB_OK);
	return TListView;
}


HWND s4()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TBitBtn = FindWindowEx(TPanel, 0, TEXT("TBitBtn"), TEXT("取消[&C]"));
	if (TBitBtn == 0)MessageBox(0, LPCTSTR("s4"), LPCTSTR("myMbox"), MB_OK);
	return TBitBtn;
}

HWND s5()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TBitBtn = FindWindowEx(TPanel, 0, TEXT("TBitBtn"), TEXT("保存[&S]"));
	if (TBitBtn == 0)MessageBox(0, LPCTSTR("s5"), LPCTSTR("myMbox"), MB_OK);
	return TBitBtn;
}

HWND s8()
{
	HWND mhwnd = FindWindow(NULL, TEXT("网店管家云端版 - [退换登记]"));
	HWND MDIClient = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	HWND TForm_SellBack_New = FindWindowEx(MDIClient, 0, TEXT("TForm_SellBack_New"), NULL);
	HWND TPanel = FindWindowEx(TForm_SellBack_New, 0, TEXT("TPanel"), NULL);
	TPanel = FindWindowEx(TForm_SellBack_New, TPanel, TEXT("TPanel"), NULL);
	HWND TBitBtn = FindWindowEx(TPanel, 0, TEXT("TBitBtn"), TEXT("新建[&N]"));
	if (TBitBtn == 0)MessageBox(0, LPCTSTR("s8"), LPCTSTR("myMbox"), MB_OK);
	return TBitBtn;
}

HWND s6()
{
	HWND mhwnd = FindWindow(NULL, TEXT("请确认"));
	if (mhwnd == 0)MessageBox(0, LPCTSTR("s6"), LPCTSTR("myMbox"), MB_OK);
	return mhwnd;
}

HWND s7()
{
	HWND mhwnd = FindWindow(NULL, TEXT("请确认"));
	HWND Button = FindWindowEx(mhwnd, 0, TEXT("Button"), TEXT("否(&N)"));
	if (Button == 0)MessageBox(0, LPCTSTR("s7"), LPCTSTR("myMbox"), MB_OK);
	return Button;
}

void cl() {
	BOOL ret;
	RECT rect;
	HWND TBitBtn1 = s4();
	if (TBitBtn1 == 0) return;
	ret = GetWindowRect(TBitBtn1, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 20, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
}

void ok() {
	BOOL ret;
	RECT rect;
	HWND TBitBtn2 = s5(); 
	if (TBitBtn2 == 0) return;
	ret = GetWindowRect(TBitBtn2, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 20, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
}

void add() {
	BOOL ret;
	RECT rect;
	HWND TBitBtn2 = s8();
	while (TBitBtn2 == 0) {
		TBitBtn2 = s8();
	}
	ret = GetWindowRect(TBitBtn2, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 20, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
}

char * MyFunc::exec(char * ch1, char * ch2, char * ch3, char * ch4)
{
	int s = 1000;
	BOOL ret;
	RECT rect;
	HWND TEdit4 = s2();
	HWND TEdit = s1();
	if (TEdit == 0) return "错误0";
	if (TEdit4 == 0) {
		SetForegroundWindow(TEdit);
		ret = GetWindowRect(TEdit, &rect);
		if (!ret) return "错误1";
		SetCursorPos(rect.right + 20, rect.top + 10);
		mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		Sleep(s);
		TEdit4 = s2();
	}
	if (TEdit4 == 0) return "错误0";
	SetForegroundWindow(TEdit4);
	SendMessageA(TEdit4, WM_SETTEXT, 0, (LPARAM)ch1);
	Sleep(s);
	SetForegroundWindow(TEdit4);
	keybd_event(13, 0, 0, 0);
	Sleep(s);
	HWND TListView = s3();
	if (TListView == 0) return "错误0";
	// 总行数:进程的数量
	int rows = (int)::SendMessage(TListView, LVM_GETITEMCOUNT, 0, 0);
	if (rows == 1) {
		ret = GetWindowRect(TListView, &rect);
		if (!ret) return "错误2";
		SetForegroundWindow(TEdit4);
		SetCursorPos(rect.left + 100, rect.top + 25 + (17 * 0));
		mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		Sleep(s);
		if (s6() != 0) { // 检测已经登记过
			HWND Button = s7();
			ret = GetWindowRect(Button, &rect);
			if (!ret) return "错误3";
			SetForegroundWindow(Button);
			SetCursorPos(rect.left + 10, rect.top + 10);
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			cl();
			return "登记过"; // 有问题
		}
	}
	else {
		//cl();
		return "多个订单"; // 有问题
	}
	SetForegroundWindow(TEdit);
	HWND TEdit1 = s11();
	if (TEdit1 == 0) return "错误0";
	SendMessageA(TEdit1, WM_SETTEXT, 0, (LPARAM)ch2);
	HWND TEdit2 = s12();
	if (TEdit2 == 0) return "错误0";
	SendMessageA(TEdit2, WM_SETTEXT, 0, (LPARAM)ch3);
	HWND TEdit3 = s13();
	if (TEdit3 == 0) return "错误0";
	SendMessageA(TEdit3, WM_SETTEXT, 0, (LPARAM)ch4);
	Sleep(s);
	ok();
	Sleep(s * 3);
	add();
	return "好了";
}

//String^ MyFunc::exec2(String^ str1, String^ str2, String^ str3, String^ str4)
//{
//	char* ch4 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str1);
//	char* ch1 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str2);
//	char* ch2 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str3);
//	char* ch3 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str4);
//}



