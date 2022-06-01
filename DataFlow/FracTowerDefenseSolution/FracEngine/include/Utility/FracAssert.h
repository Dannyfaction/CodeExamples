#pragma once
#if defined(PLATFORM_WINDOWS)
#include <cassert>
#include "BugReporter.h"
#define FRAC_ASSERT FracAssert
#include "Logger.h"
static void FracAssert(bool expr, std::string message)
{
	if (!expr) {
		LOGWARNING(std::string("ASSERT REASON: " + message));
#if defined(CONFIG_DEBUG) || defined (CONFIG_DEVELOP)
		BugReporter::BugReporter::OpenApplication();
		assert(false);
#endif
	}
}
#endif