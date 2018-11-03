#include "Function.h"
#include "MyApp.h"


Function::Function(void)
{
}


Function::~Function(void)
{
}

int Function::menberFuncAdd(int a, int b)
{
	return a + b;
}
System::String^ Function::say(System::String^ str)
{
	return str;
}



int Function::test() {
	MyApp::start();
	return 1;
}