#include "pch.h"
#include "Tools/PC/Window/ComponentInspector.h"
#include "Tools/PC/Window/EntityList.h"

#include "Core/EntityRegistry.h"

/// Components
#include "CoreRenderAPI/Components/Transform.h"

#include <DearImGui\imgui.h>

namespace Frac
{
	ComponentInspector::ComponentInspector(EntityRegistry& a_registry, EntityList& a_entityList) :
		m_registry(a_registry),
		m_entityList(a_entityList)
	{}

	void ComponentInspector::Update() 
	{
		if (m_windowState) 
		{
			// TODO Reflection
			int imguiID = 0;
			ImGui::SetNextWindowPos(ImVec2(ImGui::GetFrameHeight() * 17.5f, ImGui::GetFrameHeight() * 2.0f), ImGuiCond_Once);
			ImGui::SetNextWindowSize(ImVec2(ImGui::GetFontSize() * 15.0f, ImGui::GetFontSize() * 20.0f), ImGuiCond_Once);
			ImGui::Begin("Component Inspector", nullptr, ImGuiWindowFlags_NoCollapse);
			if (m_entityList.GetSelectedEntity()) 
			{
				std::string name = "Entity: " + m_entityList.GetSelectedEntity()->GetEntityName();
				ImGui::Text(name.c_str());
				// Transform Component
				if (m_registry.HasComponent<TOR::Transform>(*m_entityList.GetSelectedEntity())) 
				{
					const TOR::Transform& transformComponent = m_registry.GetComponent<TOR::Transform>(*m_entityList.GetSelectedEntity());
					TOR::Transform newTransformComponent = transformComponent;
					ImGui::Separator();
					ImGui::Text("Transform Component");
					//Position
					newTransformComponent.Position = AddVector3("Position", transformComponent.Position.x, transformComponent.Position.y, transformComponent.Position.z);
					ImGui::Spacing();

					//Rotation
					newTransformComponent.Orientation = AddVector3("Position", transformComponent.EulerOrientation.x, transformComponent.EulerOrientation.y, transformComponent.EulerOrientation.z);
					ImGui::Spacing();
					
					//Scale
					newTransformComponent.Scale = AddVector3("Position", transformComponent.Scale.x, transformComponent.Scale.y, transformComponent.Scale.z);
					ImGui::Spacing();

					m_registry.GetComponent<TOR::Transform>(*m_entityList.GetSelectedEntity()) = newTransformComponent;
					m_registry.GetEnTTRegistry().patch<TOR::Transform>(m_entityList.GetSelectedEntity()->GetHandle());
				} // end Transform Component
			}
			else 
			{
				std::string name = "Entity: No entity selected";
				ImGui::Text(name.c_str());
			}
			ImGui::End(); // end Component Inspector Window
		}
	}

	glm::vec3 ComponentInspector::AddVector3(std::string a_name, glm::vec3 a_vec3)
	{
		ImGui::Spacing();
		ImGui::Text(a_name);

		//ImGui doesn't use GLM so we have to translate between ImGui's regular arrays and glm::vec3
		glm::vec3 newVec3;
		float vector3[3]{ a_vec3.x, a_vec3.y, a_vec3.z };
		ImGui::PushID(imguiID++);
		if (ImGui::DragFloat3("", vector3)) {
			newVec3.x = position[0];
			newVec3.y = position[1];
			newVec3.z = position[2];
		}
		ImGui::PopID();
		return vector3;
	}

} // namespace Frac