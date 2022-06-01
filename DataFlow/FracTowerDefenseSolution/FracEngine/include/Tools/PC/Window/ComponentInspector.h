#pragma once
#include "Tools/PC/Window/IGUIWindow.h"

namespace Frac
{
	class EntityRegistry;
	class EntityList;

	/// <summary>
	/// The inspector where all individual components of an entity are displayed and can be edited
	/// </summary>
	class ComponentInspector : public IGUIWindow
	{
	public:
		ComponentInspector(EntityRegistry& a_registry, EntityList& a_entityList);
		~ComponentInspector() = default;

		/**
		* Update all components in the inspector
		*/
		void Update() override;

	private:
		EntityRegistry& m_registry;
		EntityList& m_entityList;

		int m_imguiID;

		/**
		* Adds a editable variable to the component inspector with a name
		* @return the edited variable
		*/
		glm::vec3 AddVector3(std::string a_name, const glm::vec3& a_vec3);
		float AddFloat(std::string a_name, float& a_float) {};
		int AddInteger(std::string a_name, int& a_int) {};
		bool AddBoolean(std::string a_name, bool& a_bool) {};
	};

} // namespace Frac