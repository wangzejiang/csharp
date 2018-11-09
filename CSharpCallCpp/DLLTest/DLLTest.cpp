// DLLTest.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "DLLTest.h"

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

DLLTEST_API char* Test3(char* a, char* b)
{
	char *c;
	strcpy(buf, a);
	strcat(buf, b);
	c = (char*)buf;
	return c;
}