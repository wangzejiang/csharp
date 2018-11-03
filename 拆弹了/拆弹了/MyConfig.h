#pragma once

#include <string>

class MyConfig
{
public:
	MyConfig();
	~MyConfig();

	static HWND getOrderView(HWND mhwnd);
	static HWND getInfoView(HWND mhwnd);
	static HWND getInfoPanel(HWND mhwnd);
	static HWND getEditPanel(HWND mhwnd);
	static std::string MyConfig::findNumber(std::string text);
	static std::string MyConfig::findNumber2(std::string text);
	static void Debug(std::string text);
	static void Debug(int num);
};

