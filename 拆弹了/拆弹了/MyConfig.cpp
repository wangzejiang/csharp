#include "stdafx.h"


#include<iostream>
#include<fstream>
#include<string>
#include<vector>

MyConfig::MyConfig()
{

}
MyConfig::~MyConfig()
{
}

std::wstring StringToWString(const std::string& s)
{
	std::wstring wszStr;

	int nLength = MultiByteToWideChar(CP_ACP, 0, s.c_str(), -1, NULL, NULL);
	wszStr.resize(nLength);
	LPWSTR lpwszStr = new wchar_t[nLength];
	MultiByteToWideChar(CP_ACP, 0, s.c_str(), -1, lpwszStr, nLength);
	wszStr = lpwszStr;
	delete[] lpwszStr;
	return wszStr;
}


void MyConfig::Debug(std::string text) {
	OutputDebugString(StringToWString(text).c_str());
}

void MyConfig::Debug(int num) {
	wchar_t str[10];
	_itow_s(num, str, 10);
	OutputDebugString((LPWSTR)str);
}

std::string isOk(std::string str) {
	std::fstream f("test.txt");//创建一个fstream文件流对象
	//std::vector<std::string> words; //创建一个vector<string>对象
	std::string line; //保存读入的每一行
	while (getline(f, line))//会自动把\n换行符去掉 
	{
		//words.push_back(line);
		if (line.find(str+"==") != std::string::npos) {
			return line;
		}
	}
	return "";
}

std::vector<std::string> split(std::string str, std::string pattern)
{
	std::string::size_type pos;
	std::vector<std::string> result;
	str += pattern;//扩展字符串以方便操作
	int size = str.size();

	for (int i = 0; i<size; i++)
	{
		pos = str.find(pattern, i);
		if (pos<size)
		{
			std::string s = str.substr(i, pos - i);
			result.push_back(s);
			i = pos + pattern.size() - 1;
		}
	}
	return result;
}

std::string MyConfig::findNumber2(std::string text) {
	std::string val = isOk(text);
	if (val!="") {
		std::vector<std::string> result = split(val, "==");
		std::vector<std::string>::iterator iter = result.end();
/////		return *iter;
	}
	return "";
}

std::string MyConfig::findNumber(std::string text) {
	int count = 0;
	count += text.find("三级头") != std::string::npos ? 1 : 0;
	count += text.find("三级甲") != std::string::npos ? 2 : 0;
	count += text.find("三级包") != std::string::npos ? 4 : 0;

	std::string addNumber = "";
	if (count == 1) {
		addNumber = ".1三级头";
	}
	else if (count == 2) {
		// 甲
	}
	else if (count == 3) {
		addNumber = ".2三级头+甲";
	}
	else if (count == 4) {
		// 包
	}
	else if (count == 5) {
		addNumber = ".3三级包+头盔";
	}
	else if (count == 6) {
		// 甲 + 包
	}
	else if (count == 7) {
		addNumber = ".4三级头+甲+包";
	}
	return addNumber;
}

HWND MyConfig::getOrderView(HWND mhwnd) {
	HWND hwnd, next;
	hwnd = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TForm_TradeCHK"), NULL);
	next = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, next, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TListView"), NULL);
	return hwnd;
}

HWND MyConfig::getInfoView(HWND mhwnd) {
	HWND hwnd, next;
	hwnd = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TForm_TradeCHK"), NULL);
	next = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, next, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPageControl"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TTabSheet"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TListView"), NULL);
	return hwnd;
}

HWND MyConfig::getInfoPanel(HWND mhwnd) {
	HWND hwnd, next;
	hwnd = FindWindowEx(mhwnd, 0, TEXT("MDIClient"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TForm_TradeCHK"), NULL);
	next = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, next, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPageControl"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TTabSheet"), NULL);
	hwnd = FindWindowEx(hwnd, 0, TEXT("TPanel"), NULL);
	return hwnd;
}

HWND MyConfig::getEditPanel(HWND mhwnd) {
	HWND hwnd, next;
	hwnd = FindWindowEx(mhwnd, 0, TEXT("TPanel"), NULL);
	next = FindWindowEx(hwnd, 0, TEXT("TEdit"), NULL);
	next = FindWindowEx(hwnd, next, TEXT("TEdit"), NULL);
	next = FindWindowEx(hwnd, next, TEXT("TEdit"), NULL);
	next = FindWindowEx(hwnd, next, TEXT("TEdit"), NULL);
	hwnd = FindWindowEx(hwnd, next, TEXT("TEdit"), NULL);
	return hwnd;
}