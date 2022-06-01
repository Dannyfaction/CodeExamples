#pragma once
#include "Core/ISystem.h"
#include "Tools/PC/Window/IGUIWindow.h"

struct ImGuiStyle;
namespace Frac
{
	enum MenuItemViewFlags
	{
		RENDER_SETTINGS = 1 << 0, // binary 0001
		ENTITY_LIST = 1 << 1, // binary 0010
		COMPONENT_INSPECTOR = 1 << 2, // binary 0100
	};

	class GraphicalUserInterface;
	class GraphicalUserInterfacePreFrame : public ISystem
	{
	public:
		GraphicalUserInterfacePreFrame();
		~GraphicalUserInterfacePreFrame() = default;

		void Update(float deltaTime) override;

	private:
		void UpdateDocking();
	};
	
	class GraphicalUserInterfacePostFrame : public ISystem
	{
	public:
		GraphicalUserInterfacePostFrame(GraphicalUserInterface& a_GUI);
		~GraphicalUserInterfacePostFrame() = default;

		void Update(float deltaTime) override;

	private:
		GraphicalUserInterface& m_GUI;
	};

	/// <summary>
	/// Parent class of all GUI tools in the engine
	/// </summary>
	class GraphicalUserInterface
	{
	public:
		GraphicalUserInterface();
		~GraphicalUserInterface();

		/**
		* Updates all individual GUI elements and windows
		*/
		void UpdateGUI();

		/**
		* Get the global GUI scale of the engine
		* @return: A float with the scale of the GUI
		*/
		float GetGUIScale() const;

	private:
		int m_menuItemViewFlag;

		std::unique_ptr<IGUIWindow> m_renderSettings;
		std::unique_ptr<IGUIWindow> m_entityList;
		std::unique_ptr<IGUIWindow> m_componentInspector;

		ImGuiStyle* m_style;

		void SetupImGuiStyle();

		float m_guiScale;

		GraphicalUserInterfacePreFrame m_GUIPreFrameSystem;
		GraphicalUserInterfacePostFrame m_GUIPostFrameSystem;
	};
} // namespace Frac