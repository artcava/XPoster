# Graph Report - XPoster  (2026-06-12)

## Summary
- 566 nodes · 925 edges · 89 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `IGenerator` - 2 edges
2. `XPoster.SenderPlugins` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `DeepSeekOptionsValidatorTests` - 2 edges
5. `XPoster.Tests.Abstraction` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Abstraction` - 2 edges
8. `IGeneratorFactory` - 2 edges
9. `XPoster.Abstraction` - 2 edges
10. `ISender` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 1 - "Entity (Community 1)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 0 - "Entity (Community 0)"
Cohesion: 0.19
Nodes (21): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), XPoster.Tests.Services, OpenAiServiceTests, OpenAiService(), MakeHandler() (+13 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.22
Nodes (18): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), ChatCompletionJson(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), BuildService(), AzureFoundryService(), AzureFoundryServiceTests (+10 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures() (+5 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, BuildSender(), InSender(), InSenderMissingBranchTests, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), BuildSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse() (+4 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.32
Nodes (12): FeedGeneratorTests.cs, FeedGeneratorTests.cs, GenerateAsync_Should_ReturnNull_When_SummaryGenerationFails(), GenerateAsync_Should_ReturnNull_When_NoFeedsFound(), GenerateAsync_Should_ReturnNull_When_AiServiceIsNull(), GenerateAsync_Should_ReturnNull_When_SenderIsNull(), GenerateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), FeedGeneratorTests() (+4 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, BuildHybrid(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), ChatCompletionJson(), MakeHandlerMock(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), HybridAiServiceTests (+3 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, AzureFoundryService(), GetImageGenerationEndpoint(), BuildSummaryPayload(), GenerateImageAsync(), GetChatCompletionsEndpoint(), GetSummaryAsync(), while() (+3 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully(), catch(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender() (+2 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), XSenderTests(), Constructor_InitializesCorrectly(), catch() (+2 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): NoGeneratorTests.cs, NoGeneratorTests.cs, NoGeneratorTests(), Name_IsNoGenerator(), GenerateAsync_ReturnsNull(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models (+1 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, BuildSummaryPayload(), GetChatCompletionsEndpoint(), NotSupportedException(), while(), GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync() (+1 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedMissingBranchTests, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): PowerLawGeneratorTests.cs, PowerLawGeneratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Implementation, PowerLawGeneratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, XPoster.Tests.SenderPlugins, Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), Constructor_WithValidEnvVars_Succeeds(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), Constructor_WithMissingAccessToken_ThrowsInvalidOperationException() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.25
Nodes (8): InSender.cs, using(), XPoster.SenderPlugins, generatePayLoad(), catch(), Exception(), SendAsync(), ResolveAuthorUrn()

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostMissingBranchTests, XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GetPromptForImage(), GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync(), XPoster.Services, while(), GetSummary()

### Community 25 - "Entity (Community 25)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 23 - "Entity (Community 23)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), XPoster.Implementation, InvalidOperationException(), GetByProvider(), ArgumentException(), AiServiceFactory()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()

### Community 22 - "Entity (Community 22)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, OpenAIImageResponse, OpenAIResponse, XPoster.Models, ImageData, Message

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_GenerateAsync_ReturnsNull(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests(), XPoster.Tests

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (7): BaseGeneratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, HybridAiService(), GenerateImageAsync(), GetSummaryAsync(), GetImagePromptAsync()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Abstraction, IAiService, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsLocalTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, TimeProviderTests

### Community 35 - "Entity (Community 35)"
Cohesion: 0.33
Nodes (6): GeneratorFactoryTests.cs, Generate_Should_ReturnCorrectGeneratorType_BasedOnHour(), XPoster.Tests.Implementation, Generate_Should_CreateFeedGeneratorWithInSender_At6AM(), Generate_Should_CreateNoGenerator_AtUnscheduledHours(), Generate_Should_CreateFeedGeneratorWithXSender_At8AM()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.33
Nodes (6): BaseGeneratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestGenerator(), BaseGeneratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), BuildFalService(), HybridAiService()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.33
Nodes (6): GeneratorFactory.cs, ResolveAiProvider(), foreach(), return(), Generate(), XPoster.Implementation

### Community 39 - "Entity (Community 39)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), XPoster.Tests

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): IGenerator.cs, IGenerator.cs, IGenerator, PostAsync(), XPoster.Abstraction

### Community 48 - "Entity (Community 48)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IGeneratorFactory.cs, IGeneratorFactory.cs, XPoster.Abstraction, Generate(), IGeneratorFactory

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Abstraction, ISender

### Community 42 - "Entity (Community 42)"
Cohesion: 0.40
Nodes (5): FeedGenerator.cs, XPoster.Implementation, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), XPoster.Abstraction, IAiServiceFactory

### Community 46 - "Entity (Community 46)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Abstraction

### Community 45 - "Entity (Community 45)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), catch(), Exception(), XPoster.Services

### Community 44 - "Entity (Community 44)"
Cohesion: 0.40
Nodes (5): GeneratorFactory.cs, if(), CreateGeneratorInstance(), GeneratorFactory(), ScheduledGenerationProfile()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 40 - "Entity (Community 40)"
Cohesion: 0.70
Nodes (5): PowerLawGenerator.cs, PowerLawGenerator.cs, PowerLawGenerator(), if(), XPoster.Implementation

### Community 49 - "Entity (Community 49)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 50 - "Entity (Community 50)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Abstraction

### Community 53 - "Entity (Community 53)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, GenerateImageAsync(), FalAiImageService()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): NoGenerator.cs, NoGenerator.cs, NoGenerator(), XPoster.Implementation

### Community 65 - "Entity (Community 65)"
Cohesion: 0.83
Nodes (4): ScheduledGenerationProfile.cs, ScheduledGenerationProfile.cs, ScheduledGenerationProfile(), XPoster.Abstraction

### Community 64 - "Entity (Community 64)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 56 - "Entity (Community 56)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, if(), DeepSeekService(), BuildImagePromptPayload()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), XPoster, Run()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, IgSenderTests(), SetValidEnvVars(), ClearEnvVars()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.50
Nodes (4): FeedGenerator.cs, if(), FeedGenerator(), foreach()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): GeneratorFactoryTests.cs, SetupMocksForGeneratorFactory(), GeneratorFactoryTests(), Generate_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 58 - "Entity (Community 58)"
Cohesion: 0.50
Nodes (4): BaseGenerator.cs, XPoster.Abstraction, BaseGenerator(), PostAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 74 - "Entity (Community 74)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 81 - "Entity (Community 81)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 83 - "Entity (Community 83)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 82 - "Entity (Community 82)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 67 - "Entity (Community 67)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 72 - "Entity (Community 72)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.67
Nodes (3): OpenAiService.cs, OpenAiService(), if()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 70 - "Entity (Community 70)"
Cohesion: 1.00
Nodes (3): if(), Program.cs, Program.cs

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (2): BaseGenerator.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (2): AzureFoundryService.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._