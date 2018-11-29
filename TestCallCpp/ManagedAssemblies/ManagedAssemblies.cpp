// 这是主 DLL 文件。

#include "stdafx.h"

#include "ManagedAssemblies.h"

namespace ManagedAssemblies {

	double Class1::add(double a, double b)
	{
		return a + b;
	}
	double Class1::subtract(double a, double b)
	{
		return a - b;
	}
}