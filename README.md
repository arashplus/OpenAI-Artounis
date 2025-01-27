A C# client library for interacting with OpenAI's API, providing easy access to GPT-3, GPT-4, and other models for tasks like completions, embeddings, fine-tuning, and more.
## New Features Added:
- Stream Processing: Added functionality to handle streaming data from OpenAI API.
- Caching: Implemented caching to reduce redundant API calls and improve performance.
- Usage Statistics: Track the number of requests made and token usage.
- Model Management: Manage models including selecting, listing, and configuring models.
- Request Logging: Logs each request made to OpenAI API for better traceability.
- Token Management: Securely manage API tokens.
- Model Training: Fine-tune models with custom data.
- Exception Handling: Handle exceptions by logging them to files and monitoring systems.
## Features

- Access OpenAI models like GPT-3 and GPT-4.
- Generate text completions, summaries, or responses based on prompts.
- Work with embeddings for semantic search and similarity tasks.
- Fine-tune models for custom applications.
- Use moderation tools to filter unsafe content.
- Support for batching requests and multilingual models.
- Easy integration into any C# project.
- Stream OpenAI responses for real-time data processing.
- Cache responses to improve performance.
- Track API usage and token consumption.
- Log requests and errors to file and monitoring systems.

## Installation

You can install the **Artounis-OpenAI-Client** library via [NuGet](https://www.nuget.org/packages/Artounis-OpenAI-Client).

```bash
Install-Package Artounis-OpenAI-Client
```

**Alternatively**, you can clone the repository and build it from source:

```bash
git clone https://github.com/arashplus/OpenAI-Artounis.git
cd OpenAI-Artounis
dotnet build
```

## Usage
Here’s a basic example of how to use OpenAI-Artounis to generate text completions using OpenAI’s models:

## Initialize and Get a Completion

```C# Code
using OpenAI_Artounis;

var config = new OpenAIConfig
{
    ApiKey = "your-api-key-here",
    DefaultModel = "text-davinci-003",
    Endpoint = "https://api.openai.com/v1"
};

var openAIClient = new OpenAIClient(config);
var completionService = new OpenAICompletion(openAIClient);

var result = await completionService.GetCompletionAsync("Once upon a time");
Console.WriteLine(result);
```

## Generate Embeddings

```C# Code
var embeddingsService = new OpenAIEmbeddings(openAIClient);
var embeddings = await embeddingsService.GetEmbeddingsAsync("Hello, OpenAI!");
Console.WriteLine(embeddings);
```
## Fine-Tune a Model

```C# Code
var fineTuningService = new OpenAIFineTuning(openAIClient);
var fineTuneId = await fineTuningService.FineTuneModelAsync("your-training-file-id");
Console.WriteLine(fineTuneId);
```
## Perform Moderation Check

```C# Code
var moderationService = new OpenAIModeration(openAIClient);
var moderationResult = await moderationService.ModerationCheckAsync("Some sensitive content here");
Console.WriteLine(moderationResult);
```
## Stream Data Processing (New Feature)
The OpenAIStreamProcessing class allows you to handle streaming data from OpenAI API.

```C# Code
var streamProcessing = new OpenAIStreamProcessing(openAIClient);
await streamProcessing.StreamCompletionAsync("https://api.openai.com/v1/completions", "Once upon a time", CancellationToken.None);
```
## Cache Responses (New Feature)
You can cache OpenAI responses with the OpenAICache class to avoid unnecessary calls.

```C# Code
var cache = new OpenAICache();
cache.AddToCache("Once upon a time", "Story completed.");
var cachedResponse = cache.GetFromCache("Once upon a time");
Console.WriteLine(cachedResponse);
```

## Track API Usage (New Feature)
Use OpenAIUsageStats to track API requests and token usage.

```C# Code
var usageStats = new OpenAIUsageStats();
usageStats.IncrementRequestCount();
usageStats.AddTokenUsage(10);
usageStats.DisplayStats();
```

## Manage API Tokens (New Feature)
The OpenAITokenManager allows you to manage your API token securely.

```C# Code
var tokenManager = new OpenAITokenManager("your-api-token-here");
Console.WriteLine(tokenManager.GetToken());
```

## Model Management (New Feature)
You can manage OpenAI models using the OpenAIModelManager.

```C# Code
var modelManager = new OpenAIModelManager("text-davinci-003", "v1");
modelManager.DisplayModelInfo();
```
## Log Requests and Responses (New Feature)
Use OpenAIRequestLogger to log API requests and responses for debugging and analysis.

```C# Code
var requestLogger = new OpenAIRequestLogger("log.txt");
requestLogger.LogRequest("Request data here");
requestLogger.LogResponse("Response data here");
```
## Training Models and Fine-tuning (New Feature)
The OpenAIModelTrainer and OpenAIFinetuningHelper classes help you prepare data and train models using OpenAI API.

```C# Code
var finetuningHelper = new OpenAIFinetuningHelper();
var trainingData = new List<(string, string)>
{
    ("Translate the following English text to French: 'Hello, how are you?'", "'Bonjour, comment ça va?'"),
    ("Translate the following English text to French: 'Good morning'", "'Bonjour'")
};
string filePath = @"D:\training_data.jsonl";
finetuningHelper.PrepareFineTuningData(trainingData, filePath);

var fineTuning = new OpenAIFinetuning(openAIClient);
string fileId = await fineTuning.UploadTrainingDataAsync(filePath);
if (fileId != null)
{
    string fineTuneJobId = await fineTuning.StartFineTuningJobAsync(fileId);
    Console.WriteLine($"Fine-tuning job ID: {fineTuneJobId}");
}
```

## Handle Exceptions (New Feature)
The OpenAIExceptionHandler class allows you to log exceptions to both files and monitoring systems.

```C# Code
var exceptionHandler = new OpenAIExceptionHandler(@"D:\Logs\exception-log.json", "https://your-monitoring-system-endpoint.com/api/log");

try
{
    // Some code that might throw an exception
    throw new Exception("Test exception");
}
catch (Exception ex)
{
    // Handle the exception
    await exceptionHandler.HandleExceptionAsync(ex);
}
```

## Configuration
You can configure OpenAI-Artounis using the OpenAIConfig class. Below are the configuration options:

**ApiKey**: Your OpenAI API key (required).
**DefaultModel**: The default model to use for completions (optional, default is "text-davinci-003").
**Endpoint**: The API endpoint to connect to (optional, default is "https://api.openai.com/v1").
Example:

```C# Code
var config = new OpenAIConfig
{
    ApiKey = "your-api-key-here",
    DefaultModel = "text-davinci-003",
    Endpoint = "https://api.openai.com/v1"
};
```

## Contributing
We welcome contributions to OpenAI-Artounis! If you want to contribute, follow these steps:

1. Fork the repository.
2. Clone your forked repository.
3. Create a new branch for your feature or bug fix.
4. Commit your changes and push to your fork.
5. Open a pull request with a description of the changes.

## Code of Conduct
Please follow our Code of Conduct when contributing.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments
- OpenAI for providing access to powerful models like GPT-3, GPT-4, and others.
- The open-source community for tools and libraries that helped in developing this project.

## 
If you have any questions or need help, feel free to open an issue or contact us.


## Key Sections Explained:

1. **Project Title and Description**: This section gives a brief overview of the project and its functionality.
   
2. **Features**: Lists the capabilities of your library, providing users with an idea of what they can do with it.

3. **Installation**: Provides instructions on how to install the library, both via NuGet and by building from source.

4. **Usage**: Shows example code snippets for common operations like generating text completions, embeddings, fine-tuning models, and performing moderation checks.

5. **Configuration**: Describes how to set up and configure the library using the `OpenAIConfig` class. This section is important for users to understand how to provide their OpenAI API key and adjust the default settings.

6. **Contributing**: Provides instructions for developers who want to contribute to the project, ensuring that the repository is open for improvements.

7. **License**: Specifies the open-source license (MIT in this case), which is crucial for open-source projects.

8. **Acknowledgments**: Thanks to the contributors and recognizes the libraries or APIs that your project depends on.



