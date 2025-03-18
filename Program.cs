// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.OpenAI;
using static System.Environment;

string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string key = GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

var client = new OpenAIClient(
	new Uri(endpoint),
	new AzureKeyCredential(key));

CompletionsOptions completionsOptions = new()
{
	DeploymentName = "gpt-35-turbo-instruct",
	Prompts = { "When was Microsoft founded?" },
};

Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Chatbot: {completion}");