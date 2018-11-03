#include "stdafx.h"

MyApp::MyApp()
{
}


MyApp::~MyApp()
{
}

DWORD time = 1000;

std::string WChar2Ansi(LPCWSTR pwszSrc)
{
	int nLen = WideCharToMultiByte(CP_ACP, 0, pwszSrc, -1, NULL, 0, NULL, NULL);
	if (nLen <= 0) return std::string("");
	char* pszDst = new char[nLen];
	if (NULL == pszDst) return std::string("");
	WideCharToMultiByte(CP_ACP, 0, pwszSrc, -1, pszDst, nLen, NULL, NULL);
	pszDst[nLen - 1] = 0;
	std::string strTemp(pszDst);
	delete[] pszDst;
	return strTemp;
}


std::string getText(HWND hListview, HANDLE hProcess, LVITEM *pointer, int row, int col) {
	char* buff = new char[1024];
	memset(buff, 0, 1024);
	LVITEM vItem;
	vItem.mask = LVIF_TEXT;
	vItem.iItem = row;
	vItem.iSubItem = col;
	vItem.cchTextMax = 1024;
	LPWSTR pItem = (LPWSTR)VirtualAllocEx(hProcess, NULL, 1024, MEM_COMMIT, PAGE_READWRITE);
	vItem.pszText = pItem;
	WriteProcessMemory(hProcess, pointer, &vItem, sizeof(LVITEM), NULL);
	::SendMessage(hListview, LVM_GETITEMW, (WPARAM)row, (LPARAM)pointer);
	ReadProcessMemory(hProcess, pItem, buff, 1024, NULL);
	VirtualFreeEx(hProcess, pItem, 0, MEM_RELEASE);
	std::string rValue = WChar2Ansi((LPCWSTR)buff);
	return rValue;
}


struct Product {
	std::string number;  //��Ʒ���
	std::string text;    //Ʒ��
	std::string addtext;
	int size;   // ����
	int row;
};


void getNumber(HWND hListview, Product *ps, int *num)
{
	HANDLE    hProcess;
	LVITEM    *pointer;
	HWND    headerhwnd;
	int rows, cols;  //listview�ؼ��е�������
	DWORD ProcessID = NULL;
	DWORD ThreadID = NULL;
	//listview����ͷ���
	headerhwnd = FindWindowEx(hListview, 0, TEXT("SysHeader32"), NULL);
	//������:���̵�����
	rows = ::SendMessage(hListview, LVM_GETITEMCOUNT, 0, 0);
	//�б�����
	cols = ::SendMessage(headerhwnd, HDM_GETITEMCOUNT, 0, 0);
	ThreadID = GetWindowThreadProcessId(hListview, &ProcessID);
	//�򿪲��������
	hProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_QUERY_INFORMATION, FALSE, ProcessID);
	//���������ڴ���
	pointer = (LVITEM*)VirtualAllocEx(hProcess, NULL, sizeof(LVITEM), MEM_COMMIT, PAGE_READWRITE);
	std::string tmp;
	for (int i = 0; i < rows; i++)
	{
		Product p;
		p.number = getText(hListview, hProcess, pointer, i, 1);
		p.text = getText(hListview, hProcess, pointer, i, 2);
		p.size = std::atoi(getText(hListview, hProcess, pointer, i, 5).c_str());
		p.addtext = MyConfig::findNumber2(p.number);
		p.row = i;
		ps[i] = p;
	}
	*num = rows;
	//�ͷ��ڴ�ռ�
	VirtualFreeEx(hProcess, pointer, 0, MEM_RELEASE);//�������������ͷ�����������ڴ�ռ�,MEM_RELEASE��ʽ�ܳ���,��ȫ����
	CloseHandle(hProcess);//�رմ򿪵Ľ��̶���
}

void SendAscii(wchar_t data, BOOL shift)
{
	INPUT input[2];
	memset(input, 0, 2 * sizeof(INPUT));

	if (shift)
	{
		input[0].type = INPUT_KEYBOARD;
		input[0].ki.wVk = VK_SHIFT;
		SendInput(1, input, sizeof(INPUT));
	}
	input[0].type = INPUT_KEYBOARD;
	input[0].ki.wVk = data;
	input[1].type = INPUT_KEYBOARD;
	input[1].ki.wVk = data;
	input[1].ki.dwFlags = KEYEVENTF_KEYUP;
	SendInput(2, input, sizeof(INPUT));
	if (shift)
	{
		input[0].type = INPUT_KEYBOARD;
		input[0].ki.wVk = VK_SHIFT;
		input[0].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(1, input, sizeof(INPUT));
	}
}

void SendUnicode(wchar_t data)
{
	INPUT input[2];
	memset(input, 0, 2 * sizeof(INPUT));

	input[0].type = INPUT_KEYBOARD;
	input[0].ki.wVk = 0;
	input[0].ki.wScan = data;
	input[0].ki.dwFlags = 0x4;//KEYEVENTF_UNICODE;

	input[1].type = INPUT_KEYBOARD;
	input[1].ki.wVk = 0;
	input[1].ki.wScan = data;
	input[1].ki.dwFlags = KEYEVENTF_KEYUP | 0x4;//KEYEVENTF_UNICODE;

	SendInput(2, input, sizeof(INPUT));
}

wchar_t *multiByteToWideChar(const std::string& pKey)
{
	const char* pCStrKey = pKey.c_str();
	//��һ�ε��÷���ת������ַ������ȣ�����ȷ��Ϊwchar_t*���ٶ����ڴ�ռ�
	int pSize = MultiByteToWideChar(CP_OEMCP, 0, pCStrKey, strlen(pCStrKey) + 1, NULL, 0);
	wchar_t *pWCStrKey = new wchar_t[pSize];
	//�ڶ��ε��ý����ֽ��ַ���ת����˫�ֽ��ַ���
	MultiByteToWideChar(CP_OEMCP, 0, pCStrKey, strlen(pCStrKey) + 1, pWCStrKey, pSize);
	return pWCStrKey;
}

void SendKeys(std::string msg)
{
	short vk;
	BOOL shift;
	USES_CONVERSION;
	wchar_t* data = multiByteToWideChar(msg);
	int len = wcslen(data);
	for (int i = 0; i < len; i++)
	{
		if (data[i] >= 0 && data[i] < 256) //ascii�ַ�
		{
			vk = VkKeyScanW(data[i]);
			if (vk == -1)
			{
				SendUnicode(data[i]);
			}
			else
			{
				if (vk < 0)
				{
					vk = ~vk + 0x1;
				}
				shift = vk >> 8 & 0x1;
				if (GetKeyState(VK_CAPITAL) & 0x1)
				{
					if (data[i] >= 'a' && data[i] <= 'z' || data[i] >= 'A' && data[i] <= 'Z')
					{
						shift = !shift;
					}
				}
				SendAscii(vk & 0xFF, shift);
			}
		}
		else //unicode�ַ�
		{
			SendUnicode(data[i]);
		}
		//Sleep(1000);
	}
}

void select(std::string number) {
	MyConfig::Debug(number + "\n");
	BOOL ret;
	RECT rect;
	HWND edithwnd = FindWindow(NULL, TEXT("ѡ���Ʒ"));
	HWND tPageControl = FindWindowEx(edithwnd, 0, TEXT("TPageControl"), NULL);
	ret = GetWindowRect(tPageControl, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 100, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	HWND tTabSheet = FindWindowEx(tPageControl, 0, NULL, TEXT("���װ��Ʒ"));
	HWND TPanel = FindWindowEx(tTabSheet, 0, TEXT("TPanel"), NULL);
	HWND next = FindWindowEx(tTabSheet, TPanel, TEXT("TPanel"), NULL);   // ״̬��
	HWND tPanelText = FindWindowEx(tTabSheet, next, TEXT("TPanel"), NULL);
	HWND tEdit = FindWindowEx(tPanelText, 0, TEXT("TEdit"), NULL);
	ret = GetWindowRect(tEdit, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 10, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	SendKeys(number);
	Sleep(time);
	HWND tListView = FindWindowEx(TPanel, 0, TEXT("TListView"), NULL);
	ret = GetWindowRect(tListView, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 100, rect.top + 25);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
}

void add(std::string number,int size) {
	BOOL ret;
	RECT rect;
	HWND edithwnd = FindWindow(NULL, TEXT("�༭������Ʒ"));
	HWND hwnd = MyConfig::getEditPanel(edithwnd);
	ret = GetWindowRect(hwnd, &rect);
	if (!ret) return;
	SetCursorPos(rect.right + 10, rect.top + 10);   //right
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	Sleep(time);
	select(number);
	Sleep(time);
	SendKeys(std::to_string(size));
	HWND tButton = FindWindowEx(edithwnd, 0, TEXT("TButton"), TEXT("����[&S]"));
	ret = GetWindowRect(tButton, &rect);
	if (!ret) return;
	SetCursorPos(rect.left + 10, rect.top + 10);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
}

void execOne(RECT info_rect, RECT panel_rect, Product pro)
{
	MyConfig::Debug(pro.number + "---->" + pro.text + "--->" + std::to_string(pro.size) + "--->" + pro.addtext + "\n");
	if (pro.addtext == "" || pro.addtext.length() == 0) {
		return;
	}
	//����½�
	SetCursorPos(panel_rect.left + 20, panel_rect.top + 25);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	Sleep(time);
	add(pro.addtext,pro.size);
	Sleep(time);
	//����޸�
	SetCursorPos(info_rect.left + 100, info_rect.top + 25 + 17 * pro.row);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	Sleep(time);
	SetCursorPos(panel_rect.left + 120, panel_rect.top + 25);
	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	Sleep(time);
	add(pro.number + " ����",pro.size);
	Sleep(time);
}

void exec()
{ // ���б����
	BOOL ret; RECT panel_rect, info_rect;
	HWND mhwnd = FindWindow(NULL, TEXT("����ܼ��ƶ˰� - [�������]"));
	HWND info_view = MyConfig::getInfoView(mhwnd);
	HWND panel = MyConfig::getInfoPanel(mhwnd);
	ret = GetWindowRect(info_view, &info_rect);  //��Ʒ�б�
	ret = GetWindowRect(panel, &panel_rect);   // ��Ʒ�½�
	if (!ret) return;
	int count = 0;
	Product ps[100];
	getNumber(info_view, &*ps, &count);
	for (int i = 0; i < count; ++i) {
		execOne(info_rect, panel_rect, ps[i]);
		//Debug(ps[i].number + "\n");
	}
}

void func()  // ���б����
{
	BOOL ret;
	RECT order_rect;
	HWND mhwnd = FindWindow(NULL, TEXT("����ܼ��ƶ˰� - [�������]"));
	HWND order_view = MyConfig::getOrderView(mhwnd);
	ret = GetWindowRect(order_view, &order_rect);
	if (!ret) return;
	int rows = ::SendMessage(order_view, LVM_GETITEMCOUNT, 0, 0);
	for (int i = 0; i < rows; i++)
	{
		SetCursorPos(order_rect.left + 100, order_rect.top + 25 + (17 * i));
		mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		Sleep(time);
		exec();
		Sleep(2000);
	}
	//MessageBox(mhwnd, TEXT("orver"), TEXT("tip"), NULL);
}



void MyApp::start() {
	//select("");
	//add(".",0);
	func();
}
