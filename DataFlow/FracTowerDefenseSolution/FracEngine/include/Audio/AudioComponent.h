#pragma once

namespace FMOD {
	namespace Studio {
		class EventInstance;
		class EventDescription;
	}
} // namespace FMOD

namespace Frac
{
	struct AudioSourceComponent
	{
		std::unordered_map<std::string, FMOD::Studio::EventInstance*> events;
		std::unordered_map<std::string, FMOD::Studio::EventDescription*> descriptions;
	};
} // namespace Frac
