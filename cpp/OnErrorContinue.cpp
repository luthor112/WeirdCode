#include <stdio.h>
#include <conio.h>
#include <Windows.h>

LONG WINAPI filter(struct _EXCEPTION_POINTERS *ExceptionInfo)
{
	if (ExceptionInfo->ExceptionRecord->ExceptionCode == EXCEPTION_INT_DIVIDE_BY_ZERO)
	{
		ExceptionInfo->ContextRecord->Rip += 3;
		return EXCEPTION_CONTINUE_EXECUTION;
	}
	return EXCEPTION_CONTINUE_SEARCH;
}

void main()
{
	SetUnhandledExceptionFilter(filter);

	puts("Before\n");

	int n = 0;
	int a = 1 / n;

	puts("After\n");

	_getch();
}
