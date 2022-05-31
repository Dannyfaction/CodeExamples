#pragma once
#include <fstream>

namespace BugReporter
{
	/// <summary>
	/// Creates a batch file with the necessary information from the BugReporter to communicate with Jira's Rest API
	/// </summary>
	class Batch
	{
	public:
		Batch();
		~Batch() = default;

		/**
		* Creates the batch file, fills it with the curl RestAPI calls, executes it and removes it
		*/
		void ExecuteBatchCommands();

	private:
		void CreateJiraIssueWithData();

		std::ofstream m_batch;
	};

} // namespace BugReporter