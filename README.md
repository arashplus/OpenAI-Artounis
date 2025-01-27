A C# client library for interacting with OpenAI's API, providing easy access to GPT-3, GPT-4, and other models for tasks like completions, embeddings, fine-tuning, and more.

## Features

- Access OpenAI models like GPT-3 and GPT-4.
- Generate text completions, summaries, or responses based on prompts.
- Work with embeddings for semantic search and similarity tasks.
- Fine-tune models for custom applications.
- Use moderation tools to filter unsafe content.
- Support for batching requests and multilingual models.
- Easy integration into any C# project.

## Installation

You can install the **Artounis-OpenAI-Client** library via [NuGet](https://www.nuget.org/packages/Artounis-OpenAI-Client).

```bash
Install-Package Artounis-OpenAI-Client
```

Alternatively, you can clone the repository and build it from source:

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

## Configuration
You can configure OpenAI-Artounis using the OpenAIConfig class. Below are the configuration options:

ApiKey: Your OpenAI API key (required).
DefaultModel: The default model to use for completions (optional, default is "text-davinci-003").
Endpoint: The API endpoint to connect to (optional, default is "https://api.openai.com/v1").
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

Fork the repository.
Clone your forked repository.
Create a new branch for your feature or bug fix.
Commit your changes and push to your fork.
Open a pull request with a description of the changes.

## Code of Conduct
Please follow our Code of Conduct when contributing.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments
OpenAI for providing access to powerful models like GPT-3, GPT-4, and others.
The open-source community for tools and libraries that helped in developing this project.

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



