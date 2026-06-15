# Graph Report - XPoster  (2026-06-15)

## Summary
- 720 nodes · 1200 edges · 99 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Abstraction` - 2 edges
2. `IFeedService` - 2 edges
3. `IAiServiceFactory` - 2 edges
4. `XPoster.Abstraction` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Tests.Implementation` - 2 edges
8. `XPoster.Tests.Abstraction` - 2 edges
9. `RSSFeed` - 2 edges
10. `Post` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), AzureFoundryService(), ChatCompletionJson(), AzureFoundryServiceTests (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, BuildService(), FalAiImageServiceTests, FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.20
Nodes (19): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, Constructor_InitializesCorrectly(), BuildSender(), SendAsync_WithoutImage_DoesNotQueryKv(), SendAsync_WithImage_TriesUploadAndReturnsFalse() (+11 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), var(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, KeyVaultServiceTests, InSender_SendAsync_RequestsLinkedInOwnerCode(), InSenderKv(), KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), GetSecretAsync_OnRotation_ReturnsNewValueOnNextCall(), XPoster.Tests.Services (+8 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, var(), while(), XPoster.Services, NotSupportedException(), GetSummaryAsync(), GenerateImageAsync() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), InSenderMissingBranchTests() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildKeyVaultMock(), Constructor_InitializesCorrectly(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), BuildKeyVaultMockWithOrg(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall() (+5 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), XPoster.Tests.Models (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull() (+4 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), IgSenderResilienceTests, IgSender(), BuildSender(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_WhitespaceContent_ReturnsFalse(), XSenderMissingBranchTests() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, ValidPost(), InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetImagePromptAsync(), GetSummaryAsync(), while(), XPoster.Services, GenerateImageAsync(), AzureFoundryService(), BuildSummaryPayload() (+3 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, Constructor_NullDeepSeekService_ThrowsArgumentNullException(), FalAiImageService(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), DeepSeekService(), HybridAiServiceTests, MakeHandlerMock() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), BuildKeyVaultMock(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XSenderTests(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests(), Name_IsNoOrchestrator(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, XPoster.Tests.Models, Validate_ValidOptions_Succeeds() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, while(), GetSummaryAsync(), XPoster.Services, GetSummary(), GetPromptForImage(), catch(), GenerateImageAsync() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), PowerLawOrchestratorTests(), XPoster.Tests.Implementation (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, CryptoService() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, InvalidOperationException(), XPoster.Implementation, ArgumentException(), AiServiceFactory(), if(), GetByProvider()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.25
Nodes (8): InSender.cs, XPoster.SenderPlugins, SendAsync(), ResolveAuthorUrnAsync(), Exception(), InvalidOperationException(), using(), generatePayLoad()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIImageResponse, Message, Choice, ImageData, OpenAIResponse

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostMissingBranchTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), XPoster.Services, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Abstraction

### Community 38 - "Entity (Community 38)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), XPoster.Abstraction, GetImagePromptAsync(), GetSummaryAsync(), IAiService

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests

### Community 48 - "Entity (Community 48)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), ResolveAiProvider(), return(), XPoster.Implementation, Resolve()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), Validate(), XPoster.Models, foreach()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), XPoster.Tests.Implementation

### Community 44 - "Entity (Community 44)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, catch(), if(), XPoster.Services, return()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, XPoster.Abstraction, IKeyVaultService, GetSecretAsync(), SetSecretAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Sender_IsNull(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, SetSecretAsync(), KeyVaultService(), GetSecretAsync()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsLocalTime()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildFalService(), HybridAiService()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, PostAsync(), IOrchestrator

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Abstraction

### Community 58 - "Entity (Community 58)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, XPoster.Abstraction, GetByProvider()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Implementation

### Community 51 - "Entity (Community 51)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory(), ScheduledOrchestrationProfile()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Abstraction, SendAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Abstraction

### Community 54 - "Entity (Community 54)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, Resolve(), IOrchestratorFactory

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Abstraction

### Community 61 - "Entity (Community 61)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, SendAsync(), UploadImageToPublicUrl()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), catch(), GenerateMessage()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 77 - "Entity (Community 77)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Abstraction

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 63 - "Entity (Community 63)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 68 - "Entity (Community 68)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), if(), FeedOrchestrator()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), var(), if()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, var(), OpenAiService(), if()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), if(), InSender()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 87 - "Entity (Community 87)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 82 - "Entity (Community 82)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 85 - "Entity (Community 85)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 90 - "Entity (Community 90)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 93 - "Entity (Community 93)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 92 - "Entity (Community 92)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 94 - "Entity (Community 94)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

