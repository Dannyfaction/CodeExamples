#include "pch.h"
#include "Core\FileIO.h"

#include <fstream>

namespace Frac 
{
	std::string FileIO::s_rootAssetsDirectory;
	std::vector<std::pair<std::string, std::string>> FileIO::s_wildCards;

	void FileIO::Initialize()
	{
		std::string rootDirectory;

		rootDirectory = "";

		std::string assetsSubDirectory = "Assets/";
		// fstream is relative to project
		AddWildcard("[Assets]", rootDirectory + assetsSubDirectory);
		AddWildcard("[Models]", rootDirectory + assetsSubDirectory + "Models/");
		AddWildcard("[Materials]", rootDirectory + assetsSubDirectory + "Materials/");
		AddWildcard("[Shaders]", rootDirectory + assetsSubDirectory + "Shaders/");
		AddWildcard("[Fonts]", rootDirectory + assetsSubDirectory + "Fonts/");
		AddWildcard("[Levels]", rootDirectory + assetsSubDirectory + "NewLevels/");
		AddWildcard("[AllLevelData]", rootDirectory + assetsSubDirectory + "AllLevelData/");
		AddWildcard("[PointDataFiles]", rootDirectory + assetsSubDirectory + "PointDataFiles/");
		AddWildcard("[LevelModelFiles]", rootDirectory + assetsSubDirectory + "Models/Houdini_Prototypes/Level_Geo/");
		AddWildcard("[Audio]", rootDirectory + assetsSubDirectory + "Audio/");
	}

	std::string FileIO::Read(const std::string& a_fileName)
	{
		std::string content("");

		std::ifstream file(GetPath(a_fileName));

		if (file)
		{
			std::stringstream buffer;
			buffer << file.rdbuf();

			content = buffer.str();
		}

		return content;
	}

	bool FileIO::Write(const std::string& a_filename, const std::string& a_content)
	{
		std::ofstream thefile;
		thefile.open(GetPath(a_filename));
		if (thefile.is_open()) {
			thefile << a_content;
			thefile.close();

			return true;
		}
		else {
			LOGWARNING("The file you're trying to write to is most likely set to read-only and will not be overwritten. Filename: %s", a_filename.c_str());
			return false;
		}
	}

	std::string FileIO::GetPathFromWildcard(const std::string& a_wildcard)
	{
		std::string path = GetPath(a_wildcard);
		if (path.empty()) {
			LOGERROR("Invalid wildcard");
		}
		return path;
	}

	std::string FileIO::GetPath(const std::string& a_path)
	{
		std::string fullpath(a_path);

		for (const auto& p : s_wildCards)
		{
			if (fullpath.find(p.first) != std::string::npos)
			{
				fullpath = StringReplace(fullpath, p.first, p.second);
			}
		}

		return fullpath;
	}

	std::string FileIO::StringReplace(const std::string& a_subject, const std::string& a_search, const std::string& a_replace)
	{
		std::string result(a_subject);
		size_t pos = 0;

		while ((pos = a_subject.find(a_search, pos)) != std::string::npos)
		{
			result.replace(pos, a_search.length(), a_replace);
			pos += a_search.length();
		}

		return result;
	}

	void FileIO::AddWildcard(const std::string& a_wildcard, const std::string a_filepath)
	{
		s_wildCards.push_back(std::make_pair(a_wildcard, a_filepath));
	}
} // namespace Frac