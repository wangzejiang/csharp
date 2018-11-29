// DLLTest.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "DLLTest.h"
#include <windows.h>
#include <commctrl.h>
#include <stdio.h>
#include <iostream>
#include <string>

#define KeyMaxLen 128000
static char buf[KeyMaxLen];

DLLTEST_API int Test1()
{
	return 123;
}

DLLTEST_API int Test2(int a, int b)
{
	return a + b;
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
	if (TEdit == 0)MessageBox(0, LPCTSTR("s1"), LPCTSTR("myMbox"), MB_OK);
	return TEdit;
}

DLLTEST_API char* Test3(char* a, char* b)
{
	s1();
	char *c;
	strcpy(buf, a);
	strcat(buf, b);
	c = (char*)buf;
	return c;
}
